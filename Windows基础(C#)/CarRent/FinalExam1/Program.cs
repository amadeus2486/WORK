using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    public string Brand { get; set; }//汽车品牌
    public string Model { get; set; }//汽车型号
    public string LicensePlate { get; set; }//汽车车牌
    public decimal DailyRent { get; set; }//租借日租
    public bool IsRented { get; set; }//出租状态

    public Car(string brand, string model, string licensePlate, decimal dailyRent)//初始化
    {
        Brand = brand;
        Model = model;
        LicensePlate = licensePlate;
        DailyRent = dailyRent;
        IsRented = false;//添加车辆后默认为未出租
    }
}

public class RentalRecord
{
    public Car Car { get; set; }
    public DateTime RentStartDate { get; set; }//租借起始时间
    public DateTime? RentEndDate { get; set; }//租借归还时间

    public decimal CalculateRent(DateTime endDate)//租金计算
    {
        if (endDate <= RentStartDate)
        {
            throw new ArgumentException("归还日期早于出租日期！发生错误\n");//出租时长出现问题
        }

        TimeSpan duration = endDate - RentStartDate;
        return Car.DailyRent * (decimal)duration.TotalDays;
    }
}

public class CarRentalSystem
{
    private List<Car> cars = new List<Car>();
    private List<RentalRecord> rentalRecords = new List<RentalRecord>();

    public void AddCar(string brand, string model, string licensePlate, decimal dailyRent)// 添加车辆  
    {
        cars.Add(new Car(brand, model, licensePlate, dailyRent));
        Console.WriteLine($"车辆品牌：{brand}，型号：{model}，车牌：{licensePlate}，日租：{dailyRent}");
    }

    public List<Car> FindCars(string query) // 查找车辆  
    {
        return cars.Where(c => c.Brand.Contains(query) || c.LicensePlate.Contains(query)).ToList();//以列表形式返回
    }
   
    public RentalRecord RentCar(string brand, int days)// 租借车辆 
    {
        var car = cars.FirstOrDefault(c => c.Brand == brand && !c.IsRented);//根据品牌判断目标车辆是否存在
        if (car == null)
        {
            throw new Exception("目标车辆不存在或已出租！\n");
        }
        //车辆存在且未出租，即完成租车选择，开始登记
        car.IsRented = true;//修改目标车辆的租借状态
        var rentalRecord = new RentalRecord { Car = car, RentStartDate = DateTime.Now };//根据提出租借申请的时间作为起始时间
        rentalRecords.Add(rentalRecord);//加入总租车记录
        return rentalRecord;
    }

    public void ReturnCar(string licensePlate) // 归还车辆  
    {
        var car = cars.FirstOrDefault(c => c.LicensePlate == licensePlate);//根据测评判断目标车辆是否存在
        if (car == null || !car.IsRented)
        {
            throw new Exception("该车牌车辆不存在或者该车辆未出租！\n");
        }

        var rentalRecord = rentalRecords.FirstOrDefault(rr => rr.Car.LicensePlate == licensePlate);
        if (rentalRecord == null)
        {
            throw new Exception("没有找到该车牌车辆的租赁信息！\n");
        }

        rentalRecord.RentEndDate = DateTime.Now;//以提出归还申请为归还时间
        car.IsRented = false;//修改状态信息

        decimal rent = rentalRecord.CalculateRent(rentalRecord.RentEndDate.Value);// 计算租金并处理输出 
        Console.WriteLine($"车牌号： {licensePlate} 的车辆已完成归还。租借总费用： {rent}\n");
    }

