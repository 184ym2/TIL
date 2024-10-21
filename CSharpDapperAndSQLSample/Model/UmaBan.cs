using Dapper;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;

namespace CSharpDapperAndSQLSample;

// DatabaseとCustom型のマッピング

// 馬番のオブジェクト
public record struct UmaBan
{
    /// <summary>
    /// 馬番のパターン  
    /// </summary>
    public static readonly string Pattern = @"[1-9]";

    /// <summary>
    /// 馬番の値
    /// </summary>
    public readonly string Value;
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="value">文字列</param>
    public UmaBan(string value)
    {
        if (Regex.IsMatch(value, Pattern))
        {
            this.Value = value;
        }
        else
        {
            throw new ArgumentException($"馬番の値が不正です。{value}");
        }
    }
}


