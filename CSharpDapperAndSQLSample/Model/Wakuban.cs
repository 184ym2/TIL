namespace CSharpDapperAndSQLSample.Model;

/// <summary>
/// 枠番
/// </summary>
public readonly record struct Wakuban
{
    /// <summary>
    /// 馬番の値
    /// </summary>
    public readonly int Value;

    /// <summary>
    /// 内枠かどうか
    /// </summary>
    public readonly bool IsInnerFrame;

    /// <summary>
    /// 枠番の色
    /// </summary>
    public readonly WakubanColor Color;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="value">数値</param>
    public Wakuban(int value)
    {
        Value = value;
        IsInnerFrame = value <= 4;
        Color = (WakubanColor)value;
    }

    /// <summary>
    /// 枠番に変換します。
    /// </summary>
    /// <param name="value">変換対象の数値</param>
    /// <returns>枠番</returns>
    public static Wakuban Parse(int value)
    {
        return new Wakuban(value);
    }
}


