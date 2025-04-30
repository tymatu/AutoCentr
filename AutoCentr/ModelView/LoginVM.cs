using AutoCentr.DataBase;
using AutoCentr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoCentr.ModelView;

public class LoginVM : ViewModelBase
{

    private string? _username;
    private string? _password;
    private string? _errorMsg;
    private MainWindowVM _main;
    public ICommand LoginCommand { get; }


    public LoginVM(MainWindowVM mainvm)
    {
        _main = mainvm;
        LoginCommand = new ButtonClick(ExecuteMyCommand, CanExecuteMyCommand);
    }

    private void ExecuteMyCommand(object parameter)
    {

        User? usr = JsonDataReader.GetUser(UserName, Password);
        if (usr != null)
        {
            ErrorMsg = "";
            _main.AuthSuces(usr);
        }
        else
        {
            ErrorMsg = "* Nesprávně zadané heslo nebo přihlašovací jméno";
        }

    }

    private bool CanExecuteMyCommand(object parameter)
    {
        if (string.IsNullOrWhiteSpace(UserName) || UserName.Length < 2 ||
            Password == null || Password.Length < 2)
        {

            return false;

        }
        return true;
    }
    public string? ErrorMsg
    {
        get
        {
            return _errorMsg;
        }

        set
        {
            _errorMsg = value;
            OnPropertyChanged(nameof(ErrorMsg));
        }
    }

    public string? UserName
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(UserName));
        }
    }

    public string? Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

}