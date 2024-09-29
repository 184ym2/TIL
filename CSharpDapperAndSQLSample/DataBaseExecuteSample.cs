using Dapper;
using Microsoft.Data.Sqlite;

namespace CSharpDapperAndSQLSample;

public class DataBaseExecuteSample
{
    // 相対パスの場合、実行時のルートディレクトリにデータベースファイルを置く必要があります。
    // dotnet run の場合、必ずプロジェクトのルートディレクトリ（CSharpDapperAndSQLSample）から実行されますが、
    // F5実行の場合、launch.json の cwd で指定されたディレクトリから実行します。そのため、cwd の設定を必ず確認してください。
    // 実行時のルートディレクトリにデータベースファイルがない場合、空のデータベースを作成します。
    private const string DataSource = @"Datasource=advent.db";

    /// <summary>
    /// 追加・更新・削除に関するメソッド
    /// </summary>
    public static void Execute()
    {
        // DataSource 以外のプロパティを設定しないため SqliteConnectionStringBuilder を経由しません。
        // SqliteConnection にそのまま DataSource を渡します。
        using var connection = new SqliteConnection(DataSource);

        using var command = connection.CreateCommand();
        connection.Open();

        // 追加
        var insertSql = @"
            INSERT INTO takarazuka_kinen
            (
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

        // 匿名パラメーター(Anonymous Parameter) でパラメーターを作成します。
        // 馬番(umaban)は自動採番のため、パラメーターを使用しません。
        var insertResult = connection.Execute(insertSql, new
        {
            wakuban = "1",
            bamei = "ライラック",
            seibetu = "牝",
            barei = "4",
            kinryo = "56",
            kisyu = "Mデムーロ",
            kyusya = "相沢",
            createdate = DateTime.Now,
            updatedate = DateTime.Now,
        });

        Console.WriteLine($"\r\n{insertResult}件追加しました。");

        var targetNo = 1;

        // 更新
        var updateSql = @"UPDATE takarazuka_kinen SET barei = 5 WHERE umaban = @umaban";
        // 匿名パラメーター(Anonymous Parameter) でパラメーターを作成します。
        var updateResult = connection.Execute(updateSql, new { umaban = targetNo });
        Console.WriteLine($"\r\n{updateResult}件更新しました。");

        // 削除
        var deleteSql = @"DELETE FROM takarazuka_kinen WHERE umaban = @umaban";
        // 匿名パラメーター(Anonymous Parameter) でパラメーターを作成します。
        var deleteResult = connection.Execute(deleteSql, new { umaban = targetNo });
        Console.WriteLine($"\r\n{deleteResult}件削除しました。");

        // COUNT
        var countSql = @"SELECT COUNT(*) FROM arima_kinen";
        var count = connection.ExecuteScalar(countSql);
        Console.WriteLine($"\r\n2022年の有馬記念は計{count}頭が出走しました。");

        // SUM
        var sumSql = @"SELECT SUM(barei) FROM arima_kinen";
        var sum = connection.ExecuteScalar(sumSql);
        Console.WriteLine($"\r\n2022年の有馬記念出走馬の馬齢合計は{sum}です。");

        // 複数のINSERT
        // パラメーター用のリストをTakarazukaKinenクラスを使用して作成します。
        var addList = new List<TakarazukaKinen>
        {
            new(1, 1, "ライラック", "牝", 4, 56, "Mデムーロ", "相沢"),
            new(1, 2, "カラテ", "牡", 7, 58, "菅原明", "辻野"),
            new(2, 3, "ダノンザキッド", "牡", 5, 58, "北村友", "安田隆"),
            new(2, 4, "ボッケリーニ", "牡", 7, 58, "浜中", "池江"),
            new(3, 5, "イクイノックス", "牡", 4, 58, "ルメール", "木村"),
            new(3, 6, "スルーセブンシーズ", "牝", 5, 56, "池添", "尾関"),
            new(4, 7, "プラダリア", "牡", 4, 58, "菱田", "池添"),
            new(4, 8, "ヴェラアズール", "牡", 6, 58, "松山", "渡辺"),
            new(5, 9, "ジャスティンパレス", "牡", 4, 58, "鮫島駿", "杉山晴"),
            new(5, 10, "ディープボンド", "牡", 6, 58, "和田竜", "大久保"),
            new(6, 11, "ジェラルディーナ", "牝", 5, 56, "武豊", "斉藤崇"),
            new(6, 12, "アスクビクターモア", "牡", 4, 58, "横山武", "田村"),
            new(7, 13, "ジオグリフ", "牡", 4, 58, "岩田望", "木村"),
            new(7, 14, "ブレークアップ", "牡", 5, 58, "川田", "吉岡"),
            new(8, 15, "ユニコーンライオン", "牡", 7, 58, "坂井", "矢作"),
            new(8, 16, "モズベッロ", "牡", 7, 58, "角田河", "森田"),
            new(8, 17, "ドゥラエレーデ", "牡", 3, 53, "幸", "池添"),
        };

        // パラメーター用のリストをDapperに渡すための匿名パラメーター(Anonymous Parameter) に変換します。
        // 馬番(umaban)は自動採番のため、パラメーターを使用しません。
        var multiInsertParams = addList.Select(x => new
        {
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

        // 複数のUPDATE: その1
        var multiUpdateSql = @"
            UPDATE takarazuka_kinen 
            SET updatedate = @updatedate
            WHERE umaban = @umaban;";

        var updateDate = DateTime.Now;

        // Dapperに渡すための匿名パラメーター(Anonymous Parameter) を作成します。        
        var multiUpdateParams = Enumerable.Range(1, 17).Select(index => new
        {
            umaban = index,
            updatedate = updateDate
        }).ToList();

        // 17件のUPDATEを実行します。
        var multiUpdateResult = connection.Execute(multiUpdateSql, multiUpdateParams);
        Console.WriteLine($"\r\n{multiUpdateResult}件更新しました。");

        // 複数のUPDATE: その2
        var multiUpdateSql2 = @"
            UPDATE takarazuka_kinen 
            SET updatedate = @updatedate
            WHERE umaban IN @umabanList";

        // 馬番のIN句に展開するためのリスト
        var umabanList = Enumerable.Range(1, 17).ToList();

        // パラメーター名と変数名が同じため「umabanList = umabanList」はイコールを省略できます
        var multiUpdateParams2 = new { updatedate = updateDate, umabanList };
        var multiUpdateResult2 = connection.Execute(multiUpdateSql2, multiUpdateParams2);
        Console.WriteLine($"\r\n{multiUpdateResult2}件更新しました。");

        // テスト用データベースのデータを全て削除
        var deleteSql2 = @"DELETE FROM takarazuka_kinen";
        var deleteResult2 = connection.Execute(deleteSql2);
        Console.WriteLine($"\r\n{deleteResult2}件削除しました。");
    }
}


