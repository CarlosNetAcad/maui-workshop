namespace MonkeyFinder.ViewModel;

public class BaseViewModel : INotifyPropertyChanged
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
    /// IsBusy property.
    /// </summary>
    public bool IsBusy
    {
        get => isBusy;
        set
        {
            SetField(ref isBusy, value, "IsBusy");
            OnPropertyChanged(nameof(IsBusy));
        }
    }

    /// <summary>
    /// Title property.
    /// </summary>
    public string Title
    {
        get => title;
        set { SetField(ref title, value, "Title"); }
    }

    /// <summary>
    /// State to set the oposite of isBusy.
    /// </summary>
    public bool IsNotBusy => !IsBusy;

    #endregion Props

    #region privates_fn
    #endregion privates_fn

    #region protected_fn

    /// <summary>
    /// Event handler.
    /// </summary>
    /// <param name="propertyName">Field name.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //->Alternative
        //PropertyChangedEventHandler handler = PropertyChanged;
        //if (handler is not null) handler (this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, string propertyName)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;

        field = value;

        OnPropertyChanged(propertyName);

        return true;
    }
    #endregion

    #region public_fn
    #endregion

}
