using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace ClickDummy.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new ClickDummy.App(), args);
            host.Run();
        }
    }
}
