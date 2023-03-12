using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_GenericExample.Components
{
    public class Proccessor : Component
    {
        public double Frequency { get; init; }
        public int CoreCount { get; init; }
        public Proccessor(double frequency, int coreCount)
        {
            Frequency = frequency;
            CoreCount = coreCount;
            IsSimpleComponent = true;
            Name = "Процессор";
        }
    }
}
