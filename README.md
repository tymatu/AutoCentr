# AutoCentr — Aplikace pro evidenci zákazníků autoservisu

## Popis

**AutoCentr** je WPF desktopová aplikace navržená pro správu zákazníků autoservisu. Umožňuje přidávat nové zákazníky, přiřazovat k nim pracovníky, evidovat informace o vozidlech, zakazníků. Aplikace je postavena na architektuře **MVVM (Model-View-ViewModel)** s využitím datových vazeb (Data Binding) a příkazů (ICommand). RelayCommand pro implementaci příkazů a ObservableCollection pro seznamy zákazníků a pracovníků.


---
### Architektura Auto Centra

## Dependencies
nahrádně:
+ Microsoft.Extensions.DependencyInjetion(9.0.4)
+ Newtonsoft.json (13.0.3)

### DataBase 
- JsonDataReader.cs - načítání json souborů
- Opravy.json
- Users.json
- Zakazniky.json

### Model
- Oprava.cs - model opravy
- Pobocka.cs - model pobočky
- Pracovnik.cs - model pracovnika
- User.cs - model user-a
- Zakaznik.cs - model zakaznika

### ModelView
- ButtonClick.cs
- LoginVM.cs 
- MainWindowVM.cs  
- OpravaVM.cs 
- PracovnikyVM.cs  
- ProfileVM.cs 
- ViewModelBase.cs  
- ZakaznikyVM.cs 

### Util
- BoolVisibility.cs - převádí bool hodnotu na System.Windows.Visibility pomoci IValueConventer

### View
-LoginView.xaml
  -LoginView.xaml.cs
-Menu.xaml
  -Menu.xaml.cs
-OpravyView.xaml
  OpravyView.xaml.cs
-PracovnikyView.xaml
  -PracovnikyView.xaml.cs
-ProfileView.xaml
  -ProfileView.xaml.cs
-ZakaznikyView.xaml
  -ZakaznikyView.xaml.cs


## Zbyvající třidy 
- App.xaml
  -App.xaml.cs
-MainWindow.xaml
  -MainWindow.xaml.cs






