namespace ValueAndReferenceType
{
    public struct ValueType
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public int CheckOut(int a)
        {
            a = 500;
            return a;
        }
    }


}
