using CSharpDuplicateObjectsSample.CopyClass;

namespace CSharpDuplicateObjectsSample.ReferenceTypes
{
    /// <summary>
    /// 組み込み型メンバを持つクラスをシャローコピーで複製する
    /// </summary>
    public static class ShallowCopyReferenceTypes
    {
        /// <summary>
        /// <see cref="SampleClass"/>を複製します。<br/>
        /// 複製には代入、コピーコンストラクタ、MemberwiseCloneメソッドを使用します。
        /// </summary>
        public static void ShallowCopy()
        {
            // 代入で複製
            var original = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });

            Console.WriteLine("シャローコピー 代入: 組み込み型メンバを持つクラスを複製");
            var copy = original;

            Console.WriteLine($"値変更前 コピー元 {original.Id} / {original.Name} コピー先 {copy.Id} / {copy.Name}");
            original.Id = 99;
            original.Name = "Hello, " + "World!";
            Console.WriteLine($"値変更後 コピー元 {original.Id} / {original.Name} コピー先 {copy.Id} / {copy.Name}\r\n");

            Console.WriteLine($"値変更前 コピー元 {string.Join(", ", original.Ids)} / {string.Join(", ", original.Names)} コピー先 {string.Join(", ", copy.Ids)} / {string.Join(", ", copy.Names)}");
            original.Ids[0] = 9;
            original.Names[0] = "あ";
            Console.WriteLine($"値変更後 コピー元 {string.Join(", ", original.Ids)} / {string.Join(", ", original.Names)} コピー先 {string.Join(", ", copy.Ids)} / {string.Join(", ", copy.Names)}\r\n");

            // コピーコンストラクタで複製
            var original2 = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });

            Console.WriteLine("シャローコピー コピーコンストラクタ: 組み込み型メンバを持つクラスを複製");
            var copy2 = new SampleClass(original2);

            Console.WriteLine($"値変更前 コピー元 {original2.Id} / {original2.Name} コピー先 {copy2.Id} / {copy2.Name}");
            original2.Id = 99;
            original2.Name = "Hello, " + "World!";
            Console.WriteLine($"値変更後 コピー元 {original2.Id} / {original2.Name} コピー先 {copy2.Id} / {copy2.Name}\r\n");

            Console.WriteLine($"値変更前 コピー元 {string.Join(", ", original2.Ids)} / {string.Join(", ", original2.Names)} コピー先 {string.Join(", ", copy2.Ids)} / {string.Join(", ", copy2.Names)}");
            original2.Ids[0] = 9;
            original2.Names[0] = "あ";
            Console.WriteLine($"値変更後 コピー元 {string.Join(", ", original2.Ids)} / {string.Join(", ", original2.Names)} コピー先 {string.Join(", ", copy2.Ids)} / {string.Join(", ", copy2.Names)}\r\n");

            // MemberwiseCloneで複製
            var original3 = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });

            Console.WriteLine("シャローコピー MemberwiseClone: 組み込み型メンバを持つクラスを複製");
            var copy3 = original3.SharrowCopy();

            Console.WriteLine($"値変更前 コピー元 {original3.Id} / {original3.Name} コピー先 {copy3.Id} / {copy3.Name}");
            original3.Id = 99;
            original3.Name = "Hello, " + "World!";
            Console.WriteLine($"値変更後 コピー元 {original3.Id} / {original3.Name} コピー先 {copy3.Id} / {copy3.Name}\r\n");

            Console.WriteLine($"値変更前 コピー元 {string.Join(", ", original3.Ids)} / {string.Join(", ", original3.Names)} コピー先 {string.Join(", ", copy3.Ids)} / {string.Join(", ", copy3.Names)}");
            original3.Ids[0] = 9;
            original3.Names[0] = "あ";
            Console.WriteLine($"値変更後 コピー元 {string.Join(", ", original3.Ids)} / {string.Join(", ", original3.Names)} コピー先 {string.Join(", ", copy3.Ids)} / {string.Join(", ", copy3.Names)}\r\n");

        }

    }
}