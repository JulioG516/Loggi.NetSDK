namespace Loggi.NetSDK.Models
{
    public class LoggiResponse<T>
    {
        public T Data { get; set; }
        public ErrorResponse? Error { get; set; }
        public bool IsSuccess => Error == null;

        public override string ToString()
        {
            return string.Format("IsSucess: {0}\nData Type: {1}\nError:{2} - {3}", IsSuccess, Data?.GetType(),
                Error?.Code, Error?.Message);
        }
    }
}