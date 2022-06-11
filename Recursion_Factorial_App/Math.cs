namespace Recursion_Factorial_App
{
    public class Math
    {
        // Math.Factorial(int)
        // Iteration  like for,while...
        public static int Factorial(int input)
        {
            if (input <= 1)
                return 1;

            int result = 1;
            int step = 1;
            while (step <= input)
            {
                result *= step;
                step++;
            }
            return result;
        }


        // Recursion
        public static int FactorialRecursion(int input)
        {
            // base case
            if (input <= 1)
                return 1;
            return input * FactorialRecursion(input - 1);
        }
    }

}
