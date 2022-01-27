using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evrything_or_nothing
{
    class code
    {
        private int height;
        private int width;
        private int roundcount;
        private string[,] map;
        private static Random r = new Random();
        private int[] numbers;
        private int count;
        private int lastshotx;
        private int lastshoty;
        private string tab;
        private string nullcell;
        private int[] randomcolors;
        public int HEIGHT
        {
            get { return height; }
            set { height = value; }
        }
        public int WIDTH
        {
            get { return width; }
            set { width = value; }
        }
        public int ROUNDCOUNT
        {
            get { return roundcount; }
            set { roundcount = value; }
        }
        //konstruktor
        public code()
        {
            int a = 0;
            while(a<4 || a > 7)
            {
                Console.WriteLine("kérlek add meg a pálya kívánt magasságát (4<=magasság<=7) : ");
                a = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
            height = a;
            a = 0;
            while (a < 3 || a > 8)
            {
                Console.WriteLine("kérlek add meg a pálya kívánt szélességét (3<=szélesség<=8) : ");
                a = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
            width = a;
            roundcount = 0;
            string tabulator0 = "                                                ";
            tab = tabulator0.Substring(0, 96 / width);
            nullcell = '0' + tab;
            map = MAP();
            numbers = new int [1000];
            randomcolors = new int[3];
        }
        public string[,] MAP()
        {
            string[,] map = new string[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = '0' + tab;
                }
            }
            return map;
        }
        public void randloader()
        {
            while(randomcolors[0]== randomcolors[1]|| randomcolors[0] == randomcolors[2] || randomcolors[1] == randomcolors[2])
            {
                for (int i = 0; i < 3; i++)
                {
                    randomcolors[i] = r.Next(1, 7);
                }
            }
        }
        public int[] randomnumber()
        {
            if (roundcount == 0)
            {
                numbers[0] = randomcolors[r.Next(0, 3)];
                numbers[1] = randomcolors[r.Next(0, 3)];
                while (numbers[0] == numbers[1])
                {
                    numbers[1] = randomcolors[r.Next(0, 3)];
                }
            }
            else
            {
                numbers[roundcount + 1] = randomcolors[r.Next(0, 3)];
                while (numbers[roundcount] == numbers[roundcount + 1])
                {
                    numbers[roundcount + 1] = randomcolors[r.Next(0, 3)];
                }
            }
            return numbers;
        }
        public string[,] roundzero()
        {
                for (int i = 0; i < width; i++)
                {
                    map[0, i] = Convert.ToString(randomcolors[r.Next(0, 3)]) + tab;
                }
            return map;
        }
        public void colors(char a)
        {
            switch (a)
            {
                case '0':
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case '1':
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case '2':
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case '3':
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case '4':
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case '5':
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case '6':
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case '7':
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
        }
        public void output()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    colors(map[i, j][0]);
                    Console.Write(map[i, j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
                Console.WriteLine();
                for (int k = 0; k < ((96 / width) + 2) * width; k++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("-");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void next_projectile()
        {
            Console.SetCursorPosition(0, 0);
            if (roundcount % 2 == 0)
            {
                Console.Write("Építő : a téglád színe: ");
            }
            else
            {
                Console.Write("Romboló : az ágyúgolyód színe : ");
            }
            colors(Convert.ToChar(Convert.ToString(numbers[roundcount])));
            Console.WriteLine("        ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public int nextstep()
        {
            int maxycoordinate = height * 2;
            int cursorLeft = ((((96 / width) * width) + (2 * width)) / 2);
            if (width % 2 == 0)
            {
                cursorLeft -= (((96 / width) + 4) / 2);
                lastshotx = (width / 2) - 1;
            }
            else
            {
                lastshotx = (width / 2);
            }
            Console.SetCursorPosition(cursorLeft, maxycoordinate + 1);
            bool turnOver = false;
            Console.Write('X');
            Console.SetCursorPosition(cursorLeft, maxycoordinate + 1);
            while (turnOver != true)
            {
                int lastposition = 0;
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (Console.CursorLeft > (((96 / width) + 2) / 2) && key.Key == ConsoleKey.LeftArrow)
                {
                    lastposition = cursorLeft;
                    cursorLeft -= ((96 / width) + 2);
                    Console.SetCursorPosition(cursorLeft, ((height * 2) + 1));
                    Console.WriteLine('X');
                    Console.SetCursorPosition(lastposition, ((height * 2) + 1));
                    Console.WriteLine(" ");
                    lastshotx--;
                }
                else if (Console.CursorLeft < (((96 + (width * 2) + 2)) - (96 / width) - 2) && key.Key == ConsoleKey.RightArrow)
                {
                    lastposition = cursorLeft;
                    cursorLeft += ((96 / width) + 2);
                    Console.SetCursorPosition(cursorLeft, ((height * 2) + 1));
                    Console.WriteLine('X');
                    Console.SetCursorPosition(lastposition, ((height * 2) + 1));
                    Console.WriteLine(" ");
                    lastshotx++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    turnOver = true;
                }
                Console.SetCursorPosition(cursorLeft, maxycoordinate + 1);
            }
            Console.SetCursorPosition(0, maxycoordinate + 1);
            return lastshotx;
        }
        public int ycoordinate()
        {
            int i = 0;
            bool caught = false;
            while (!caught && i < map.GetLength(1))
            {
                if (map[i, lastshotx][0] == '0')
                {
                    lastshoty = i;
                    caught = true;
                }
                else
                {
                    i++;
                }
            }
            if (!caught)
            {
                lastshoty = -1;
            }
            return lastshoty;
        }
        public void CELLINSERTER()
        {
            ycoordinate();//ha van eleme az oszlopnak, de nincs teli
            if (lastshoty <= (height - 1) && lastshoty > 0)
            {
                map[lastshoty, lastshotx] = Convert.ToString(numbers[roundcount]) + tab;
            }
            else if (lastshoty == -1)//ha teli van az oszlop
            {

            }
            else if (lastshoty == 0)//ha üres az oszlop
            {
                map[0, lastshotx] = Convert.ToString(numbers[roundcount]) + tab;
            }
            lastshotx = 0;
        }
        public void CELLDESTROY(int negY)//0,-1 ha a saját oszlopa, 1,0 ha ajobbra lévő oszlop, -1,0ha a balra lévő oszlop
        {                                         //ezt magában a destroyer programban kell majd vizsgálni hogy melyik eset
            ycoordinate();
            bool hit = false;
            string examined = numbers[roundcount] + tab;
            if (lastshoty + negY >= 0 && lastshoty + negY < height)
            {
                if (map[lastshoty + negY, lastshotx] == examined)//ha nullcell akkor nem kezeli, mellé lőtt a felhasználó a falnak
                {
                    map[lastshoty + negY, lastshotx] = nullcell;
                    hit = true;
                }
                else if (map[lastshoty + negY, lastshotx] != examined && lastshoty != 0)
                {
                    CELLINSERTER();
                }
            }
            else if (lastshoty == -1 && map[height - 1, lastshotx] == examined)//ha fullon van a tömb, de az utolsó rombolható
            {
                map[lastshoty + height, lastshotx] = nullcell;
                hit = true;
            }
            else if (lastshoty == 0)//ha a 0.cella üres , komment kivétele : üres oszlopba beépíti a lövedéket , bármilyen színű is legyen az
            {
                //CELLINSERTER();
            }

            if (lastshoty == -1)
            {
                negY += height + 1;
            }

            if (hit && lastshotx < width - 1 && lastshotx > 0)//középen van nem szélen vízszintesen
            {
                if (map[lastshoty + negY, lastshotx - 1] == examined)
                {
                    map[lastshoty + negY, lastshotx - 1] = nullcell;
                    if (lastshoty != -1)
                    {
                        CELLGAPCLEANER(-1);
                    }
                }
                if (map[lastshoty + negY, lastshotx + 1] == examined)
                {
                    map[lastshoty + negY, lastshotx + 1] = nullcell;
                    if (lastshoty != -1)
                    {
                        CELLGAPCLEANER(1);
                    }
                }
            }
            else if (hit && lastshotx == 0)//bal szélen van
            {
                if (map[lastshoty + negY, lastshotx + 1] == examined)
                {
                    map[lastshoty + negY, lastshotx + 1] = nullcell;
                    if (lastshoty != -1)
                    {
                        CELLGAPCLEANER(1);
                    }
                }
            }
            else if (hit && lastshotx == width - 1)//jobb szélen van
            {
                if (map[lastshoty + negY, lastshotx - 1] == examined)
                {
                    map[lastshoty + negY, lastshotx - 1] = nullcell;
                    if (lastshoty != -1)
                    {
                        CELLGAPCLEANER(-1);
                    }
                }
            }
            lastshotx = 0;
        }
        public void CELLGAPCLEANER(int negX)
        {
            if (map[lastshoty, lastshotx + negX] != nullcell && lastshoty != -1)
            {
                string swap = "";
                int traded = 0;
                for (int i = lastshoty; i < height; i++)
                {
                    swap = map[lastshoty - 1 + traded, lastshotx + negX];
                    map[lastshoty - 1 + traded, lastshotx + negX] = map[lastshoty + traded, lastshotx + negX];
                    map[lastshoty + traded, lastshotx + negX] = swap;
                    traded++;
                    if (map[lastshoty - 1 + traded, lastshotx + negX] != nullcell)
                    {
                        i = height;
                    }
                }
            }
        }

        public void maythebetterlive()
        {
            if (roundcount == 0)
            {
                randloader();
                MAP();
                roundzero();
            }
            while (counter() < (width * height) && counter() > 0)
            {
                randomnumber();
                next_projectile();
                output();
                nextstep();
                Console.Clear();
                if (roundcount % 2 == 0)
                {
                    CELLINSERTER();
                }
                else
                {
                    CELLDESTROY(-1);
                }
                roundcount++;
            }
            if (counter() == height * width)
            {
                Console.WriteLine("Nyert a romboló");
            }
            else if (counter() == 0)
            {
                Console.WriteLine("Nyert az építő");
            }
        }
        public int counter()
        {
            count = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j][0] == '0')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