    public void DisplayCarRentalInfo(string licensePlate)// 显示车辆租赁信息
    {
        var car = cars.FirstOrDefault(c => c.LicensePlate == licensePlate);//根据车牌判断是否存在目标车辆
        if (car == null)
        {
            Console.WriteLine("没有找到该车牌的车辆！\n");
            return;
        }

        var rentalRecord = rentalRecords.FirstOrDefault(rr => rr.Car.LicensePlate == licensePlate);//根据车牌判断是否存在出租记录
        if (rentalRecord == null)
        {
            Console.WriteLine($"车牌：{licensePlate}的车辆最近没有出租记录！\n");
        }
        else
        {
            Console.WriteLine($"车牌：{licensePlate}的车辆最近的出租记录为：{rentalRecord.RentStartDate}到" +
                $"{(rentalRecord.RentEndDate.HasValue ? rentalRecord.RentEndDate.Value.ToString("yyyy-MM-dd") : "还未归还。")}\n");
            //有该车牌车辆的出租记录，分为已经完成租借归还（返回时间区间）和未完成归还（返回未归还）两种情况
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        CarRentalSystem carRentalSystem = new CarRentalSystem();//创建系统

         
        //carRentalSystem.AddCar("丰田", "卡罗拉", "G11451", 50m); // 添加车辆对象，方便功能实现
        //carRentalSystem.AddCar("本田", "思域", "G41919", 45m);
  
        while (true)//功能实现面板
        {
            Console.WriteLine("输入对应数字进行对应操作：");
            Console.WriteLine("1.添加车辆");
            Console.WriteLine("2.查找车辆");
            Console.WriteLine("3.租借车辆");
            Console.WriteLine("4.归还车辆");
            Console.WriteLine("5.退出");

            string input = Console.ReadLine();
            switch (input)//通过Switch语句进行对应功能的跳转
            {
                case "1":
                    AddCar(carRentalSystem);
                    break;
                case "2":
                    FindCar(carRentalSystem);
                    break;
                case "3":
                    RentCar(carRentalSystem);
                    break;
                case "4":
                    ReturnCar(carRentalSystem);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("输入错误，请正确输入！");
                    break;
            }
        }
    }

    static void AddCar(CarRentalSystem carRentalSystem)
    {
        Console.Write("输入车辆品牌：");
        string brand = Console.ReadLine();
        Console.Write("输入车辆型号：");
        string model = Console.ReadLine();
        Console.Write("输入车牌：");
        string licensePlate = Console.ReadLine();
        Console.Write("输入预期日租：");
        decimal dailyRent = Convert.ToDecimal(Console.ReadLine());

        carRentalSystem.AddCar(brand, model, licensePlate, dailyRent);//创建成功车辆对象并添加到List
        Console.WriteLine("车辆信息加入成功！\n");
    }

    static void FindCar(CarRentalSystem carRentalSystem)
    {
        Console.Write("请输入车辆特征（车辆品牌或车牌号）：");
        string query = Console.ReadLine();

        var cars = carRentalSystem.FindCars(query);//查询
        if (cars.Count == 0)
        {
            Console.WriteLine("没有找到目标车辆。\n");
        }
        else
        {
            foreach (var car in cars)//找到了则逐条输出List中符合条件的信息
            {
                Console.WriteLine($"品牌：{car.Brand}，型号：{car.Model}，车牌：{car.LicensePlate}，日租：{car.DailyRent}\n");
            }
        }
    }

    static void RentCar(CarRentalSystem carRentalSystem)
    {
        Console.Write("输入要租借的车辆品牌：");
        string brand = Console.ReadLine();
        Console.Write("输入要租借的天数：");
        int days = Convert.ToInt32(Console.ReadLine());

        try
        {
            var rentalRecord = carRentalSystem.RentCar(brand, days);//进行租借并返回记录
            Console.WriteLine("车辆租借成功！\n");
            carRentalSystem.DisplayCarRentalInfo(rentalRecord.Car.LicensePlate);
        }
        catch (Exception ex)
        {
            Console.WriteLine("错误：" + ex.Message);
        }
    }

    static void ReturnCar(CarRentalSystem carRentalSystem)
    {
        Console.Write("输入要归还车辆的车牌号：");
        string licensePlate = Console.ReadLine();

        try
        {
            carRentalSystem.ReturnCar(licensePlate);//进行归还，无返回值，但会显示出租费用
            Console.WriteLine("车辆归还成功！\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("错误：" + ex.Message);
        }
    }
}