using System.Text.RegularExpressions;

namespace CSharpDapperAndSQLSample.Model;

/// <summary>
/// 厩舎
/// </summary>
public readonly record struct Kyusya
{
    /// <summary>
    /// 海外厩舎を示す正規表現
    /// </summary>
    private readonly static Regex _regex = new("^[A-Za-z]\\.[A-Za-z]+$");

    /// <summary>
    /// 厩舎の値
    /// </summary>
    public readonly string Value;

    /// <summary>
    /// 海外厩舎かどうか
    /// </summary>
    public readonly bool IsOverseas;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="value">文字列</param>
    public Kyusya(string value)
    {
        Value = value;
        IsOverseas = _regex.IsMatch(value);
    }

    /// <summary>
    /// 性別に変換します。
    /// </summary>
    /// <param name="value">変換対象の文字列</param>
    /// <returns>性別</returns>
    public static Kyusya Parse(string value)
    {
        return new Kyusya(value);
    }
}


