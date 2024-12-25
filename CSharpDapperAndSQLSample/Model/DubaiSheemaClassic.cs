namespace CSharpDapperAndSQLSample.Model;

/// <summary>
/// ドバイシーマクラシック
/// </summary>
public class DubaiSheemaClassic(
    int time,
    Wakuban bracketNumber,
    Umaban horseNumber,
    string horseName,
    string sex,
    int age,
    double weight,
    string jockey,
    string trainer
)
{
    /// <summary>
    /// 回数
    /// </summary>
    public int Time { get; } = time;

    /// <summary>
    /// 枠番(ゲート番)
    /// </summary>
    public Wakuban BracketNumber { get; } = bracketNumber;

    /// <summary>
    /// 馬番
    /// </summary>
    public Umaban HorseNumber { get; } = horseNumber;

    /// <summary>
    /// 馬名
    /// </summary>
    public string HorseName { get; } = horseName;

    /// <summary>
    /// 性別
    /// </summary>
    public string Sex { get; } = sex;

    /// <summary>
    /// 馬齢
    /// </summary>
    public int Age { get; } = age;

    /// <summary>
    /// 斤量
    /// </summary>
    public double Weight { get; } = weight;

    /// <summary>
    /// 騎手
    /// </summary>
    public string Jockey { get; } = jockey;

    /// <summary>
    /// 厩舎
    /// </summary>
    public string Trainer { get; } = trainer;
}
