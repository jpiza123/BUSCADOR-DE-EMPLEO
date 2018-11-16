using System;
using SQLite;
using System.ComponentModel;
namespace BolsadeEmpleo.Entidades
{
    [Table("Usuarios")]
    public class Usuario: INotifyPropertyChanged
    {
        public int id;
        [PrimaryKey, AutoIncrement]

        public int Id
        {
            get{
                return id;
            }
            set{
                this.id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string username;
        [NotNull, Unique]

        public string Username{
            get{
                return username;
            }
            set{
                this.username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string contraseña;
        [NotNull]

        public string Contraseña
        {
            get
            {
                return contraseña;
            }
            set
            {
                this.contraseña = value;
                OnPropertyChanged(nameof(Contraseña));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string v)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }

}
