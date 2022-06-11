namespace ValueAndReferenceType
{
    public struct ValueType
    {
        public int X { get; set; }
        public int Y { get; set; }
    }


    // // Or we can write it like this
    //public record RecordType
    //{
    //    public int X { get; init; } // here we can't make "set"
    //    public int Y { get; init; } // Because "record" it does't anable change the value 
    //}
}
