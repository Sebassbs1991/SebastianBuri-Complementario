using SebastianBuriComplementario.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SebastianBuriComplementario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        public static IEnumerable<Estudiante>SELECT_WHERE(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario=? and Contrasena=?", usuario, contrasena);

        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {


                var databasepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasepath);

                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUser.Text, txtPass.Text);
                if (resultado.Count() > 0)
                {
                    string nombre = txtUser.Text;
                    Navigation.PushAsync(new RegistrarDatos(nombre));
                }
                else
                {
                    DisplayAlert("Alerta", "Datos erroneos", "ok");
                }

            }
            catch(Exception ex)
            {

            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());

        }
    }
}