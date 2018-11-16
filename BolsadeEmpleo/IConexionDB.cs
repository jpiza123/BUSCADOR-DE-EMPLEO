using System;
namespace BolsadeEmpleo
{
    public interface IConexionDB
    {

        SQLite.SQLiteConnection DBConexion();
    }
}
