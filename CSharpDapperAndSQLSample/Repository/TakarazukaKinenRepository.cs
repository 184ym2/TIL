using CSharpDapperAndSQLSample.Model;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CSharpDapperAndSQLSample.Repository;

public class TakarazukaKinenRepository
{
    // 相対パスの場合、実行時のルートディレクトリにデータベースファイルを置く必要があります。
    // dotnet run の場合、必ずプロジェクトのルートディレクトリ（CSharpDapperAndSQLSample）から実行されますが、
    // F5実行の場合、launch.json の cwd で指定されたディレクトリから実行します。そのため、cwd の設定を必ず確認してください。
    // 実行時のルートディレクトリにデータベースファイルがない場合、空のデータベースを作成します。
    private const string DataSource = @"Datasource=advent.db";

    /// <summary>
    /// 追加、更新、削除の例
    /// </summary>
    public static void Execute()
    {
        // DataSource 以外のプロパティを設定しないため SqliteConnectionStringBuilder を経由しません。
        // SqliteConnection にそのまま DataSource を渡します。
        using var connection = new SqliteConnection(DataSource);

        using var command = connection.CreateCommand();
        connection.Open();

        InsertSingleRecord(connection);
        UpdateAndDeleteSingleRecord(connection);
        InsertMultipleRecords(connection);
        UpdateMultipleRecords(connection);
        DeleteAllRecords(connection);
    }

    /// <summary>
    /// 単一レコードの挿入
    /// </summary>
    private static void InsertSingleRecord(SqliteConnection connection)
    {
        const string INSERT_SQL = @"
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

        var result = connection.Execute(INSERT_SQL, new
        {
            // 匿名パラメーター(Anonymous Parameter) でパラメーターを作成します。
            // ※takarazuka_kinenの馬番(umaban)は自動採番のため、パラメーターを使用しません。
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

        Console.WriteLine($"\r\n{result}件追加しました。");
    }

    /// <summary>
    /// 単一レコードの更新と削除
    /// </summary>
    private static void UpdateAndDeleteSingleRecord(SqliteConnection connection)
    {
        const int TARGET_NUMBER = 1;

        const string UPDATE_SQL = @"UPDATE takarazuka_kinen SET barei = 5, updatedate = @updatedate WHERE umaban = @umaban;";

        var updateResult = connection.Execute(UPDATE_SQL, new
        {
            // 匿名パラメーター(Anonymous Parameter) でパラメーターを作成します。  
            updatedate = DateTime.Now,
            umaban = TARGET_NUMBER
        });

        Console.WriteLine($"\r\n{updateResult}件更新しました。");

        const string DELETE_SQL = @"DELETE FROM takarazuka_kinen WHERE umaban = @umaban;";

        var deleteResult = connection.Execute(DELETE_SQL, new
        {
            // 匿名パラメーター(Anonymous Parameter) でパラメーターを作成します。  
            umaban = TARGET_NUMBER
        });

        Console.WriteLine($"\r\n{deleteResult}件削除しました。");
    }

    /// <summary>
    /// 複数レコードの挿入
    /// </summary>
    private static void InsertMultipleRecords(SqliteConnection connection)
    {
        const string INSERT_SQL = @"
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
            new(8, 17, "ドゥラエレーデ", "牡", 3, 53, "幸", "池添")
        };

        // パラメーター用のリストを匿名パラメーター(Anonymous Parameter) に変換します。
        // ※takarazuka_kinenの馬番(umaban)は自動採番のため、パラメーターを使用しません。
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

        var result = connection.Execute(INSERT_SQL, multiInsertParams);
        Console.WriteLine($"\r\n{result}件追加しました。");

        /*
        匿名パラメーター(Anonymous Parameter) を先にまとめて作成してExecuteを実行するのではなく、
        追加したいデータを foreach で回しながら匿名パラメーター(Anonymous Parameter) を作成し、Executeを実行する方法もあります。

        foreach (var item in addList)
        {
            var multiInsertResult = connection.Execute(insertSql, new
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

            Console.WriteLine($"\r\n{multiInsertResult}件追加しました。");
        }   

        */
    }

    /// <summary>
    /// 複数レコードの更新
    /// </summary>
    private static void UpdateMultipleRecords(SqliteConnection connection)
    {
        const string UPDATE_SQL_1 = @"
            UPDATE takarazuka_kinen 
            SET updatedate = @updatedate
            WHERE umaban = @umaban;";

        var updateDate = DateTime.Now;

        // 匿名パラメーター(Anonymous Parameter) でパラメーターを作成します。        
        var multiUpdateParams = Enumerable.Range(1, 17).Select(index => new
        {
            umaban = index,
            updatedate = updateDate
        }).ToList();

        var multiUpdateResult = connection.Execute(UPDATE_SQL_1, multiUpdateParams);
        Console.WriteLine($"\r\n{multiUpdateResult}件更新しました。");

        const string UPDATE_SQL_2 = @"
            UPDATE takarazuka_kinen 
            SET updatedate = @updatedate
            WHERE umaban IN @umabanList;";

        // 馬番のIN句に展開するためのリスト
        var umabanList = Enumerable.Range(1, 17).ToList();

        var multiUpdateResult2 = connection.Execute(UPDATE_SQL_2, new
        {
            // 匿名パラメーター(Anonymous Parameter) でパラメーターを作成します。
            // パラメーター名と変数名が同じため「umabanList = umabanList」はイコールを省略できます。
            updatedate = updateDate,
            umabanList
        });
        Console.WriteLine($"\r\n{multiUpdateResult2}件更新しました。");
    }

    /// <summary>
    /// 全レコードの削除
    /// </summary>
    private static void DeleteAllRecords(SqliteConnection connection)
    {
        // テスト用データベースのデータを全て削除
        const string DELETE_SQL = @"DELETE FROM takarazuka_kinen;";

        var result = connection.Execute(DELETE_SQL);
        Console.WriteLine($"\r\n{result}件削除しました。");
    }

}


