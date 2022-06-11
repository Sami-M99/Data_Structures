namespace Sorting
{
    public static class Swap
    {
        public static void swap<T>(T[] array, int x, int y)
        {
            T temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }
    }

}
