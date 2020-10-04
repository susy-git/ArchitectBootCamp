using System;

namespace CompositePattern
{
    public class PasswordBox : IWindowElement
        {
            private readonly string name;

            public PasswordBox(string name)
            {
                this.name = name;
            }

            public void Print()
            {
                Console.WriteLine($"Print Frame ({this.name})");
            }
        }
}
