using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_1_GenericExample.Components;
using Homework_1_GenericExample.Items;
using Homework_1_GenericExample.WorkStationParts;

namespace Homework_1_GenericExample.GenericRealization
{
    public class WorkStation<TItem> where TItem : class, IContainComponents, new()
    {
        private Dictionary<string, List<Component>> componentStorage = new();
        private IDestructor destructor;
        private IItemBuilder itemBuilder;

        public WorkStation(IDestructor destructor, IItemBuilder itemBuilder, Dictionary<string, List<Component>> componentStorage = null)
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
        public void AcceptBrokenItem(params TItem[] items)
        {
            foreach (var item in items)
            {
                var components = destructor.Decompose(item);
                foreach (var component in components)
                {
                    AddComponentToStorage(component);
                }
            }
        }
        public TItem CreateItem()
        {
            var item = itemBuilder.CreateItem<TItem>(componentStorage);
            return item;
        }
        public bool CheckOnWork(TItem item)
        {
            foreach (var component in itemBuilder.ComponentCheckList)
            {
                if (component.Value == "Обязательно")
                {
                    var isOK = false;
                    foreach (var elem in item.Components)
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
