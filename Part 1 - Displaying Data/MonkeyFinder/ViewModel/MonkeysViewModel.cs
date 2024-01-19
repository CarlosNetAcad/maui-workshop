﻿using MonkeyFinder.Interfaces.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    IMonkeyService monkeyService;

    public ObservableCollection<Monkey> Monkeys { get; set; }

    public MonkeysViewModel(
        string title,
        IMonkeyService monkeyService
    ) : base(title)
    {
        this.monkeyService = monkeyService;

    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;

            var monkeysList = await monkeyService.GetMonkeys();

            if (Monkeys?.Count != 0) Monkeys.Clear();

            foreach (var monkey in monkeysList)
                Monkeys.Add(monkey);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);

            await Shell.Current.DisplayAlert("Error!","Unable to get monkeys.", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
