using System;

namespace CompositePattern
{
    public class LinkLable : IWindowElement
        {
            private readonly string name;

            public LinkLable(string name)
            {
                this.name = name;
            }

            public void Print()
            {
                Console.WriteLine($"Print Frame ({this.name})");
            }
        }

}
