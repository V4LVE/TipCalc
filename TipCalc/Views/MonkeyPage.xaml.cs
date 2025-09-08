using TipCalc.ViewModels;

namespace TipCalc.Views;

public partial class MonkeyPage : ContentPage
{
    private MonkeyPageViewModel _monkeyPageViewModel;

    public MonkeyPage(MonkeyPageViewModel monkeyPageViewModel)
    {
        _monkeyPageViewModel = monkeyPageViewModel;
        BindingContext = _monkeyPageViewModel;
        InitializeComponent();
    }
}