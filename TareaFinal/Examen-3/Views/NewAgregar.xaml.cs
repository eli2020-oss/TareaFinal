using Examen_3.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaAgregar : ContentPage
    {
        public VistaAgregar()
        {
            InitializeComponent();
        }

      

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaPagos());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        
    }
}