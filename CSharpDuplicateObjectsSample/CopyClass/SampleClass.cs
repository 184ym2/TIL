namespace CSharpDuplicateObjectsSample.CopyClass
{
    /// <summary>
    /// コピー元のクラス
    /// クラスメンバはプリミティブ型
    /// </summary>
    public class SampleClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int[] Ids { get; set; }

        public string[] Names { get; set; }

        public SampleClass(int id, string name, int[] ids, string[] names)
        {
            Id = id;
            Name = name;
            Ids = ids;
            Names = names;
        }

        // コピーコンストラクタ
        public SampleClass(SampleClass sampleClass)
        {
            Id = sampleClass.Id;
            Name = sampleClass.Name;
            Ids = sampleClass.Ids;
            Names = sampleClass.Names;
        }

        /// <summary>
        /// シャローコピー用のMemberwiseCloneメソッド
        /// </summary>
        /// <returns></returns>
        public SampleClass SharrowCopy()
        {
            return (SampleClass)MemberwiseClone();
        }

        /// <summary>
        /// ディープコピー用のメソッド
        /// </summary>
        /// <returns></returns>
        public SampleClass DeepCopy()
        {
            var clone = SharrowCopy();

            if (clone.Ids != null)
            {
                clone.Ids = (int[])this.Ids.Clone();
            }

            if (clone.Names != null)
            {
                clone.Names = (string[])this.Names.Clone();
            }

            return clone;
        }
    }

}