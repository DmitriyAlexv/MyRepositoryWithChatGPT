using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_1_GenericExample.Components;
using Homework_1_GenericExample.Items;

namespace Homework_1_GenericExample.WorkStationParts
{
    public interface IDestructor 
    {
        public List<Component> Decompose<TItem>(TItem item) where TItem : class, IContainComponents;
    }
}
