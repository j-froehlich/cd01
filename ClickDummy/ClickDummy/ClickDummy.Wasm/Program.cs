using System;
using Uno.UI;
using Windows.UI.Xaml;

namespace ClickDummy.Wasm
{
    public class Program
    {
        private static App _app;

        static int Main(string[] args)
        {
            FeatureConfiguration.UIElement.AssignDOMXamlName = true;
            Windows.UI.Xaml.Application.Start(_ => _app = new App());

            return 0;
        }
    }
}
