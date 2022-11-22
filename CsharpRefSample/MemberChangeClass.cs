namespace CSharpRefSample
{
    /// <summary>
    /// 参照型で値渡しした場合のクラスメンバ書き換え
    /// </summary>
    class MemberChangeClass
    {
        public void Call()
        {
            Console.WriteLine("\r\n---参照型で値渡しした場合のクラスメンバ書き換え---\r\n");
            var sample = new SampleClass();
            Console.WriteLine($"呼び出し前 {sample.Name} {sample.Names[1]}"); // 呼出前 STAR B

            MemberChange(sample);
            Console.WriteLine($"呼び出し後 {sample.Name} {sample.Names[1]}"); // 呼出後 MOON BBB
        }

        private void MemberChange(SampleClass sample)
        {
            // 値渡しでもメンバーの書き換えは反映される
            sample.Name = "MOON";
            sample.Names[1] = "BBB";
        }
    }

    class SampleClass
    {
        public string Name { get; set; } = "STAR";
        public string[] Names { get; set; } = new string[] { "A", "B", "C" };
    }
}