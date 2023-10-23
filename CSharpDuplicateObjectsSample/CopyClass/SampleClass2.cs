namespace CSharpDuplicateObjectsSample.CopyClass
{
    public class SampleClass2
    {
        // コンパイラ エラー CS1612 回避のため、SampleStructをフィールドにしています。
        // https://learn.microsoft.com/ja-jp/dotnet/csharp/language-reference/compiler-messages/cs1612
        public SampleStruct SampleStruct;

        public SampleClass SampleClass;

        // 初期化
        public SampleClass2(SampleStruct sampleStruct, SampleClass sampleClass)
        {
            SampleStruct = sampleStruct;
            SampleClass = sampleClass;
        }

        // コピーコンストラクタ
        public SampleClass2(SampleClass2 sampleClass2)
        {
            SampleStruct = sampleClass2.SampleStruct;
            SampleClass = sampleClass2.SampleClass;
        }

        /// <summary>
        /// シャローコピーを実行します。
        /// </summary>
        /// <returns><see cref="SampleClass2" />が戻ります。</returns>
        public SampleClass2 SharrowCopy()
        {
            return (SampleClass2)MemberwiseClone();
        }

        /// <summary>
        /// ディープコピーを実行します。
        /// </summary>
        /// <returns><see cref="SampleClass2" />が戻ります。</returns>
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