using System;
using System.Collections;
using System.Collections.Generic;

namespace CreateCustomDataStructures
{
    class StartUp
    {
        static void Main()
        {
            var originalStack = new Stack<int>();
           
            originalStack.Push(20);
            originalStack.Push(30);
            originalStack.Push(40);
            originalStack.Push(50);

            Console.WriteLine(originalStack.Pop()); //50   
            Console.WriteLine(originalStack.Pop()); //40

            Console.WriteLine(originalStack.Peek());//30
            Console.WriteLine(originalStack.Peek());//30

            foreach (var a in originalStack)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("...............................................................................................................");

            var stack = new MyStack<int>();
            var stack2 = new MyStack<int>(231);

            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);

            Console.WriteLine(stack.Pop()); //50   
            Console.WriteLine(stack.Pop()); //40

            Console.WriteLine(stack.Peek());//30
            Console.WriteLine(stack.Peek());//30

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
