using CSharpDuplicateObjectsSample.CopyClass;

namespace CSharpDuplicateObjectsSample.ReferenceTypes
{
    /// <summary>
    /// クラスをシャローコピーで複製するクラス
    /// <|summary>
    public static class ShallowCopyReferenceTypes
    {
        /// <summary>
        /// 組み込み型メンバを持つクラス<see cref="SampleClass"/>をシャローコピーで複製します。<br/>
        /// 複製には代入、コピーコンストラクタ、MemberwiseCloneメソッドを使用します。
        /// </summary>
        public static void ShallowCopy()
        {
            Console.WriteLine("\r\n組み込み型メンバを持つクラスをシャローコピーで複製する");

            #region  代入で複製-----------------------------------------------------------------
            var orig = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });

            Console.WriteLine("\r\n1. 代入");
            var copy = orig;

            Console.WriteLine($"値変更前 \r\n@orig|コピー元 {orig.Id} | {orig.Name} | {string.Join(", ", orig.Ids)} | {string.Join(", ", orig.Names)}" +
            $"\r\n@copy|コピー先 {copy.Id} | {copy.Name} | {string.Join(", ", copy.Ids)} | {string.Join(", ", copy.Names)}");

            orig.Id = 99;
            orig.Name = "Hello, " + "World!";
            orig.Ids[0] = 9;
            orig.Names[0] = "あ";
           
            Console.WriteLine($"値変更後 \r\n@orig|コピー元 {orig.Id} | {orig.Name} | {string.Join(", ", orig.Ids)} | {string.Join(", ", orig.Names)}" +
            $"\r\n@copy|コピー先 {copy.Id} | {copy.Name} | {string.Join(", ", copy.Ids)} | {string.Join(", ", copy.Names)}");
            #endregion

