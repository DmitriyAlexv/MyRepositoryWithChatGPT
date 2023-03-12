using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_1_GenericExample.Components;
using Homework_1_GenericExample.Items;

namespace Homework_1_GenericExample.WorkStationParts
{
    public class DestructorObject: IDestructorObject
    {
        public List<Component> Decompose(object item)
        {
            try
            {
                var a = (IContainComponents)item;
            }
            catch
            {
                throw new ArgumentException("Объект не содержит компонентов");
            }
            var _item = (IContainComponents)item;
            if (_item == null || _item.Components == null) throw new ArgumentException("Нет объекта");
            List<Component> workedComponents = new();
            foreach (var component in _item.Components)
            {
                if (!component.IsBroken) workedComponents.Add(component);
            }
            _item = null;
            return workedComponents;
        }
    }
}
