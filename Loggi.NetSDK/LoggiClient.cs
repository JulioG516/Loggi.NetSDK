﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Loggi.NetSDK.Models;
using Loggi.NetSDK.Models.Authorization;
using Loggi.NetSDK.Models.Enums;
using Loggi.NetSDK.Models.FreightPriceQuotation;
using Loggi.NetSDK.Models.Helpers;
using Loggi.NetSDK.Models.Labels;
using Loggi.NetSDK.Models.LoggiPontos;
using Loggi.NetSDK.Models.Package;
using Loggi.NetSDK.Models.Shipments;
using Loggi.NetSDK.Models.Tracking;
using Loggi.NetSDK.Models.TrackingDetails;
using Loggi.NetSDK.Models.FreightPriceQuotation.Fluent;
using Loggi.NetSDK.Models.PickupTime;
using Loggi.NetSDK.Models.Shipments.AddressTypes;

namespace Loggi.NetSDK
{
    /// <summary>
    /// Cliente para interagir com a API da Loggi.
    /// </summary>
    public class LoggiClient
    {
        private string _clientId;
        private string _clientSecret;
        private readonly string _companyId;

        private readonly HttpClient _httpClient;

        private Token _token;

        /// <summary>
        /// Construtor do cliente
        /// </summary>
        /// <param name="companyId">Código numérico fornecido pela Loggi para identificar o cliente.</param>
        public LoggiClient(string companyId)
        {
            _companyId = companyId;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.loggi.com/")
            };
        }

        /// <summary>
        /// Autentica o usuario para que possa ser utilizado as demais requests.
        /// </summary>
        /// <param name="clientId">Id do cliente cadastrado na Loggi.</param>
        /// <param name="clientSecret">Chave secreta gerada pela Loggi.</param>
        /// <returns>Objeto <see cref="LoggiResponse{T}"/> Podendo conter o <see cref="Token"/> Se obter sucesso.</returns>
        /// <exception cref="ArgumentNullException">Quando ClientID é vazio ou null.</exception>
        /// <exception cref="ArgumentNullException">Quando ClientSecret é vazio ou null.</exception>
        public async Task<LoggiResponse<Token>> AuthenticateAsync(string clientId, string clientSecret)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentNullException(nameof(clientId), "clientID não pode ser null ou vazio.");

            if (string.IsNullOrEmpty(clientSecret))
                throw new ArgumentNullException(nameof(clientSecret), "clientSecret não pode ser null ou vazio.");

