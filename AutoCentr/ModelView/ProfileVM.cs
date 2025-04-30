using AutoCentr.DataBase;
using AutoCentr.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoCentr.ModelView;
public class ProfileVM : ViewModelBase
{
    private Pracovnik? _selectedPrac;
    private ObservableCollection<Pobocka> _pobocky;
    private string? _username;
    private Pobocka _selectedPobocka;
    private ObservableCollection<Zakaznik> _zakazniky;
    private string? _password;
    private List<User> users = new List<User>();
    private List<Pracovnik> pracovniky;
    private User _user;

    public Pracovnik? SelectedPrac
    {
        get { return _selectedPrac; }
        set
        {
            if (_selectedPrac != value && value != null)
            {
                _selectedPrac = value;
                SelectedPobocka = value.Pobocka;
                Zakazniky = new ObservableCollection<Zakaznik>(JsonDataReader.ReadZakaznikByPracovnikId(value.Id));
                OnPropertyChanged(nameof(SelectedPrac));
            }
        }
    }
    public string? Username
    {
        get { return _username; }
        set
        {
            if (_username != value)
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
    }
    public string? Password
    {
        get { return _password; }
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }
    public Pobocka SelectedPobocka
    {
        get { return _selectedPobocka; }
        set
        {
            if (_selectedPobocka != value)
            {
                _selectedPobocka = value;
                OnPropertyChanged(nameof(SelectedPobocka));
            }
        }
    }
    public ObservableCollection<Pobocka> Pobocky
    {
        get { return _pobocky; }
        set
        {
            _pobocky = value;
            OnPropertyChanged(nameof(Pobocky));
        }
    }
    public ObservableCollection<Zakaznik> Zakazniky
    {
        get { return _zakazniky; }
        set
        {
            _zakazniky = value;
            OnPropertyChanged(nameof(Zakazniky));
        }
    }

    public ProfileVM(string id)
    {
        SaveCommand = new ButtonClick(ExecuteUlozit);
        pracovniky = JsonDataReader.ReadPracovniky();
        SelectedPrac = pracovniky.First(l => l.Id == id);
        Zakazniky = new ObservableCollection<Zakaznik>(JsonDataReader.ReadZakaznikByPracovnikId(SelectedPrac.Id));
        Pobocky = new ObservableCollection<Pobocka>(EnumHelper.GetEnumValues<Pobocka>());
        SelectedPobocka = SelectedPrac.Pobocka;
        users = JsonDataReader.ReadUsers();
        _user = users.First(u => u.Id == id);
        Password = _user.Password;
        Username = _user.Username;
    }

    private void ExecuteUlozit(object obj)
    {
        _user.Username = Username;
        _user.Password = Password;
        SelectedPrac.Pobocka = SelectedPobocka;
        JsonDataReader.SaveProfile(pracovniky, users);
    }

    public ICommand SaveCommand { get; set; }
}
