using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_GenericExample.Components
{
    public class HardDrive : Component
    {
        public string MemoryType { get; init; }
        public int StorageCapacity { get; init; }
        public HardDrive(string memoryType, int storageCapacity)
        {
            MemoryType = memoryType;
            StorageCapacity = storageCapacity;
            IsSimpleComponent = true;
            Name = "Жёсткий диск";
        }
    }
}
