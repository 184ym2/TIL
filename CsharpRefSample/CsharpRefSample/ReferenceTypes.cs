using System;

namespace CsharpRefSample
{
    /// <summary>
    /// 参照渡し
    /// </summary>
    class ReferenceTypes
    {
        /// <summary>
        /// 参照渡しと ref
        /// </summary>
        public void Call()
        {
            // 値渡し
            var paramRef = new int[] { 1, 2, 3 };
            Console.WriteLine("呼出前　" + string.Join(", ", paramRef));
            ReferenceTypes_PassByValue(paramRef);
            Console.WriteLine("呼出後　" + string.Join(", ", paramRef));

            // 参照渡し　ref
            var paramRef2 = new int[] { 1, 2, 3 };
            Console.WriteLine("呼出前　" + string.Join(", ", paramRef2));
            ReferenceTypes_PassByReference_ref(ref paramRef2);
            Console.WriteLine("呼出後　" + string.Join(", ", paramRef2));

            // 値の入れ替え
            Console.WriteLine("\r\n---Swapメソッド---\r\n");
            var hello = "Hello";
            var world = "World!";
            Console.WriteLine("呼出前　 {0} {1}", hello, world);
            SwapStrings(ref hello, ref world);
            Console.WriteLine("呼出後　 {0} {1}", hello, world);
        }

        /// <summary>
        /// in と out
        /// </summary>
        public void Call2()
        {
            // 参照渡し　in
            var paramRef = new int[] { 1, 2, 3 };
            Console.WriteLine("呼出前　" + string.Join(", ", paramRef));
            ReferenceTypes_PassByReference_in(paramRef);
            ReferenceTypes_PassByReference_in(in paramRef);
            Console.WriteLine("呼出後　" + string.Join(", ", paramRef));

            // 参照渡し　out
            var paramRef2 = new int[] { 1, 2, 3 };
            Console.WriteLine("呼出前　" + string.Join(", ", paramRef2));
            ReferenceTypes_PassByReference_out(out paramRef2);
            Console.WriteLine("呼出後　" + string.Join(", ", paramRef2));
        }

        /// <summary>
        /// 参照型の値渡し
        /// </summary>
        /// <param name="param"></param>
        private void ReferenceTypes_PassByValue(int[] param)
        {
            param = new int[] { 1000, 2000, 3000 };
        }

        /// <summary>
        /// 参照型の参照渡し ref
        /// </summary>
        /// <param name="param"></param>
        private void ReferenceTypes_PassByReference_ref(ref int[] param)
        {
            param = new int[] { 1000, 2000, 3000 };
        }

        /// <summary>
        /// 参照型の参照渡し in
        /// </summary>
        /// <param name="param"></param>
        private void ReferenceTypes_PassByReference_in(in int[] param)
        {
            // メソッド内で代入をするとエラーになる　書き換え不可
        }

        /// <summary>
        /// 参照型の参照渡し out
        /// </summary>
        /// <param name="param"></param>
        private void ReferenceTypes_PassByReference_out(out int[] param)
        {
            // メソッド内で代入をしなければエラーになる 書き換え必須
            param = new int[] { 1000, 2000, 3000 };
        }

        private void SwapStrings(ref string s1, ref string s2)
        {
            var temp = s1;

            s1 = s2;
            s2 = temp;

            Console.WriteLine("メソッド内部： {0} {1}", s1, s2);
        }

    }
}
