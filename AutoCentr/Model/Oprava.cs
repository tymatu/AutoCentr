using Newtonsoft.Json;
using System.ComponentModel;


namespace AutoCentr.Model
{
    public class Oprava : INotifyPropertyChanged
    {

        private string _id;
        [JsonProperty("id")]
        public string Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public Oprava()
        {
            Id = Guid.NewGuid().ToString();
        }


        private string _nazev;
        [JsonProperty("nazev")]
        public string Nazev
        {
            get { return _nazev; }
            set
            {
                if (_nazev != value)
                {
                    _nazev = value;
                    OnPropertyChanged(nameof(Nazev));
                }
            }
        }

        private string _cena;
        [JsonProperty("cena")]
        public string Cena
        {
            get { return _cena; }
            set
            {
                if (_cena != value)
                {
                    _cena = value;
                    OnPropertyChanged(nameof(Cena));
                }
            }
        }


        private string _zakaznik;
        [JsonProperty("zakaznik")]
        public string Zakaznik
        {
            get { return _zakaznik; }
            set
            {
                if (_zakaznik != value)
                {
                    _zakaznik = value;
                    OnPropertyChanged(nameof(Zakaznik));
                }
            }
        }

        private DateTime _datum;
        [JsonProperty("datum")]
        public DateTime Datum
        {
            get { return _datum; }
            set
            {
                if (_datum != value)
                {
                    _datum = value;
                    OnPropertyChanged(nameof(Datum));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
