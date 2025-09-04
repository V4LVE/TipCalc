using System.Collections.ObjectModel;
using TipCalc.Models;

namespace TipCalc.Views;

public partial class RestaurantListPage : ContentPage
{
    public ObservableCollection<Restaurant> RestaurantList { get; set; }

    public RestaurantListPage()
    {
        InitializeComponent();
        CreateRestaurantList();
        BindingContext = this;
    }

    private void CreateRestaurantList()
    {
        RestaurantList = new ObservableCollection<Restaurant>();

        RestaurantList.Add(new Restaurant { Name = "The Fancy Fork", ImageUrl = "https://interiordesign.net/wp-content/uploads/2024/04/InteriorDesign_March2024_Brave-New-World-1024x683.jpg", TipPercent = 20 });
        RestaurantList.Add(new Restaurant { Name = "Burger Bonanza", ImageUrl = "https://interiordesign.net/wp-content/uploads/2024/04/InteriorDesign_March2024_Brave-New-World-20-1024x683.jpg", TipPercent = 15 });
        RestaurantList.Add(new Restaurant { Name = "Pasta Palace", ImageUrl = "https://interiordesign.net/wp-content/uploads/2024/04/InteriorDesign_March2024_Brave-New-World-23-746x1024.jpg", TipPercent = 18 });
        RestaurantList.Add(new Restaurant { Name = "Sushi Central", ImageUrl = "https://interiordesign.net/wp-content/uploads/2024/04/InteriorDesign_March2024_Brave-New-World-9-768x960.jpg", TipPercent = 20 });
        RestaurantList.Add(new Restaurant { Name = "Taco Town", ImageUrl = "https://interiordesign.net/wp-content/uploads/2024/04/InteriorDesign_March2024_Brave-New-World-13-1024x683.jpg", TipPercent = 15 });
    }

    private void AddRes_Clicked(object sender, EventArgs e)
    {
        RestaurantList.Add(new Restaurant
        {
            Name = "Gelada",
            TipPercent = 100,
            ImageUrl = "https://interiordesign.net/wp-content/uploads/2024/04/InteriorDesign_March2024_Brave-New-World-29-682x1024.jpg"
        });
    }

    private void DeleteRes_Clicked(object sender, EventArgs e)
    {
        RestaurantList.Remove(RestaurantList.FirstOrDefault());
    }
}