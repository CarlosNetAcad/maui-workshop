namespace MonkeyFinder.ViewModel;

[INotifyPropertyChanged]
public partial class BaseViewModel
{
    #region Flds

    /// <summary>
    /// State to set the changes of the properties.
    /// </summary>
    bool isBusy;

    /// <summary>
    /// Title of the UI interface.
    /// </summary>
    string title;

    /// <summary>
    /// INotifyPropertChanged implementation.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion Fdls

    #region Props

    /// <summary>
    /// State to set the oposite of isBusy.
    /// </summary>
    //public bool IsNotBusy => !IsBusy;

    #endregion Props

    #region Ctors

    public BaseViewModel()
    {

    }
    #endregion

    #region privates_fn
    #endregion privates_fn

    #region protected_fn   
    #endregion

    #region public_fn
    #endregion

}
