using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

/// <summary>
/// Frank Garcia and Zach Biggs
/// </summary>
namespace A03_Snake
{
    /// <summary>
    /// Class for Managing the snake and its segments.
    /// </summary>
    class Snake
    {
        private int n;
        private int capacity;
        private Segment[] body;

        public int Head { get; set; }
        public int Tail { get; set; }


        /// <summary>
        /// Class for managing the snake segments.
        /// </summary>
        public class Segment
        {
            public int Left { get; set; }
            public int Top { get; set; }

            public Segment(Segment seg)
            {
                this.Top = seg.Top;
                this.Left = seg.Left;
            }

            public Segment(int left, int top)
            {
                Left = left;
                Top = top;
            }
        }

        /// <summary>
        /// Constructs the snake's body beginning with the head and 
        /// will construct the body according to the capacity
        /// </summary>
        /// <param name="capacity"></param> the max size of the snake
        public Snake(int capacity)
        {
            this.capacity = capacity;
            this.body = new Segment[capacity];

            n = 1;
            Head = 0;
            Tail = 0;

            this.body[0] = new Segment(39, 11);

            for (int i = 1; i < capacity; i++)
            {
                Enqueue(new Segment(body[i-1].Left - 2, body[i-1].Top));
            } 
        }

        /// <summary>
        /// Checks if the snake has run slithered off the edge of the gameboard or
        /// collided with an obstacle.
        /// </summary>
        /// <returns></returns> if the snake has run off the gameboard or into
        /// an obstacle
        public bool ValidPosition()
        {
            for (int i = 1; i < capacity; i++)
            {
                if (body[0].Top == body[i].Top && body[0].Left == body[i].Left)
                {
                    return false;
                }
            }

            return (body[0].Top >= 1 && body[0].Top <= 20 &&
                body[0].Left >= 5 && body[0].Left <= 63);

        }

        /// <summary>
        /// Checks if the body is empty.
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            return n == 0;
        }
       
        /// <summary>
        /// Adds a segment to the body of the snake.
        /// </summary>
        /// <param name="b"></param> the body of the snake
        public void Enqueue(Segment b)
        {
            Tail = ++Tail % capacity;
            body[Tail] = b;
            if (Empty())
                Head = Tail;

            n++;
        }

        public int GetHeadXPosition()
        {
            return body[0].Left;
        }

        public int GetHeadYPosition()
        {
            return body[0].Top;
        }

        /// <summary>
        /// Paints the snake on the board according to its size.
        /// Will paint the head in a separate color.
        /// </summary>
        public void PaintSnake()
        {
            for (int i = 0; i < capacity; i++)
            {
                Console.SetCursorPosition( this.body[i].Left, this.body[i].Top);
                if (i == 0)
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                else
                    Console.BackgroundColor = ConsoleColor.Green;
                
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
            }      
        }

        /// <summary>
        /// Makes the other
        /// </summary>
        /// <param name="direction"></param>
        public void Move(String direction)
        {
            switch (direction)
            {
                case "up":
                    Move(0, -1);
                    break;

                case "down":
                    Move(0, 1);
                    break;

                case "left":
                    Move(-2, 0);
                    break;

                case "right":
                    Move(2, 0);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Moves the snake in a given direction. Works with its sister method to make it easier to understand the directions.
        /// </summary>
        /// <param name="xDirection">2 for right -2 for left 0 nothing</param>
        /// <param name="yDirection">1 for down -1 for up 0 nothing</param>
        public void Move(int xDirection, int yDirection)
        {
            Segment temp = new Segment(body[0]);
            
            body[0].Left += xDirection;
            body[0].Top += yDirection;

            for (int i = 1; i < capacity; i++)
            {
                Segment temp2;
                temp2 = body[i];
                body[i] = temp;
                temp = temp2;
            }
        }
    }
}
