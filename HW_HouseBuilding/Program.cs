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
        public Window this[int index]
        {
            get
            {
                if (index >= 0 && index < windows.Length) return windows[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                windows[index] = value;
            }
        }
        public Wall this[uint index]
        {
            get
            {
                if (index >= 0 && index < walls.Length) return walls[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                walls[index] = value;
            }
        }
        public void HouseDone()
        {
            if (this.windows[3].IsComplete)
            {
                WriteLine("House done!");
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
            if (!house.basement.IsComplete) house.basement.IsComplete = true;
            else if (!house.walls[0].IsComplete) house.walls[0].IsComplete = true;
            else if (!house.walls[1].IsComplete) house.walls[1].IsComplete = true;
            else if (!house.walls[2].IsComplete) house.walls[2].IsComplete = true;
            else if (!house.walls[3].IsComplete) house.walls[3].IsComplete = true;
            else if (!house.door.IsComplete) house.door.IsComplete = true;
            else if (!house.roof.IsComplete) house.roof.IsComplete = true;
            else if (!house.windows[0].IsComplete) house.windows[0].IsComplete = true;
            else if (!house.windows[1].IsComplete) house.windows[1].IsComplete = true;
            else if (!house.windows[2].IsComplete) house.windows[2].IsComplete = true;
            else if (!house.windows[3].IsComplete) house.windows[3].IsComplete = true;
        }
    }
    class TeamLeader : Worker, IWorker
    {
        public override void DoingOnePart(House house)
        {
            WriteLine("Are you crazy?! I'm the lazy boss, only paperwork for me!!!\n" +
                "********************TeamLider REPORT****************\n");
            //base.DoingOnePart(house);
            WriteLine(house);
            double PercentDone = 0;
            if (house.basement.IsComplete) PercentDone += 100 / 11; 
            if (house.walls[0].IsComplete) PercentDone += 100 / 11; 
            if (house.walls[1].IsComplete) PercentDone += 100 / 11; 
            if (house.walls[2].IsComplete) PercentDone += 100 / 11; 
            if (house.walls[3].IsComplete) PercentDone += 100 / 11; 
            if (house.door.IsComplete) PercentDone += 100 / 11; 
            if (house.roof.IsComplete) PercentDone += 100 / 11;
            if (house.windows[0].IsComplete) PercentDone += 100 / 11;
            if (house.windows[1].IsComplete) PercentDone += 100 / 11;
            if (house.windows[2].IsComplete) PercentDone += 100 / 11;
            if (house.windows[3].IsComplete) PercentDone += 100 / 11;
            WriteLine($"{PercentDone}% of the House done!!!\n"); 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Basement base1 = new Basement();
            ////base1.IsComplete = false; 
            //Wall[] walls1 = new Wall[4];
            //walls1[0] = new Wall();
            //walls1[1] = new Wall();
            //walls1[2] = new Wall();
            //walls1[3] = new Wall();
            House h1 = new House();
            Worker worker1 = new Worker();
            worker1.DoingOnePart(h1);
            WriteLine(h1);
            h1.HouseDone();
            worker1.DoingOnePart(h1);
            WriteLine(h1);
            h1.HouseDone();
            worker1.DoingOnePart(h1);
            WriteLine(h1);
            h1.HouseDone();
            worker1.DoingOnePart(h1);
            WriteLine(h1);
            h1.HouseDone();
            worker1.DoingOnePart(h1);
            WriteLine(h1);
            h1.HouseDone();
            TeamLeader Lider = new TeamLeader();
            Lider.DoingOnePart(h1);
            
        }
    }
}
