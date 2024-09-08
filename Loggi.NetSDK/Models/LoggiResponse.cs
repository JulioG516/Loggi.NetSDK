namespace Loggi.NetSDK.Models
{
    public class LoggiResponse<T>
    {
        public T Data { get; set; }
        public ErrorResponse? Error { get; set; }
        public bool IsSuccess => Error == null;
    }
}