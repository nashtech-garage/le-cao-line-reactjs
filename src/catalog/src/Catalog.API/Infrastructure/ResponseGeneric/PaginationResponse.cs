namespace Catalog.API.Infrastructure.ResponseGeneric
{
    public class PaginationResponse<T> : ListResponse<T>
    {
        public int Total { get; set; }

        public static PaginationResponse<T> Success<T>(string message = "", List<T?>? items = null, int total = 0)
        {
            return new PaginationResponse<T>()
            {
                Message = message,
                State = true,
                Object = items,
                Total = total
            };
        }
    }
}