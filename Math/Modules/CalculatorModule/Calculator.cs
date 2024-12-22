namespace ModulesForTesting.Modules.Calculator
{
    public class Calculator
    {
        public int Sum(int[] args) => args.Sum();

        public int Divide(int target, int divideBy) => target / divideBy;

        public int Min(int[] args) => args.Min();

        public bool IsOddNumber(int a) => a % 2 == 0;

        public IEnumerable<int> GetRangeOfOddNumbers(int min, int max)
        {
            return Enumerable.Range(min, max - min + 1).Where(el => el % 2 != 0);
        }

        public async Task<int> AsyncMath()
        {
            int output = 0;
            await Task.Run(() => { output = 2 + 2; });

            return output;
        }
    }
}
