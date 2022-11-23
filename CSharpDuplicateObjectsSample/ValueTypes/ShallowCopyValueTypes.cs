using CSharpDuplicateObjectsSample.CopyClass;

namespace CSharpDuplicateObjectsSample.ValueTypes
{
    /// <summary>
    /// 組み込み型メンバを持つ構造体をシャローコピーで複製する
    /// </summary>
    public static class ShallowCopyValueTypes
    {
        /// <summary>
        /// <see cref="SampleStruct"/>を複製します。<br/>
        /// 複製には代入、コピーコンストラクタ、MemberwiseCloneメソッドを使用します。
        /// </summary>
        public static void ShallowCopy()
        {
            #region  代入で複製-----------------------------------------------------------------
            var original = new SampleStruct(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });

            Console.WriteLine("シャローコピー 代入: 組み込み型メンバを持つ構造体を複製");
            var copy = original;

            // 値型（int）と参照型（string）メンバ
            Console.WriteLine($"値変更前 コピー元 {original.Id} / {original.Name} コピー先 {copy.Id} / {copy.Name}");
            original.Id = 99;
            original.Name = "Hello, " + "World!";
            Console.WriteLine($"値変更後 コピー元 {original.Id} / {original.Name} コピー先 {copy.Id} / {copy.Name}\r\n");

            // 参照型（配列）メンバ
            Console.WriteLine($"値変更前 コピー元 {string.Join(", ", original.Ids)} / {string.Join(", ", original.Names)} コピー先 {string.Join(", ", copy.Ids)} / {string.Join(", ", copy.Names)}");
            original.Ids[0] = 9;
            original.Names[0] = "あ";
            Console.WriteLine($"値変更後 コピー元 {string.Join(", ", original.Ids)} / {string.Join(", ", original.Names)} コピー先 {string.Join(", ", copy.Ids)} / {string.Join(", ", copy.Names)}\r\n");
            #endregion

            #region  コピーコンストラクタで複製-----------------------------------------------------------------
            var original2 = new SampleStruct(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });

            Console.WriteLine("シャローコピー コピーコンストラクタ: 組み込み型メンバを持つ構造体を複製");
            var copy2 = new SampleStruct(original2);

            // 値型（int）と参照型（string）メンバ
            Console.WriteLine($"値変更前 コピー元 {original2.Id} / {original2.Name} コピー先 {copy2.Id} / {copy2.Name}");
            original2.Id = 99;
            original2.Name = "Hello, " + "World!";
            Console.WriteLine($"値変更後 コピー元 {original2.Id} / {original2.Name} コピー先 {copy2.Id} / {copy2.Name}\r\n");

             // 参照型（配列）メンバ
            Console.WriteLine($"値変更前 コピー元 {string.Join(", ", original2.Ids)} / {string.Join(", ", original2.Names)} コピー先 {string.Join(", ", copy2.Ids)} / {string.Join(", ", copy2.Names)}");
            original2.Ids[0] = 9;
            original2.Names[0] = "あ";
            Console.WriteLine($"値変更後 コピー元 {string.Join(", ", original2.Ids)} / {string.Join(", ", original2.Names)} コピー先 {string.Join(", ", copy2.Ids)} / {string.Join(", ", copy2.Names)}\r\n");
            #endregion

