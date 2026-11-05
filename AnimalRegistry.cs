using System;
using System.IO;

partial class AnimalRegistry
{
 public void LoadFromFile(string path)
    {
      using(StreamReader reader = new StreamReader(path))
      {
        string line;
        while((line = reader.ReadLine()) != null)
        {
           string[] parts = line.Split(',');
           string type = parts[0];
           string name = parts[1];
           bool success =  int.TryParse(parts[2],out int age);
           if(success)
           {
                // age now holds the valid integer value
                // Check if the types are correct or not and create an object according to its type 
                if(type == "Dog")
                {
                  Dog dog = new Dog(name, age);  // Creating dog object 
                  animals.Add(dog); //Storing the dog object on the shelter 
                } 
                else if( type == "Cat")
                {
                  Cat cat = new Cat(name, age);  // Creting cat bject       
                  animals.Add(cat); //Stroing the cat object   
                }    
           }       
        }     
      }
    }   
}