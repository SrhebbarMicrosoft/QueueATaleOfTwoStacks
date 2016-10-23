using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueATaleOfTwoStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            int q = int.Parse(Console.ReadLine().Trim());
            MyQueue queue = new MyQueue();
            while (q-- != 0)
            {
                string[] tokens = Console.ReadLine().Split();
                switch (int.Parse(tokens[0]))
                {
                    case 1:
                        queue.Enqueue(int.Parse(tokens[1]));
                        break;
                    case 2:
                        queue.Dequeue();
                        break;
                    case 3:
                        Console.WriteLine(queue.Peek());
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }

    internal class MyQueue
    {
        private Stack input;
        private Stack output;

        public MyQueue()
        {
            input = new Stack();
            output = new Stack();
        }

        internal void Enqueue(int v)
        {
            input.Push(v);
        }

        internal void Dequeue()
        {
            if (output.Count == 0)
            {
                this.MoveToOutputStack();
            }
            if (output.Count != 0)
            {
                output.Pop();
            }
        }

        private void MoveToOutputStack()
        {
            while (input.Count != 0)
            {
                output.Push(input.Pop());
            }
        }

        internal int Peek()
        {
            if (output.Count == 0)
            {
                this.MoveToOutputStack();
            }
            if (output.Count != 0)
            {
                return (int)output.Peek();
            }
            return 0;
        }
    }
}
