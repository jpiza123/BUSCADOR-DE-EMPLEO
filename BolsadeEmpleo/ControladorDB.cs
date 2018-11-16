using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BolsadeEmpleo.Entidades;
using SQLite;
using Xamarin.Forms;

namespace BolsadeEmpleo
{
    public class ControladorDB
    {
        private SQLiteConnection con;
        private ObservableCollection<Usuario> usuarios { get; set; }
        private ObservableCollection<Oferta> ofertas { get; set; }
        private static object collisionLock = new object();

        public ControladorDB()
        {
            con = DependencyService.Get<IConexionDB>().DBConexion();

            con.CreateTable<Usuario>();
            con.CreateTable<Oferta>();
            this.usuarios = new ObservableCollection<Usuario>(con.Table<Usuario>());
            this.ofertas = new ObservableCollection<Oferta>(con.Table<Oferta>());
            if (!con.Table<Usuario>().Any())
            {
                crearUsuario();
            }


        }

        public void crearUsuario()
        {
            this.usuarios.Add(new Usuario { Username = "admin", Contraseña = "admin" });
        }

        public int SaveUser(Usuario usuario)
        {

            lock (collisionLock)
            {
                if (usuario.Id != 0)
                {
                    con.Update(usuario);
                    return usuario.Id;
                }
                else
                {
                    var lista = con.Query<Usuario>("SELECT * FROM Usuarios WHERE Contraseña = ? AND Username = ?", usuario.Contraseña, usuario.Username);
                    bool b = false;
                    foreach (var u in lista){
                        if (u.Id > 0)
                             b = true;
                    }
                    if (!b)
                        return con.Insert(usuario);
                    else return 0;
                }
            }
        }

        public int DeleteUser(Usuario usuario)
        {
            var id = usuario.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    con.Delete<Usuario>(id);
                }
            }
            this.usuarios.Remove(usuario);
            return id;
        }

        public Usuario GetUser(int id)
        {
            lock (collisionLock)
            {
                return con.Table<Usuario>().
                          FirstOrDefault(usuario => usuario.Id == id);
            }
        }
        public int GetUserbyUserPass(string user, string pass)
        {
            lock (collisionLock)
            {
                int i= -1;
                var lista = con.Query<Usuario>("SELECT * FROM Usuarios WHERE Contraseña = ? AND Username = ?", pass, user);
                foreach(var s in lista){
                     i = s.Id;
                    Console.WriteLine(s.Id);
                }

                if (i > 0)
                    return i;
                else return -1;
            }
                
        }


        public int SaveOferta(Oferta oferta)
        {

            lock (collisionLock)
            {
                if (oferta.Id != 0)
                {
                    con.Update(oferta);
                    return oferta.Id;
                }
                else
                {
                    if (con.Insert(oferta) > 0)
                        return oferta.Id;
                    else return 0;
                }
            }
        }

        public int DeleteOferta(Oferta oferta)
        {
            var id = oferta.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    con.Delete<Oferta>(id);
                }
            }
            this.ofertas.Remove(oferta);
            return id;
        }

        public Oferta GetOferta(int id)
        {
            lock (collisionLock)
            {
                return con.Table<Oferta>().
                          FirstOrDefault(oferta => oferta.Id == id);
            }
        }
        public List<Oferta> GetOfertasByIdCandidato(int id)
        {
            lock (collisionLock)
            {
                List<Oferta> lista = con.Query<Oferta>("SELECT * FROM Ofertas WHERE IdCandidato = ? ", id);
                if (lista.Count > 0)
                {
                    return lista;
                }
                else return null;
            }
        }
        public List<Oferta> GetOfertasByIdPublicador(int id)
        {
            lock (collisionLock)
            {
                List<Oferta> lista = con.Query<Oferta>("SELECT * FROM Ofertas WHERE IdPublicador = ? ", id);
                if (lista.Count > 0)
                {
                    return lista;
                }
                else return null;
            }
        }
        public List<Oferta> GetOfertaByCargoOCity(string cargo, string ciudad)
        {
            lock (collisionLock)
            {
                int i = 0;
                var  lista = con.Query<Oferta>("SELECT * FROM Ofertas WHERE NombreCargo = ? ", cargo);
                foreach (var s in lista)
                {
                    i = s.Id;
                }

                if (i > 0)
                    return lista;
                else return null;
            }

        }


    }
}
