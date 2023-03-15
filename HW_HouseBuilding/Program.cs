using System;
using static System.Console;

namespace HW_HouseBuilding
{
    public interface Ipart
    {
        bool IsComplete { get; set; }
    }
    class House
    {
        public Basement basement { get; }
        public Door door { get; }
        public Roof roof { get; }
        public Wall[] walls { get; }
        public Window[] windows { get; }
        public House()
        {
            this.basement = new Basement();
            this.door = new Door();
            this.roof = new Roof();
            this.windows = new Window[4];
            windows[0] = new Window();
            windows[1] = new Window();
            windows[2] = new Window();
            windows[3] = new Window();
            this.walls = new Wall[4];
            walls[0] = new Wall();
            walls[1] = new Wall();
            walls[2] = new Wall();
            walls[3] = new Wall();
        }
        //public int Length
        //{
        //    get { return walls.Length; }
        //}
        //public Window this[int index]
        //{
        //    get
        //    {
        //        if (index >= 0 && index < windows.Length) return windows[index];
        //        else throw new IndexOutOfRangeException();
        //    }
        //    set
        //    {
        //        windows[index] = value;
        //    }
        //}
        //public Wall this[uint index]
        //{
        //    get
        //    {
        //        if (index >= 0 && index < walls.Length) return walls[index];
        //        else throw new IndexOutOfRangeException();
        //    }
        //    set
        //    {
        //        walls[index] = value;
        //    }
        //}
        public void HouseDone()
        {
            if (this.windows[3].IsComplete)
            {
                WriteLine("*********House done!*********");
                WriteLine("             /\\");
                WriteLine("            /\\ \\");
                WriteLine("           /__\\/");
                WriteLine("           |__|/");
            }
            else WriteLine("House is in progeress...");
        }
        public override string ToString()
        {
            return $"Baismant is done: {this.basement.IsComplete}\n" +
            $"wall 1 is done: {this.walls[0].IsComplete}\n" +
            $"wall 2 is done: {this.walls[1].IsComplete}\n" +
            $"wall 3 is done: {this.walls[2].IsComplete}\n" +
            $"wall 4 is done: {this.walls[3].IsComplete}\n" +
            $"door is done: {this.door.IsComplete}\n" +
            $"roof is done: {this.roof.IsComplete}\n" +
            $"window 1 is done: {this.windows[0].IsComplete}\n" +
            $"window 2 is done: {this.windows[1].IsComplete}\n" +
            $"window 3 is done: {this.windows[2].IsComplete}\n" +
            $"window 4 is done: {this.windows[3].IsComplete}\n";
        }
    }
    class Basement : Ipart
    {
        public static string BasementName { get; } = "Basement";
        public bool IsComplete { get; set; } = false;
    }
    class Wall : Ipart
    {
        public string WallName { get; } = "Wall";
        public bool IsComplete { get; set; } = false;
        public Wall(string WallName = "Wall", bool IsComplete = false)
        {
            this.WallName = WallName;
            this.IsComplete = IsComplete;
        }
    }
    class Door : Ipart
    {
        public bool IsComplete { set; get; } = false;
        public string DoorName { get; set; } = "Door";
        public Door(string DoorName = "Door", bool IsComplete = false)
        {
            this.DoorName = DoorName;
            this.IsComplete = IsComplete;
        }
    }
    class Window : Ipart
    {
        public bool IsComplete { set; get; } = false;
        public string WindowName { get; set; } = "Window";
        public Window(string WindowName = "Window", bool IsComplete = false)
        {
            this.WindowName = WindowName;
            this.IsComplete = (IsComplete);
        }
    }
    class Roof : Ipart
    {
        public bool IsComplete { set; get; } = false;
        public string RoofName { get; set; } = "Roof";
        public Roof(string RoofName = "Roof", bool IsComplete = false)
        {
            this.RoofName = RoofName;
            this.IsComplete = IsComplete;
        }
    }
    internal interface IWorker
    {
        void DoingOnePart(House house);
    }
    class Worker : IWorker
    {
        public virtual void DoingOnePart(House house)
        {
            string str = null;
            if (!house.basement.IsComplete)
            {
                house.basement.IsComplete = true; str = "Фундамент заложил";
            }
            else if (!house.walls[0].IsComplete)
            {
                house.walls[0].IsComplete = true; str = "Первая стена готова";
            }
            else if (!house.walls[1].IsComplete)
            {
                house.walls[1].IsComplete = true; str = "Вторая стена готова";
            }
            else if (!house.walls[2].IsComplete)
            {
                house.walls[2].IsComplete = true; str = "Бог любит Троицу, третья стена готова";
            }
            else if (!house.walls[3].IsComplete)
            {
                house.walls[3].IsComplete = true; str = "Все стены завершил";
            }
            else if (!house.door.IsComplete)
            {
                house.door.IsComplete = true; str = "Никакой опасный зверь не проникнет в эту дверь! Дверь готова";
            }
            else if (!house.roof.IsComplete)
            {
                house.roof.IsComplete = true; str = "До дождя и под крышу завели";
            }
            else if (!house.windows[0].IsComplete)
            {
                house.windows[0].IsComplete = true; str = "Первое окно прорубил, как Петр I  - в Европу";
            }
            else if (!house.windows[1].IsComplete)
            {
                house.windows[1].IsComplete = true; str = "Два окна - пара";
            }
            else if (!house.windows[2].IsComplete)
            {
                house.windows[2].IsComplete = true; str = "И третье окно сделано";
            }
            else if (!house.windows[3].IsComplete)
            {
                house.windows[3].IsComplete = true; str = "Закончил дом";
            }
            else WriteLine("Дом уже построен, я за зарплатой..."); 
            if (str!=null) WriteLine($"Поработал! {str}!");
            if (str =="Закончил дом") house.HouseDone();
        }
    }
    class TeamLeader : Worker, IWorker
    {
        public override void DoingOnePart(House house)
        {
            WriteLine("Are you crazy?! I'm the lazy boss, only paperwork for me!!!\n" +
                "********************TeamLider REPORT***********************\n");
            WriteLine(house);
                double PercentDone = 0;
                if (house.basement.IsComplete) PercentDone += 9.1;
            for (int i = 0; i < house.walls.Length; i++)
            {
                if (house.walls[i].IsComplete) PercentDone += 9.1;
            }
                if (house.door.IsComplete) PercentDone += 9.1;
                if (house.roof.IsComplete) PercentDone += 9.1;
            for (int i = 0; i < house.windows.Length; i++)
            {
                if (house.windows[i].IsComplete) PercentDone += 9.1;
            }
                WriteLine($"{Math.Round(PercentDone)}% of the House done!!!\n");
                if (house.windows[3].IsComplete) house.HouseDone();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            House h1 = new House();
            Worker worker1 = new Worker();
            TeamLeader Lider = new TeamLeader();
            worker1.DoingOnePart(h1);
            worker1.DoingOnePart(h1);
            worker1.DoingOnePart(h1);
            worker1.DoingOnePart(h1);
            worker1.DoingOnePart(h1);
            worker1.DoingOnePart(h1);
            worker1.DoingOnePart(h1);
            worker1.DoingOnePart(h1);
            worker1.DoingOnePart(h1);
            worker1.DoingOnePart(h1);
            worker1.DoingOnePart(h1);
            worker1.DoingOnePart(h1);
            Lider.DoingOnePart(h1);
        }
    }
}
