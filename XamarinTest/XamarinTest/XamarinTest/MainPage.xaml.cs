using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinTest.Entity;

namespace XamarinTest
{
    public partial class MainPage : ContentPage
    {
        List<TipoOperacion> ListOperaciones;
        List<Operacion> Historico;
        public double result = 0;
        public double num1 = 0;
        public double num2 = 0;
        public double sum = 0;
        public MainPage()
        {
            InitializeComponent();
            InitApp();
        }

        private void InitApp()
        {
            Historico = new List<Operacion>();
            ListOperaciones = new List<TipoOperacion>();
            ListOperaciones.Add(new TipoOperacion { id = 1, nombre = "Suma" });
            ListOperaciones.Add(new TipoOperacion { id = 2, nombre = "Resta" });
            ListOperaciones.Add(new TipoOperacion { id = 3, nombre = "Multiplicacion" });
            ListOperaciones.Add(new TipoOperacion { id = 4, nombre = "Division" });
            ListOperaciones.Add(new TipoOperacion { id = 5, nombre = "Promedio" });
            ListOperaciones.Add(new TipoOperacion { id = 6, nombre = "Elevar" });
            foreach (var item in ListOperaciones)
            {
                pickerOperacion.Items.Add(item.nombre);
            }
            pickerOperacion.SelectedIndex = 0;
        }

        private void Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(numero1.Text) && !string.IsNullOrEmpty(numero2.Text) && pickerOperacion.SelectedIndex >= 0)
                {
                    Operacion operacion = new Operacion();
                    num1 = double.Parse(numero1.Text);
                    num2 = double.Parse(numero2.Text);
                    switch (pickerOperacion.SelectedIndex)
                    {
                        // Suma
                        case 0:
                            result = num1 + num2;
                            operacion.simbolo = "+";
                            llenarObjeto(operacion);
                            break;
                        // Resta
                        case 1:
                            result = num1 - num2;
                            operacion.simbolo = "-";
                            llenarObjeto(operacion);
                            break;
                        // Multiplicacion
                        case 2:
                            result = num1 * num2;
                            operacion.simbolo = "*";
                            llenarObjeto(operacion);
                            break;
                        // Division
                        case 3:
                            result = num1 / num2;
                            operacion.simbolo = "/";
                            llenarObjeto(operacion);
                            break;
                        // Promedio
                        case 4:
                            sum = 0;
                            sum = num1 + num2;
                            result = sum / 2;
                            operacion.num1 = sum;
                            operacion.resultado = result;
                            break;
                        // Elevar
                        case 5:
                            result = Math.Pow(num1, num2);
                            llenarObjeto(operacion);
                            operacion.simbolo = "^";
                            break;
                    }
                    operacion.TipoOperacion.nombre = (string)pickerOperacion.SelectedItem;
                    Historico.Add(operacion);
                    resultado.Text = result.ToString();
                }
                else
                {
                    DisplayAlert("Campos vacios", "Debe llenar los campos para realizar la operacion", "Vale");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Ha ocurrido un error, por favor comuniquese con la persona a cargo", "Ok");
            }
        }

        private void llenarObjeto(Operacion operacion)
        {
            try
            {
                operacion.num1 = (int)num1;
                operacion.num2 = (int)num2;
                operacion.resultado = result;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Ha ocurrido un error, por favor comuniquese con la persona a cargo", "Ok");
            }
            
        }

       private void clickedHistory(object sender, EventArgs e)
       {
            this.Navigation.PushModalAsync(new Historico(Historico));
       }


    }
}
