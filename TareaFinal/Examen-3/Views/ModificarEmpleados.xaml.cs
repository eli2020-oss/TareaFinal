using Examen_3;
using Examen_3.Models;
using Examen_3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModificarEmpleados : ContentPage
    {
        public ModificarEmpleados()
        {
            InitializeComponent();
        }
        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var _pagos = new Examen_3.Models.Empleado
            {

                //Id_pago = Convert.ToInt32(this.idpago.Text),
                //Descripcion = this.description.Text,
                //Monto = Convert.ToDouble(this.monto.Text),
                //Fecha = this.DueDate.Date,
                Id_empleado = Convert.ToInt32(txtidempleado.Text),
                Nombre = txtnombre.Text,
                Apellido = txtapellido.Text,
                Edad = txtedad.Text,
                Direccion = txtdireccion.Text,
                Puesto = txtpuesto.Text







            };

            if (await App.BaseDatos.deleteAsync(_pagos) != 0)
            {
                var mensaje = await DisplayAlert("Eliminar", "Desea Eliminar", "Si", "No");

                if (mensaje)
                {
                    await DisplayAlert("Alerta", "Empleado Eliminado Correctamente!!", "OK");
                    await Navigation.PushModalAsync(new ListaPagos());
                }
            }




            else
                await DisplayAlert("Eliminar Empleado", "Error al Eliminar !!", "Ok");
            //await DisplayAlert // Convert.ToDateTime( this.DueDate.no),


        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtidempleado.Text))
            {
                Empleado person = new Empleado()
                {

                    Id_empleado = Convert.ToInt32(txtidempleado.Text),
                    Nombre = txtnombre.Text,
                    Apellido = txtapellido.Text,
                    Edad = txtedad.Text,
                    Direccion = txtdireccion.Text,
                    Puesto = txtpuesto.Text

                };

                //Update Person  
                await App.BaseDatos.SaveTaskAsync(person);

                //idpago.Text = string.Empty;
                //description.Text = string.Empty;

                await DisplayAlert("Alert", "Datos Actualizado Correctamente", "OK");
                await Navigation.PushModalAsync(new ListaPagos());

            }
            else
            {
                await DisplayAlert("Alert", "Error", "OK");
            }
        }
        private async void btnlista_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ListaPagos());
    }
}
}