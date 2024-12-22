namespace ModulesForTesting.Modules.FiboModule
{
    // this is not my code. This is a part of my course of unit testing
    public class Fibo
    {
        public List<int> GetFiboSeries(int range)
        {
            var output = new List<int>();
            int a = 0, b = 1, c = 0;
            if (range == 1)
            {
                output.Add(0);
                return output;
            }
            output.Add(0);
            output.Add(1);

            for (int i = 2; i < range; i++)
            {
                c = a + b;
                output.Add(c);
                a = b;
                b = c;
            }

            return output;
        }
    }
}
