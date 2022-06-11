using System;

namespace ValueAndReferenceType
{

    // Immutable (DTO = Data Transfer Object ) = Unchangeable
    // LINQ
    // Value?
    public record RecordType(int X, int Y);


    // // Or we can write it like this
    //public record RecordType
    //{
    //    public int X { get; init; } // here we can't make "set"
    //    public int Y { get; init; } // Because "record" it does't anable change the value 
    //}
}
