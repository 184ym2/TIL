namespace CSharpDuplicateObjectsSample.CopyClass
{
    /// <summary>
    /// コピー元の構造体
    /// クラスメンバはプリミティブ型
    /// </summary>
    public struct SampleStruct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int[] Ids { get; set; }

        public string[] Names { get; set; }

        public SampleStruct(int id, string name, int[] ids, string[] names)
        {
            Id = id;
            Name = name;
            Ids = ids;
            Names = names;
        }

        // コピーコンストラクタ
        public SampleStruct(SampleStruct sampleStruct)
        {
            Id = sampleStruct.Id;
            Name = sampleStruct.Name;
            Ids = sampleStruct.Ids;
            Names = sampleStruct.Names;
        }

        /// <summary>
        /// シャローコピー用のMemberwiseCloneメソッド
        /// </summary>
        /// <returns></returns>
        public SampleStruct SharrowCopy()
        {
            return (SampleStruct)MemberwiseClone();
        }

        /// <summary>
        /// ディープコピー用のメソッド
        /// </summary>
        /// <returns></returns>
        public SampleStruct DeepCopy()
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