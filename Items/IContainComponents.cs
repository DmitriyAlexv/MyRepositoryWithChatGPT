using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_1_GenericExample.Components;

namespace Homework_1_GenericExample.Items
{
    public interface IContainComponents
    {
        public List<Component> Components { get; set; }
    }
}
