namespace Vcmng.Infrastructure.Response
{
    public class BaseResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
