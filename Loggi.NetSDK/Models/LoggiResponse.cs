using System.Text;

namespace Loggi.NetSDK.Models
{
    /// <summary>
    /// Representa uma resposta da API Loggi. Podendo ter informações em <see cref="Data"/> quando há sucesso
    /// Ou informações em Error representada por <see cref="ErrorResponse"/> quando houve uma falha. 
    /// </summary>
    /// <typeparam name="T">O tipo dos dados contidos na resposta.</typeparam>
    public class LoggiResponse<T>
    {
        /// <summary>
        /// Os dados definido na API, é null quando há uma falha.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Informações do erro, caso a chamada da API tenha falha.
        /// </summary>
        public ErrorResponse? Error { get; set; }
        
        /// <summary>
        /// Indica se a chamada da API foi bem sucedida.
        /// </summary>
        public bool IsSuccess => Error == null;

        /// <summary>
        /// Retorna uma representação em string da resposta.
        /// </summary>
        /// <returns>Uma string que representa o objeto atual.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder().Append("IsSucess: ")
                .Append(IsSuccess)
                .Append("\nData Type: ")
                .Append(Data?.GetType());
            if (Error != null)
            {
                sb.Append("\nError:")
                    .Append(Error?.Code)
                    .Append(" - ")
                    .Append(Error?.Message);
            }

            return sb.ToString();
        }
    }
}