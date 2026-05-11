namespace zad2filenetmaui
{
    public partial class MainPage : ContentPage
    {
        string path = Path.Combine(FileSystem.Current.AppDataDirectory,"dziennik.txt");
        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(path))
            {
                DisplayLabel.Text = File.ReadAllText(path);
            }
        }
        async void OnAppend(object sender,EventArgs e)
        {
            string tresc = $"{System.DateTime.Now.ToString("dd.MM.yyyy HH:mm")} {wpisEditor.Text}\n";
            await File.AppendAllTextAsync(path,tresc);
            DisplayLabel.Text = await File.ReadAllTextAsync(path);
        }
        async void OnClear(object sender,EventArgs e)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            DisplayLabel.Text = "";
        }
       
    }
}
/*
 **********************************************************************
 nazwa          OnAppend
opis            funkcja dodaje tekst z kontrolki Entry do pliku dziennik.txt

parametry       object sender, EventArgs e
opis            sender: obiekt wywołujący funkcję , e : Szczegóły dotyczące wywołania funkcji

zwracany typ    brak

***********************************************************************
nazwa          OnClear
opis            funkcja usuwa plik dziennik.txt jeśli istnieje

parametry       object sender, EventArgs e
opis            sender: obiekt wywołujący funkcję , e : Szczegóły dotyczące wywołania funkcji

zwracany typ    brak

***********************************************************************
 */