            var response = await _httpClient.GetToken(new TokenRequest()
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            });

            if (response.Data != null)
            {
                _token = response.Data;
                _clientId = clientId; // So we can refresh later on
                _clientSecret = clientSecret;
            }

            return response;
        }


        /// <summary>
        /// Cria um Shipment de forma assíncrona. Para iniciar um envio, você precisará de um endereço de origem, outro de destino e um pacote.
        /// </summary>
        /// <param name="shipment">Objeto <see cref="Shipment"/> obtido a partir de um builder.</param>
        /// <returns>Um objeto <see cref="LoggiResponse{T}"/> Contendo <see cref="ShipmentResponse"/> Se obter sucesso.</returns>
        /// <exception cref="ArgumentNullException">Quando shipment é null.</exception>
        /// <exception cref="ArgumentNullException">Quando shipment.ShipTo é null.</exception>
        /// <exception cref="ArgumentNullException">Quando shipment.ShipFrom é null.</exception>
        /// <exception cref="ArgumentNullException">Quando shipment.Packages é null ou vazio.</exception>
        /// <exception cref="InvalidOperationException">Quando não autenticado.</exception>
        public async Task<LoggiResponse<ShipmentResponse>> CriarShipmentAsync(Shipment shipment)
        {
            if (shipment == null)
                throw new ArgumentNullException(nameof(shipment), "Shipment nâo pode ser null.");
            if (shipment.ShipTo != null)
                throw new ArgumentNullException(nameof(shipment.ShipTo), "ShipTo em Shipment não pode ser null.");
            if (shipment.ShipFrom != null)
                throw new ArgumentNullException(nameof(shipment.ShipFrom), "ShipFrom em Shipment não pode ser null.");
            if (shipment.Packages == null || !shipment.Packages.Any())
                throw new ArgumentNullException(nameof(shipment.Packages), "Packages deve conter ao menos um valor.");

            
            var response = await _httpClient.SendPostAsync<ShipmentResponse>(
                $"v1/companies/{_companyId}/async-shipments",
                shipment, _token);

            return response;
        }

        /// <summary>
        /// Faz o rastreio de pacotes a partir das informações de CompanyID e TrackingCode.
        /// </summary>
        /// <param name="trackingCode">O codigo de rastreio do pacote</param>
        /// <returns>Um objeto <see cref="LoggiResponse{T}"/> Contendo <see cref="TrackingResponse"/> Se obter sucesso.</returns>
        /// <exception cref="ArgumentNullException">Quando trackingCode é null ou vazio.</exception>
        /// <exception cref="InvalidOperationException">Quando não autenticado.</exception>
        public async Task<LoggiResponse<TrackingResponse>> RastrearPacote(string trackingCode)
        {
            if (string.IsNullOrEmpty(trackingCode))
                throw new ArgumentNullException(nameof(trackingCode), "Tracking Code não pode ser null ou vazio.");

            var response = await _httpClient.SendGetJsonAsync<TrackingResponse>
                ($"v1/companies/{_companyId}/packages/{trackingCode}/tracking", _token);

            return response;
        }

        /// <summary>
        /// Recupera detalhes de um pacote a partir das informações do TrackingCode.
        /// </summary>
        /// <param name="trackingCode">O codigo de rastreio do pacote</param>
        /// <returns>Um objeto <see cref="LoggiResponse{T}"/> Contendo <see cref="TrackingDetailsResponse"/> Se obter sucesso.</returns>
        /// <exception cref="ArgumentNullException">Quando trackingCode é null ou vazio.</exception>
        /// <exception cref="InvalidOperationException">Quando não autenticado.</exception>
        public async Task<LoggiResponse<TrackingDetailsResponse>> RastrearPacoteDetalhado(string trackingCode)
        {
            if (string.IsNullOrEmpty(trackingCode))
                throw new ArgumentNullException(nameof(trackingCode), "Tracking Code não pode ser null ou vazio.");

            var response = await _httpClient.SendGetJsonAsync<TrackingDetailsResponse>
                ($"v1/companies/{_companyId}/packages/{trackingCode}", _token);

            return response;
        }

        /// <summary>
        /// A geração de etiqueta Loggi só pode ser feita após a resposta de sucesso do serviço de criação de pacotes.
        /// Para o serviço de criação de pacotes assíncrono, deve-se aguardar a mensagem de confirmação do webhook de que o pacote foi criado.
        /// A solicitação de geração de uma etiqueta está sempre associada à um envio previamente criado.
        /// Para referenciar este(s) envio(s), será necessário informar o(s) loggiKey(s) associado(s).
        /// </summary>
        /// <param name="loggiKey">LoggiKey obtido ao criar um shipment.</param>
        /// <param name="layout">Valor Opcional para configurar o Layout de resposta Veja possiveis Valores: <see cref="LabelLayouts"/> O Valor padrão é <see cref="LabelLayouts.LayoutA4"/></param>
        /// <param name="responseType">Valor opcional para configurar o tipo de resposta, Possiveis Valores: <see cref="LabelResponseTypes"/> O valor padrão é <see cref="LabelResponseTypes.Base64"/></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Quando é fornecida uma LoggiKey vazia ou nula.</exception>
        public async Task<LoggiResponse<LabelResponse>> CriarEtiqueta(string loggiKey,
            string layout = LabelLayouts.LayoutA4, string responseType = LabelResponseTypes.Base64)
        {
            if (string.IsNullOrEmpty(loggiKey))
                throw new ArgumentNullException(nameof(loggiKey), "A LoggiKey não pode ser nula ou vazia.");

            return await CriarEtiqueta(new List<string> { loggiKey }, layout, responseType);
        }


        /// <summary>
        /// A geração de etiqueta Loggi só pode ser feita após a resposta de sucesso do serviço de criação de pacotes.
        /// Para o serviço de criação de pacotes assíncrono, deve-se aguardar a mensagem de confirmação do webhook de que o pacote foi criado.
        /// A solicitação de geração de uma etiqueta está sempre associada à um envio previamente criado.
        /// Para referenciar este(s) envio(s), será necessário informar o(s) loggiKey(s) associado(s).
        /// </summary>
        /// <param name="loggiKeys">Lista de strings de LoggiKeys obtidos ao criar shipments.</param>
        /// <param name="layout">Valor Opcional para configurar o Layout de resposta Veja possiveis Valores: <see cref="LabelLayouts"/> O Valor padrão é <see cref="LabelLayouts.LayoutA4"/></param>
        /// <param name="responseType">Valor opcional para configurar o tipo de resposta, Possiveis Valores: <see cref="LabelResponseTypes"/> O valor padrão é <see cref="LabelResponseTypes.Base64"/></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Quando é fornecida uma LoggiKey vazia ou nula.</exception>
        public async Task<LoggiResponse<LabelResponse>> CriarEtiqueta(List<string> loggiKeys,
            string layout = LabelLayouts.LayoutA4, string responseType = LabelResponseTypes.Base64)
        {
            if (loggiKeys == null || !loggiKeys.Any())
                throw new ArgumentNullException(nameof(loggiKeys), "Lista de LoggiKeys deve conter ao menos um valor");

            var labelRequest = new LabelRequest()
            {
                ResponseType = responseType,
                Layout = layout,
                LoggiKeys = loggiKeys
            };

            var response = await _httpClient.SendPostAsync<LabelResponse>($"v1/companies/{_companyId}/labels",
                labelRequest, _token);

            return response;
        }

        /// <summary>
        /// Esta API disponibiliza opções de preços e prazos da Loggi nas plataformas parceiras,
        /// em tempo real, conforme as características do envio e do parceiro e informações de companyId,
        /// shipFrom, shipTo, packages, pickupTypes ou externalServiceIds (SISUs).
        /// Mesmo com poucas informações preenchidas, a API disponibiliza os preços e os prazos mais adequados ao parceiro. Ainda assim, para obter um retorno de estimativa de preço e prazo mais preciso,
        /// recomendamos o preenchimento de todos os campos obrigatórios.
        /// </summary>
        /// <param name="quotation">Objeto Quotation que pode ser criado com um <see cref="QuotationBuilder"/></param>
        /// <returns><see cref="LoggiResponse{T}"/> com objeto <see cref="QuotationResponse"/> Quando há sucesso.</returns>
        /// <exception cref="ArgumentNullException">Quqando a quotation ter valor null.</exception>
        public async Task<LoggiResponse<QuotationResponse>> CriarCotacao(Quotation quotation)
        {
            if (quotation == null)
                throw new ArgumentNullException(nameof(quotation), "Quotation não pode ser null.");


            var response = await _httpClient.SendPostAsync<QuotationResponse>
            ($"/v1/companies/{_companyId}/quotations",
                quotation, _token);

            return response;
        }

        /// <summary>
        /// É possível cancelar o envio de um pacote, desde que o status não esteja como entregue, cancelado ou extraviado.
        /// Se o pacote estiver no status Saiu para entrega ou com os Correios, vamos tentar cancelar o envio, mas não garantimos que dê certo. Nesses casos, a API retorna uma mensagem de aviso.
        /// Você consegue consultar a lista de status clicando aqui.
        /// </summary>
        /// <param name="trackingCode">Codigo de rastreio da Loggi, pode ser vazio se conter o LoggiKey</param>
        /// <param name="loggiKey">LoggiKey recebido pela Loggi ao gerar o shipment, é preferivel ao Codigo de rastreio</param>
        /// <returns><see cref="LoggiResponse{T}"/> Contendo um <see cref="PackageCancelResponse"/> se obter sucesso.</returns>
        /// <exception cref="InvalidOperationException">Quando trackingCode e loggiKey estão ambos vazios.</exception>
        public async Task<LoggiResponse<PackageCancelResponse>> CancelarPacote(string trackingCode,
            string loggiKey = "")
        {
            if (string.IsNullOrEmpty(trackingCode) && string.IsNullOrEmpty(loggiKey))
                throw new InvalidOperationException(
                    "Deve conter ao menos um dos valores para ser usado TrackingCode ou LoggiKey.");

            string query;
            query = !string.IsNullOrEmpty(loggiKey) ? $"?loggi_key={loggiKey}" : $"?tracking_code={trackingCode}";

            var response = await _httpClient.SendPostAsync<PackageCancelResponse>
                ($"/v1/companies/{_companyId}/packages/cancel{query}", null, _token);

            return response;
        }


        /// <summary>
        /// *Atualmete Setembro de 2024, não funciona, é retornado pela Loggi como houve falha mesmo estando tudo correto.*
        /// Esta API permite atualizar as informações de envio de um pacote com novos dados, conforme as informações do company_id, tracking_code ou loggikey.
        /// É possível alterar as informações do destinatário, desde que o status do pacote não esteja como entregue, cancelado ou extraviado.
        /// </summary>
        /// <param name="packageUpdate"></param>
        /// <returns><see cref="LoggiResponse{T}"/>Valor booleano como resposta da Loggi.</returns>
        /// <exception cref="InvalidOperationException">Quando PackageUpdate esta é null ou PackageUpdate.ShipTo é null.</exception>
        public async Task<LoggiResponse<bool>> AtualizarPacote(PackageUpdate packageUpdate)
        {
            if (packageUpdate == null)
                throw new InvalidOperationException("Package update não pode ser null.");

            if (packageUpdate.ShipTo == null)
                throw new InvalidOperationException(
                    "O ShipTo deve está dentro do PackageUpdate para que possa ser atualizado com sucesso,");

            var response = await _httpClient.SendPostAsyncBoolResponse
                ($"v1/companies/{_companyId}/packages", packageUpdate, _token);

            return response;
        }

        /// <summary>
        /// Lista os Loggi Pontos disponíveis para dropoff.
        /// </summary>
        /// <param name="pontosRequest"></param>
        /// <returns><see cref="LoggiResponse{T}"/> Contendo um <see cref="PontosResponse"/> se obter sucesso.</returns>
        /// <exception cref="InvalidOperationException">Quando pontosRequest é null ou não possui categorias.</exception>
        public async Task<LoggiResponse<PontosResponse>> ListarLoggiPontos(PontosRequest pontosRequest)
        {
            if (pontosRequest == null)
                throw new InvalidOperationException("PontosRequest não pode ser null.");

            if (!pontosRequest.Categories.Any())
                throw new InvalidOperationException("Categorias no PontosRequest deve conter ao menos um valor.");

            var response = await _httpClient.SendPostAsync<PontosResponse>
                ("/dropoff/locations", pontosRequest, _token);

            return response;
        }

        /// <summary>
        /// *Atualmente Setembro de 2024 não funciona direito.* Para buscar uma janela de coleta, você precisará informar o endereço de coleta
        /// </summary>
        /// <param name="endereco">Endereco para a janela de coletas do tipo <see cref="CorreiosAddressType"/> ou <see cref="LineAddressType"/></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Quando o endereco é null.</exception>
        /// <exception cref="InvalidOperationException">Quando não é do tipo correto.</exception>
        public async Task<LoggiResponse<JanelaColetaResponse>> BuscarJanelaColeta(IAddressType endereco)
        {
            if (endereco == null)
                throw new InvalidOperationException("Endereco não pode ser null");

            if (!(endereco is CorreiosAddressType) && !(endereco is LineAddressType))
                throw new InvalidOperationException("Deve ter um tipo de CorreiosAddressType ou LineAddressType");

            var body = new JanelaColetaRequest()
            {
                Address = endereco
            };

            var response = await _httpClient.SendPostAsync<JanelaColetaResponse>
                ($"api.loggi.com/v1/pickup/timeslot", body, _token);

            return response;
        }
    }
}