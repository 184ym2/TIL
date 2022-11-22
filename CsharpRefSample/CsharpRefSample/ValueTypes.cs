using System;

namespace CsharpRefSample
{
    /// <summary>
    /// 値型
    /// </summary>
    class ValueTypes
    {
        /// <summary>
        /// 値渡しと ref
        /// </summary>
        public void Call()
        {
            // 値渡し
            var paramValue = 1;
            Console.WriteLine($"呼出前　{paramValue}");
            ValueTypes_PassByValue(paramValue);
            Console.WriteLine($"呼出後　{paramValue}");

            // 参照渡し　ref
            var paramValue2 = 1;
            Console.WriteLine($"呼出前　{paramValue2}");
            ValueTypes_PassByReference_ref(ref paramValue2);
            Console.WriteLine($"呼出後　{paramValue2}");
        }

        /// <summary>
        /// in と out
        /// </summary>
        public void Call2()
        {
            // 参照渡し　in
            var paramValue = 1;
            Console.WriteLine("呼出前　" + string.Join(", ", paramValue));
            ValueTypes_PassByReference_in(paramValue);
            ValueTypes_PassByReference_in(in paramValue);
            Console.WriteLine("呼出後　" + string.Join(", ", paramValue));

            // 参照渡し　out
            var paramValue2 = 1;
            Console.WriteLine("呼出前　" + string.Join(", ", paramValue2));
            ValueTypes_PassByReference_out(out paramValue2);
            Console.WriteLine("呼出後　" + string.Join(", ", paramValue2));
        }

        /// <summary>
        /// 値型の値渡し
        /// </summary>
        /// <param name="param"></param>
        private void ValueTypes_PassByValue(int param)
        {
            param = 1000;
        }

        /// <summary>
        /// 値型の参照渡し ref
        /// </summary>
        /// <param name="param"></param>
        private void ValueTypes_PassByReference_ref(ref int param)
        {
            param = 1000;
        }

        /// <summary>
        /// 値型の参照渡し in
        /// </summary>
        /// <param name="param"></param>
        private void ValueTypes_PassByReference_in(in int param)
        {
            // メソッド内で代入をするとエラーになる　書き換え不可
        }

        /// <summary>
        /// 値型の参照渡し out
        /// </summary>
        /// <param name="param"></param>
        private void ValueTypes_PassByReference_out(out int param)
        {
            // メソッド内で代入をしなければエラーになる 書き換え必須
            param = 1000;
        }
    }
}
