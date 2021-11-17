using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTest.Entity;

namespace XamarinTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Historico : ContentPage
    {
        List<Operacion> ListHistorico = new List<Operacion>();
        public Historico(List<Operacion> ListHistorico)
        {
            InitializeComponent();
            Lista.ItemsSource = ListHistorico;
        }
        

    }
}