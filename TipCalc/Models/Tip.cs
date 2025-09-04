using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TipCalc.Models
{
    public class Tip : INotifyPropertyChanged
    {
        private string _billAmount;
        private string _tipAmount;
        private string _totalAmount;
        private double _tipPercentage;


        public string BillAmount
        {
            get => _billAmount;
            set
            {
                _billAmount = value;
                CalculateTip();
                RaisePropertyChanged();
            }
        }

        public string TipAmount
        {
            get => _tipAmount;
            set
            {
                _tipAmount = value;
                RaisePropertyChanged();
            }
        }

        public string TotalAmount
        {
            get => _totalAmount;
            set
            {
                _totalAmount = value;
                RaisePropertyChanged();
            }
        }

        public double TipPercentage
        {
            get => _tipPercentage;
            set
            {
                _tipPercentage = value;
                CalculateTip();
                RaisePropertyChanged();
            }
        }


        public void CalculateTip()
        {
            if (string.IsNullOrEmpty(BillAmount))
            {
                return;
            }

            TipAmount = (double.Parse(BillAmount) * TipPercentage / 100).ToString("0.00");
            TotalAmount = (double.Parse(BillAmount) + double.Parse(TipAmount)).ToString("0.00");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
