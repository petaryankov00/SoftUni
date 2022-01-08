using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackImplementation
{
    public class CustomStack<T> 
    {
        private T[] arrayBuffer;
        private const int capacity = 4;
        private int count;

        public CustomStack()
        {
            arrayBuffer = new T[capacity];
            count = 0;
        }


        public int Count => this.count;


        public void Push(T element)
        {
            if (arrayBuffer.Length == this.Count)
            {
                var doubledArrayBuffer = new T[arrayBuffer.Length * 2];
                for (int i = 0; i < arrayBuffer.Length; i++)
                {
                    doubledArrayBuffer[i] = arrayBuffer[i];
                }

                this.arrayBuffer = doubledArrayBuffer;
            }

            arrayBuffer[this.count] = element;
            count++;
        }

        public T Pop()
        {
            if (this.arrayBuffer.Length == 0)
            {
                throw new InvalidOperationException("Custom Stack is Empty");
            }

            var lastItem = this.arrayBuffer[this.count - 1];
            this.arrayBuffer[this.count - 1] = default(T);
            count--;
            return lastItem;
        }

        public T Peek()
        {
            if (this.arrayBuffer.Length == 0)
            {
                throw new InvalidOperationException("Custom Stack is Empty");
            }

            return this.arrayBuffer[this.count - 1];
        }

        public void ForEach(Action<T> action)
        {
            int currentCount = this.count;

            for (int i = currentCount - 1; i >= 0; i--)
            {
                action(this.arrayBuffer[i]);
            }
        }

    }
}
