using P03.StudentSystem;

namespace P03_StudentSystem
{
   public class StartUp
    {
        public static void Main()
        {
            var inputOutputProvider = new ConsoleInputOutputProvider();
            var engine = new Engine(new StudentSystem(), inputOutputProvider);
            engine.Process();
        }
    }
}
