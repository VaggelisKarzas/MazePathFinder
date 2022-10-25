using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazePathFinder
{
    public class Program
    {
        public static String[] method = new string[] { "U", "D", "L", "R" };
        public static int timeout = 2;
        
        static void Main(string[] args)
        {
            String solution;

            string[,] maze = new string[,]{
           {"X","X","X","S","X","X","X","X","X","X","X","X","X"},
           {"X","X","X"," ","X","X","X"," "," "," "," "," ","X"},
           {"X","X"," "," "," ","X","X","X","X"," ","X"," ","X"},
           {"X","X"," ","X"," ","X","X","X","X"," ","X"," ","X"},
           {"X","X"," ","X"," ","X","X","X","X"," ","X","X","X"},
           {"X","X"," ","X"," "," ","X","X","X"," ","X","X","X"},
           {"X","X"," "," "," "," ","X","X","X"," ","X","X","X"},
           {"X"," ","X"," ","X"," ","X","X","X"," ","X","X","X"},
           {"X"," ","X"," ","X"," ","X"," "," "," ","X","X","X"},
           {"X"," "," "," ","X"," "," "," ","X"," ","X","X","X"},
           {"X","X","X"," ","X","X","X","X","X"," ","X","X","X"},
           {"X","X","X"," ","X","X","X","X","X"," ","X","X","X"},
           {"X","X","X"," "," "," "," "," "," "," "," ","X","X"},
           {"X","X","X","X","X","X","X","X","X"," ","X","X","X"},
           {"X","X","X"," ","X","X","X","X","X"," ","X","X","X"},
           {"X","X","X"," ","X","X","X"," "," "," "," "," ","X"},
           {"X","X"," "," "," ","X","X","X","X"," ","X"," ","X"},
           {"X","X"," ","X"," ","X","X","X","X"," ","X"," ","X"},
           {"X","X"," ","X"," ","X","X","X","X"," ","X","X","X"},
           {"X","X"," ","X"," "," ","X","X","X"," ","X","X","X"},
           {"X","X"," "," ","X"," ","X","X","X"," ","X","X","X"},
           {"X"," ","X"," ","X"," ","X","X","X"," ","X","X","X"},
           {"X"," ","X"," ","X"," ","X"," "," "," ","X","X","X"},
           {"X"," "," "," ","X"," "," "," ","X"," ","X","X","X"},
           {"X","X","X"," ","X","X","X","X","X"," ","X","X","X"},
           {"X","X","X"," ","X","X","X","X","X"," "," ","X","X"},
           {"X","X","X"," ","X","X","X","X","X"," ","X","X","X"},
           {"X","X","X"," ","X","X","X","X","X"," ","X","X","X"},
           {"X","X","X"," ","X","X","X"," "," "," "," "," ","X"},
           {"X","X","X"," "," ","X","X"," ","X","X","X"," ","X"},
           {"X","X"," ","X","X","X","X"," ","X"," ","X"," ","X"},
           {"X","X"," ","X"," ","X","X"," ","X"," ","X","X","X"},
           {"X","X"," ","X"," "," ","X"," ","X"," ","X","X","X"},
           {"X","X"," "," ","X"," ","X"," "," "," ","X","X","X"},
           {"X"," ","X"," ","X"," ","X","X","X"," ","X","X","X"},
           {"X"," ","X"," ","X"," ","X"," "," "," ","X","X","X"},
           {"X"," "," "," ","X"," "," "," ","X"," ","X","X","X"},
           {"X","X","X"," ","X","X","X","X","X"," ","X","X","X"},
           {"X","X","X"," ","X","X","X","X","X"," ","X","X","X"},
           {"X","X","X","X"," "," "," "," "," "," "," ","X","X"},
           {"X","X","X","X"," ","X","X","X","X"," ","X","X","X"},
           {"X","X","X"," "," ","X","X","X","X","X","X","X","X"},
           {"X","X","X"," ","X","X","X"," "," "," "," "," ","X"},
           {"X","X"," "," "," ","X","X","X","X"," ","X"," ","X"},
           {"X","X"," ","X"," ","X","X","X","X"," ","X"," ","X"},
           {"X","X"," ","X"," ","X","X","X","X"," ","X","X","X"},
           {"X","X"," ","X"," "," ","X","X","X"," ","X","X","X"},
           {"X","X"," "," ","X"," ","X","X","X"," ","X","X","X"},
           {"X"," ","X"," ","X"," ","X","X","X"," ","X","X","X"},
           {"X"," ","X"," ","X"," ","X"," "," "," ","X","X","X"},
           {"X"," "," "," ","X"," "," "," ","X"," ","X","X","X"},
           {"X","X","X"," ","X","X","X","X","X"," ","F","X","X"},
           {"X","X","X","X","X","X","X","X","X","X","X","X","X"},
            };

            printMaze(maze);

            solution = solveMaze(maze);

            print(solution);
          
            printMaze(maze, solution);
        }

        /// <summary>
        /// Function that returns the starting point of the maze
        /// </summary>
        /// <param name="maze"></param>
        /// <returns>
        /// Returns the position i,j
        /// </returns>
        public static int[] findStart(string[,] maze)
        {
            int[] start= new int[2] {1,2};

            for (int i = 0; i < maze.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= maze.GetLength(1)-1; j++)
                {
                    
                    if (maze[i,j].Equals("S"))
                    {
                        start[0] = i;
                        start[1] = j;
                        break;

                    }
                }
            }
            
            return start;
            
        }

        /// <summary>
        /// Function that prints the maze and the solution path
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="solution"></param>
        public static void printMaze(string[,] maze, String solution)
        {
            if (solution.Equals("NoValidPath") || solution.Equals("OutOfTime") || solution == null)
                return;

            int[] start = findStart(maze);
            
                int i = start[0];
                int j = start[1];
                foreach (char c2 in solution)
                {

                    if (c2.Equals('U'))
                    {
                        i = i - 1;
                    }
                    else if (c2.Equals('D'))
                    {
                        i = i + 1;
                    }
                    else if (c2.Equals('L'))
                    {
                        j = j - 1;
                    }
                    else if (c2.Equals('R'))
                    {
                        j = j + 1;
                    }
                    
                    maze[i, j] = "*";

                }

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                    Console.Write("   ");
                }

                Console.WriteLine("");

            }
        }

        /// <summary>
        /// Function that checks if the next move is a solution of the current path
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        public static bool isSolution(string[,] maze, Queue<string> queue)
        {
            int[] start = findStart(maze);

            try
            {
                String final = queue.Peek();

                int i = start[0];
                int j = start[1];
                foreach (char c2 in final)
                {

                    if (c2.Equals('U'))
                    {
                        i = i - 1;
                    }
                    else if (c2.Equals('D'))
                    {
                        i = i + 1;
                    }
                    else if (c2.Equals('L'))
                    {
                        j = j - 1;
                    }
                    else if (c2.Equals('R'))
                    {
                        j = j + 1;
                    }

                    if (maze[i, j + 1].Equals("F"))
                        return true;
                    else if (maze[i, j - 1].Equals("F"))
                        return true;
                    else if (maze[i + 1, j].Equals("F"))
                        return true;
                    else if (maze[i - 1, j + 1].Equals("F"))
                        return true;
                }
            }
            catch
            {
                return false;
            }
            
            return false;

        }

        /// <summary>
        /// Function that checks whether a move is valid or not
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="currentpath"></param>
        /// <returns></returns>
        public static bool isValid(string[,] maze, string currentpath)
        {
            int[] start = findStart(maze);          

            int i = start[0];
            int j = start[1];

            foreach (char s in currentpath)
            {
                
                if (s.Equals('U'))
                {
                    i =i-1;
                }
                else if(s.Equals('D'))
                {
                    i = i + 1;
                }
                else if(s.Equals('L'))
                {
                    j=j-1;
                }
                else if(s.Equals('R'))
                {
                    j=j+1;
                }
            }

            if (i >= 0 && j >= 0)
                if (maze[i, j].Equals(" "))
                {
                    return true;
                }
            return false;
        }

        /// <summary>
        /// Function that fills the maze with the all the moves it has done so that it doesn't backtrack 
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="current"></param>
        /// <returns>
        /// Returns the maze filled with the correct path at a given time
        /// </returns>
        public static string[,] backtrackMapUpdate(string[,] maze ,String current)
        {
            int[] start = findStart(maze);

            int i = start[0];
            int j = start[1];
            foreach (char s in current)
            {

                if (s.Equals('U'))
                {
                    i = i - 1;
                }
                else if (s.Equals('D'))
                {
                    i = i + 1;
                }
                else if (s.Equals('L'))
                {
                    j = j - 1;
                }
                else if (s.Equals('R'))
                {
                    j = j + 1;
                }

                if(i >= 0 &&j>0)
                maze[i, j] = "O";
            }
             return maze;
            
        }

        /// <summary>
        /// Function that implements the bfs algorithm through a queue system
        /// </summary>
        /// <param name="maze"></param>
        /// <returns>
        /// Returns a string with the solution
        /// </returns>
        public static String solveMaze(string[,] maze)
        {         
            String[,] copy = copyArray(maze);

            Queue<String> myQueue = new Queue<string>();
            myQueue.Enqueue("");
            String path;
            String current;
            bool issolution = false;

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
             
            while (!issolution && stopWatch.ElapsedMilliseconds < timeout * 1000)
            {
                try 
                {
                    path = myQueue.Dequeue(); 
                }
                catch (Exception)
                {
                    
                    stopWatch.Stop();
                    return "NoValidPath";
                }
                               
                foreach(string method in Program.method)
                {
                
                    current = path + method;
                    if(isValid(copy, current))
                    {
                        myQueue.Enqueue(current);
                        copy = backtrackMapUpdate(copy, current);
                    }
                }  
                
                issolution = isSolution(copy, myQueue);
            }

            if (stopWatch.ElapsedMilliseconds > timeout * 1000)
                return "OutOfTime";

            return myQueue.Peek();
        }

        /// <summary>
        /// Function that can copy an array
        /// </summary>
        /// <param name="array"></param>
        /// <returns> 
        /// Returns the copied array
        /// </returns>
        public static string[,] copyArray(string[,] array)
        {
            String[,] copy = new string[array.GetLength(0), array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    copy[i, j] = array[i, j];
                }
            }

            return copy;
        }

        /// <summary>
        /// Function that prints the maze without the solution
        /// </summary>
        /// <param name="array"></param>
        public static void printMaze(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                    Console.Write("   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------------");
            Console.WriteLine("---------------");
        }

        /// <summary>
        /// Function that prints the maze with the solution
        /// </summary>
        /// <param name="solution"></param>
        public static void print(String solution)
        {
            if (solution.Equals("NoValidPath"))
            {
                Console.WriteLine("There is no valid path");
                return;
            }
            else if (solution.Equals("OutOfTime"))
            {
                Console.WriteLine("Algorithm was terminated due to time limitations");
                return;
            }

            Console.WriteLine("Solution Found");
            Console.WriteLine("Steps: "+ solution.Length);

            int i = 1;

            foreach (char c in solution)
            {

                if (i < solution.Length)
                    Console.Write(c + "->");
                else
                    Console.Write(c);

                i++;

            }

            Console.WriteLine();
            Console.WriteLine("---------------");
            Console.WriteLine("---------------");

        }
    }
}
