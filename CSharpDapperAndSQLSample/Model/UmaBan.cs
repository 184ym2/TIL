namespace CSharpDapperAndSQLSample.Model;

/// <summary>
/// 馬番
/// </summary>
public record struct Umaban
{
    /// <summary>
    /// 馬番の値
    /// </summary>
    public readonly int Value;

    /// <summary>
    /// 先入れかどうかを示す値 <br />
    /// 奇数番の馬から先にゲートに入ります。
    /// </summary>
    public readonly bool IsFirstInserted;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="value">数値</param>
    public Umaban(int value)
    {
        Value = value;
        IsFirstInserted = value % 2 != 0;
    }

    /// <summary>
    /// 馬番に変換します。
    /// </summary>
    /// <param name="value">変換対象の数値</param>
    /// <returns>馬番</returns>
    public static Umaban Parse(int value)
    {
        return new Umaban(value);
    }
}


