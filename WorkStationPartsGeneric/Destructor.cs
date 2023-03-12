using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_1_GenericExample.Components;
using Homework_1_GenericExample.Items;

namespace Homework_1_GenericExample.WorkStationParts
{
    public class Destructor: IDestructor
    {
        public List<Component> Decompose<TItem>(TItem item) where TItem : class, IContainComponents
        {
            if (item == null || item.Components == null) throw new ArgumentException("Нет объекта");
            List<Component> workedComponents = new();
            foreach (var component in item.Components)
            {
                if (!component.IsBroken) workedComponents.Add(component);
            }
            item = null;
            return workedComponents;
        }
    }
}
