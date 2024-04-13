using System;

namespace CSharpDapperSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var querySample = new DataBaseQuerySample();
            querySample.Query();

            var executeSample = new DataBaseExecuteSample();
            executeSample.Execute();
        }
    }

}