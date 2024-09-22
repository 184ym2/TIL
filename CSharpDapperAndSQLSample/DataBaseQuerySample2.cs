using Dapper;
using System.Data;
using Microsoft.Data.Sqlite;

namespace CSharpDapperAndSQLSample;

// DatabaseとCustom型のマッピング

// 馬番のオブジェクト
public record struct UmaNo
{
    public readonly string Value;

    public UmaNo(string value)
    {
        this.Value = value;
    }

}

// https://learn.microsoft.com/ja-jp/dotnet/standard/data/sqlite/dapper-limitations
// 
public class NoTypeHandler : SqlMapper.TypeHandler<UmaNo>
{
    // コマンド実行前にパラメータの値を代入する。
    public override void SetValue(IDbDataParameter parameter, UmaNo value)
    {
        parameter.DbType = DbType.Int64;
        parameter.Value = value.Value;
    }

    // データベースの値をパースして型付けされた値に戻す
    public override UmaNo Parse(object value)
        => new UmaNo(value.ToString());
}

