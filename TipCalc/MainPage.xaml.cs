namespace TipCalc
{
    public partial class MainPage : ContentPage
    {
        decimal bill = 0;
        int tipPercentage = 15;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnBillChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(BillEntry.Text, out var newBill) && newBill > 0)
                bill = newBill;
            else
                bill = 0;

            CalculateTip();
        }

        void OnTipPercentageChanged(object sender, ValueChangedEventArgs e)
        {
            tipPercentage = (int)e.NewValue;
            PercentageLabel.Text = $"{tipPercentage}%";
            CalculateTip();
        }

        async void On15PercentClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have tipped 15%", "OK");
            tipPercentage = 15;
            TipSlider.Value = tipPercentage;
            CalculateTip();
        }

        async void On20PercentClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirm", "Are you sure you want to tip 20%?", "Yes", "No");
            if (!answer)
                return;

            tipPercentage = 20;
            TipSlider.Value = tipPercentage;
            CalculateTip();
        }
        void OnRoundDownClicked(object sender, EventArgs e)
        {
            var total = bill + (bill * tipPercentage / 100);
            var roundedTotal = Math.Floor(total / 10) * 10; // round down to nearest 10
            TipLabel.Text = $"Tip: {(roundedTotal - bill):0.00} kr.";
            TotalLabel.Text = $"Total: {roundedTotal:0.00} kr.";
        }

        void OnRoundUpClicked(object sender, EventArgs e)
        {
            var total = bill + (bill * tipPercentage / 100);
            var roundedTotal = Math.Ceiling(total / 10) * 10; // round up to nearest 10
            TipLabel.Text = $"Tip: {(roundedTotal - bill):0.00} kr.";
            TotalLabel.Text = $"Total: {roundedTotal:0.00} kr.";
        }

        void OnFeelingLuckyClicked(object sender, EventArgs e)
        {
            var random = new Random();
            int maxTip = (int)Math.Ceiling(bill);
            if (maxTip < 1)
                maxTip = 0;

            var tip = random.Next(0, maxTip); // random tip between 1 and maxTip inclusive

            var total = bill + tip;
            var percentage = bill > 0 ? (tip / bill) * 100 : 0;

            TipSlider.Value = tipPercentage;

            TipLabel.Text = $"Tip: {tip:0.00} kr.";
            TotalLabel.Text = $"Total: {total:0.00} kr.";
        }

        void CalculateTip()
        {
            var tip = bill * tipPercentage / 100;
            var total = bill + tip;

            TipLabel.Text = $"Tip: {tip:0.00} kr.";
            TotalLabel.Text = $"Total: {total:0.00} kr.";
        }

        async void OnViewCurrencyClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Currency", "Cancel", null, "Danske Kroner", "Euro", "Dollars");

            var tip = bill * tipPercentage / 100;
            var total = bill + tip;

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
