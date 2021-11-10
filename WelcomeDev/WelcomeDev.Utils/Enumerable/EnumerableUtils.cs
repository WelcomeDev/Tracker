namespace WelcomeDev.Utils.Enumerable
{
    public static class EnumerableUtils
    {
        public static void ForEach<T>(this IEnumerable<T> array, Action<T> action)
        {
            if (array is null)
                throw new ArgumentNullException("array");

            if (action is null)
                throw new ArgumentNullException("action");

            foreach (T item in array)
                action(item);
        }
    }
}
