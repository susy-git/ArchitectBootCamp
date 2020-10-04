using System;
using System.Collections.Generic;

namespace CompositePattern
{
    public class Window : IWindowElement, ICompositeElement
    {
        private readonly string name;
        private readonly List<IWindowElement> children = new List<IWindowElement>();

        public Window(string name)
        {
            this.name = name;
        }

        public void AddChild(IWindowElement child)
        {
            this.children.Add(child);
        }

        public void Print()
        {
            Console.WriteLine($"Print WinForm ({this.name})");
            foreach (var child in this.children)
                child.Print();
        }
    }
}
