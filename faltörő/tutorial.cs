using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace teszter
{
    class tutorial
    {
        public tutorial()
        {

        }
        public string[] read_the_file()
        {
            int hossz = File.ReadAllLines("tutorial.txt").Count();
            string[] storage = new string[hossz];

            FileStream fs = new FileStream("tutorial.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            int i = 0;
            while (!sr.EndOfStream)//(!EndOfStream)==(!eof)
            {
                storage[i] = sr.ReadLine();
                i++;
            }
            sr.Close();
            fs.Close();
            return storage;
        }
        public void tout()
        {
            Console.WriteLine();
            Console.WriteLine("                           Üdvözöllek a Faltörő játékban");
            Console.WriteLine();
            Console.WriteLine("A Tutorial : 'T' - billentyű lenyomásával érhető el ");
            Console.WriteLine("A játék Tutorial nélküli idítása : 'Enter' - lenyomásával");
            Console.Write("kérlek válassz : ");
            bool turn_over = false;
            while(turn_over!=true)
            {
                ConsoleKeyInfo key0 = Console.ReadKey(true);
                if (key0.Key == ConsoleKey.T)
                {
                    Console.WriteLine();
                    for (int i = 0; i < read_the_file().Length; i++)
                    {
                        Console.WriteLine(read_the_file()[i]);
                    }
                    bool ending = false;
                    Console.WriteLine();
                    Console.WriteLine("készen állsz? ('Enter' lenyomása)");
                    while (ending == false)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                        {
                            ending = true;
                        }
                    }
                    turn_over = true;
                }
                else if(key0.Key==ConsoleKey.Enter)
                {
                    turn_over = true;
                }
            }
            Console.Clear();
        }
    }
}
