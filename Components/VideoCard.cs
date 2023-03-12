using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_GenericExample.Components
{
    public class VideoCard : Component
    {
        public int RAM { get; init; }
        public double Frequency { get; init; }
        public string RAMType { get; init; }
        public VideoCard(int rAM, double frequency, string rAMType)
        {
            RAM = rAM;
            Frequency = frequency;
            RAMType = rAMType;
            IsSimpleComponent = true;
            Name = "Видеокарта";
        }
    }
}
