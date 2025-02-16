using Dapper;
using System.Data;
using Microsoft.Data.Sqlite;
using CSharpDapperAndSQLSample.Model.DTO.En;
using CSharpDapperAndSQLSample.Model;

namespace CSharpDapperAndSQLSample.Repository;

public class DubaiSheemaClassicRepository
{
    // 相対パスの場合、実行時のルートディレクトリにデータベースファイルを置く必要があります。
    // dotnet run の場合、必ずプロジェクトのルートディレクトリ（CSharpDapperAndSQLSample）から実行されますが、
    // F5実行の場合、launch.json の cwd で指定されたディレクトリから実行します。そのため、cwd の設定を必ず確認してください。
    // 実行時のルートディレクトリにデータベースファイルがない場合、空のデータベースを作成します。
    private const string DataSource = @"Datasource=advent.db";

    /// <summary>
    /// 取得の例
    /// </summary>
    public static void Execute()
    {
        // DataSource 以外のプロパティを設定しないため SqliteConnectionStringBuilder を経由しません。
        // SqliteConnection にそのまま DataSource を渡します。
        using var connection = new SqliteConnection(DataSource);

        using var command = connection.CreateCommand();
        connection.Open();

        GetAllDubaiSheemaClassicRecords(connection);
        AddDubaiSheemaClassicRecords(connection);
        DeleteDubaiSheemaClassicRecords(connection);
    }

    /// <summary>
    /// データの取得
    /// </summary>
    private static void GetAllDubaiSheemaClassicRecords(SqliteConnection connection)
    {
        const string SelectSql = @"SELECT * FROM dubai_sheema_classic WHERE kaisu = 25;";

        var rows = connection.Query<DubaiSheemaClassicDTO>(SelectSql);

        Console.WriteLine("\r\n複数行を取得し、全てのレコードを返します。");
        foreach (var row in rows)
        {
            Console.WriteLine($"第{row.Time}回 {row.BracketNumber} {row.HorseNumber} {row.HorseName} {row.Sex}{row.Age} {row.Weight} {row.Jockey} {row.Trainer} {row.CreateDate} {row.UpdateDate}");
        }
    }

    /// <summary>
    /// データの追加
    /// </summary>
    private static void AddDubaiSheemaClassicRecords(SqliteConnection connection)
    {
        const string InsertSql = @"
            INSERT INTO dubai_sheema_classic
            (
                kaisu,
                wakuban,
                umaban,
                bamei,
                seibetu,
                barei,
                kinryo,
                kisyu,
                kyusya,
                createdate,
                updatedate
            )
            VALUES
            (
                @kaisu,
                @wakuban,
                @umaban,
                @bamei,
                @seibetu,
                @barei,
                @kinryo,
                @kisyu,
                @kyusya,
                @createdate,
                @updatedate
            );";

        // パラメーター用のリストをDubaiSheemaClassicクラスを使用して作成します。
        var addList = new List<DubaiSheemaClassic>
        {
            new (26, Wakuban.Parse(1), Umaban.Parse(6), "ジュンコ", "セ", 5, 57.0, "Ｍ．ギュイヨン", "Ａ．ファーブル"),
            new (26, Wakuban.Parse(2), Umaban.Parse(3), "ジャスティンパレス", "牡", 5, 57.0, "Ｊ．モレイラ", "杉山晴紀"),
            new (26, Wakuban.Parse(3), Umaban.Parse(1), "ポイントロンズデール", "牡", 5, 57.0, "Ｗ．ローダン", "Ａ．オブライエン"),
            new (26, Wakuban.Parse(4), Umaban.Parse(11), "レベルスロマンス", "セ", 6, 57.0, "Ｗ．ビュイック", "Ｃ．アップルビー"),
            new (26, Wakuban.Parse(5), Umaban.Parse(2), "シャフリヤール", "牡", 6, 57.0, "Ｃ．デムーロ", "藤原英昭"),
            new (26, Wakuban.Parse(6), Umaban.Parse(5), "シムカミル", "牡", 5, 57.0, "Ｊ．ドイル", "Ａ．ドゥミユール"),
            new (26, Wakuban.Parse(7), Umaban.Parse(12), "シスファハン", "牡", 6, 57.0, "Ｌ．ディロジール", "Ｈ．グレーヴェ"),
            new (26, Wakuban.Parse(8), Umaban.Parse(10), "スピリットダンサー", "セ", 7, 57.0, "Ｏ．オーア", "Ｒ．フェイヒー"),
            new (26, Wakuban.Parse(9), Umaban.Parse(7), "オーギュストロダン", "牡", 4, 56.5, "Ｒ．ムーア", "Ａ．オブライエン"),
            new (26, Wakuban.Parse(10), Umaban.Parse(4), "エミリーアップジョン", "牝", 5, 55.0, "Ｋ．シューマーク", "Ｊ＆Ｔ．ゴスデン"),
            new (26, Wakuban.Parse(11), Umaban.Parse(8), "スターズオンアース", "牝", 5, 55.0, "Ｌ．デットーリ", "高柳瑞樹"),
            new (26, Wakuban.Parse(12), Umaban.Parse(9), "リバティアイランド", "牝", 4, 54.5, "川田将雅", "中内田充正")
        };

        // パラメーター用のリストを匿名パラメーター(Anonymous Parameter) に変換します。
        var multiInsertParams = addList.Select(x => new
        {
            kaisu = x.Time,
            wakuban = x.BracketNumber, // Wakuban は独自クラスだが、パラメーターとして使用できる
            umaban = x.HorseNumber, // UmaBan は独自クラスだが、パラメーターとして使用できる
            bamei = x.HorseName,
            seibetu = x.Sex,
            barei = x.Age,
            kinryo = x.Weight,
            kisyu = x.Jockey,
            kyusya = x.Trainer,
            createdate = DateTime.Now,
            updatedate = DateTime.Now
        });

        var insertResult = connection.Execute(InsertSql, multiInsertParams);
        Console.WriteLine($"\r\n{insertResult}件追加しました。");

        /*
            匿名パラメーター(Anonymous Parameter) を先にまとめて作成してExecuteを実行するのではなく、
            追加したいデータを foreach で回しながら、匿名パラメーター(Anonymous Parameter) を作成してExecuteを実行する方法もあります。
        */
    }

    /// <summary>
    /// データの削除
    /// </summary>
    private static void DeleteDubaiSheemaClassicRecords(SqliteConnection connection)
    {
        const string DeleteSql = @"DELETE FROM dubai_sheema_classic WHERE kaisu = 26;";

        var deleteResult = connection.Execute(DeleteSql);
        Console.WriteLine($"\r\n{deleteResult}件削除しました。");
    }
}


