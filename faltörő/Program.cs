using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evrything_or_nothing;
using this_is_the_end;
using teszter;

namespace _6hetes_op
{
    class Program
    {
        static void Main(string[] args)
        {
            tutorial Tutorial = new tutorial();
            Console.SetWindowSize(135, 31);
            Tutorial.tout();
            code CODE = new code();
            Console.SetWindowSize(115, 25);
            CODE.maythebetterlive();
            win WIN = new win();
            Console.SetWindowSize(156, 24);
            for (int i = 0; i < WIN.winner_winner_chicken_dinner().Length; i++)
            {
                Console.WriteLine(WIN.winner_winner_chicken_dinner()[i]);
            }
            //ki nyert
            Console.ReadKey();
        }
    }
}
