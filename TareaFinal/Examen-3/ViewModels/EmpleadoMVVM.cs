using Examen_3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Examen_3.ViewModels
{
    public class EmpleadoMVVM
    {
        readonly SQLiteAsyncConnection _database;

        public EmpleadoMVVM(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Models.Empleado>().Wait();
        }

        public EmpleadoMVVM()
        {
        }

        public Task<List<Models.Empleado>> GetTaskAsync()
        {
            return _database.Table<Models.Empleado>().OrderByDescending(x => x.Id_empleado).ToListAsync();
        }

        
        public Task<int> SaveTaskAsync(Models.Empleado taskModel)
        {

            if (taskModel.Id_empleado!= 0)
            {
                return _database.UpdateAsync(taskModel);
            }
            else
            {
                return _database.InsertAsync(taskModel);
            }

        }

        public Task<int>UpdateTaskAsync(Models.Empleado empleado)
        {
            return _database.UpdateAsync(empleado);
        }

        public Task<int> deleteAsync(Models.Empleado empleado)
        {
            return _database.DeleteAsync(empleado);
        }

        public Task<Models.Empleado> GetItemAsync(int personId)
        {
            return _database.Table<Models.Empleado>().Where(i => i.Id_empleado == personId).FirstOrDefaultAsync();
        }

        public Task<Models.Empleado> DeleteItemAsync(int personId)
        {
            return _database.Table<Models.Empleado>().Where(i => i.Id_empleado == personId).FirstOrDefaultAsync();
        }


    }
}