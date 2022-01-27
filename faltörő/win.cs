using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace this_is_the_end
{
    class win
    {
        //konstruktor
        public win()
        {

        }
        public string[] winner_winner_chicken_dinner()
        {
            int hossz = File.ReadAllLines("CONGRATS.txt").Count();
            string[] storage = new string[hossz];   
            FileStream fs = new FileStream("CONGRATS.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
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
    }
}
