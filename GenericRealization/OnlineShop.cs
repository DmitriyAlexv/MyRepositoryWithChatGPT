using Homework_1_GenericExample.Collection;
using Homework_1_GenericExample.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_GenericExample.GenericRealization
{
    public class OnlineShop<TItem> where TItem : class, ISellable
    {
        private StorageFacility<TItem> StorageFacility;
        private long balance;

        public OnlineShop(StorageFacility<TItem> storageFacility)
        {
            StorageFacility = storageFacility;
            balance = 0;
        }

        public void Cell(ref int money, int number, Address buyerAddress)
        {
            if (IsItemSold(number)) Console.WriteLine("Компьютер под данным номером продан");
            else if (money >= StorageFacility[number].Item1.Price && IsValidAddress(buyerAddress))
            {
                StorageFacility[number] = (StorageFacility[number].Item1, buyerAddress);
                balance += StorageFacility[number].Item1.Price;
                money -= StorageFacility[number].Item1.Price;
                Console.WriteLine("Заказ успешно оформелен");
            }
            else Console.WriteLine("Недостаточно денег");
        }

        public long SendRevenue()
        {
            var revenue = balance;
            balance = 0;
            return revenue;
        }
        
        private bool IsItemSold(int index)
        {
            return StorageFacility[index].Item2 != null;
        }

        private bool IsValidAddress(Address address)
        {
            if (address.Country != null && address.City != null && address.Street != null) return true;
            else return false;
        }
    }
}
