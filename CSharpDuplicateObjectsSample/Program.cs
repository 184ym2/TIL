using CSharpDuplicateObjectsSample.ReferenceTypes;
using CSharpDuplicateObjectsSample.ValueTypes;

namespace CSharpDuplicateObjectsSample
{
    class Program
    {
        static void Main(string[] args)
        { 
            ShallowCopyValueTypes.ShallowCopy();
            ShallowCopyReferenceTypes.ShallowCopy();

            ShallowCopyValueTypes.ShallowCopy2();
            ShallowCopyReferenceTypes.ShallowCopy2();
        }
    }

}

