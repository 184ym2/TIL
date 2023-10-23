namespace CSharpDuplicateObjectsSample.CopyClass
{
    public struct SampleStruct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int[] Ids { get; set; }

        public string[] Names { get; set; }

        // 初期化
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
        /// シャローコピーを実行します。
        /// </summary>
        /// <returns><see cref="SampleStruct" />が戻ります。</returns>
        public SampleStruct SharrowCopy()
        {
            return (SampleStruct)MemberwiseClone();
        }

        /// <summary>
        /// ディープコピーを実行します。
        /// </summary>
        /// <returns><see cref="SampleStruct" />が戻ります。</returns>
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