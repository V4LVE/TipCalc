using System.Windows.Input;
using TipCalc.Views;

namespace TipCalc
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        }
    }
}
