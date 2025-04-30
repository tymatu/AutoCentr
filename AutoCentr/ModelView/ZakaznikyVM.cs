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


public class ZakaznikyVM : ViewModelBase
{
    private ObservableCollection<Zakaznik> _zakazniky;
    private Zakaznik? _selectedZak;
    private Pracovnik _selectedPrac;
    private ObservableCollection<Pracovnik> _pracovniky;
    private Zakaznik _zakaznikData;
    private Zakaznik? _lastZakaznik;

    public ICommand SaveCommand { get; }
    public ICommand ClearCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand RemoveCommand { get; }
    public Zakaznik? SelectedZak
    {
        get { return _selectedZak; }
        set
        {
            if (_selectedZak != value)
            {
                if (_lastZakaznik != null && SelectedPrac != null)
                {
                    _lastZakaznik.IdPracovnik = SelectedPrac.Id;
                }
                _selectedZak = value;
                if (value != null)
                {
                    SelectedPrac = Pracovniky.First(l => l.Id == value.IdPracovnik);
                    ZakaznikData = value;
                    _lastZakaznik = value;
                }

                OnPropertyChanged(nameof(SelectedZak));
            }
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


    public Pracovnik? SelectedPrac
    {
        get { return _selectedPrac; }
        set
        {
            if (_selectedPrac != value)
            {
                _selectedPrac = value;
                OnPropertyChanged(nameof(SelectedPrac));
            }
        }
    }


    public Zakaznik? ZakaznikData
    {
        get { return _zakaznikData; }
        set
        {
            if (_zakaznikData != value)
            {
                _zakaznikData = value;
                OnPropertyChanged(nameof(ZakaznikData));
            }
        }
    }
    public ObservableCollection<Pracovnik> Pracovniky
    {
        get { return _pracovniky; }
        set
        {
            _pracovniky = value;
            OnPropertyChanged(nameof(Pracovniky));
        }
    }

    public ZakaznikyVM()
    {
        Zakazniky = new ObservableCollection<Zakaznik>();
        Pracovniky = new ObservableCollection<Pracovnik>();
        ZakaznikData = new Zakaznik();
        var p = JsonDataReader.ReadZakazniky();
        var l = JsonDataReader.ReadPracovniky();
        foreach (var zak in p)
        {
            Zakazniky.Add(zak);
        }
        foreach (var prac in l)
        {
            Pracovniky.Add(prac);
        }
        RemoveCommand = new ButtonClick(ExecuteRemove, CanExecuteRemove);
        AddCommand = new ButtonClick(ExecuteSave, CanExecuteSave);
        ClearCommand = new ButtonClick(ExecuteClear);
        SaveCommand = new ButtonClick(ExecuteUlozit);
    }

    private void ExecuteUlozit(object obj)
    {
        List<Zakaznik> zak = new List<Zakaznik>();
        foreach (var v in Zakazniky)
        {
            zak.Add(v);
        }
        JsonDataReader.SaveZakazniky(zak);
    }


    private void ExecuteClear(object obj)
    {
        ZakaznikData = new Zakaznik();
        SelectedZak = null;
    }

    private void ExecuteSave(object obj)
    {
        Zakaznik zak = ZakaznikData;
        zak.DatumPrijeti = DateTime.Now;
        zak.IdPracovnik = SelectedPrac.Id;
        Zakazniky.Add(zak);
        ExecuteClear(null);
    }

    private bool CanExecuteSave(object arg)
    {
        return SelectedZak == null
               && ZakaznikData != null
               && SelectedPrac != null
               && !string.IsNullOrWhiteSpace(ZakaznikData.Jmeno)
               && !string.IsNullOrWhiteSpace(ZakaznikData.Prijmeni);
    }

    private void ExecuteRemove(object obj)
    {
        Zakazniky.Remove(SelectedZak);
        ZakaznikData = new Zakaznik();
        SelectedZak = null;
    }

    private bool CanExecuteRemove(object arg)
    {
        return SelectedZak != null;
    }
}
