namespace CSharpDapperAndSQLSample.Model.DTO.Jp;

/// <summary>
/// 東京優駿（日本ダービー）のデータを格納するクラス（取得のみ使用）
/// </summary>
public class TokyoYushunDTO()
{
    /// <summary>
    /// 回数
    /// </summary>
    public int? Kaisu { get; set; }

    /// <summary>
    /// 枠番
    /// </summary>
    public Wakuban? Wakuban { get; set; }

    /// <summary>
    /// 馬番
    /// </summary>
    public Umaban? Umaban { get; set; }

    /// <summary>
    /// 馬名
    /// </summary>
    public string? Bamei { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    public string? Seibetu { get; set; }

    /// <summary>
    /// 馬齢
    /// </summary>
    public int? Barei { get; set; }

    /// <summary>
    /// 斤量
    /// </summary>
    public double? Kinryo { get; set; }

    /// <summary>
    /// 騎手
    /// </summary>
    public string? Kisyu { get; set; }

    /// <summary>
    /// 厩舎
    /// </summary>
    public string? Kyusya { get; set; }

    /// <summary>
    /// 作成日付
    /// </summary>
    public string? CreateDate { get; set; }

    /// <summary>
    /// 更新日付
    /// </summary>
    public string? UpdateDate { get; set; }
}
