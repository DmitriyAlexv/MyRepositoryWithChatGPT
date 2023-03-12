using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_1_GenericExample.Components;

namespace Homework_1_GenericExample.WorkStationParts
{
    public interface IItemBuilderObject
    {
        public Dictionary<string, string> ComponentCheckList { get; set; }
        public object CreateItem(Dictionary<string, List<Component>> availableComponents);
    }
}
