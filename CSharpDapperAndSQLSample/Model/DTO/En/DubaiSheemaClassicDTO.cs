namespace CSharpDapperAndSQLSample.Model.DTO.En;

/// <summary>
/// ドバイシーマクラシックのデータを格納するクラス（取得のみ使用）
/// </summary>
public class DubaiSheemaClassicDTO()
{
    /// <summary>
    /// 回数
    /// </summary>
    public int? Time { get; set; }

    /// <summary>
    /// 枠番(ゲート番)
    /// </summary>
    public Wakuban? BracketNumber { get; set; }

    /// <summary>
    /// 馬番
    /// </summary>
    public Umaban? HorseNumber { get; set; }

    /// <summary>
    /// 馬名
    /// </summary>
    public string? HorseName { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    public string? Sex { get; set; }

    /// <summary>
    /// 馬齢
    /// </summary>
    public int? Age { get; set; }

    /// <summary>
    /// 斤量
    /// </summary>
    public double? Weight { get; set; }

    /// <summary>
    /// 騎手
    /// </summary>
    public string? Jockey { get; set; }

    /// <summary>
    /// 厩舎
    /// </summary>
    public string? Trainer { get; set; }

    /// <summary>
    /// 作成日付
    /// </summary>
    public string? CreateDate { get; set; }

    /// <summary>
    /// 更新日付
    /// </summary>
    public string? UpdateDate { get; set; }
}
