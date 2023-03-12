using Homework_1_GenericExample.Components;
using Homework_1_GenericExample.GenericRealization;
using Homework_1_GenericExample.Items;
using Homework_1_GenericExample.WorkStationParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_GenericExample.ObjectRealisation
{
    public class MyComputorCompanyObject
    {
        private ObjectWorkStation WorkStation;
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
        private int сurrentComputerReleased = 0;
        public string CompanyName { get; }
        public MyComputorCompanyObject()
        {
            CompanyName = "Super Computor Fabrica";
            WorkStation = new ObjectWorkStation(new DestructorObject(), new ItemBuilderObject(computorPlan));
        }
        public void AcceptBrokenComputor(params Computor[] computors)
        {
            WorkStation.AcceptBrokenItem(computors);
        }
        public Computor GetComputor()
        {
            var computor = WorkStation.CreateItem();
            try
            {
                var a = (Computor)computor;
            }
            catch
            {
                throw new ArgumentException("Объект не компьютер");
            }
            var _computor = (Computor)computor;
            if (WorkStation.CheckOnWork(computor) == false)
            {
                AcceptBrokenComputor(_computor);
                return null;
            }
            _computor.Fabricator = CompanyName;
            _computor.ID = сurrentComputerReleased;
            сurrentComputerReleased++;
            _computor.BuildDate = DateTime.Now;
            return _computor;
        }
    }
}
