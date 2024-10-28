using Dapper;
using System.Data;
using Microsoft.Data.Sqlite;

namespace CSharpDapperAndSQLSample;

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
        var sql = @"SELECT * FROM tokyo_yushun;";

        // TokyoYushunDTO の Umaban は独自クラスだが、正常にマッピングされる
        var rows = connection.Query<TokyoYushunDTO>(sql);

        Console.WriteLine("\r\n複数行を取得し、全てのレコードを返します。");
        foreach (var row in rows)
        {
            Console.WriteLine($"第{row.Kaisu}回 {row.Wakuban} {row.Umaban} {row.Bamei} {row.Seibetu}{row.Barei} {row.Kinryo} {row.Kisyu} {row.Kyusya}");
        }
    }

    /// <summary>
    /// データの追加
    /// </summary>
    private static void AddTokyoYushunRecords(SqliteConnection connection)
    {
        var insertSql = @"
            INSERT INTO tokyo_yushun
            (
                kaisu,
                wakuban,
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
                @bamei,
                @seibetu,
                @barei,
                @kinryo,
                @kisyu,
                @kyusya,
                @createdate,
                @updatedate
            );";

        // 複数のINSERT
        // パラメーター用のリストをTokyoYushunクラスを使用して作成します。
        var addList = new List<TokyoYushun>
        {
            new(89, Wakuban.Parse("1"), UmaBan.Parse("1"), "アスクワイルドモア", "牡", 3, 57, "岩田望", "藤原"),
            new(89, Wakuban.Parse("1"), UmaBan.Parse("2"), "セイウンハーデス", "牡", 3, 57, "幸", "橋口"),
            new(89, Wakuban.Parse("2"), UmaBan.Parse("3"), "アスクビクターモア", "牡", 3, 57, "田辺", "田村"),
            new(89, Wakuban.Parse("2"), UmaBan.Parse("4"), "マテンロウレオ", "牡", 3, 57, "横山和", "昆"),
            new(89, Wakuban.Parse("3"), UmaBan.Parse("5"), "ピースオブエイト", "牡", 3, 57, "藤岡佑", "奥村豊"),
            new(89, Wakuban.Parse("3"), UmaBan.Parse("6"), "プラダリア", "牡", 3, 56, "池添", "池添学"),
            new(89, Wakuban.Parse("4"), UmaBan.Parse("7"), "オニャンコポン", "牡", 3, 57, "菅原明", "小島"),
            new(89, Wakuban.Parse("4"), UmaBan.Parse("8"), "ビーアストニッシド", "牡", 3, 57, "和田竜", "飯田雄"),
            new(89, Wakuban.Parse("5"), UmaBan.Parse("9"), "ジャスティンパレス", "牡", 3, 57, "Mデムーロ", "杉山晴"),
            new(89, Wakuban.Parse("5"), UmaBan.Parse("10"), "マテンロウオリオン", "牡", 3, 57, "横山典", "昆"),
            new(89, Wakuban.Parse("6"), UmaBan.Parse("11"), "ジャスティンロック", "牡", 3, 57, "松山", "吉岡"),
            new(89, Wakuban.Parse("6"), UmaBan.Parse("12"), "ダノンベルーガ", "牡", 3, 57, "川田", "堀"),
            new(89, Wakuban.Parse("7"), UmaBan.Parse("13"), "ドウデュース", "牡", 3, 57, "武豊", "友道"),
            new(89, Wakuban.Parse("7"), UmaBan.Parse("14"), "デシエルト", "牡", 3, 57, "岩田康", "安田隆"),
            new(89, Wakuban.Parse("7"), UmaBan.Parse("15"), "ジオグリフ", "牡", 3, 57, "福永", "木村"),
            new(89, Wakuban.Parse("8"), UmaBan.Parse("16"), "キラーアビリティ", "牡", 3, 57, "横山武", "斉藤崇"),
            new(89, Wakuban.Parse("8"), UmaBan.Parse("17"), "ロードレゼル", "牡", 3, 57, "レーン", "中内田"),
            new(89, Wakuban.Parse("8"), UmaBan.Parse("18"), "イクイノックス", "牡", 3, 57, "ルメール", "木村")
        };

        // パラメーター用のリストをDapperに渡すための匿名パラメーター(Anonymous Parameter) に変換します。
        // ※tokyo_yushunの馬番(umaban)は自動採番のため、パラメーターを使用しません。

        // TokyoYushunDTO の Wakuban は独自クラスだが、パラメーターとして使用できる
        var multiInsertParams = addList.Select(x => new
        {
            kaisu = x.Kaisu,
            wakuban = x.Wakuban,
            bamei = x.Bamei,
            seibetu = x.Seibetu,
            barei = x.Barei,
            kinryo = x.Kinryo,
            kisyu = x.Kisyu,
            kyusya = x.Kyusya,
            createdate = DateTime.Now,
            updatedate = DateTime.Now
        });

        // 17件のINSERTを実行します。
        var multiInsertResult = connection.Execute(insertSql, multiInsertParams);
        Console.WriteLine($"\r\n{multiInsertResult}件追加しました。");

        /*
        匿名パラメーター(Anonymous Parameter) を先に作成するのではなく、追加したいデータを foreach で回す方法もあります。
        */
    }

   
    /// <summary>
    /// データの削除
    /// </summary>
    private static void DeleteTokyoYushunRecords(SqliteConnection connection)
    {
        // テスト用データベースのデータを全て削除
        var deleteSql2 = @"DELETE FROM tokyo_yushun where kaisu = 89";
        var deleteResult2 = connection.Execute(deleteSql2);
        Console.WriteLine($"\r\n{deleteResult2}件削除しました。");
    }

}


