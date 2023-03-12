using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_1_GenericExample.Components;

namespace Homework_1_GenericExample.WorkStationParts
{
    public interface IDestructorObject 
    {
        public List<Component> Decompose(object item);
    }
}
