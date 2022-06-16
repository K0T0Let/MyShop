using MyShop.data.Interfaces;
using MyShop.data.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyShop.data.ModelViews
{
    public class MVIndex
    {
        public MVIndex(IEnumerable<Assembly> assembly, IEnumerable<Brand> brand)
        {
            this.assembly = assembly;
            this.brand = brand;
        }

        IEnumerable<Assembly> _assembly;

        //Выход
        public IEnumerable<Assembly> assembly
        { 
            get => _assembly;
            set => _assembly = value.Where(a => a.Connections[0].Meaning == "true");
        }

        //Выход
        public IEnumerable<Brand> brand { get; set; }
    }
}
