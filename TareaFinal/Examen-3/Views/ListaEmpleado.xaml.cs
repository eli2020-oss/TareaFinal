using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaFinal.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPagos : ContentPage
    {
        public ListaPagos()
        {
            InitializeComponent();
        }

        private async void ListaPrecios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Empleado item = (Models.Empleado)e.Item;
          /// await DisplayAlert("Elemento Tocado " , "Descripcion: " + item.Descripcion, "Ok");

            var page = new ModificarEmpleados();
           page.BindingContext = item;
           await Navigation.PushModalAsync(page);
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaPagos());
        }
    }
    

}