using System;

namespace CSharpRefSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var valueTypys = new ValueTypes();
            var refTypys = new ReferenceTypes();
            var change = new MemberChangeClass();

            valueTypys.ValueTypesCall();
            refTypys.ReferenceTypesCall();
            change.Call();
        }
    }

}
