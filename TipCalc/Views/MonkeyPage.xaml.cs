using TipCalc.ViewModels;

namespace TipCalc.Views;

public partial class MonkeyPage : ContentPage
{
    private MonkeyPageViewModel _viewModel;

    public MonkeyPage(MonkeyPageViewModel monkeyPageViewModel)
    {
        BindingContext = monkeyPageViewModel;
        _viewModel = monkeyPageViewModel;
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        _viewModel.GetMonkeysCommand.Execute(null);
    }
}