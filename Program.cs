using System;

 public class ZooAnimal
 {
     private string species;
     private double weight;
     
     public string Species
     {
         get{return species;}
         set{species=value;}
     }
     public double Weight
     {
         get{return weight;}
         set{weight=value;}
         
     }
     public ZooAnimal(string species, double weight)
     {
         species=species;
         weight=weight;
     }
     
     public virtual void sound()
     {
         Console.WriteLine("животное издает звук:");
     }
 }

class Lion:ZooAnimal
{
    public Lion(double weight):base("Lyova", weight) {}
    
    public void roar()
    {
        Console.WriteLine("Лев издает звук");
    }
    
    public override void sound()
    {
        Console.WriteLine("Ryaaaar!");
    }
}

class Elefant:ZooAnimal
{
    public Elefant(double weight):base("Dambo", weight) {}
    
    public void trumpet()
    {
        Console.WriteLine("Slon-Dambo издает звук");
    }
    
    public override void sound()
    {
        Console.WriteLine("Duoooooo!");
    }
}

class Pinguin:ZooAnimal
{
    public Pinguin(double weight):base("Kovalski", weight) {}
    
    public void swim()
    {
        Console.WriteLine("Kovalski na missii");
    }
    
    public override void sound()
    {
        Console.WriteLine("Priem!");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("test:");
        Lion lion = new Lion(200);
        Elefant elefant = new Elefant(2000);
        Pinguin pinguin = new Pinguin(50);
        
        lion.roar();
        elefant.trumpet();
        pinguin.swim();
        
        lion.sound();
        elefant.sound();
        pinguin.sound();
    }
}



