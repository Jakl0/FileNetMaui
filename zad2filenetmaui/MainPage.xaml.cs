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
