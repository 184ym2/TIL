namespace CSharpDuplicateObjectsSample.CopyClass
{
    public class SampleClass2
    {
        public SampleStruct SampleStruct;

        public SampleClass SampleClass;

        // コピーコンストラクタ
        public SampleClass2(SampleClass2 sampleClass2)
        {
            SampleStruct = sampleClass2.SampleStruct;
            SampleClass = sampleClass2.SampleClass;
        }

        /// <summary>
        /// シャローコピー用のMemberwiseCloneメソッド
        /// </summary>
        /// <returns></returns>
        public SampleClass2 SharrowCopy()
        {
            return (SampleClass2)MemberwiseClone();
        }

        /// <summary>
        /// ディープコピー用のメソッド
        /// </summary>
        /// <returns></returns>
        public SampleClass2 DeepCopy()
        {
            var clone = SharrowCopy();

            if (clone.SampleStruct.Ids != null)
            {
                clone.SampleStruct.Ids = (int[])this.SampleStruct.Ids.Clone();
            }

            if (clone.SampleStruct.Names != null)
            {
                clone.SampleStruct.Names = (string[])this.SampleStruct.Names.Clone();
            }

            if (clone.SampleClass.Ids != null)
            {
                clone.SampleClass.Ids = (int[])this.SampleClass.Ids.Clone();
            }

            if (clone.SampleClass.Names != null)
            {
                clone.SampleClass.Names = (string[])this.SampleClass.Names.Clone();
            }

            return clone;
        }
    }
}