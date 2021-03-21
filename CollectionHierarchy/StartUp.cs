using CollectionHierarchy.Core;
using CollectionHierarchy.IO.Contracts;
using CollectionHierarchy.IO.Modules;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main()
        {
            IReadable readerable = new Reader();
            IWritable writable = new Writer();

            IEngine engine = new Engine(readerable, writable);
            engine.Run();
        }
    }
}
