using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_GenericExample.Collection
{
    public class StorageFacility<TItem> : Aggregate<TItem, Address?> where TItem : class
    {
        private TItem[] items;
        private Address?[] addresses;
        public StorageFacility()
        {
            items = new TItem[0];
            addresses = new Address?[0];
        }
        public override (TItem, Address?) this[int index]
        {
            get => (items[index], addresses[index]);
            set => (items[index], addresses[index]) = value;
        }
        public void SetItemAddress(int index, Address address)
        {
            addresses[index] = address;
        }
        public override int Count => items.Length;

        public override void Add(TItem item)
        {
            var result = new TItem[items.Length + 1];
            var addressResult = new Address?[addresses.Length + 1];
            for (int i = 0; i < items.Length; i++)
            {
                result[i] = items[i];
                addressResult[i] = addresses[i];
            }
            result[^1] = item;
            addressResult[^1] = null;
            items = result;
            addresses = addressResult;
        }

        public override StorageEnumerator<TItem> CreateIterator()
        {
            return new StorageEnumerator<TItem>(this);
        }
        public override void RemoveAt(int index)
        {
            if (items.Length == 0 || index < 0 || index >= items.Length) return;
            var result = new TItem[items.Length - 1];
            var addressResult = new Address?[addresses.Length - 1];
            var j = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }
                result[j] = items[i];
                addressResult[i] = addresses[i];
                j++;
            }
            items = result;
            addresses = addressResult;
        }
    }
}
