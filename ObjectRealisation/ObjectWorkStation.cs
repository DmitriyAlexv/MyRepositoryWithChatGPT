using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_1_GenericExample.Components;
using Homework_1_GenericExample.Items;
using Homework_1_GenericExample.WorkStationParts;

namespace Homework_1_GenericExample.ObjectRealisation
{
    public class ObjectWorkStation
    {
        private Dictionary<string, List<Component>> componentStorage = new();
        private IDestructorObject destructor;
        private IItemBuilderObject itemBuilder;

        public ObjectWorkStation(IDestructorObject destructor, IItemBuilderObject itemBuilder, Dictionary<string, List<Component>> componentStorage = null)
        {
            if (componentStorage != null) this.componentStorage = componentStorage;
            this.destructor = destructor;
            this.itemBuilder = itemBuilder;
        }

        public void AddComponentToStorage(Component component)
        {
            if (component == null) throw new ArgumentException("Нет компонента");
            if (itemBuilder.ComponentCheckList.ContainsKey(component.Name))
            {
                if (componentStorage.ContainsKey(component.Name)) componentStorage[component.Name].Add(component);
                else componentStorage.Add(component.Name, new List<Component>() { component });
            }
            else Console.WriteLine("Недопустимый компонент");
        }
        public void AcceptBrokenItem(params object[] items)
        {
            foreach (var item in items)
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
                var components = destructor.Decompose(_item);
                foreach (var component in components)
                {
                    AddComponentToStorage(component);
                }
            }
        }
        public object CreateItem()
        {
            var item = itemBuilder.CreateItem(componentStorage);
            return item;
        }
        public bool CheckOnWork(object item)
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
            foreach (var component in itemBuilder.ComponentCheckList)
            {
                if (component.Value == "Обязательно")
                {
                    var isOK = false;
                    foreach (var elem in _item.Components)
                    {
                        if (elem.Name == component.Key)
                        {
                            isOK = true;
                            break;
                        }
                    }
                    if (!isOK) return false;
                }
            }
            return true;
        }
    }
}

