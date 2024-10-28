using System.Data;
using Dapper;

namespace CSharpDapperAndSQLSample;

class Program
{
    static void Main(string[] args)
    {
        // 取得、集計の例
        ArimaKinenRepository.Execute();

        // 追加、更新、削除の例
        TakarazukaKinenRepository.Execute();

        // 作成した型ハンドラーを使用するためには、SqlMapper.AddTypeHandlerを使用する 
        ConfigureDapperTypeHandlers();

        // 型ハンドラーを使用した取得、追加
        TokyoYushunRepository.Execute();
    }

    /// <summary>
    /// 型ハンドラーの設定
    /// </summary>
    private static void ConfigureDapperTypeHandlers()
    {
        // UmaBanの型ハンドラーを追加
        SqlMapper.AddTypeHandler(new UmaBanTypeHandler());

        // Wakubanの型ハンドラーを追加
        SqlMapper.AddTypeHandler(new WakubanTypeHandler());
    }
}
