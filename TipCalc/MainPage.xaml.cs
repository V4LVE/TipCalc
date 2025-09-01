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
            if (decimal.TryParse(BillEntry.Text, out var newBill))
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

        void On15PercentClicked(object sender, EventArgs e)
        {
            tipPercentage = 15;
            TipSlider.Value = tipPercentage;
            CalculateTip();
        }

        void On20PercentClicked(object sender, EventArgs e)
        {
            tipPercentage = 20;
            TipSlider.Value = tipPercentage;
            CalculateTip();
        }
        void OnRoundDownClicked(object sender, EventArgs e)
        {
            var total = bill + bill * tipPercentage / 100;
            var roundedTotal = Math.Floor(total / 10) * 10; // round down to nearest 10
            TipLabel.Text = $"Tip: {(roundedTotal - bill):0.00} kr.";
            TotalLabel.Text = $"Total: {roundedTotal:0.00} kr.";
        }

        void OnRoundUpClicked(object sender, EventArgs e)
        {
            var total = bill + bill * tipPercentage / 100;
            var roundedTotal = Math.Ceiling(total / 10) * 10; // round up to nearest 10
            TipLabel.Text = $"Tip: {(roundedTotal - bill):0.00} kr.";
            TotalLabel.Text = $"Total: {roundedTotal:0.00} kr.";
        }

        void OnFeelingLuckyClicked(object sender, EventArgs e)
        {
            var random = new Random();
            int maxTip = (int)Math.Ceiling(bill);
            if (maxTip < 1)
                maxTip = 1;

            var tip = random.Next(1, maxTip + 1); // random tip between 1 and maxTip inclusive

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
    }
}
