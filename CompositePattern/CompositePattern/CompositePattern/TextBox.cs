using System;

namespace CompositePattern
{
    public class TextBox : IWindowElement
    {
        private readonly string name;

        public TextBox(string name)
        {
            this.name = name;
        }

        public void Print()
        {
            Console.WriteLine($"Print Frame ({this.name})");
        }
    }

}
