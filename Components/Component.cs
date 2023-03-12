using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_GenericExample.Components
{
    public class Component
    {
        public string Name { get; set; }
        public bool IsBroken { get; set; }
        public bool IsSimpleComponent { get; protected set; }
        public Component()
        {
            IsSimpleComponent = true;
        }
    }
}
