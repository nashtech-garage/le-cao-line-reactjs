namespace Account.API.Infrastructure.ResponseGeneric
{
    public class ListResponse<T> : Response<T>
    {
        public new List<T?>? Object { get; set; }

        public static ListResponse<T> Success<T>(string message = "", List<T?>? items = null)
        {
            return new ListResponse<T>()
            {
                Message = message,
                State = true,
                Object = items
            };
        }
    }
}
