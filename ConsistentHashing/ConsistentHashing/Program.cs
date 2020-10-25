using KetamaHash.Utils;
using System;

namespace ConsistentHashing
{
    class Program
    {
        static void Main(string[] args)
        {
           HashAlgorithmTest.Test(1000000, 10, 160);

            //HashAlgorithmTest.Test(1000000, 10, 150);

            //HashAlgorithmTest.Test(1000000, 10, 80);
        }
    }
}
