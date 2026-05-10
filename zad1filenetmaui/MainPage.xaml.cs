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
