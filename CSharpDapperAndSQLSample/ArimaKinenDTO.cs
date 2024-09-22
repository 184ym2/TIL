namespace CSharpDapperAndSQLSample;

public class ArimaKinenDTO
{
    /// <summary>
    /// 枠番
    /// </summary>
    public int Wakuban { get; set; }

    /// <summary>
    /// 馬番
    /// </summary>
    public int Umaban { get; set; }

    /// <summary>
    /// 馬名
    /// </summary>
    public string Bamei { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    public string Seibetu { get; set; }

    /// <summary>
    /// 馬齢
    /// </summary>
    public int Barei { get; set; }

    /// <summary>
    /// 斤量
    /// </summary>
    public int Kinryo { get; set; }

    /// <summary>
    /// 騎手
    /// </summary>
    public string Kisyu { get; set; }

    /// <summary>
    /// 厩舎
    /// </summary>
    public string Kyusya { get; set; }
}
