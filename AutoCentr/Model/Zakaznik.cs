using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCentr.Model
{
    public class Zakaznik : INotifyPropertyChanged
    {
        private string _id;
        private string _jmeno;
        private string _prijmeni;
        private DateTime _datumPrijeti;
        private string _detaily;
        private string _informace;
        private string _idPracovnik;
        private string _auto;

        public Zakaznik()
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


        [JsonProperty("auto")]
        public string Auto
        {
            get { return _auto; }
            set { _auto = value; OnPropertyChanged(nameof(Auto)); }
        }

        [JsonProperty("datum_prijeti")]
        public DateTime DatumPrijeti
        {
            get { return _datumPrijeti; }
            set { _datumPrijeti = value; OnPropertyChanged(nameof(DatumPrijeti)); }
        }

        public string Detaily
        {
            get { return _detaily; }
            set { _detaily = value; OnPropertyChanged(nameof(Oprava)); }
        }

        public string Informace
        {
            get { return _informace; }
            set { _informace = value; OnPropertyChanged(nameof(Informace)); }
        }

        [JsonProperty("id_pracovnik")]
        public string IdPracovnik
        {
            get { return _idPracovnik; }
            set { _idPracovnik = value; OnPropertyChanged(nameof(IdPracovnik)); }
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
}