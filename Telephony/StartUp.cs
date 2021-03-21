using Telephony.Contracts;
using Telephony.Core;
using Telephony.IO.Contracts;
using Telephony.IO.Models;

namespace Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            IReadable reader = new Reader();
            IWritable writer = new Writer();

            IEngine engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}
