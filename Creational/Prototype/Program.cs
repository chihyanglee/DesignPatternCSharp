using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person();
            p1.Name = "p1";
            p1.Prototype = new Prototype(1);
            // shallow copy
            var p2 = p1.ShallowCopy();
            // deep copy
            var p3 = p1.DeepCopy();
            System.Console.WriteLine($"name    p1  p2  p3");
            System.Console.WriteLine($"        {p1.Name}  {p2.Name}  {p3.Name}");
            System.Console.WriteLine($"protoId p1  p2  p3");
            System.Console.WriteLine($"        {p1.Prototype.Id}   {p2.Prototype.Id}   {p3.Prototype.Id}");

            // change p1
            System.Console.WriteLine("change p1 name to p5");
            p1.Name = "p5";
            System.Console.WriteLine($"name    p1  p2  p3");
            System.Console.WriteLine($"        {p1.Name}  {p2.Name}  {p3.Name}");
            System.Console.WriteLine($"protoId p1  p2  p3");
            System.Console.WriteLine($"        {p1.Prototype.Id}   {p2.Prototype.Id}   {p3.Prototype.Id}");

            // change p1.Prototype.Id
            System.Console.WriteLine("change p1.Prototype.Id to 5");
            p1.Prototype.Id = 5;
            System.Console.WriteLine($"name    p1  p2  p3");
            System.Console.WriteLine($"        {p1.Name}  {p2.Name}  {p3.Name}");
            System.Console.WriteLine($"protoId p1  p2  p3");
            System.Console.WriteLine($"        {p1.Prototype.Id}   {p2.Prototype.Id}   {p3.Prototype.Id}");
        }

        class Prototype
        {
            public int Id { get; set; }
            public Prototype(int id)
            {
                this.Id = id;
            }
        }

        class Person
        {
            public string Name { get; set; }
            public Prototype Prototype { get; set; }
            public Person ShallowCopy()
            {
                return (Person)this.MemberwiseClone();
            }

            public Person DeepCopy()
            {
                // do shallow copy
                var clone = (Person)this.MemberwiseClone();
                clone.Prototype = new Prototype(Prototype.Id);
                clone.Name = string.Copy(this.Name);
                return clone;
            }
        }
    }
}
