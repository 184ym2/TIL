namespace CSharpDapperAndSQLSample;

/// <summary>
/// 宝塚記念のデータを格納するクラス
/// </summary>
public class TakarazukaKinen(int wakuban, int umaban, string bamei, string seibetu, int barei, int kinryo, string Kisyu, string kyusya)
{
    /// <summary>
    /// 枠番
    /// </summary>
    public int Wakuban { get; } = wakuban;

    /// <summary>
    /// 馬番
    /// </summary>
    public int Umaban { get; } = umaban;

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
    public int Kinryo { get; } = kinryo;

    /// <summary>
    /// 騎手
    /// </summary>
    public string Kisyu { get; } = Kisyu;

    /// <summary>
    /// 厩舎
    /// </summary>
    public string Kyusya { get; } = kyusya;
}
