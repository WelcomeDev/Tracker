namespace WelcomeDev.Provider.Di.Pageable
{
    public class PageableList<T> : List<T>
    {
        public int TotalCount { get; }

        public PageableList(IEnumerable<T> source, PageableParams pageable)
        {
            TotalCount = source.Count();

            var (pageSize, pageNumber, sortDirection) = pageable;
            var items = source.Skip(pageNumber * pageSize).Take(pageSize);

            items = sortDirection == SortDirection.ASC ? 
                items.OrderBy(x => x) 
                : 
                items.OrderByDescending(x => x);

            AddRange(items);
        }
    }
}
