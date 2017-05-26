using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class FileManagement2
{
    private string fileName; 
    public FileManagement2(string name)
    {
        fileName = name; 
      
    }
    public void read()
    {

        foreach (string line in File.ReadLines(fileName, Encoding.UTF8))
        {
            Console.WriteLine(line);

        }

    }
    public void insertLine( string line)
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true);
        file.WriteLine(line);
        file.Close();

    }
    public void deleteLine(string lineToDelete)
    {
        var lines = File.ReadAllLines(fileName);
        File.WriteAllLines(fileName, lines.Where(li => li != lineToDelete));
      
    }
    public void modifyLine(string newLine, int num)
    {
        int counter = 1;
        string line = "";

        using (StreamWriter newTask = new StreamWriter("prueba3.txt", false))
        {
            using (StreamReader file = new System.IO.StreamReader(fileName))
            {
                while (((line = file.ReadLine()) != null) && (counter < num))
                {
                    newTask.WriteLine(line);
                    counter++;
                }
                newTask.WriteLine(newLine);
                while ((line = file.ReadLine()) != null)
                {
                    newTask.WriteLine(line);

                }

            }
               
        }
        File.Delete("prueba.txt");
        System.IO.File.Move("prueba3.txt", "prueba.txt");
        


    }

    public void deleteByNumLine(int numLine)
    {
        int counter = 1;
        string line = "";

        using (StreamWriter newTask = new StreamWriter("prueba3.txt", false))
        {
            using (StreamReader file = new System.IO.StreamReader(fileName))
            {
                while (((line = file.ReadLine()) != null) && (counter < numLine))
                {
                    newTask.WriteLine(line);
                    counter++;
                }
                newTask.WriteLine("");
                while ((line = file.ReadLine()) != null)
                {
                    newTask.WriteLine(line);

                }

            }

        }
        File.Delete("prueba.txt");
        System.IO.File.Move("prueba3.txt", "prueba.txt");

    }

}

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = Console.ReadLine();
            FileManagement2 fileTest = new FileManagement2(fileName);
            fileTest.read();
            fileTest.insertLine( "Jorge, 50, Argentina");
            fileTest.deleteLine("Maria,30, Mexico");
            fileTest.modifyLine("Adriana, 46, Espana", 3);
            Console.ReadLine();

        }
    }
}
