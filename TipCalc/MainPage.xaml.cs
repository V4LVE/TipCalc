using TipCalc.Models;

namespace TipCalc
{
    public partial class MainPage : ContentPage
    {
        public Tip Tip { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Tip = new Tip
            {
                BillAmount = "100",
                TipAmount = "0",
                TotalAmount = "0",
                TipPercentage = "15"
            };
            BindingContext = Tip;
        }

        void OnBillChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(BillEntry.Text, out var newBill) && newBill > 0)
                Tip.BillAmount = newBill.ToString();
            else
                Tip.BillAmount = "0";

            CalculateTipAndUpdateUI();
        }

        void CalculateTipAndUpdateUI()
        {
            Tip.CalculateTip();

            TipLabel.Text = $"Tip: {Tip.TipAmount} kr.";
            TotalLabel.Text = $"Total: {Tip.TotalAmount} kr.";
            TipSlider.Value = int.Parse(Tip.TipPercentage);
            PercentageLabel.Text = $"{Tip.TipPercentage}%";
        }

        void OnTipPercentageChanged(object sender, ValueChangedEventArgs e)
        {
            Tip.TipPercentage = e.NewValue.ToString();
            PercentageLabel.Text = $"{Tip.TipPercentage}%";
            CalculateTipAndUpdateUI();
        }

        async void On15PercentClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have tipped 15%", "OK");
            Tip.TipPercentage = "15";
            CalculateTipAndUpdateUI();
        }

        async void On20PercentClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirm", "Are you sure you want to tip 20%?", "Yes", "No");
            if (!answer)
                return;

            Tip.TipPercentage = "20";
            CalculateTipAndUpdateUI();
        }
        void OnRoundDownClicked(object sender, EventArgs e)
        {
            var total = double.Parse(Tip.BillAmount) + (double.Parse(Tip.BillAmount) * double.Parse(Tip.TipPercentage) / 100);
            var roundedTotal = Math.Floor(total / 10) * 10; // round down to nearest 10
            TipLabel.Text = $"Tip: {(roundedTotal - double.Parse(Tip.BillAmount)):0.00} kr.";
            TotalLabel.Text = $"Total: {roundedTotal:0.00} kr.";
        }

        void OnRoundUpClicked(object sender, EventArgs e)
        {
            var total = double.Parse(Tip.BillAmount) + (double.Parse(Tip.BillAmount) * double.Parse(Tip.TipPercentage) / 100);
            var roundedTotal = Math.Ceiling(total / 10) * 10; // round up to nearest 10
            TipLabel.Text = $"Tip: {(roundedTotal - double.Parse(Tip.BillAmount)):0.00} kr.";
            TotalLabel.Text = $"Total: {roundedTotal:0.00} kr.";
        }

        void OnFeelingLuckyClicked(object sender, EventArgs e)
        {
            var random = new Random();
            int maxTip = (int)Math.Ceiling(double.Parse(Tip.BillAmount));
            if (maxTip < 1)
                maxTip = 0;

            var tip = random.Next(0, maxTip); // random tip between 1 and maxTip inclusive

            var total = double.Parse(Tip.BillAmount) + tip;

            TipLabel.Text = $"Tip: {tip:0.00} kr.";
            TotalLabel.Text = $"Total: {total:0.00} kr.";
        }

        async void OnViewCurrencyClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Currency", "Cancel", null, "Danske Kroner", "Euro", "Dollars");

            var tip = double.Parse(Tip.BillAmount) * double.Parse(Tip.TipPercentage) / 100;
            var total = double.Parse(Tip.BillAmount) + tip;

            switch (action)
            {
                case "Danske Kroner":
                    TipLabel.Text = $"Tip: {tip:0.00} kr.";
                    TotalLabel.Text = $"Total: {total:0.00} kr.";
                    break;
                case "Euro":
                    TipLabel.Text = $"Tip: {tip:0.00} €";
                    TotalLabel.Text = $"Total: {total:0.00} €";
                    break;
                case "Dollars":
                    TipLabel.Text = $"Tip: {tip:0.00} $";
                    TotalLabel.Text = $"Total: {total:0.00} $";
                    break;
                default:
                    break;
            }
        }
    }
}