            #region  MemberwiseCloneで複製-----------------------------------------------------------------
            var original3 = new SampleStruct(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });

            Console.WriteLine("シャローコピー MemberwiseClone: 組み込み型メンバを持つ構造体を複製");
            var copy3 = original3.SharrowCopy();

            // 値型（int）と参照型（string）メンバ
            Console.WriteLine($"値変更前 コピー元 {original3.Id} / {original3.Name} コピー先 {copy3.Id} / {copy3.Name}");
            original3.Id = 99;
            original3.Name = "Hello, " + "World!";
            Console.WriteLine($"値変更後 コピー元 {original3.Id} / {original3.Name} コピー先 {copy3.Id} / {copy3.Name}\r\n");

             // 参照型（配列）メンバ
            Console.WriteLine($"値変更前 コピー元 {string.Join(", ", original3.Ids)} / {string.Join(", ", original3.Names)} コピー先 {string.Join(", ", copy3.Ids)} / {string.Join(", ", copy3.Names)}");
            original3.Ids[0] = 9;
            original3.Names[0] = "あ";
            Console.WriteLine($"値変更後 コピー元 {string.Join(", ", original3.Ids)} / {string.Join(", ", original3.Names)} コピー先 {string.Join(", ", copy3.Ids)} / {string.Join(", ", copy3.Names)}\r\n");
            #endregion
        }

        /// <summary>@
        /// <see cref="SampleStruct2"/>を複製します。<br/>
        /// 複製には代入、コピーコンストラクタ、MemberwiseCloneメソッドを使用します。
        /// </summary>
        public static void ShallowCopy2()
        {
            #region  代入で複製-----------------------------------------------------------------
            var original = new SampleStruct2
            {
                SampleStruct = new SampleStruct(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" }),
                SampleClass = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" })
            };

            Console.WriteLine("シャローコピー 代入: クラスと構造体をメンバを持つ構造体をシャローコピーで複製");
            var copy = original;

            // 値型（構造体）メンバ
            Console.WriteLine($"構造体メンバ値変更前 コピー元 {original.SampleStruct.Id} / {original.SampleStruct.Name} / {string.Join(", ", original.SampleStruct.Ids)} / {string.Join(", ", original.SampleStruct.Names)} " +
            $"コピー先 {copy.SampleStruct.Id} / {copy.SampleStruct.Name} / {string.Join(", ", copy.SampleStruct.Ids)} / {string.Join(", ", copy.SampleStruct.Names)}");

            original.SampleStruct.Id = 99;
            original.SampleStruct.Name = "Hello, " + "World!";
            original.SampleStruct.Ids[0] = 9;
            original.SampleStruct.Names[0] = "あ";

            Console.WriteLine($"構造体メンバ値変更後 コピー元 {original.SampleStruct.Id} / {original.SampleStruct.Name} / {string.Join(", ", original.SampleStruct.Ids)} / {string.Join(", ", original.SampleStruct.Names)} " +
            $"コピー先 {copy.SampleStruct.Id} / {copy.SampleStruct.Name} / {string.Join(", ", copy.SampleStruct.Ids)} / {string.Join(", ", copy.SampleStruct.Names)}\r\n");

            // 参照型（クラス）メンバ
            Console.WriteLine($"クラス型メンバ値変更前 コピー元 {original.SampleClass.Id} / {original.SampleClass.Name} / {string.Join(", ", original.SampleClass.Ids)} / {string.Join(", ", original.SampleClass.Names)} " +
            $"コピー先 {copy.SampleClass.Id} / {copy.SampleClass.Name} / {string.Join(", ", copy.SampleClass.Ids)} / {string.Join(", ", copy.SampleClass.Names)}");

            original.SampleClass.Id = 99;
            original.SampleClass.Name = "Hello, " + "World!";
            original.SampleClass.Ids[0] = 9;
            original.SampleClass.Names[0] = "あ";

            Console.WriteLine($"クラス型メンバ値変更後 コピー元 {original.SampleClass.Id} / {original.SampleClass.Name} / {string.Join(", ", original.SampleClass.Ids)} / {string.Join(", ", original.SampleClass.Names)} " +
            $"コピー先 {copy.SampleClass.Id} / {copy.SampleClass.Name} / {string.Join(", ", copy.SampleClass.Ids)} / {string.Join(", ", copy.SampleClass.Names)}");
            #endregion

            /*
                        // コピーコンストラクタで複製
                        var original2 = new SampleStruct2
                        {
                            SampleStruct = new SampleStruct(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" }),
                            SampleClass = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" })
                        };

                        Console.WriteLine("シャローコピー コピーコンストラクタ: 組み込み型メンバを持つ構造体を複製");
                        var copy2 = new SampleStruct2(original2);

                        Console.WriteLine($"値変更前 コピー元 {original2.Id} / {original2.Name} コピー先 {copy2.Id} / {copy2.Name}");
                        original2.Id = 99;
                        original2.Name = "Hello, " + "World!";
                        Console.WriteLine($"値変更後 コピー元 {original2.Id} / {original2.Name} コピー先 {copy2.Id} / {copy2.Name}\r\n");

                        Console.WriteLine($"値変更前 コピー元 {string.Join(", ", original2.Ids)} / {string.Join(", ", original2.Names)} コピー先 {string.Join(", ", copy2.Ids)} / {string.Join(", ", copy2.Names)}");
                        original2.Ids[0] = 9;
                        original2.Names[0] = "あ";
                        Console.WriteLine($"値変更後 コピー元 {string.Join(", ", original2.Ids)} / {string.Join(", ", original2.Names)} コピー先 {string.Join(", ", copy2.Ids)} / {string.Join(", ", copy2.Names)}\r\n");

                        // MemberwiseCloneで複製
                        var original3 = new SampleStruct2
                        {
                            SampleStruct = new SampleStruct(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" }),
                            SampleClass = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" })
                        };

                        Console.WriteLine("シャローコピー MemberwiseClone: 組み込み型メンバを持つ構造体を複製");
                        var copy3 = original3.SharrowCopy();

                        Console.WriteLine($"値変更前 コピー元 {original3.Id} / {original3.Name} コピー先 {copy3.Id} / {copy3.Name}");
                        original3.Id = 99;
                        original3.Name = "Hello, " + "World!";
                        Console.WriteLine($"値変更後 コピー元 {original3.Id} / {original3.Name} コピー先 {copy3.Id} / {copy3.Name}\r\n");

                        Console.WriteLine($"値変更前 コピー元 {string.Join(", ", original3.Ids)} / {string.Join(", ", original3.Names)} コピー先 {string.Join(", ", copy3.Ids)} / {string.Join(", ", copy3.Names)}");
                        original3.Ids[0] = 9;
                        original3.Names[0] = "あ";
                        Console.WriteLine($"値変更後 コピー元 {string.Join(", ", original3.Ids)} / {string.Join(", ", original3.Names)} コピー先 {string.Join(", ", copy3.Ids)} / {string.Join(", ", copy3.Names)}\r\n");
                        */
        }
    }
}