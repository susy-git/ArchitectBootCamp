using System;

namespace CompositePattern
{
    public class Button : IWindowElement
    {
        private readonly string name;

        public Button(string name)
        {
            this.name = name;
        }

        public void Print()
        {
            Console.WriteLine($"Print Buton ({this.name})");
        }
    }
}
