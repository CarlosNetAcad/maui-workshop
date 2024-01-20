using MonkeyFinder.Interfaces.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    #region Flds

    /// <summary>
    /// Monkey service.
    /// </summary>
    /// 
    IMonkeyService monkeyService;
    #endregion

    #region Props

    /// <summary>
    /// MonkeyList
    /// </summary>
    public ObservableCollection<Monkey> Monkeys { get; set; } = new ();

    #endregion

    #region Ctors

    /// <summary>
    /// Main Ctor.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="monkeyService"></param>
    public MonkeysViewModel(
        string title,
        IMonkeyService monkeyService
    ) : base(title)
    {
        this.monkeyService = monkeyService;

    }

    #endregion

    #region Cmds

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;

            var monkeysList = await this.monkeyService.GetMonkeys();

            if (Monkeys?.Count > 0) Monkeys?.Clear();

            foreach (var monkey in monkeysList)
                Monkeys.Add(monkey);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);

            await Shell.Current.DisplayAlert("Error!",ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GoToDetailAsync(Monkey monkey)
    {
        if (monkey is null) return;

        await Shell.Current.GoToAsync(
            $"{nameof(DetailsPage)}",
            true,
            new Dictionary<string, object> { { "Monkey", monkey} }
            );

    }
    #endregion
}
