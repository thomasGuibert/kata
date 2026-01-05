namespace WordWrap
{
    public class Wrapper
    {
        public static string Wrap(string input, int rowSize) 
            => Sentense.CreateSentense(input).WithRowSize(rowSize).ToString();
    }
}