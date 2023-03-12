using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Homework_1_GenericExample.Components;
using Homework_1_GenericExample.Items;

namespace Homework_1_GenericExample.WorkStationParts
{
    public class ItemBuilderObject : IItemBuilderObject
    {
        public Dictionary<string, string> ComponentCheckList { get; set; }
        public ItemBuilderObject(Dictionary<string, string> componetCheckList)
        {
            ComponentCheckList = componetCheckList;
        }
        public object CreateItem(Dictionary<string, List<Component>> availableComponents)
        {
            var item = new Computor(); // Я не понял как реализовать так, чтобы создавать тип который мне будет в входных данных
            item.Components = new List<Component>();
            foreach (var component in ComponentCheckList)
            {
                if (availableComponents.ContainsKey(component.Key))
                {
                    item.Components.Add(availableComponents[component.Key][0]);
                    availableComponents[component.Key].RemoveAt(0);
                    if (availableComponents[component.Key].Count == 0) availableComponents.Remove(component.Key);
                }
                else if (component.Value == "Не обязательно") continue;
                else Console.WriteLine($"(На складе нет {component} для сборки предмета)\n");
            }
            return item;
        }
    }
}
