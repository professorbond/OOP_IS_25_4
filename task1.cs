using System;

class ZooAnimal() 
{
    public void ZooAnimal()
    {
        private string _species {get; set; };
        private double _weight {get; set; };

    }
 
    public virtual void sound()
    {
        Console.WriteLine("Животное издает звук");
    }

}

class Lion : ZooAnimal
public Lion(string _species, double _weight)
{
    public roar()
    {
        Console.WriteLine("Лев рычит");
    }
    public override void sound()
    {
        Console.WriteLine("Лев издает звук");
    }
};

class Elephant:ZooAnimal
{
    public trumpet()
    {
        Console.WriteLine("Слон трубит");
    }
    public override void sound()
    {
        Console.WriteLine("Слон издает звук");
    }
}

class Penguin:ZooAnimal
{
    public swim()
    {
        Console.WriteLine("Пингвин плавает");
    }
    public override void sound()
    {
        Console.WriteLine("Пингвин издает звук");
    }
};