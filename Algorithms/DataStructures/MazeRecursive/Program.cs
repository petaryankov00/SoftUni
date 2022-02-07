using System;

namespace MazeRecursive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] maze = new string[]
            {
                "010001",
                "01010E",
                "010101",
                "000001",
            };

            FindPaths(maze, 0, 0, new bool[maze.Length, maze[0].Length], "");
        }

        public static  void FindPaths(string[] maze, int row, int col, bool[,] visited, string path)
        {
            visited[row,col] = true;

            if (maze[row][col] == 'E')
            {
                Console.WriteLine(path);
                return;
            }

            if (isSafe(maze,row + 1,col,visited))
            {
                FindPaths(maze, row + 1, col, visited, path + "D");
            }
            if (isSafe(maze, row - 1, col, visited))
            {
                FindPaths(maze, row - 1, col, visited, path + "U");
            }
            if (isSafe(maze, row, col - 1, visited))
            {
                FindPaths(maze, row, col - 1, visited, path + "L");
            }
            if (isSafe(maze, row, col + 1, visited))
            {
                FindPaths(maze, row, col + 1, visited, path + "R");
            }

        }

        private static bool isSafe(string[] maze, int row, int col, bool[,] visited)
        {
            if (row < 0 || col < 0 || row >= maze.Length || col >= maze[0].Length)
            {
                return false;
            }
            if (maze[row][col] == '1' || visited[row,col])
            {
                return false;

            }

            return true;

        }
    }
}
