using System.Threading.Tasks;

namespace zad1filenetmaui
{
    public partial class MainPage : ContentPage
    {
        string path = Path.Combine(FileSystem.Current.AppDataDirectory,"moj_plik.txt");

        public MainPage()
        {
            InitializeComponent();
        }
        public async void OnSaveClick(object sender,EventArgs e)
        {
            string tresc = TekstEntry.Text;
            await File.WriteAllTextAsync(path, tresc);
        }
        public async void OnReadClick(object sender,EventArgs e)
        {
            if (File.Exists(path))
            {
                DisplayLabel.Text = await File.ReadAllTextAsync(path);
            }
            else
            {
                DisplayLabel.Text = "Nie znaleziono pliku";
            }
        }
        
    }
}
/*
 **********************************************************************
 nazwa          OnSaveClick
opis            funkcja zapisuje tekst z kontrolki Entry do pliku moj_plik.txt

parametry       object sender, EventArgs e
opis            sender: obiekt wywołujący funkcję , e : Szczegóły dotyczące wywołania funkcji

zwracany typ    brak

***********************************************************************
nazwa          OnReadClick
opis            funkcja wczytująca zawartość pliku wyświetlająca ją w konsoli

parametry       object sender, EventArgs e
opis            sender: obiekt wywołujący funkcję , e : Szczegóły dotyczące wywołania funkcji

zwracany typ    brak

***********************************************************************
 */
