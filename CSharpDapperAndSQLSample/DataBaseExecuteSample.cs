using Dapper;
using Microsoft.Data.Sqlite;

namespace CSharpDapperAndSQLSample;

public class DataBaseExecuteSample
{
    // 相対パスの場合、実行するフォルダと同じ場所にデータベースファイルを置きます。
    // データベースファイルがない場合、空のデータベースを作成します。
    private const string DataSource = @"Datasource=advent.db";

    /// <summary>
    /// 追加・更新・削除に関するメソッド
    /// </summary>
    public static void Execute()
    {
        // DataSource 以外のプロパティを設定しないため SqliteConnectionStringBuilder を経由しません。
        // SqliteConnection にそのまま DataSource を渡します。
        using var connection = new SqliteConnection(DataSource);

        using (var command = connection.CreateCommand())
        {
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

            // Anonymous Parameter でパラメーターを作成します。
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

            Console.WriteLine($"{insertResult}件追加しました。");

            var targetNo = 1;

            // 更新
            var updateSql = @"UPDATE takarazuka_kinen SET barei = 5 WHERE umaban = @umaban";
            var updateResult = connection.Execute(updateSql, new { umaban = targetNo });
            Console.WriteLine($"{updateResult}件更新しました。");

            // 削除
            var deleteSql = @"DELETE FROM takarazuka_kinen WHERE umaban = @umaban";
            var deleteResult = connection.Execute(deleteSql, new { umaban = targetNo });
            Console.WriteLine($"{deleteResult}件削除しました。");

            // COUNT
            var countSql = @"SELECT COUNT(*) FROM arima_kinen";
            var count = connection.ExecuteScalar(countSql);
            Console.WriteLine($"2022年の有馬記念は計{count}頭が出走しました。");

            // SUM
            var sumSql = @"SELECT SUM(barei) FROM arima_kinen";
            var sum = connection.ExecuteScalar(sumSql);
            Console.WriteLine($"馬齢の合計は{sum}です。");
        }
    }
}

