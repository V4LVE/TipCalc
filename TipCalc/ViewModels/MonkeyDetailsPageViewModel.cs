using TipCalc.Models;

namespace TipCalc.ViewModels
{
    [QueryProperty(nameof(Monkey), "MyMonkey")]
    public class MonkeyDetailsPageViewModel : BaseViewModel
    {
        Monkey monkey;
        public Monkey Monkey
        {
            get => monkey;
            set => SetProperty(ref monkey, value);
        }
    }
}
