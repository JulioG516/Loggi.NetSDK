# Labels - Etiquetas

## Criar Etiqueta
A geração de etiqueta Loggi só pode ser feita após a resposta de sucesso do serviço de criação de pacotes, passado no [Criar um Shipment](shipment.md#criar-um-shipment-envio).
Para o serviço de criação de pacotes assíncrono, deve-se aguardar a mensagem de confirmação de que o pacote foi criado.

A solicitação de geração de uma etiqueta está sempre associada à um envio previamente criado.
Para referenciar este(s) envio(s), será necessário informar o(s) loggiKey(s) associado(s).

```csharp
var response = await _loggiClient.CriarEtiqueta("MVTTG2LG3TXAOY3DASIM3WQZT4");
if (response.IsSuccess)
{
    Console.WriteLine(response.Data.Success); // String das etiquetas em Base64 ou Url.
}
else
{
    Console.WriteLine(response.Error);
}

```

## Tipo do retorno <!-- {docsify-ignore} -->
Importante notar que pode ser passado valores do Enum LabelLayouts, sendo LabelLayouts.LayoutA4 (este é o padrão), ou LabelLayouts.LayoutA6 e o valor do LabelResponseTypes
Sendo LabelResponseTypes.Url ou LabelResponseTypes.Base64 (este sendo o padrão)

## Exemplo: <!-- {docsify-ignore} -->
```csharp
var response = await _loggiClient.CriarEtiqueta("MVTTG2LG3TXAOY3DASIM3WQZT4", LabelLayouts.LayoutA6, LabelResponseTypes.Url);

```

## Retorno
```csharp
    public class LabelResponse
    {
        /// <summary>
        /// Arquivo binário em BASE64 ou URL com as etiquetas geradas com sucesso.
        /// </summary>
        [JsonPropertyName("success")]
        [JsonConverter(typeof(LabelResponseTypeConverter))]
        public ILabelResponseType Success { get; set; }


        /// <summary>
        /// Lista de loggi keys dos pacotes que não puderam ter as etiquetas geradas e seus respectivos erros.
        /// </summary>
        [JsonPropertyName("failure")]
        public List<FailureLabel> Failure { get; set; }
    }

```

## Nota
Lembre-se de que o acesso ao retorno da API deve ser feito sempre através da propriedade `Data` do objeto `response`. Isso garante que você está acessando os dados corretos, em caso de sucesso na sua requisição.
Reveja como funciona o [padrão de resposta](README.md#padrão-de-respostas)
