using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCentr.Model;
public class Pracovnik : INotifyPropertyChanged
{
    private string _id;
    private string _jmeno;
    private string _prijmeni;
    private string _telefon;
    private Pobocka _pobocka;
    private string _user;


    public Pracovnik()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id
    {
        get { return _id; }
        set { _id = value; OnPropertyChanged(nameof(Id)); }
    }

    public string Jmeno
    {
        get { return _jmeno; }
        set { _jmeno = value; OnPropertyChanged(nameof(Jmeno)); }
    }

    public string Prijmeni
    {
        get { return _prijmeni; }
        set { _prijmeni = value; OnPropertyChanged(nameof(Prijmeni)); }
    }

    public string Telefon
    {
        get { return _telefon; }
        set { _telefon = value; OnPropertyChanged(nameof(Telefon)); }
    }

    [JsonProperty("pobocka")]
    public Pobocka Pobocka
    {
        get { return _pobocka; }
        set { _pobocka = value; OnPropertyChanged(nameof(Pobocka)); }
    }


    [JsonProperty("id_user")]
    public string User
    {
        get { return _user; }
        set { _user = value; OnPropertyChanged(nameof(User)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public override string ToString()
    {
        return Jmeno + " " + Prijmeni;
    }   
}
