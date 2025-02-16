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
/// Kyusyaの型ハンドラー
/// </summary>
public class KyusyaTypeHandler : SqlMapper.TypeHandler<Kyusya>
{
    /// <summary>
    /// カスタム型をdapperの型に変換します。
    /// </summary>
    /// <param name="parameter">パラメータのDbType</param>
    /// <param name="value">設定する値</param>
    public override void SetValue(IDbDataParameter parameter, Kyusya value)
    {
        parameter.DbType = DbType.String;
        parameter.Value = value.Value;
    }

    /// <summary>
    /// dapperの型をカスタム型に変換します。
    /// </summary>
    /// <param name="value">データベースから取得した値</param>
    /// <returns><see cref="Kyusya"/>が戻ります。</returns>
    public override Kyusya Parse(object value)
    {
        /*
            下記は型変換できない場合を考慮していますが、
            適切なDB設計を行うことで、例外処理は不要になります。

            例）
            public override Kyusya Parse(object value)　=> Kyusya.Parse(value);
        */

        if (value is string stringValue)
        {
            return Kyusya.Parse(stringValue);
        }
        else
        {
            throw new ArgumentException($"対応していない型です: {value?.GetType().FullName}");
        }
    }
}

