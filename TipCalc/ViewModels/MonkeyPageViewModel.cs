using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using TipCalc.Models;
using TipCalc.Service;

namespace TipCalc.ViewModels
{
    public class MonkeyPageViewModel : BaseViewModel
    {
        private MonkeyService _monkeyService;

        public ObservableCollection<Monkey> Monkeys { get; set; }

        public MonkeyPageViewModel(MonkeyService monkeyService)
        {
            _monkeyService = monkeyService;
            Title = "Monkey Finder";
            Monkeys = new ObservableCollection<Monkey>();
        }

        public async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var monkeys = await _monkeyService.GetMonkeys();

                if (Monkeys.Count != 0)
                    Monkeys.Clear();

                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }


        private Command _getMonkeysCommand;
        public ICommand GetMonkeysCommand =>
            _getMonkeysCommand ??= new Command(async () => await GetMonkeysAsync());
    }
}
