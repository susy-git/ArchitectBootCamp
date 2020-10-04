using System;

namespace CompositePattern
{
    public class Checkbox : IWindowElement
    {
        private readonly string name;

        public Checkbox(string name)
        {
            this.name = name;
        }

        public void Print()
        {
            Console.WriteLine($"Print Frame ({this.name})");
        }
               
    }
}
