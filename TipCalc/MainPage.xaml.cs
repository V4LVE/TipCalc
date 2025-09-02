using TipCalc.Views;
using TipCalc.Views.Modals;

namespace TipCalc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AboutToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        private async void FeedbackToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FeedbackPage(), animated: true);
        }
    }
}
