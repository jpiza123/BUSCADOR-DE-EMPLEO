using System;
using System.ComponentModel;
using SQLite;
namespace BolsadeEmpleo.Entidades
{
    [Table("Ofertas")]
    public class Oferta: INotifyPropertyChanged
    {
        public int id;
        [PrimaryKey, AutoIncrement]

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public int idPublicador;
        [NotNull]

        public int IdPublicador
        {
            get
            {
                return idPublicador;
            }
            set
            {
                this.idPublicador = value;
                OnPropertyChanged(nameof(IdPublicador));
            }
        }

        public int idCandidato;
        [NotNull]

        public int IdCandidato
        {
            get
            {
                return idCandidato;
            }
            set
            {
                this.idCandidato = value;
                OnPropertyChanged(nameof(IdCandidato));
            }
        }



        public string nombreCargo;
        [NotNull]

        public string NombreCargo
        {
            get
            {
                return nombreCargo;
            }
            set
            {
                this.nombreCargo = value;
                OnPropertyChanged(nameof(NombreCargo));
            }
        }

        public string ciudad;
        [NotNull]

        public string Ciudad
        {
            get
            {
                return ciudad;
            }
            set
            {
                this.ciudad = value;
                OnPropertyChanged(nameof(Ciudad));
            }
        }

        public string salario;
        [NotNull]

        public string Salario
        {
            get
            {
                return salario;
            }
            set
            {
                this.salario = value;
                OnPropertyChanged(nameof(Salario));
            }
        }


        public string fecha;
        [NotNull]

        public string Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                this.fecha = value;
                OnPropertyChanged(nameof(Fecha));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string v)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
