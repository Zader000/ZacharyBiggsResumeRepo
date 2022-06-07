using System;
using System.Diagnostics;
using System.Threading;

/// <summary>
/// App for running the game Snake.
/// 
/// Frank Garcia and Zach Biggs
/// </summary>
namespace A03_Snake
{

    class Program
    {
        private static string direction = "right";
        static void Main(string[] args)
        {
            int width = 60;
            int height = 20;
            String direction = "right";
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan time;

            Console.CursorVisible = false;
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("Press the enter key to start game.");
            Console.ReadKey(true);

            GameBoard board = new GameBoard(width, height);
            board.PaintBoard();

            Snake snake = new Snake(10);
            snake.PaintSnake();

            Obstacle obstacle1 = new Obstacle(snake, width, height);
            obstacle1.PaintObstacle();

            Obstacle obstacle2 = new Obstacle(snake, width, height);
            obstacle2.PaintObstacle();

            Obstacle obstacle3 = new Obstacle(snake, width, height);
            obstacle3.PaintObstacle();

            Obstacle obstacle4 = new Obstacle(snake, width, height);
            obstacle4.PaintObstacle();




            long i = 0;
            stopWatch.Start();
            do
            {
                
                board.PaintBoard();
                snake.Move(direction);
                if (!snake.ValidPosition() || ObstableCollision(snake, obstacle1, obstacle2, obstacle3, obstacle4))
                    break;
                snake.PaintSnake();
                obstacle1.PaintObstacle();
                obstacle2.PaintObstacle();
                obstacle3.PaintObstacle();
                obstacle4.PaintObstacle();
                direction = Control();
                Thread.Sleep(50);
                
                if (i % 5000 == 0 && i != 0)
                {
                    obstacle1.ChangeCoords(width, height);
                    obstacle2.ChangeCoords(width, height);
                    obstacle3.ChangeCoords(width, height);
                    obstacle4.ChangeCoords(width, height);
                }
                i += 50;
            } while (snake.ValidPosition());

            stopWatch.Stop();
            time = stopWatch.Elapsed;

            //press any key...
            board.EraseBoard();
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("Game Over");
            Console.CursorLeft = 20;
            Console.WriteLine($"Time Elapsed: {time.Seconds} seconds");

            Console.CursorTop = 20;
        }


        private static string Control()
        {
            ConsoleKey? key = null;

            if(Console.KeyAvailable)
                key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    direction = "up";
                    break;
                case ConsoleKey.DownArrow:
                    direction = "down";
                    break;
                case ConsoleKey.LeftArrow:
                    direction = "left";
                    break;
                case ConsoleKey.RightArrow:
                    direction = "right";
                    break;
            }
            return direction;
        }

        private static bool ObstableCollision(Snake s, Obstacle o1, Obstacle o2, Obstacle o3, Obstacle o4)
        {
            return ((s.GetHeadXPosition() == o1.Left && s.GetHeadYPosition() == o1.Top)
                || (s.GetHeadXPosition() == o2.Left && s.GetHeadYPosition() == o2.Top)
                || (s.GetHeadXPosition() == o3.Left && s.GetHeadYPosition() == o3.Top)
                || (s.GetHeadXPosition() == o4.Left && s.GetHeadYPosition() == o4.Top));
        }
    }
}
