using System.Collections.Generic;
using System.Linq;

namespace TreeImplementation
{
    public class TNode<T>
    {
        private T value;

        public TNode(T value, params TNode<T>[] children)
        {
            this.value = value;
            this.Children = children.ToList();
        }

        public T Value
        {
            get => this.value;
            set { this.value = value; }
        }

        public List<TNode<T>> Children { get; private set; }

        //public void AddChild(TNode<T> child)
        //{
        //    this.Children.Add(child);
        //}

        //public TNode<T> GetChild(int index)
        //{
        //    return this.Children[index];
        //}
    }
}
