using study.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace study.ViewModel
{
    public class Page1ViewModel : BaseViewModel
    {
        public ObservableCollection<Contacto> Contactos { get; set; }

        private Contacto contacto;
        public Contacto Contacto
        {
            get { return contacto; }
            set { contacto = value; OnPropetyChanged(); }
        }

        public ICommand cmdContactoDetalle { get; set; }
        public ICommand cmdContactoDel { get; set; }
        public ICommand cmdContactoMod { get; set; }
        public ICommand cmdContactoGrabar { get; set; }
        public ICommand cmdContactoAdd { get; set; }
        public ICommand cmdGetOut { get; set; }
        public Page1ViewModel()
        {
            Contactos = new ObservableCollection<Contacto>();


            Contactos.Add(new Contacto()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Pepe",
                LastName = "pepinillo",
                Telefonos = new ObservableCollection<Telefono> { new Telefono() { Id = Guid.NewGuid().ToString(), Numero = "313135496843" }, new Telefono() { Id = Guid.NewGuid().ToString(), Numero="314446484651" } }
            });

            Contactos.Add(new Contacto()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Hoola",
                LastName = "alooH",
                Telefonos = new ObservableCollection<Telefono> { new Telefono() { Id = Guid.NewGuid().ToString(), Numero = "11545789" } }
            
            });

            cmdContactoDetalle = new Command<Contacto>(async (x) => await PCmdContactoDetalle(x));
            cmdContactoDel = new Command<Contacto>(async (x) => await PCmdContactoDel(x));
            cmdContactoMod = new Command<Contacto>(async (x) => await PCmdContactoMod(x));
            cmdContactoGrabar = new Command<Contacto>(async (x) => await PCmdContactoGrabar(x));
            cmdContactoAdd = new Command(async () => await PCmdContactoAdd());
            cmdGetOut = new Command(async () => await PCmdGetOut());


            async Task PCmdContactoDetalle(Model.Contacto _Contacto)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.Page2(_Contacto, this));
            }

            async Task PCmdContactoAdd()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.Page3( this));
            }

            async Task PCmdContactoDel(Model.Contacto _Contacto)
            {
                Contactos.Remove(_Contacto);
                OnPropetyChanged();
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            async Task PCmdGetOut()
            {
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PopAsync();

            }

            async Task PCmdContactoMod(Model.Contacto _Contacto)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.Page3(_Contacto, this));
            }

            async Task PCmdContactoGrabar(Model.Contacto _Contacto)
            {
                int indice = -1;
                Contacto tmp = Contactos.FirstOrDefault(item => item.Id == _Contacto.Id);

                if (tmp == null) { Contactos.Add(_Contacto); }
                else
                {
                    indice = Contactos.IndexOf(tmp);
                    Contactos[indice] = _Contacto;
                }
                OnPropetyChanged();
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
