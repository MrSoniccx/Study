using study.Model;
using study.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace study.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3(Page1ViewModel vm)
        {
            //nuevo contact
            InitializeComponent();

            vm.Contacto = new Model.Contacto() { Id = Guid.NewGuid().ToString() };
            vm.Contacto.Telefonos = new System.Collections.ObjectModel.ObservableCollection<Model.Telefono>();

            BindingContext = vm;
            Title = "Nuevo Contacto";

        }


        public Page3(Model.Contacto contacto, Page1ViewModel vm)
        {
            //nuevo contact
            InitializeComponent();
            vm.Contacto = new Model.Contacto();
            vm.Contacto = contacto;


            BindingContext = vm;
            Title = "Modificiar";

        }
    }
}