using System;

namespace CsharpRefSample
{
    class Program
    {
        static void Main(string[] args)
        {

            var valueTypes = new ValueTypes();
            var refTypes = new ReferenceTypes();

            valueTypes.Call();
            refTypes.Call();
        }
    }
}
