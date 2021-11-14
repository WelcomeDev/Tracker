namespace WelcomeDev.Provider.Di.Pageable
{
    public class PageableList<T>
        where T : class, IComparable<T>
    {
        public int TotalCount { get; }

        public IEnumerable<T> Items { get; }

        public PageableList(IEnumerable<T> source, PageableParams pageable = null)
        {
            TotalCount = source.Count();

            if (pageable is null)
            {
                Items = source.ToList();
                return;
            }

            var (pageSize, pageNumber, sortDirection) = pageable;
            Items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            Items = sortDirection == SortDirection.ASC ?
                Items.OrderBy(x => x)
                :
                Items.OrderByDescending(x => x);
        }
    }
}
