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
    public void insertData( string line)
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
    public void modified(string newLine, int num)
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
            

    }



}



namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManagement2 fileTest = new FileManagement2("prueba.txt");
            fileTest.read();
            fileTest.insertData( "holi");
            fileTest.deleteLine("Hector Ricardo");
            fileTest.modified("hola", 3);
            Console.ReadLine();

        }
    }
}
