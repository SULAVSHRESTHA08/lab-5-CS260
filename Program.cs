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
 public Dog(string name , int age):base(name, age)
 { 
 }
 public override void Speak()
 {
    Console.WriteLine("Woof");
 }   
}