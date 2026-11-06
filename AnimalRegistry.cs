using System;
using System.IO;

partial class AnimalRegistry
{
 //Field: lives as long as the animal REgistry object does 
 private Shelter<Animal>  animals = new Shelter<Animal>(10); 
 public void LoadFromFile(string path)
    {
      try
      {
      using(StreamReader reader = new StreamReader(path))
      {
        string line;
        while((line = reader.ReadLine()) != null)
        {
           string[] parts = line.Split(',');
           if (parts.Length != 3)
           {
            Console.WriteLine($"Warning: Invalid Line: {line}");
            continue;
           }
           string type = parts[0].Trim();
           string name = parts[1].Trim();
           bool success =  int.TryParse(parts[2].Trim(),out int age);
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
                else
                {
                  Console.WriteLine($"Warning: Unknown animal type '{type}' on line: {line}");
                }    
           } 
           else
           {
            Console.WriteLine($"Warning: Invalid age on line: {line}");
           }        
        }     
      }
    }  
    catch (FileNotFounException)
    {
     Console.WriteLine("Error: File not found. Please check the path and try again.");
    }
    catch (IOException ex )
    {
      Console.WriteLine($"Error reading File: {ex.Message}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error reading file: {ex.Message}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An unexpected error occured: {ex.Message}");
    }
}
}