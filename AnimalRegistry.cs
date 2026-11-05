using System;
using System.IO;

partial class AnimalRegistry
{
 public void LoadFromFile(string path)
    {
      using(StreamReader reader = new StreamReader("animal.txt"))
      {
        string line;
        while((line = reader.ReadLine()) != null)
        {
           string parts = line.Split(',');
                
        }     
      }
    }   
}