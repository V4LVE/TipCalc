using TipCalc.Models;

namespace TipCalc.Views.Modals;

public partial class FeedbackPage : ContentPage
{
	public FeedbackPage()
	{
		InitializeComponent();
	}

    private void Star_Tapped(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private async void SendFeedback_Clicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private async void OpenDetailsButton_Clicked(object sender, EventArgs e)
    {
        var person = new Person
        {
            Name = "Seymour Ass",
            Address = "Dil Doe Street 69",
            Age = 69
        };

        string json = System.Text.Json.JsonSerializer.Serialize(person);

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?person={json}", true);
    }
}