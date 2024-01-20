namespace MonkeyFinder.ViewModel;

[QueryProperty("Monkey", "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    Monkey monkey;

    public MonkeyDetailsViewModel(string title) : base(title)
    {
        
    }
}
