using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_1_GenericExample.Components;
using Homework_1_GenericExample.Items;

namespace Homework_1_GenericExample.WorkStationParts
{
    public interface IItemBuilder
    {
        public Dictionary<string, string> ComponentCheckList { get; set; }
        public TItem CreateItem<TItem>(Dictionary<string, List<Component>> availableComponents) where TItem : IContainComponents, new();
    }
}
