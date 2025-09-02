namespace TipCalc.Views.Modals;

public partial class FeedbackPage : ContentPage
{
	public FeedbackPage()
	{
		InitializeComponent();
	}

    private async void CloseButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(animated: true);
    }

    private void Star_Tapped(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private async void SendFeedback_Clicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}