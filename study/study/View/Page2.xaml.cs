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
    public partial class Page2 : ContentPage
    {
        public Page2(Model.Contacto contacto, Page1ViewModel vm)
        {
            InitializeComponent();
            vm.Contacto = new Model.Contacto();
            vm.Contacto = contacto;
            this.BindingContext = vm;
        }
    }
}