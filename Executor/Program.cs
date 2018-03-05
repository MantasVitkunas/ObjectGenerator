using System;

namespace Executor
{
    class Program
    {
        static void Main(string[] args)
        {
            //new ObjectGenerator.Generator().GenerateObjects("C:\\Users\\manta\\Documents\\Visual Studio 2017\\Projects\\ObjectGenerator\\ObjectGenerator\\");
            new ObjectGenerator.Generator().GenerateObjects("Z:\\Projects\\git\\ObjectGenerator\\ObjectGenerator");
            Console.ReadKey();
        }
    }
}
