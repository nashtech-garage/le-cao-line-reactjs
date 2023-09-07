namespace Account.API.Infrastructure.ResponseGeneric
{
    public class Response<T>
    {
        public bool State { get; set; }
        public string? Message { get; set; }
        public T? Object { get; set; }

        public static Response<T> Success(string message = "", T? obj = default(T))
        {
            return new Response<T>()
            {
                State = true,
                Message = message,
                Object = obj
            };
        }
        public static Response<T> Fail(string message = "", T? obj = default(T))
        {
            return new Response<T>()
            {
                State = false,
                Message = message,
                Object = obj
            };
        }
    }
}
