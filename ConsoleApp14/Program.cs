using System;

namespace ConsoleApp14
{
    class Program
    {
        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }

        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }

        static void Main(string[] args)
        {
            Difficulty level = 0;
            double score = 0.0;
            bool main = true; 
            bool checkn = true; 
            bool setting = true;
            double levels = 0;
            while(main == true)
            {
                Console.WriteLine("Score : {0}, Difficulty : {1}", score, level);
                int n = int.Parse(Console.ReadLine());
                if(n !=0 && n!= 1 && n != 2)
                {
                    while (checkn == true)
                    {
                        Console.WriteLine("Please input 0-2");
                        n = int.Parse(Console.ReadLine());
                        if (n == 0 || n == 1 || n == 2)
                        {
                            checkn = false;
                        }
                    }
                }
                if (n == 0)
                {
                    if (levels == 0)
                    {
                        int easy = 3;
                        levels = 0;
                        game(easy, levels, ref score);
                    }
                    else if (levels == 1)
                    {
                        int normal = 5;
                        levels = 1;
                        game(normal, levels, ref score);
                    }
                    else if (levels == 3)
                    {
                        int hard = 7;
                        levels = 2;
                        game(hard, levels, ref score);
                    }
                }
                else if (n == 1)
                {
                    while (setting == true)
                    {
                        int numsetting = int.Parse(Console.ReadLine());
                        if (numsetting == 0)
                        {
                            level = Difficulty.Easy;
                            setting = false;
                        }
                        else if (numsetting == 1)
                        {
                            level = Difficulty.Normal;
                            setting = false;
                        }
                        else if (numsetting == 2)
                        {
                            level = Difficulty.Hard;
                            setting = false;
                        }
                        else
                        {
                            setting = true;
                        }
                    }
                }
                else if (n == 2)
                {
                    main = false;
                }
            }
        }

        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }

            return randomProblems;
        }

        static void game(int n, double level, ref double S)
        {
            double QC = 0;
            long time1 = DateTimeOffset.Now.ToUnixTimeSeconds();
            Problem [] random;
            for(int i = 1; i <= n; i++)
            {
                random = GenerateRandomProblems(n);
                Console.WriteLine(random[0].Message);
                int x = int.Parse(Console.ReadLine());
                if(x == random[0].Answer)
                {
                    QC++;
                }
            }
            long time2 = DateTimeOffset.Now.ToUnixTimeSeconds();
            double T = time2 - time1;

            S = (QC / n) * ((25.00 - Math.Pow(level, 2)) / (Math.Max(T, 25 - Math.Pow(level, 2)))) * (Math.Pow(((2 * level) + 1.0), 2));
            //Console.WriteLine(QC / n);
            //Console.WriteLine((25.0 - Math.Pow(level, 2)));
            //Console.WriteLine((Math.Max(T, 25 - Math.Pow(level, 2))));
            //Console.WriteLine((25.0 - Math.Pow(level, 2) / (Math.Max(T, 25 - Math.Pow(level, 2)))));
            //Console.WriteLine(Math.Pow(((2 * level) + 1.0), 2));
            //Console.WriteLine(time2 - time1);
        }
    }
}
