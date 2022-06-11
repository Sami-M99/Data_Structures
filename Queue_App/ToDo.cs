namespace Queue_App
{
    public class ToDo
    {
        public string Describe { get; set; }
        public double Time { get; set; }

        public override string ToString()
        {
            return $"{Describe,-20} {Time,-5}";
        }
    }
}
