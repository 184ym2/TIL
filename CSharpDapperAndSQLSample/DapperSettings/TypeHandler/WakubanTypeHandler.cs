using CSharpDapperAndSQLSample.Model;
using Dapper;
using System.Data;

namespace CSharpDapperAndSQLSample.DapperSettings.TypeHandler;

// DatabaseとCustom型のマッピング

// https://learn.microsoft.com/ja-jp/dotnet/standard/data/sqlite/dapper-limitations#data-types

/*
    Dapper では、SqliteDataReader インデクサーを使用して値が読み取られます。 
    このインデクサーの戻り値の型は object です。つまり、long、double、string、または byte [] の値のみが返されます。 
    詳細については、「データ型」を参照してください。 
    これらの型と他のプリミティブ型との間の変換は、ほとんどが Dapper によって処理されます。 
    ただし、DateTimeOffset、Guid、TimeSpan は処理されません。 これらの型を結果で使用する場合は、型ハンドラーを作成してください。
*/

/// <summary>
/// Wakubanの型ハンドラー
/// </summary>
public class WakubanTypeHandler : SqlMapper.TypeHandler<Wakuban>
{
    /// <summary>
    /// カスタム型をdapperの型に変換します。
    /// </summary>
    /// <param name="parameter">パラメータのDbType</param>
    /// <param name="value">設定する値</param>
    public override void SetValue(IDbDataParameter parameter, Wakuban value)
    {
        parameter.DbType = DbType.Int64;
        parameter.Value = value.Value;
    }

    /// <summary>
    /// dapperの型をカスタム型に変換します。
    /// </summary>
    /// <param name="value">データベースから取得した値</param>
    /// <returns><see cref="Wakuban"/>が戻ります。</returns>
    public override Wakuban Parse(object value)
    {
        if (value is int intValue)
        {
            return new Wakuban(intValue);
        }
        else if (value is long longValue)
        {
            return new Wakuban((int)longValue);
        }
        else
        {
            throw new ArgumentException("対応していない型です。");
        }
    }
}

