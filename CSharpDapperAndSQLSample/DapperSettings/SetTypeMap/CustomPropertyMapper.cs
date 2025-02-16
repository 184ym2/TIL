using CSharpDapperAndSQLSample.Model.DTO.En;
using Dapper;

namespace CSharpDapperAndSQLSample.DapperSettings.SetTypeMap;

/// <summary>
/// Dapperのカスタムマッピングを設定するクラス
/// </summary>
public class CustomPropertyMapper
{
    /// <summary>
    /// DubaiSheemaClassicのカスタムマッピングを設定します。
    /// </summary>
    public static void ConfigureDubaiSheemaClassicMappings()
    {
        SqlMapper.SetTypeMap(
           // マッピング対象のクラス
           typeof(DubaiSheemaClassicDTO),
           // マッピングのルール
           new CustomPropertyTypeMap(typeof(DubaiSheemaClassicDTO), (type, columnName) =>
               {
                   var property = columnName switch
                   {
                       "kaisu" => type.GetProperty("Time"),             // 回数
                       "wakuban" => type.GetProperty("BracketNumber"),  // 枠番(ゲート番)
                       "umaban" => type.GetProperty("HorseNumber"),     // 馬番
                       "bamei" => type.GetProperty("HorseName"),        // 馬名
                       "seibetu" => type.GetProperty("Sex"),            // 性別
                       "barei" => type.GetProperty("Age"),              // 馬齢
                       "kinryo" => type.GetProperty("Weight"),          // 斤量
                       "kisyu" => type.GetProperty("Jockey"),           // 騎手
                       "kyusya" => type.GetProperty("Trainer"),         // 厩舎
                       "createdate" => type.GetProperty("CreateDate"),  // 大文字と小文字が異なるだけの場合、カスタムマッピングをする必要がないが他の項目と揃えるために追加
                       "updatedate" => type.GetProperty("UpdateDate"),  // 大文字と小文字が異なるだけの場合、カスタムマッピングをする必要がないが他の項目と揃えるために追加
                       _ => null
                   };

                   return property ?? throw new InvalidOperationException($"クラス '{type.FullName}' にプロパティ '{columnName}' が見つかりません");
               }
           )
       );
    }

}