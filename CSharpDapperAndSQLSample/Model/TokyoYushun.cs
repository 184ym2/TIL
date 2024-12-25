namespace CSharpDapperAndSQLSample.Model;

/// <summary>
/// 東京優駿（日本ダービー）
/// </summary>
public class TokyoYushun(
    int Kaisu, 
    Wakuban wakuban, 
    Umaban umaban, 
    string bamei, 
    string seibetu, 
    int barei, 
    double kinryo, 
    string Kisyu, 
    string kyusya
)
{
    /// <summary>
    /// 回数
    /// </summary>
    public int Kaisu { get; } = Kaisu;

    /// <summary>
    /// 枠番
    /// </summary>
    public Wakuban Wakuban { get; } = wakuban;

    /// <summary>
    /// 馬番
    /// </summary>
    public Umaban Umaban { get; } = umaban;

    /// <summary>
    /// 馬名
    /// </summary>
    public string Bamei { get; } = bamei;

    /// <summary>
    /// 性別
    /// </summary>
    public string Seibetu { get; } = seibetu;

    /// <summary>
    /// 馬齢
    /// </summary>
    public int Barei { get; } = barei;

    /// <summary>
    /// 斤量
    /// </summary>
    public double Kinryo { get; } = kinryo;

    /// <summary>
    /// 騎手
    /// </summary>
    public string Kisyu { get; } = Kisyu;

    /// <summary>
    /// 厩舎
    /// </summary>
    public string Kyusya { get; } = kyusya;
}
