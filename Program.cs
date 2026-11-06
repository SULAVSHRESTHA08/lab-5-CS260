using System;
using System.IO;


// Animal base class
abstract class Animal :IComparable<Animal> //abstract animal class created 
{
    public string Name{get; set;}  //set the property
    public int Age {get;set;}
    public Animal(string name, int age) //Constructor created and variable are set
    {
        Name = name;
        Age = age;
    }
    public int CompareTo(Animal other) //initialized the compare to method that compares the object by their age 
    {
        return this.Age.CompareTo(other.Age);  // this => other i.e assending order comparision 
    }
    public abstract  void Speak(); // initialied the abstrat  speak method so that other animal child class must override. 
}
sealed class Dog : Animal
{
 public Dog(string name , int age):base(name, age) // passed from the base constructor
 { 
 }
 public override void Speak()
 {
    Console.WriteLine("Woof");
 }   
}
sealed class Cat : Animal
{
    public Cat(string name, int age): base(name, age)
    {
    }
    public override void Speak()
    {
        Console.WriteLine("Meow");
    }
}
class Shelter<T> where T :Animal, IComparable<T>
{
    private T[] items;
    public int Count{get; private set;}
    public Shelter(int capacity = 10)
    {
        items = new T[capacity]; 
        Count = 0;
    }
    public void Add(T item)
    {
        if (Count == items.Length)
        {
            Grow();// grow if necessary when the array is full
        }
        items[Count] = item; //add the item into the next available index
     
        Count = Count +1; //Increase the count 
    }
    public void Grow()
    {
        T[] grow = new T[items.Length *2]; // increase the array length of items 
        for(int i = 0; i< Count; i++) // looping to copy theold item to the new array grow
        {
          grow[i] = items[i];
        }
        items = grow;  // after copying giving item a new more bigger space to store more and its a reference 
    }
    public  T Max()
    {
     if (Count == 0)
     {
      throw new InvalidOperationException("Shelter is Empty");         
     }
     T maxAnimal = items[0]; //initialized the oldest one as the maximum one 
     for( int i = 1 ; i< Count ; i++)
        {
         if( items[i].CompareTo(maxAnimal) > 0) // compare to find the maximum one,> 0  means current object is greater than the other  
            {
                maxAnimal = items[i]; //replace the maximum animal
            }   
        } 
      return maxAnimal; // returning the oldest animal 
    }
    public T Min()
    {
     if (Count == 0)
     {
       throw new InvalidOperationException("Shelter is Empty");        
     }
     T minAnimal = items[0];
     for(int i = 1 ; i < Count ; i++)
     {
      if(items[i].CompareTo(minAnimal)<0) // current object less than the other then younger 
        {
         minAnimal = items[i];         
        }        
     }
     return minAnimal; // return the youngest animal by their age  
    }
    // key to access the animal on specific index
    // Returns the animal at the specified index
    public T GetAt(int index)
    {
        if (index < 0 || index >=Count)
        {
            throw new ArgumentOutOfRangeException();
        }   
            return items[index];
    }
}
static class AnimalExtensions //extension must be contained on static class 
{
    public static string ToDisplayString(this Animal a)
    {
      if( a == null)
        {
            throw new ArgumentNullException(nameof(a)); // chceking if the values are null or not 
        }
        else
        {
            return $"{a.Name} ({a.GetType().Name}, {a.Age} years)"; //returning the string version a.GetType().Name gives you whether the object is dog or cat (type)
        }    
    }
}
class Program
{
 static void Main(string[]args)
 {
    AnimalRegistry registry = new AnimalRegistry();
    try
    {
     registry.LoadFromFile("animal.txt");
     registry.PrintAll();
     registry.PrintOldest();
     registry.PrintYoungest();
     registry.PrintAverage();
    }
    catch(FileNotFoundException)
    {
      Console.WriteLine("Animal data file was not found");        
    }
 }    
}