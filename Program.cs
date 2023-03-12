using Homework_1_GenericExample;
using System.Net.WebSockets;
using Homework_1_GenericExample.Components;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;
using Homework_1_GenericExample.Items;
using Homework_1_GenericExample.WorkStationParts;
using Homework_1_GenericExample.GenericRealization;
using Homework_1_GenericExample.ObjectRealisation;
using Homework_1_GenericExample.Collection;

internal class Program
{
    #region[Вспомогательные вещи]
    private static double[] frequencyList = new double[]
    {
        2.3,
        2.6,
        2.7,
        2.9,
        3.0,
        3.1,
        3.3,
        3.5,
        3.8,
        4.1
    };
    private static int[] rAMList = new int[]
    {
        1,
        2,
        4,
        8,
        16,
        32,
        64
    };
    private static int[] coreCountList = new int[]
    {
        1,
        2,
        4,
        8,
        16
    };
    private static int[] storageCapacityList = new int[]
    {
        64,
        128,
        256,
        512,
        1024,
        2048
    };
    public static bool isBroken()
    {
        var random = new Random();
        if (random.Next(2) == 1) return true;
        return false;
    }
    public static Computor GetRandomComputor()
    {
        var random = new Random();
        var components = new List<Component>()
        {
            new Component(){Name = "Блок питания", IsBroken = isBroken()},
            new Component(){Name = "Материнская плата", IsBroken = isBroken()},
            new Component(){Name = "Оперативная память", IsBroken = isBroken()},
            new Component(){Name = "Провод", IsBroken = isBroken()},
            new Component(){Name = "Корпус", IsBroken = isBroken()},
            new Component(){Name = "Дисковод", IsBroken = isBroken()},
            new Component(){Name = "CD", IsBroken = isBroken()},
            new Component(){Name = "DVD", IsBroken = isBroken()},
            new Component(){Name = "Модем", IsBroken = isBroken()},
            new Component(){Name = "Звуковая плата", IsBroken = isBroken()},
            new Proccessor(frequencyList[random.Next(frequencyList.Length)],coreCountList[random.Next(coreCountList.Length)]){IsBroken = isBroken()},
            new VideoCard(rAMList[random.Next(rAMList.Length)],frequencyList[random.Next(frequencyList.Length)],$"DDR{random.Next(3,6)}"){IsBroken = isBroken()},
            new HardDrive("HDD",storageCapacityList[random.Next(storageCapacityList.Length)]){IsBroken = isBroken()},
        };
        for (int i = 0; i < 13; i++)
        {
            if (random.Next(2) == 1) components.RemoveAt(random.Next(components.Count));
        }
        var computor = new Computor(random.Next(10000), $"Fabricator - {random.Next(10)}", DateTime.Now, components);
        computor.IsWork = false;
        return computor;
    }
    public static void ObjectPrintResult(List<Computor> computors)
    {
        foreach (var computor in computors)
        {
            Console.WriteLine($"Номер компьютера - {computor.ID}");
            foreach (var component in computor.Components)
            {
                Console.WriteLine('\t' + component.Name);
                if (component is VideoCard videoCard)
                {
                    Console.WriteLine($"\t\tЧастота - {videoCard.Frequency} ГГц");
                    Console.WriteLine($"\t\tКоличество оперативной памяти - {videoCard.RAM} Гб");
                    Console.WriteLine($"\t\tТип опреативной памяти - {videoCard.RAMType}");
                }
                else if (component is Proccessor proccessor)
                {
                    Console.WriteLine($"\t\tКоличество ядер - {proccessor.CoreCount}");
                    Console.WriteLine($"\t\tЧастота - {proccessor.Frequency} ГГц");
                }
                else if (component is HardDrive hardDrive)
                {
                    Console.WriteLine($"\t\tВместимость диска - {hardDrive.StorageCapacity} Гб");
                    Console.WriteLine($"\t\tТип диска - {hardDrive.MemoryType}");
                }

            }
            Console.WriteLine();
        }
    }
    #endregion
    private static void Object()
    {
        var brokenComputors2 = new Computor[20];
        for (int i = 0; i < 20; i++)
        {
            brokenComputors2[i] = GetRandomComputor();
        }
        var myCompany2 = new MyComputorCompanyObject();
        myCompany2.AcceptBrokenComputor(brokenComputors2);
        var newComputors2 = new List<Computor>();
        while (true)
        {
            var computor = myCompany2.GetComputor();
            if (computor == null) break;
            else newComputors2.Add(computor);
        }
        Console.WriteLine($"Получено {newComputors2.Count} компьютеров");
        ObjectPrintResult(newComputors2);
    }
    public static void PrintResult(StorageFacility<Computor> computors)
    {
        var iterator = computors.CreateIterator();
        while (!iterator.IsDone())
        {
            Console.WriteLine($"Номер компьютера - {iterator.Current.ID} - цена - {iterator.Current.Price}");
            foreach (var component in iterator.Current.Components)
            {
                Console.WriteLine('\t' + component.Name);
                if (component is VideoCard videoCard)
                {
                    Console.WriteLine($"\t\tЧастота - {videoCard.Frequency} ГГц");
                    Console.WriteLine($"\t\tКоличество оперативной памяти - {videoCard.RAM} Гб");
                    Console.WriteLine($"\t\tТип опреативной памяти - {videoCard.RAMType}");
                }
                else if (component is Proccessor proccessor)
                {
                    Console.WriteLine($"\t\tКоличество ядер - {proccessor.CoreCount}");
                    Console.WriteLine($"\t\tЧастота - {proccessor.Frequency} ГГц");
                }
                else if (component is HardDrive hardDrive)
                {
                    Console.WriteLine($"\t\tВместимость диска - {hardDrive.StorageCapacity} Гб");
                    Console.WriteLine($"\t\tТип диска - {hardDrive.MemoryType}");
                }

            }
            Console.WriteLine();
            iterator.MoveNextToNotSoldItem();
        }
    }
    private static int yourBalance = 120000;
    private static Address yourAddress = new Address() { Country = "Russia", City = "Podolsk", Street = "Pravdi", HouseNumber = 1 };
    private static void Main(string[] args)
    {
        // Вместо 30 можно любое число
        var brokenComputers = new Computor[30];

        for (int i = 0; i < brokenComputers.Length; i++)
        {
            brokenComputers[i] = GetRandomComputor();
        }
        var myCompany = new MyComputorCompany();
        myCompany.AcceptBrokenComputor(brokenComputers);

        while (true)
        {
            var isSuccessful = myCompany.GetComputor();
            if (isSuccessful == false) break;
        }
        Console.Clear();
        Console.WriteLine($"Получено {myCompany.ProducedComputorStorage.Count} компьютеров");
        while (true)
        {
            PrintResult(myCompany.ProducedComputorStorage);
            Console.WriteLine($"Ваш баланс - {yourBalance}");
            Console.WriteLine("Введитие номер компьютера, который вы хотите купить");
            Console.WriteLine("Введите \'x\', чтобы выйти");
            var number = -1;
            var input = Console.ReadLine();
            if (int.TryParse(input, out number) && number >= 0 && number < myCompany.ProducedComputorStorage.Count)
            {
                myCompany.OnlineShop.Cell(ref yourBalance, number, yourAddress);
            }
            else if (input == "x") break;
            else Console.WriteLine("Некоректный номер компьютера");
            Console.WriteLine("Hit any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}