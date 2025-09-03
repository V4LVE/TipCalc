using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui;

namespace TipCalc.Models
{
    public class Tip
    {
        public string BillAmount { get; set; }
        public string TipAmount { get; set; }
        public string TotalAmount { get; set; }
        public double TipPercentage { get; set; }


       public void CalculateTip()
        {
            TipAmount = (double.Parse(BillAmount) * TipPercentage / 100).ToString();
            TotalAmount = (double.Parse(BillAmount) + double.Parse(TipAmount)).ToString();
        }
    }
}
