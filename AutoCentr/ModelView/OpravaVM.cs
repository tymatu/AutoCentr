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
public class OpravaVM : ViewModelBase
{
    private ObservableCollection<Oprava> _opravy;
    public ObservableCollection<Oprava> Opravy
    {
        get { return _opravy; }
        set
        {

            _opravy = value;
            OnPropertyChanged(nameof(Opravy));
        }
    }

    private Oprava? _selectedOprava;
    public Oprava? SelectedOprava
    {
        get { return _selectedOprava; }
        set
        {
            if (value != null)
            {
                SelectedZak = Zakazniky.FirstOrDefault(p => p.Id == value.Zakaznik);
                OpravaData = new Oprava();
                OpravaData.Nazev = value.Nazev;
                OpravaData.Datum = value.Datum;
                OpravaData.Cena = value.Cena;
            }
            _selectedOprava = value;
            OnPropertyChanged(nameof(SelectedOprava));
        }
    }

    private ObservableCollection<Zakaznik> _zakazniky;
    public ObservableCollection<Zakaznik> Zakazniky
    {
        get { return _zakazniky; }
        set
        {
            _zakazniky = value;
            OnPropertyChanged(nameof(Zakazniky));
        }
    }

    private Zakaznik _selectedZak;
    public Zakaznik SelectedZak
    {
        get { return _selectedZak; }
        set
        {
            _selectedZak = value;
            OnPropertyChanged(nameof(SelectedZak));
        }
    }

    private Oprava? _opravaData;
    public Oprava? OpravaData
    {
        get { return _opravaData; }
        set
        {
            _opravaData = value;
            OnPropertyChanged(nameof(OpravaData));
        }
    }

    public ICommand ClearCommand { get; set; }
    public ICommand AddCommand { get; set; }
    public ICommand RemoveCommand { get; set; }
    public ICommand SaveCommand { get; set; }

    public OpravaVM()
    {
        RemoveCommand = new ButtonClick(ExecuteRemove, CanExecuteRemove);
        AddCommand = new ButtonClick(ExecuteSave, CanExecuteSave);
        ClearCommand = new ButtonClick(ExecuteClear);
        SaveCommand = new ButtonClick(ExecuteUlozit);

        Opravy = new ObservableCollection<Oprava>(JsonDataReader.ReadOpravy());
        Zakazniky = new ObservableCollection<Zakaznik>(JsonDataReader.ReadZakazniky());

        OpravaData = new Oprava();
    }

    private void ExecuteUlozit(object obj)
    {
        JsonDataReader.SaveOpravy(Opravy.ToList());
    }

    private void ExecuteClear(object obj)
    {
        OpravaData = new Oprava();
        SelectedOprava = null;
    }

    private bool CanExecuteSave(object arg)
    {
        return SelectedOprava == null && OpravaData != null
               && !string.IsNullOrWhiteSpace(OpravaData.Nazev)
               && !string.IsNullOrWhiteSpace(OpravaData.Cena);

    }

    private void ExecuteSave(object obj)
    {
        Oprava op = OpravaData;
        op.Datum = DateTime.Now;
        op.Zakaznik = SelectedZak.Id;
        Opravy.Add(op);
    }

    private bool CanExecuteRemove(object arg)
    {
        return SelectedOprava != null;
    }

    private void ExecuteRemove(object obj)
    {
        Opravy.Remove(SelectedOprava);
    }
}
