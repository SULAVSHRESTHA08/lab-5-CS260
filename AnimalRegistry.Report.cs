using System;
partial class AnimalRegistry
{
  public void PrintAll()
  {
   
   for(int i = 0 ; i < animals.Count ; i++)
   {
    Animal animal = animals.GetAt(i);  
    Console.WriteLine(animal.ToDisplayString()); 
   }
  } 
  public void PrintOldest()
  {
    if (animals.Count == 0)
    {  
     Console.WriteLine("No animals in the shelter.");
     return;
    }
    Animal oldest = animals.Max();
   Console.WriteLine(oldest.ToDisplayString());
  } 
  public void PrintYoungest()
  {
    if (animals.Count == 0)
    {  
     Console.WriteLine("No animals in the shelter.");
     return;
    }
    Animal youngest = animals.Min();
   Console.WriteLine(youngest.ToDisplayString());
  }
  public void PrintAverage()
  {
    int totalAge = 0;
    if (animals.Count == 0)
    {  
     Console.WriteLine("No animals in the shelter.");
     return;
    }
    for(int i = 0; i < animals.Count ; i++)
    {
      Animal animal = animals.GetAt(i);
      totalAge = totalAge + animal.Age;
    }
    double averageAge = (double) totalAge /animals.Count;
    Console.WriteLine($"Average age = {averageAge}");
  }
}