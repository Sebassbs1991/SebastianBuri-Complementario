using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace SebastianBuriComplementario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resumen : ContentPage
    {

    
    private const string Url = "http://192.168.200.13/cursos/post.php";
    private readonly HttpClient client = new HttpClient();
    private ObservableCollection<SebastianBuriComplementario.Datos> _post;


    
        public Resumen()
        {
            InitializeComponent();
            
            get();
        }


        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<SebastianBuriComplementario.Datos> posts = JsonConvert.DeserializeObject<List<SebastianBuriComplementario.Datos>>(content);
                _post = new ObservableCollection<SebastianBuriComplementario.Datos>(posts);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "ERROR" + ex.Message, "OK");
            }
        }

        
    }
}