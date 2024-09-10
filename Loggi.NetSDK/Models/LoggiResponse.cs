using System.Text;

namespace Loggi.NetSDK.Models
{
    public class LoggiResponse<T>
    {
        public T Data { get; set; }
        public ErrorResponse? Error { get; set; }
        public bool IsSuccess => Error == null;

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