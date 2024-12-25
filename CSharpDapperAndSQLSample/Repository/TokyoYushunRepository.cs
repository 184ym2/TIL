using Dapper;
using System.Data;
using Microsoft.Data.Sqlite;
using CSharpDapperAndSQLSample.Model.DTO.Jp;
using CSharpDapperAndSQLSample.Model;

namespace CSharpDapperAndSQLSample.Repository;

public class TokyoYushunRepository
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

        GetAllTokyoYushunRecords(connection);
        AddTokyoYushunRecords(connection);
        DeleteTokyoYushunRecords(connection);
    }

    /// <summary>
    /// データの取得
    /// </summary>
    private static void GetAllTokyoYushunRecords(SqliteConnection connection)
    {
        const string SELECT_SQL = @"SELECT * FROM tokyo_yushun WHERE kaisu = 88;";

        var rows = connection.Query<TokyoYushunDTO>(SELECT_SQL);

        Console.WriteLine("\r\n複数行を取得し、全てのレコードを返します。");
        foreach (var row in rows)
        {
            Console.WriteLine($"第{row.Kaisu}回 {row.Wakuban.Value} {row.Wakuban.Color} {row.Umaban.Value} {row.Bamei} {row.Seibetu}{row.Barei} {row.Kinryo} {row.Kisyu} {row.Kyusya} {row.CreateDate} {row.UpdateDate}");
        }
    }

    /// <summary>
    /// データの追加
    /// </summary>
    private static void AddTokyoYushunRecords(SqliteConnection connection)
    {
        const string INSERT_SQL = @"
            INSERT INTO tokyo_yushun
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

        // パラメーター用のリストをTokyoYushunクラスを使用して作成します。
        var addList = new List<TokyoYushun>
        {
            new(89, Wakuban.Parse(1), Umaban.Parse(1), "アスクワイルドモア", "牡", 3, 57, "岩田望", "藤原"),
            new(89, Wakuban.Parse(1), Umaban.Parse(2), "セイウンハーデス", "牡", 3, 57, "幸", "橋口"),
            new(89, Wakuban.Parse(2), Umaban.Parse(3), "アスクビクターモア", "牡", 3, 57, "田辺", "田村"),
            new(89, Wakuban.Parse(2), Umaban.Parse(4), "マテンロウレオ", "牡", 3, 57, "横山和", "昆"),
            new(89, Wakuban.Parse(3), Umaban.Parse(5), "ピースオブエイト", "牡", 3, 57, "藤岡佑", "奥村豊"),
            new(89, Wakuban.Parse(3), Umaban.Parse(6), "プラダリア", "牡", 3, 56, "池添", "池添学"),
            new(89, Wakuban.Parse(4), Umaban.Parse(7), "オニャンコポン", "牡", 3, 57, "菅原明", "小島"),
            new(89, Wakuban.Parse(4), Umaban.Parse(8), "ビーアストニッシド", "牡", 3, 57, "和田竜", "飯田雄"),
            new(89, Wakuban.Parse(5), Umaban.Parse(9), "ジャスティンパレス", "牡", 3, 57, "Mデムーロ", "杉山晴"),
            new(89, Wakuban.Parse(5), Umaban.Parse(10), "マテンロウオリオン", "牡", 3, 57, "横山典", "昆"),
            new(89, Wakuban.Parse(6), Umaban.Parse(11), "ジャスティンロック", "牡", 3, 57, "松山", "吉岡"),
            new(89, Wakuban.Parse(6), Umaban.Parse(12), "ダノンベルーガ", "牡", 3, 57, "川田", "堀"),
            new(89, Wakuban.Parse(7), Umaban.Parse(13), "ドウデュース", "牡", 3, 57, "武豊", "友道"),
            new(89, Wakuban.Parse(7), Umaban.Parse(14), "デシエルト", "牡", 3, 57, "岩田康", "安田隆"),
            new(89, Wakuban.Parse(7), Umaban.Parse(15), "ジオグリフ", "牡", 3, 57, "福永", "木村"),
            new(89, Wakuban.Parse(8), Umaban.Parse(16), "キラーアビリティ", "牡", 3, 57, "横山武", "斉藤崇"),
            new(89, Wakuban.Parse(8), Umaban.Parse(17), "ロードレゼル", "牡", 3, 57, "レーン", "中内田"),
            new(89, Wakuban.Parse(8), Umaban.Parse(18), "イクイノックス", "牡", 3, 57, "ルメール", "木村")
        };

        // パラメーター用のリストを匿名パラメーター(Anonymous Parameter) に変換します。
        var multiInsertParams = addList.Select(x => new
        {
            kaisu = x.Kaisu,
            wakuban = x.Wakuban, // Wakuban は独自クラスだが、パラメーターとして使用できる
            umaban = x.Umaban, // Umaban は独自クラスだが、パラメーターとして使用できる
            bamei = x.Bamei,
            seibetu = x.Seibetu,
            barei = x.Barei,
            kinryo = x.Kinryo,
            kisyu = x.Kisyu,
            kyusya = x.Kyusya,
            createdate = DateTime.Now,
            updatedate = DateTime.Now
        });

        var insertResult = connection.Execute(INSERT_SQL, multiInsertParams);
        Console.WriteLine($"\r\n{insertResult}件追加しました。");

        /*
        匿名パラメーター(Anonymous Parameter) を先にまとめて作成してExecuteを実行するのではなく、
        追加したいデータを foreach で回しながら、匿名パラメーター(Anonymous Parameter) を作成してExecuteを実行する方法もあります。
        */
    }

    /// <summary>
    /// データの削除
    /// </summary>
    private static void DeleteTokyoYushunRecords(SqliteConnection connection)
    {
        const string DELETE_SQL = @"DELETE FROM tokyo_yushun WHERE kaisu = 89;";

        var deleteResult = connection.Execute(DELETE_SQL);
        Console.WriteLine($"\r\n{deleteResult}件削除しました。");
    }

}

