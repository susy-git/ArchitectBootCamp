using System;
using System.Collections.Generic;

namespace CompositePattern
{
    public class Frame : IWindowElement, ICompositeElement
    {
        private readonly string name;
        private readonly List<IWindowElement> children = new List<IWindowElement>();

        public Frame(string name)
        {
            this.name = name;
        }

        public void AddChild(IWindowElement child)
        {
            this.children.Add(child);
        }

        public void Print()
        {
            Console.WriteLine($"Print Frame ({this.name})");
            foreach (var child in this.children)
                child.Print();
        }
    }
}
