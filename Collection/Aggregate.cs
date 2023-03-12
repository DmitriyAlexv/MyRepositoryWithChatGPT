using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_GenericExample.Collection
{
    public abstract class Aggregate<T,U>
    {
        public abstract (T,U) this[int index] { get; set; }
        public abstract int Count { get; }
        public abstract IEnumerator<T> CreateIterator();
        public abstract void RemoveAt(int index);
        public abstract void Add(T item);
    }
}