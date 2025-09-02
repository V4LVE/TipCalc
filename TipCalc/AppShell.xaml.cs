using System.Windows.Input;

namespace TipCalc
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    }
}
