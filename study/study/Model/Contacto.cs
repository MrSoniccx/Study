using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace study.Model
{
    public class Contacto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ObservableCollection<Telefono> Telefonos { get; set; }

    }

    public class Telefono
    {
        public string Id { get; set; }
        public string Numero { get; set; }
    }
}
