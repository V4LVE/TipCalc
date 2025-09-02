using System.Text.Json;
using TipCalc.Models;

namespace TipCalc.Views;

[QueryProperty(nameof(PersonJson), "person")]
public partial class DetailsPage : ContentPage
{
    private string personJson;
    public string PersonJson
    {
        set
        {
            personJson = value;

            var person = JsonSerializer.Deserialize<Person>(personJson);
            if (person != null)
            {
                WelcomeLabel.Text = $"Welcome, {person.Name}\n" +
                                    $"Address: {person.Address}\n" +
                                    $"Age: {person.Age}";
            }
        }
    }

    public DetailsPage()
    {
        InitializeComponent();
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..", true);
    }
}