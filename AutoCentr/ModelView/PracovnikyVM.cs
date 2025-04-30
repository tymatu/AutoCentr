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

public class PracovnikyVM : ViewModelBase
{
    private ObservableCollection<Pracovnik> _pracovniky;
    private Pracovnik? _selectedPrac;
    private Pracovnik _dataPrac;
    private ObservableCollection<Pobocka> _pobocky;
    private Pobocka _selectedPobocka;
    private ObservableCollection<Zakaznik> _zakazniky;
    private List<User> users = new List<User>();
    private Pracovnik _lastPrac;
    private string? _username;

    public ICommand SaveCommand { get; }
    public ICommand ClearCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand RemoveCommand { get; }

    public ObservableCollection<Pracovnik> Pracovniky
    {
        get { return _pracovniky; }
        set
        {
            _pracovniky = value;
            OnPropertyChanged(nameof(Pracovniky));
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
    public Pracovnik? SelectedPrac
    {
        get { return _selectedPrac; }
        set
        {
            if (_selectedPrac != value && value != null)
            {
                if (_lastPrac != null)
                {
                    _lastPrac.Pobocka = SelectedPobocka;
                }
                _selectedPrac = value;
                SelectedPobocka = value.Pobocka;
                _lastPrac = value;
                DataPrac = value;
                Zakazniky = new ObservableCollection<Zakaznik>(JsonDataReader.ReadZakaznikByPracovnikId(value.Id));
                OnPropertyChanged(nameof(SelectedPrac));
            }
        }
    }
    public Pracovnik? DataPrac
    {
        get { return _dataPrac; }
        set
        {
            if (_dataPrac != value)
            {
                _dataPrac = value;
                OnPropertyChanged(nameof(DataPrac));
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

    public PracovnikyVM()
    {
        RemoveCommand = new ButtonClick(ExecuteRemove, CanExecuteRemove);
        AddCommand = new ButtonClick(ExecuteSave, CanExecuteSave);
        ClearCommand = new ButtonClick(ExecuteClear);
        SaveCommand = new ButtonClick(ExecuteUlozit);



        var p = JsonDataReader.ReadPracovniky();
        Pracovniky = new ObservableCollection<Pracovnik>(p);

        DataPrac = new Pracovnik();
        Pobocky = new ObservableCollection<Pobocka>(EnumHelper.GetEnumValues<Pobocka>());
    }

    private void ExecuteUlozit(object obj)
    {

        JsonDataReader.SavePracovnikyAndUsers(Pracovniky.ToList(), users);

    }

    private void ExecuteClear(object obj)
    {
        SelectedPrac = null;
        DataPrac = new Pracovnik();
        Pracovniky = new ObservableCollection<Pracovnik>();
        Username = "";
    }

    private bool CanExecuteSave(object arg)
    {
        return SelectedPrac == null
               && DataPrac != null
               && !string.IsNullOrEmpty(DataPrac.Jmeno)
               && !string.IsNullOrEmpty(DataPrac.Prijmeni)
               && !string.IsNullOrEmpty(DataPrac.Telefon)
               && !string.IsNullOrEmpty(Username);
    }

    private void ExecuteSave(object obj)
    {

        User usr = new User();
        usr.Username = Username;
        usr.Password = "1234";
        users.Add(usr);
        DataPrac.Pobocka = SelectedPobocka;
        DataPrac.User = usr.Id;
        Pracovniky.Add(DataPrac);
        ExecuteClear(null);
    }

    private bool CanExecuteRemove(object arg)
    {
        return SelectedPrac != null;
    }

    private void ExecuteRemove(object obj)
    {
        Pracovniky.Remove(SelectedPrac);
    }
}
