using System;
class ZooAnimal
{   
        private string _species;
        private double weight;

        public string Species
        {
            get {return _species;}
            set {_species = value;}
        }
        public double  weight
        {
            get {return weight;}
            set {weight = value;}
        }
        public virtual void Sound()
        {
            Console.WriteLine ("Животное издает звук";)
        }
}
class Lion : ZooAnimal
{
    public void Roar()
    {
        Console.WriteLine ("Лев рычит";)
    }
    public override void Sound ()
    {
        Console.WriteLine ("Лев рычит");
    }
}
class Elephant : ZooAnimal
{
    public void Trumpet ()
    {
        Console.WriteLine ("Слон трубит");
    }
    public override void Sound()
    {
        Console.WriteLine ("Слон трубит");
    }
}
class Penguin : ZooAnimal
{
    public void Swim()
    {
        Console.WriteLine("Пингвин плавает");
    }
    public override void Sound()
    {
        Console.WriteLine("Пингвин издает звук");
    }
}
class Program
{
    static void Main()
    {
        Lion lion = new Lion();
        lion.Species = "Лев";
        lion.Weight = 190;
    }
}
