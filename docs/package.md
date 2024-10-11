# Package - API 

## Atualizar dados de um pacote
Esta API permite atualizar as informações de envio de um pacote com novos dados, conforme as informações do `TrackingCode` ou `LoggiKey`.
É possível alterar as informações do destinatário, desde que o status do pacote não esteja como entregue, cancelado ou extraviado.

## Mais alguns detalhes: <!-- {docsify-ignore} -->
- A única informação que não pode ser alterada é o estado (UF), por conta das exigências fiscais brasileiras.

- Caso seja fornecido o código de rastreio do pacote (tracking_code) e o código único (loggi_key), o loggi_key será utilizado como padrão.

## Como Utilizar: <!-- {docsify-ignore} -->
Crie uma clase `PackageUpdate` com a propriedade `ShipTo`
contendo uma classe `ShipTo` com os itens a ser alterado.

```csharp
        var package = new PackageUpdate()
        {
            ShipTo = new ShipTo()
            {
                Name = "Maria Lucia",
                PhoneNumber = "11998765432",
                FederalTaxId = "12345678911",
                Address = new CorreiosAddressType()
                {
                    CorreiosAddress = new CorreiosAddress()
                    {
                        Logradouro = "Pacífico Mascarenhas",
                        Numero = "S/N",
                        Bairro = "Centro",
                        Cidade = "Baldim"
                    }
                }
            }
        };

        var response = await _loggiClient.AtualizarPacote(package);

        if (response.IsSuccess)
        {
            Console.WriteLine(response.Data); // Bool
        }
        else
        {
            Console.WriteLine(response.Error);
        }

```

## Retorno - Atualizar dados de um pacote
Valor do tipo  `boolean` indicando se foi aceito na Loggi.

## Cancelar Envio
Esta API permite cancelar o envio de um pacote, conforme as informações do `TrackingCode` ou `LoggiKey`.
É possível cancelar o envio de um pacote, desde que o status não esteja como entregue, cancelado ou extraviado.
Se o pacote estiver no status Saiu para entrega ou com os Correios, a Loggi tentar cancelar o envio, mas não garante que dê certo. Nesses casos, a API retorna uma mensagem de aviso.


## Como Utilizar <!-- {docsify-ignore} -->
Utilizando `TrackingCode`
```csharp
    var response = await _loggiClient.CancelarPacote("TrackingCode");
```

ou 
Utilizando `LoggiKey`
```csharp
    var response = await _loggiClient.CancelarPacote("",  "LoggiKey");
```

Importante notar que pode ser passado o `TrackingCode` junto com o `LoggiKey`
porém será dado prioridade ao `LoggiKey`.

## Retorno - Cancelar Envio
Classe `PackageCancelResponse` contendo propriedades `WarningType`
e `WarningMessage` com detalhes CASO o cancelamento não tenha sido confirmado.

```csharp
    public class PackageCancelResponse
    {
        /// <summary>
        /// Mensagem com a constante que identifica casos em que o cancelamento não pode ser confirmado.
        /// </summary>
        [JsonPropertyName("warning_type")]
        public string WarningType { get; set; }

        /// <summary>
        /// Mensagem de alerta para casos em que o cancelamento não pode ser confirmado.
        /// </summary>
        [JsonPropertyName("warning_message")]
        public string WarningMessage { get; set; }
    }
```

## Nota 
Lembre-se de que o acesso ao retorno da API deve ser feito sempre através da propriedade `Data` do objeto `response`. Isso garante que você está acessando os dados corretos, em caso de sucesso na sua requisição.
Reveja como funciona o [padrão de resposta](README.md#padrão-de-respostas)
