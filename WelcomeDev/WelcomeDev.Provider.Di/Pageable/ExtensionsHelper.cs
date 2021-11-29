namespace WelcomeDev.Provider.Di.Pageable
{
    public static class ExtensionsHelper
    {
        public static IEnumerable<T> GetPageable<T>(this IEnumerable<T> items, PageableParams pageable)
        {
            var (pageSize, pageNumber, sortDirection) = pageable;

            items = items.Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize);

            items = sortDirection == SortDirection.ASC ?
                items.OrderBy(x => x)
                :
                items.OrderByDescending(x => x);

            return items;
        }
    }
}
