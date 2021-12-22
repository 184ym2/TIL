using System;

namespace CsharpRefSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var valueTypes = new ValueTypes();
            var refTypes = new ReferenceTypes();
            var mis = new MistakeSample();

            valueTypes.Call();
            refTypes.Call();
            mis.call();
        }
    }

}
