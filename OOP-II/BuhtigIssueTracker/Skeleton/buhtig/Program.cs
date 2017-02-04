namespace BuhtigIssueTracker
{
    using System.Globalization;
    using System.Threading;
    using Logic;

    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var myEngine = new Engine();
            myEngine.Run();
        }
    }
}
