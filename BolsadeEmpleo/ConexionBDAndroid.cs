using System;
using SQLite;
using System.IO;
using BolsadeEmpleo;

[assembly: Xamarin.Forms.Dependency(typeof(ConexionBDAndroid))]
namespace BolsadeEmpleo
{
    public class ConexionBDAndroid: IConexionDB
    {


        public SQLiteConnection DBConexion()
        {
            var nameDB = "EmplearDB";
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), nameDB);
            return new SQLiteConnection(path);
        }
    }
}
