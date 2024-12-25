using Dapper;

namespace CSharpDapperAndSQLSample.DapperSettings.TypeHandler;

/// <summary>
/// Dapperのカスタム型ハンドラーを設定するクラス
/// </summary>
public class TypeHandlerSettings
{
    /// <summary>
    /// Dapperのカスタム型ハンドラーを設定します。
    /// </summary>
    public static void ConfigureDapperTypeHandlers()
    {
        // UmaBanの型ハンドラーを追加
        SqlMapper.AddTypeHandler(new UmabanTypeHandler());

        // Wakubanの型ハンドラーを追加
        SqlMapper.AddTypeHandler(new WakubanTypeHandler());
    }
}