using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
       public Wall [] walls { get; }
        public House (Basement basement, Wall [] walls, int size =4)
        {
            this.basement = basement;
            this.walls = walls;
        }
        public int Length
        {
            get { return walls.Length; }
        }
        public Wall this[int index]
        {
            get 
            {
                if(index>=0&&index<walls.Length)return walls[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                walls[index] = value;
            }
        }
        public void HouseDone()
        {
            if (this.walls[3].IsComplete)
            {
                WriteLine("House done!");
            }
            else WriteLine("House is in progeress"); 
        }
        public override string ToString()
        {
            return $"Baismant is done: {this.basement.IsComplete}\n"+
            $"wall 1 is done: {this.walls[0].IsComplete}\n" +
            $"wall 2 is done: {this.walls[1].IsComplete}\n" +
            $"wall 3 is done: {this.walls[2].IsComplete}\n" +
            $"wall 4 is done: {this.walls[3].IsComplete}";
        }
    }
    class Basement:Ipart
    {
        public string BasementName { get;  } = "Basement"; 
        public bool IsComplete { get; set; }=false;
    }
    class Wall : Ipart
    {
        public Wall(string WallName = "Wall", bool IsComplete = false) 
        {
            this.WallName = WallName;
            this.IsComplete = IsComplete;
        }
        public string WallName { get; } = "Wall";
        public bool IsComplete { get;set; }=false;
    }
    //class Door:Ipart
    //{
    //    public string Name { get; set; }
    //}
    //class Window:Ipart
    //{
    //    public string Name { get; set; }
    //}
    //class Roof:Ipart
    //{
    //    public string Name { get; set; }
    //}
   internal interface IWorker
    {
        void DoingOnePart(House house); 
    }
    class Worker : IWorker
    {
        public void DoingOnePart (House house)
        {
           if(!house.basement.IsComplete)house.basement.IsComplete = true;
            else if (!house.walls[0].IsComplete) house.walls[0].IsComplete = true;
            else if (!house.walls[1].IsComplete) house.walls[1].IsComplete = true;
            else if (!house.walls[2].IsComplete) house.walls[2].IsComplete = true;
            else if (!house.walls[3].IsComplete) house.walls[3].IsComplete = true;
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Basement base1 = new Basement();
            //base1.IsComplete = false; 
            Wall[] walls1 = new Wall[4];
            walls1[0] = new Wall();
            walls1[1] = new Wall();
            walls1[2] = new Wall();
            walls1[3] = new Wall();
            House h1 = new House(base1, walls1);
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
        }
    }
}
