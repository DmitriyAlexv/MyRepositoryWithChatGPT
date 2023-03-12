using Homework_1_GenericExample.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_GenericExample
{
    public class StorageEnumerator<TItem> : IEnumerator<TItem> where TItem : class
    {
        private Aggregate<TItem, Address?> aggregate;
        private int currentIndex;
        public TItem Current { get; private set; }

        object IEnumerator.Current => Current;

        public StorageEnumerator(Aggregate<TItem, Address?> aggregate)
        {
            this.aggregate = aggregate;
            Current = First();
        }
        public TItem First()
        {
            if (aggregate.Count == 0) return null;
            return aggregate[0].Item1;
        }
        public void Dispose() { }// Сложна...
        public bool IsDone()
        {
            return currentIndex == aggregate.Count;
        }

        public bool MoveNext()
        {
            currentIndex++;
            if (IsDone()) return false;
            Current = aggregate[currentIndex].Item1;
            return true;
        }
        public bool MoveNextToNotSoldItem()
        {
            while (true)
            {
                currentIndex++;
                if (IsDone()) return false;
                if (aggregate[currentIndex].Item2 == null)
                {
                    Current = aggregate[currentIndex].Item1;
                    return true;
                }
            }
        }
        public void Reset()
        {
            currentIndex = 0;
            Current = First();
        }
    }
}
