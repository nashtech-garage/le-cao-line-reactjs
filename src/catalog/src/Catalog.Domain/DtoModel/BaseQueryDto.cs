namespace Catalog.Domain.DtoModel
{
    public abstract class BaseQueryDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}