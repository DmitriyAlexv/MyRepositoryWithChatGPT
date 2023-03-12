using Homework_1_GenericExample.Collection;
using Homework_1_GenericExample.Components;
using Homework_1_GenericExample.Items;
using Homework_1_GenericExample.WorkStationParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_GenericExample.GenericRealization
{
    public class MyComputorCompany
    {
        private WorkStation<Computor> workStation;
        private Dictionary<string, string> computorPlan = new()
        {
            {"Процессор","Обязательно"},
            {"Видеокарта","Обязательно"},
            {"Жёсткий диск","Обязательно"},
            {"Блок питания","Обязательно"},
            {"Материнская плата","Обязательно"},
            {"Провод","Обязательно"},
            {"Оперативная память","Обязательно"},
            {"Корпус","Не обязательно"},
            {"Дисковод","Не обязательно"},
            {"CD","Не обязательно"},
            {"DVD","Не обязательно"},
            {"Модем","Не обязательно"},
            {"Звуковая плата","Не обязательно"},
        };
        private long totalBalance = 0;
        private int сurrentComputerReleased = 0;
        public OnlineShop<Computor> OnlineShop { get; private set; }
        public StorageFacility<Computor> ProducedComputorStorage { get; private set; }
        public string CompanyName { get; }
        public MyComputorCompany()
        {
            ProducedComputorStorage = new();
            CompanyName = "Super Computor Fabrica";
            OnlineShop = new OnlineShop<Computor>(ProducedComputorStorage);
            workStation = new WorkStation<Computor>(new Destructor(), new ItemBuilder(computorPlan));
        }
        public void AcceptBrokenComputor(params Computor[] computors)
        {
            workStation.AcceptBrokenItem(computors);
        }
        public bool GetComputor()
        {
            var computor = workStation.CreateItem();
            computor.IsWork = workStation.CheckOnWork(computor);
            if (computor.IsWork == false)
            {
                AcceptBrokenComputor(computor);
                return false;
            }
            computor.Fabricator = CompanyName;
            computor.ID = сurrentComputerReleased;
            сurrentComputerReleased++;
            computor.BuildDate = DateTime.Now;
            SetPrice(computor);
            ProducedComputorStorage.Add(computor);
            return true;
        }
        public void GetRevenue()
        {
            totalBalance += OnlineShop.SendRevenue();
        }
        public long GetProfit()
        {
            return totalBalance;
        }
        private void SetPrice(Computor computor)
        {
            var price = 0;
            foreach (var component in computor.Components)
            {
                if (component is VideoCard videoCard) price += videoCard.RAM * 250 * (int)Math.Round(videoCard.Frequency / 2) * (int.Parse(videoCard.RAMType[^1].ToString()) / 2);
                else if (component is Proccessor proccessor) price += proccessor.CoreCount * 2000 * (int)Math.Round(proccessor.Frequency / 2);
                else if (component is HardDrive hardDrive) price += hardDrive.StorageCapacity * 5;
                else price += new Random().Next(2000, 5000);
            }
            computor.Price = price;
        }
    }
}
