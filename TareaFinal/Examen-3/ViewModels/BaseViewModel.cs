
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Examen_3.Models;
using Xamarin.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;

namespace Examen_3.ViewModels
{
     public class BaseViewModel : INotifyPropertyChanged
    {
        EmpleadoMVVM articulosMVVM = new EmpleadoMVVM();
        public event PropertyChangedEventHandler PropertyChanged;

        private int id_empleado;
        public int Id_Empleado
        {
            get { return id_empleado; }
            set
            {
                id_empleado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("id_Empleado"));
            }
        }


        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nombre"));
            }
        }

        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set
            {
                apellido = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Apellido"));
            }
        }

        private string edad;
        public string Edad
        {
            get { return edad; }
            set
            {
                edad = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Edad"));
            }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set
            {
                direccion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Direccion"));
            }
        }

        private string puesto;
        public string Puesto
        {
            get { return puesto; }
            set
            {
                puesto = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Puesto"));
            }
        }

        private byte[] photo;
        public byte[] Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Photo"));
            }
        }

        private DateTime dueDate = DateTime.Now;
        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DueDate"));
            }
        }

        private List<Models.Empleado> taskList;
        public List<Models.Empleado> TaskList
        {
            get { return taskList; }
            set
            {

                taskList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TaskList"));
            }
        }
        public Command cmdAddTask { get; set; }
        public Command cmdAddTask1 { get; set; }
        public Command cmdeliminar { get; set; }
        public BaseViewModel()
        {
            cmdAddTask = new Command(AddTask);
            cmdAddTask1 = new Command(deleteAsync1);
          //  cmdeliminar = new Command(OnDelete);
            getTask();
        }

        public ICommand EliminarCommand
        {
            get
            {
                return new RelayCommand(deleteAsync1);
            }
        }

        private async void AddTask(object obj)
        {
            var r = await App.BaseDatos.SaveTaskAsync(new Models.Empleado
            {

                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                Direccion = direccion,
                Puesto = puesto,
                ///Photo_recibo=Photo
            });

            getTask();

            await Application.Current.MainPage.DisplayAlert("Alert", "Informacion Guardada", "OK");

            Limpiar();
        }

        

        private async void deleteAsync1()
        {
            if (!string.IsNullOrEmpty(id_empleado.ToString()))
            {
                //Get Person

                var person = await App.BaseDatos.GetItemAsync(Convert.ToInt32(id_empleado.ToString()));
                if (person != null)
                {
                    //Delete Person
                    await App.BaseDatos.deleteAsync(person);
                    await Application.Current.MainPage.DisplayAlert("Success", "Person Deleted", "OK");

                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }

        public async void getTask()
        {
            TaskList = await App.BaseDatos.GetTaskAsync();
        }

        void Limpiar()
        {
            
            Nombre = String.Empty;
            Apellido = String.Empty;
            Edad = String.Empty;
            Direccion = String.Empty;
            Puesto = String.Empty;

        }

        //private async void OnDelete(int id) {

        //    Pagos pad

        //    if (pag== null)

        //    await App.BaseDatos.DeleteItemAsync(pag.Id_pago);


        //}
    }
}
