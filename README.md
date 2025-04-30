# AutoCentr — Aplikace pro evidenci zákazníků autoservisu

## Popis

**AutoCentr** je WPF desktopová aplikace navržená pro správu zákazníků autoservisu. Umožňuje přidávat nové zákazníky, přiřazovat k nim pracovníky, evidovat informace o vozidlech, zakazníků. Aplikace je postavena na architektuře **MVVM (Model-View-ViewModel)** s využitím datových vazeb (Data Binding) a příkazů (ICommand). RelayCommand pro implementaci příkazů a ObservableCollection pro seznamy zákazníků a pracovníků. Data se načítají a deserializujou z JSON souborů.


---
### Architektura Auto Centra

## Dependencies
nahrádně:
+ Microsoft.Extensions.DependencyInjetion(9.0.4)
+ Newtonsoft.json (13.0.3)

### DataBase 
- JsonDataReader.cs - třída pro načítání a deserializaci dat z JSON souborů
- Opravy.json - data o opravách
- Users.json - data uživatelů (přihlašovací údaje)
- Zakazniky.json - data zákazníků

### Model
- Oprava.cs - model opravy
- Pobocka.cs - model pobočky
- Pracovnik.cs - model pracovnika
- User.cs - model user-a
- Zakaznik.cs - model zakaznika

### ModelView
- ButtonClick.cs - pomocná třída pro zpracování příkazů tlačítek
- LoginVM.cs -  logika přihlášení uživatele (ověření, autentizace)
- MainWindowVM.cs - logika hlavního okna, přepínání mezi stránkami
- OpravaVM.cs - správa dat o opravách
- PracovnikyVM.cs -  zobrazení a správa seznamu pracovníků
- ProfileVM.cs - logika uživatelského profilu
- ViewModelBase.cs - základní třída s implementací INotifyPropertyChanged
- ZakaznikyVM.cs - zobrazení a správa zákazníků

### Util
- BoolVisibility.cs - převádí bool hodnotu na System.Windows.Visibility pomoci IValueConventer

### View
- LoginView.xaml
  - LoginView.xaml.cs
- Menu.xaml
  - Menu.xaml.cs
- OpravyView.xaml
  - OpravyView.xaml.cs
-PracovnikyView.xaml
  -PracovnikyView.xaml.cs
- ProfileView.xaml
  - ProfileView.xaml.cs
- ZakaznikyView.xaml
  - ZakaznikyView.xaml.cs


## Zbyvající třidy 
- App.xaml
  -App.xaml.cs
-MainWindow.xaml
  -MainWindow.xaml.cs






