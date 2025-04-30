using AutoCentr.Model;
using System.Windows.Input;
using AutoCentr.View;
using Microsoft.Extensions.DependencyInjection;
using Menu = AutoCentr.View.Menu;

namespace AutoCentr.ModelView;


public class MainWindowVM : ViewModelBase
{
    private IServiceProvider _provider;
    private object _currentView;
    private bool _unAuth;
    private User _user;

    public object CurrentView
    {
        get { return _currentView; }
        set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
    }
    public bool UnAuth
    {
        get
        {
            return _unAuth;
        }

        set
        {
            _unAuth = value;
            OnPropertyChanged(nameof(UnAuth));
        }
    }

    public ICommand InfoCommand { get; }
    public ICommand OdhlasitCommand { get; }
    public ICommand ZakaznikyCommand { get; }
    public ICommand PracovnikyCommand { get; }
    public ICommand OpravyCommand { get; }
    public ICommand ProfileCommand { get; }
    public void Login(object? obj)
    {
        CurrentView = new LoginView(new LoginVM(this));
    }

    public MainWindowVM(IServiceProvider provider)
    {
        UnAuth = true;
        _provider = provider;
        Login(null);
        InfoCommand = new ButtonClick(InfoExec);
        OdhlasitCommand = new ButtonClick(OdhlasitExec);
        ZakaznikyCommand = new ButtonClick(ZakaznikExec);
        PracovnikyCommand = new ButtonClick(PracovnikyExec);
        OpravyCommand = new ButtonClick(OpravyExec);
        ProfileCommand = new ButtonClick(ProfileExec);
    }

    private void ProfileExec(object obj)
    {
        CurrentView = new ProfileView(new ProfileVM(_user.Id));
    }

    private void OpravyExec(object obj)
    {
        CurrentView = _provider.GetRequiredService<OpravyView>();
    }

    private void PracovnikyExec(object obj)
    {
        CurrentView = _provider.GetRequiredService<PracovnikyView>();
    }

    private void ZakaznikExec(object obj)
    {
        CurrentView = _provider.GetRequiredService<ZakaznikyView>();
    }

    private void OdhlasitExec(object obj)
    {
        UnAuth = true;
        Login(null);
    }

    private void InfoExec(object obj)
    {
        CurrentView = _provider.GetRequiredService<Menu>();
    }

    public void AuthSuces(User user)
    {
        UnAuth = false;
        _user = user;
        CurrentView = _provider.GetRequiredService<Menu>();
    }
}
