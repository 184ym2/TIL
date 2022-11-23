namespace CSharpDuplicateObjectsSample.CopyClass
{
    /// <summary>
    /// コピー元の構造体
    /// </summary>
    public struct SampleStruct2
    {
        public SampleStruct SampleStruct;

        public SampleClass SampleClass;

        // コピーコンストラクタ
        public SampleStruct2(SampleStruct2 sampleStruct2)
        {
            SampleStruct = sampleStruct2.SampleStruct;
            SampleClass = sampleStruct2.SampleClass;
        }

        /// <summary>
        /// シャローコピー用のMemberwiseCloneメソッド
        /// </summary>
        /// <returns></returns>
        public SampleStruct2 SharrowCopy()
        {
            return (SampleStruct2)MemberwiseClone();
        }

        /// <summary>
        /// ディープコピー用のメソッド
        /// </summary>
        /// <returns></returns>
        public SampleStruct2 DeepCopy()
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