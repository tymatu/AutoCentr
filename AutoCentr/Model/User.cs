using Newtonsoft.Json;
using System;
using System.ComponentModel;


namespace AutoCentr.Model
{
    public class User : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _id;

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        [JsonProperty("id")]



        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        [JsonProperty("username")]
        public string Username
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

        [JsonProperty("password")]
        public string Password
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
