namespace WelcomeDev.Provider.Di.Pageable
{
    public interface IPageableProvider<T> where T : class, IComparable<T>
    {
        PageableList<T> GetAll(PageableParams pageable = null);
    }
}
