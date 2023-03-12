using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_1_GenericExample.Components;

namespace Homework_1_GenericExample.Items
{
    public class Computor : IContainComponents, ISellable
    {
        public int ID { get; set; }
        public string Fabricator { get; set; }
        public DateTime BuildDate { get; set; }
        public List<Component> Components { get; set; }
        public bool IsWork { get; set; }
        public int Price { get; set; }

        public Computor() { }
        public Computor(int iD, string fabricator, DateTime buildDate, List<Component> components = null)
        {
            IsWork = true;
            ID = iD;
            Fabricator = fabricator;
            BuildDate = buildDate;
            Components = components;
        }
    }
}
