using TipCalc.ViewModels;

namespace TipCalc.Views;

public partial class MonkeyDetailsPage : ContentPage
{
    public MonkeyDetailsPage(MonkeyDetailsPageViewModel monkeyDetailsPageViewModel)
    {
        InitializeComponent();
        BindingContext = monkeyDetailsPageViewModel;
    }
}