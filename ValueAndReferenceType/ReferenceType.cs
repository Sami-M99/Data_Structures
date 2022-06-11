namespace ValueAndReferenceType
{
    public class ReferenceType
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public int CheckOut(out int a)
        {
            a = 500;
            return a;
        }

    }


}
