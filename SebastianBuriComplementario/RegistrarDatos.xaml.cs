using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SebastianBuriComplementario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarDatos : ContentPage
    {
        public RegistrarDatos(string nombre)
        {
            InitializeComponent();
            lblUser.Text = $"Usuario Conectado: {nombre}";
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            double costo = 1800;
            string nombre = txtNombre.Text;
            double monto = Convert.ToDouble(txtMonto.Text);
            double total;

            total = (costo - monto) / 3;
            double total2 = total + 90;

            txtTotal.Text = total2.ToString();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("montoInicial", txtMonto.Text);
                parametros.Add("pagoMensual", txtTotal.Text);

                cliente.UploadValues("http://192.168.200.13/cursos/post.php", "POST", parametros);
                await DisplayAlert("Alerta", "Ingresado correctamente", "ok");
                //var mensaje = "Dato ingresado con éxito";
               // DependencyService.Get<Mensaje>().LongAlert(mensaje);

                                //Limpiar cajas de texto

                txtNombre.Text = "";
                txtMonto.Text = "";
                txtTotal.Text = "";

               
                await Navigation.PushAsync(new Resumen());


            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error de ingreso", "OK");
            }

        }

        
    }
}
