using TipCalc.ViewModels;

namespace TipCalc.Views;

public partial class MonkeyPage : ContentPage
{
    public MonkeyPage(MonkeyPageViewModel monkeyPageViewModel)
    {
        BindingContext = monkeyPageViewModel;
        InitializeComponent();
    }
}