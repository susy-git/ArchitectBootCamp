using System;

namespace CompositePattern
{
    public class Picture : IWindowElement
    {
        private readonly string name;

        public Picture(string name)
        {
            this.name = name;
        }

        public void Print()
        {
            Console.WriteLine($"Print Picture ({this.name})");
        }
    }
}
