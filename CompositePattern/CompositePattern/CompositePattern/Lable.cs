using System;

namespace CompositePattern
{
    public class Lable : IWindowElement
    {
        private readonly string name;

        public Lable(string name)
        {
            this.name = name;
        }

        public void Print()
        {
            Console.WriteLine($"Print Frame ({this.name})");
        }
    }
}
