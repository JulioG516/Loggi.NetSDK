# Coleta

## Aviso
Esta API no momento atual outubro de 2024 não esta funcionando
pois a Loggi devolve um erro com autenticação falha, mesmo estando correto.

## Buscar Janela de Coleta
Para buscar uma janela de coleta, você precisará informar o endereço de coleta

Veja o exemplo abaixo.

```csharp
        var response = await _loggiClient.BuscarJanelaColeta(new CorreiosAddressType()
        {
            Instrunctions = "",
            CorreiosAddress = new CorreiosAddress()
            {
                Logradouro = "R. Liberdade",
                Numero = "2400",
                Cep = "30622580",
                Cidade = "Belo Horizonte",
                Uf = "MG"
            }
        });
```

## Nota 
Lembre-se de que o acesso ao retorno da API deve ser feito sempre através da propriedade `Data` do objeto `response`. Isso garante que você está acessando os dados corretos, em caso de sucesso na sua requisição.
Reveja como funciona o [padrão de resposta](README.md#padrão-de-respostas)
