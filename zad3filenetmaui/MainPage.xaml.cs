

namespace zad3filenetmaui
{
    public partial class MainPage : ContentPage
    {
        List<Plik> pliki = new List<Plik>();
        public MainPage()
        {
            InitializeComponent();
            
            
            NapiszPliki();
            odswiezPliki();
            

            
        }
        
        public async void NapiszPliki()
        {
            for (int i = 1; i <= 5; i++)
            {
                string path = Path.Combine(FileSystem.Current.AppDataDirectory, $"Tekst{i}.txt");
                string tresc = $"Treść Pliku {i}";
                await File.WriteAllTextAsync(path, tresc);
            }
            
        }
        public void odswiezPliki()
        {
            string katalog = FileSystem.Current.AppDataDirectory;
            
            string []sciezki = Directory.GetFiles(katalog);
            pliki = new List<Plik>();
            foreach (string sciezka in sciezki)
            {
                string nazwaPliku = Path.GetFileName(sciezka);

                long rozmiar = new FileInfo(sciezka).Length;

                var nowyPlik = new Plik
                {
                    sciezkaPliku = sciezka,
                    Nazwa = nazwaPliku,
                    Rozmiar = rozmiar
                };
                pliki.Add(nowyPlik);
            }
            Lista.ItemsSource = pliki;
            long lacznyRozmiar = 0;
            foreach (Plik plik in pliki) lacznyRozmiar += plik.Rozmiar;
            countLabel.Text = $"Ilość plików: {pliki.Count} Łączny rozmiar: {lacznyRozmiar} kB";
        }
        public async void OnPlikSelected(object sender ,SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is not Plik plik)
                return;
            Lista.SelectedItem = null;
            string tresc = await File.ReadAllTextAsync(plik.sciezkaPliku) ;

            await DisplayAlert(plik.Nazwa,tresc,"zamknij");

        }
        public async void OnUsunClick(object sender,EventArgs e)
        {
            Button button = (Button)sender;
            if(button?.CommandParameter is Plik plik)
            {
                bool potw = await DisplayAlert("Uwaga", $"Czy chcec usunąć {plik.Nazwa}?","Tak","Nie");
                if (potw)
                {
                    File.Delete(plik.sciezkaPliku);
                }
            }


            odswiezPliki();

        }
    }
}
/*
 **********************************************************************
 nazwa          NapiszPliki
opis            funkcja pisze początkowe pliki i wrzuca do nich krótki tekst

parametry       object sender, EventArgs e
opis            sender: obiekt wywołujący funkcję , e : Szczegóły dotyczące wywołania funkcji

zwracany typ    brak

***********************************************************************
nazwa          odswiezPliki
opis            funkcja odświeża całą Listę plików po każdej operacji

parametry       object sender, EventArgs e
opis            sender: obiekt wywołujący funkcję , e : Szczegóły dotyczące wywołania funkcji

zwracany typ    brak

***********************************************************************
 nazwa          OnPlikSelected
opis            funkcja pobiera treść klikniętego pliku po czym wyświetla go w alercie

parametry       object sender, EventArgs e
opis            sender: obiekt wywołujący funkcję , e : Szczegóły dotyczące wywołania funkcji , umożliwia pobranie tylko poszczególnego elementu

zwracany typ    brak

***********************************************************************
nazwa          OnUsunClick
opis            funkcja usuwa poszczególny plik obok którego znajdywał się kliknięty przycisk

parametry       object sender, EventArgs e
opis            sender: obiekt wywołujący funkcję , e : Szczegóły dotyczące wywołania funkcji

zwracany typ    brak

***********************************************************************
 */