            #region  コピーコンストラクタで複製-----------------------------------------------------------------
            var orig2 = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });

            Console.WriteLine("\r\n2. コピーコンストラクタ");
            var copy2 = new SampleClass(orig2);

            Console.WriteLine($"値変更前 \r\n@orig|コピー元 {orig2.Id} | {orig2.Name} | {string.Join(", ", orig2.Ids)} | {string.Join(", ", orig2.Names)}" +
            $"\r\n@copy|コピー先 {copy2.Id} | {copy2.Name} | {string.Join(", ", copy2.Ids)} | {string.Join(", ", copy2.Names)}");

            orig2.Id = 99;
            orig2.Name = "Hello, " + "World!";
            orig2.Ids[0] = 9;
            orig2.Names[0] = "あ";
          
            Console.WriteLine($"値変更後 \r\n@orig|コピー元 {orig2.Id} | {orig2.Name} | {string.Join(", ", orig2.Ids)} | {string.Join(", ", orig2.Names)}" +
            $"\r\n@copy|コピー先 {copy2.Id} | {copy2.Name} | {string.Join(", ", copy2.Ids)} | {string.Join(", ", copy2.Names)}");
            #endregion

            #region  MemberwiseCloneで複製-----------------------------------------------------------------
            var orig3 = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });

            Console.WriteLine("\r\n3. MemberwiseClone");
            var copy3 = orig3.SharrowCopy();

            Console.WriteLine($"値変更前 \r\n@orig|コピー元 {orig3.Id} | {orig3.Name} | {string.Join(", ", orig3.Ids)} | {string.Join(", ", orig3.Names)}" +
            $"\r\n@copy|コピー先 {copy3.Id} | {copy3.Name} | {string.Join(", ", copy3.Ids)} | {string.Join(", ", copy3.Names)}");

            orig3.Id = 99;
            orig3.Name = "Hello, " + "World!";
            orig3.Ids[0] = 9;
            orig3.Names[0] = "あ";

            Console.WriteLine($"値変更後 \r\n@orig|コピー元 {orig3.Id} | {orig3.Name} | {string.Join(", ", orig3.Ids)} | {string.Join(", ", orig3.Names)} " +
            $"\r\n@copy|コピー先 {copy3.Id} | {copy3.Name} | {string.Join(", ", copy3.Ids)} | {string.Join(", ", copy3.Names)}");
            #endregion
        }

        /// <summary>
        /// クラスと構造体をメンバを持つクラス<see cref="SampleClass2"/>をシャローコピーで複製します。<br/>
        /// 複製には代入、コピーコンストラクタ、MemberwiseCloneメソッドを使用します。
        /// </summary>
        public static void ShallowCopy2()
        {
            Console.WriteLine("\r\nクラスと構造体をメンバを持つ構造体をシャローコピーで複製する");

            #region  代入で複製-----------------------------------------------------------------
            var sampleStruct = new SampleStruct(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });
            var sampleClass = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });
            var orig = new SampleClass2(sampleStruct,sampleClass);

            Console.WriteLine("\r\n1. 代入");
            var copy = orig;

            // 値型（構造体）メンバ
            Console.WriteLine($"構造体メンバ値変更前\r\n@orig|コピー元 {orig.SampleStruct.Id} | {orig.SampleStruct.Name} | {string.Join(", ", orig.SampleStruct.Ids)} | {string.Join(", ", orig.SampleStruct.Names)}" +
            $"\r\n@copy|コピー先 {copy.SampleStruct.Id} | {copy.SampleStruct.Name} | {string.Join(", ", copy.SampleStruct.Ids)} | {string.Join(", ", copy.SampleStruct.Names)}");

            orig.SampleStruct.Id = 99;
            orig.SampleStruct.Name = "Hello, " + "World!";
            orig.SampleStruct.Ids[0] = 9;
            orig.SampleStruct.Names[0] = "あ";

            Console.WriteLine($"構造体メンバ値変更後\r\n@orig|コピー元 {orig.SampleStruct.Id} | {orig.SampleStruct.Name} | {string.Join(", ", orig.SampleStruct.Ids)} | {string.Join(", ", orig.SampleStruct.Names)}" +
            $"\r\n@copy|コピー先 {copy.SampleStruct.Id} | {copy.SampleStruct.Name} | {string.Join(", ", copy.SampleStruct.Ids)} | {string.Join(", ", copy.SampleStruct.Names)}");

            // 参照型（クラス）メンバ
            Console.WriteLine($"\r\nクラス型メンバ値変更前\r\n@orig|コピー元 {orig.SampleClass.Id} | {orig.SampleClass.Name} | {string.Join(", ", orig.SampleClass.Ids)} | {string.Join(", ", orig.SampleClass.Names)}" +
            $"\r\n@copy|コピー先 {copy.SampleClass.Id} | {copy.SampleClass.Name} | {string.Join(", ", copy.SampleClass.Ids)} | {string.Join(", ", copy.SampleClass.Names)}");

            orig.SampleClass.Id = 99;
            orig.SampleClass.Name = "Hello, " + "World!";
            orig.SampleClass.Ids[0] = 9;
            orig.SampleClass.Names[0] = "あ";

            Console.WriteLine($"クラス型メンバ値変更後\r\n@orig|コピー元 {orig.SampleClass.Id} | {orig.SampleClass.Name} | {string.Join(", ", orig.SampleClass.Ids)} | {string.Join(", ", orig.SampleClass.Names)}" +
            $"\r\n@copy|コピー先 {copy.SampleClass.Id} | {copy.SampleClass.Name} | {string.Join(", ", copy.SampleClass.Ids)} | {string.Join(", ", copy.SampleClass.Names)}");
            #endregion

            #region  コピーコンストラクタで複製-----------------------------------------------------------------
            var sampleStruct2 = new SampleStruct(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });
            var sampleClass2 = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });
            var orig2 = new SampleClass2(sampleStruct2,sampleClass2);

            Console.WriteLine("\r\n2. コピーコンストラクタ");
            var copy2 = new SampleClass2(orig2);

            // 値型（構造体）メンバ
            Console.WriteLine($"構造体メンバ値変更前\r\n@orig|コピー元 {orig2.SampleStruct.Id} | {orig2.SampleStruct.Name} | {string.Join(", ", orig2.SampleStruct.Ids)} | {string.Join(", ", orig2.SampleStruct.Names)}" +
            $"\r\n@copy|コピー先 {copy2.SampleStruct.Id} | {copy2.SampleStruct.Name} | {string.Join(", ", copy2.SampleStruct.Ids)} | {string.Join(", ", copy2.SampleStruct.Names)}");

            orig2.SampleStruct.Id = 99;
            orig2.SampleStruct.Name = "Hello, " + "World!";
            orig2.SampleStruct.Ids[0] = 9;
            orig2.SampleStruct.Names[0] = "あ";

            Console.WriteLine($"構造体メンバ値変更後\r\n@orig|コピー元 {orig2.SampleStruct.Id} | {orig2.SampleStruct.Name} | {string.Join(", ", orig2.SampleStruct.Ids)} | {string.Join(", ", orig2.SampleStruct.Names)}" +
            $"\r\n@copy|コピー先 {copy2.SampleStruct.Id} | {copy2.SampleStruct.Name} | {string.Join(", ", copy2.SampleStruct.Ids)} | {string.Join(", ", copy2.SampleStruct.Names)}");

            // 参照型（クラス）メンバ
            Console.WriteLine($"\r\nクラス型メンバ値変更前\r\n@orig|コピー元 {orig2.SampleClass.Id} | {orig2.SampleClass.Name} | {string.Join(", ", orig2.SampleClass.Ids)} | {string.Join(", ", orig2.SampleClass.Names)}" +
            $"\r\n@copy|コピー先 {copy2.SampleClass.Id} | {copy2.SampleClass.Name} | {string.Join(", ", copy2.SampleClass.Ids)} | {string.Join(", ", copy2.SampleClass.Names)}");

            orig2.SampleClass.Id = 99;
            orig2.SampleClass.Name = "Hello, " + "World!";
            orig2.SampleClass.Ids[0] = 9;
            orig2.SampleClass.Names[0] = "あ";

            Console.WriteLine($"クラス型メンバ値変更後\r\n@orig|コピー元 {orig2.SampleClass.Id} | {orig2.SampleClass.Name} | {string.Join(", ", orig2.SampleClass.Ids)} | {string.Join(", ", orig2.SampleClass.Names)}" +
            $"\r\n@copy|コピー先 {copy2.SampleClass.Id} | {copy2.SampleClass.Name} | {string.Join(", ", copy2.SampleClass.Ids)} | {string.Join(", ", copy2.SampleClass.Names)}");
            #endregion

            #region  MemberwiseCloneで複製-----------------------------------------------------------------
            var sampleStruct3 = new SampleStruct(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });
            var sampleClass3 = new SampleClass(10, "AAA", new[] { 1, 2, 3 }, new[] { "A", "B", "C" });
            var orig3 = new SampleClass2(sampleStruct2,sampleClass2);

            Console.WriteLine("\r\n3. MemberwiseClone");
            var copy3 = orig3.SharrowCopy();

            // 値型（構造体）メンバ
            Console.WriteLine($"構造体メンバ値変更前\r\n@orig|コピー元 {orig3.SampleStruct.Id} | {orig3.SampleStruct.Name} | {string.Join(", ", orig3.SampleStruct.Ids)} | {string.Join(", ", orig3.SampleStruct.Names)}" +
            $"\r\n@copy|コピー先 {copy3.SampleStruct.Id} | {copy3.SampleStruct.Name} | {string.Join(", ", copy3.SampleStruct.Ids)} | {string.Join(", ", copy3.SampleStruct.Names)}");

            orig3.SampleStruct.Id = 99;
            orig3.SampleStruct.Name = "Hello, " + "World!";
            orig3.SampleStruct.Ids[0] = 9;
            orig3.SampleStruct.Names[0] = "あ";

            Console.WriteLine($"構造体メンバ値変更後\r\n@orig|コピー元 {orig3.SampleStruct.Id} | {orig3.SampleStruct.Name} | {string.Join(", ", orig3.SampleStruct.Ids)} | {string.Join(", ", orig3.SampleStruct.Names)}" +
            $"\r\n@copy|コピー先 {copy3.SampleStruct.Id} | {copy3.SampleStruct.Name} | {string.Join(", ", copy3.SampleStruct.Ids)} | {string.Join(", ", copy3.SampleStruct.Names)}");

            // 参照型（クラス）メンバ
            Console.WriteLine($"\r\nクラス型メンバ値変更前\r\n@orig|コピー元 {orig3.SampleClass.Id} | {orig3.SampleClass.Name} | {string.Join(", ", orig3.SampleClass.Ids)} | {string.Join(", ", orig3.SampleClass.Names)}" +
            $"\r\n@copy|コピー先 {copy3.SampleClass.Id} | {copy3.SampleClass.Name} | {string.Join(", ", copy3.SampleClass.Ids)} | {string.Join(", ", copy3.SampleClass.Names)}");

            orig3.SampleClass.Id = 99;
            orig3.SampleClass.Name = "Hello, " + "World!";
            orig3.SampleClass.Ids[0] = 9;
            orig3.SampleClass.Names[0] = "あ";

            Console.WriteLine($"クラス型メンバ値変更後\r\n@orig|コピー元 {orig3.SampleClass.Id} | {orig3.SampleClass.Name} | {string.Join(", ", orig3.SampleClass.Ids)} | {string.Join(", ", orig3.SampleClass.Names)}" +
            $"\r\n@copy|コピー先 {copy3.SampleClass.Id} | {copy3.SampleClass.Name} | {string.Join(", ", copy3.SampleClass.Ids)} | {string.Join(", ", copy3.SampleClass.Names)}");

            #endregion
        }
    }
}