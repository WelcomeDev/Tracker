namespace WelcomeDev.Utils.Array
{
    public static class ArrayUtil
    {
        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            if (array is null)
                throw new ArgumentNullException("array");

            if (action is null)
                throw new ArgumentNullException("action");

            foreach (T item in array)
            {
                action(item);
            }
        }
    }
}
