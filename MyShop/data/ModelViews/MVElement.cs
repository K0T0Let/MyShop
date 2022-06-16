﻿using Microsoft.AspNetCore.Html;
using MyShop.data.Models;
using MyShop.data.Utilit.MethodsExtension;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.data.ModelViews
{
    public class MVElement
    {
        public MVElement(Assembly assembly, IEnumerable<Assembly> assemblies)
        {
            Sets(assembly, assemblies);
        }

        //Выходы
        public int assemblyId;
        public string name;
        public double price;
        public Brand brand;
        public int quantity;
        public HtmlString description;
        public List<string> images = new();
        public Dictionary<int, Color> colors = new();
        public Dictionary<int, string> ROMs = new();
        public Dictionary<string, List<(string Name, string Value)>> categories = new();

        void Sets(Assembly assembly, IEnumerable<Assembly> assemblies)
        {
            assemblyId = assembly.Id;

            price = (assembly.Connections.FirstOrDefault(c => c.PropertyId == 2).Meaning).ToDouble();

            var ModelName = new System.Text.StringBuilder();
            ModelName.Append(assembly.Product.Name);
            ModelName.Append($" {assembly.Connections.FirstOrDefault(c => c.PropertyId == 3).Meaning}Gb ");
            ModelName.Append(assembly.Color.Name);
            name = ModelName.ToString();

            brand = assembly.Product.Brand;

            quantity = int.Parse(assembly.Connections.FirstOrDefault(c => c.PropertyId == 4).Meaning);

            description = new HtmlString(assembly.Product.Description);

            images.AddRange(assembly.Images.Select(i => i.Src).ToList());

            colors.Add(assembly.Id, assembly.Color);
            foreach (var item in assemblies)
            {
                if (!colors.Any(c => c.Value.Id == item.ColorId))
                    colors.Add(item.Id, item.Color);
            }
            colors = colors.OrderBy(c => c.Value.Id).ToDictionary(c => c.Key, c => c.Value);

            ROMs.Add(assembly.Id, assembly.Connections.FirstOrDefault(c => c.PropertyId == 3).Meaning);
            foreach (var item in assemblies.Where(a => a.ColorId == assembly.ColorId))
            {
                if (!ROMs.ContainsValue(item.Connections.FirstOrDefault(c => c.PropertyId == 3).Meaning))
                    ROMs.Add(item.Id, item.Connections.FirstOrDefault(c => c.PropertyId == 3).Meaning);
            }
            ROMs = ROMs.OrderBy(r => int.Parse(r.Value)).ToDictionary(r => r.Key, r => r.Value);

            foreach (var item in assembly.Connections)
            {
                if (item.Property.Category_propertyId != 1)
                    if (categories.ContainsKey(item.Property.Category_property.Name))
                        categories[item.Property.Category_property.Name].Add((Name: item.Property.Name, Value: item.Meaning));
                    else
                        categories.Add(
                            item.Property.Category_property.Name, 
                            new List<(string Name, string Value)> { (Name: item.Property.Name, Value: item.Meaning) }
                            );
            }
        }
    }
}
