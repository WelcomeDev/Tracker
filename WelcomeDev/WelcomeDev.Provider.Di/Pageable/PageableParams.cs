namespace WelcomeDev.Provider.Di.Pageable
{
    public class PageableParams
    {
        public const int DefaultPageSize = 10;

        public const int DefaultPageNumber = 1;

        public const SortDirection DefaultSortDirection = SortDirection.ASC;

        public int PageSize { get; set; } = DefaultPageSize;

        public int PageNumber { get; set; } = DefaultPageNumber;

        public SortDirection SortDirection { get; set; } = DefaultSortDirection;

        public PageableParams()
        { }

        public PageableParams(int pageSize, int pageNumber, SortDirection sortDirection)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            SortDirection = sortDirection;
        }

        public void Deconstruct(out int pageSize, out int pageNumber, out SortDirection sortDirection)
        {
            pageSize = PageSize;
            pageNumber = PageNumber;
            sortDirection = SortDirection;
        }
    }
}
