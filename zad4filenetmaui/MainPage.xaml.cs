using System.Diagnostics;
using System.Threading.Tasks;

namespace zad4filenetmaui
{
    public partial class MainPage : ContentPage
    {
        string path = Path.Combine(FileSystem.Current.AppDataDirectory, "notatki_eksport.txt");
        string lastActPath = Path.Combine(FileSystem.Current.AppDataDirectory, "ostatnia_akcja.txt");
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnExport(object sender,EventArgs e)
        {
            string tekst = expEditor.Text;
            string data = (System.DateTime.Today).ToString();
            List<string> notatki = tekst
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                .ToList();
            await File.WriteAllTextAsync(path,data);
            foreach(string notatka in notatki)
            {
                await File.AppendAllTextAsync(path,notatka);
            }

            await File.WriteAllTextAsync(lastActPath, (System.DateTime.Today).ToString());
        }
        async public void OnImport(object sender,EventArgs e)
        {
            try
            {
                var wynik = await FilePicker.Default.PickAsync();
                if (wynik != null)
                {
                    string nazwaPliku = wynik.FileName;
                    string sciezka = wynik.FullPath;
                    using var strumien = await wynik.OpenReadAsync();

                    using var czytnik = new StreamReader(strumien);

                    string tresc = await czytnik.ReadToEndAsync();
                    await DisplayAlert("Wybrano plik", $"Nazwa: {nazwaPliku}", "OK");
                    expEditor.Text = tresc;
                    Debug.WriteLine(tresc);

                    await File.WriteAllTextAsync(lastActPath, (System.DateTime.Today).ToString());
                }

                

            }

            catch (Exception ex)

            {

                await DisplayAlert("Błąd", $"Nie udało się wybrać pliku: {ex.Message}", "OK");

            }


            
        }
        

    }
}
