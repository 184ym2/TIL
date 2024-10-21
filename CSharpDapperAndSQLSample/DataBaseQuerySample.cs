using Dapper;
using System.Data;
using Microsoft.Data.Sqlite;

namespace CSharpDapperAndSQLSample;

public class DataBaseQuerySample
{
    // 相対パスの場合、実行時のルートディレクトリにデータベースファイルを置く必要があります。
    // dotnet run の場合、必ずプロジェクトのルートディレクトリ（CSharpDapperAndSQLSample）から実行されますが、
    // F5実行の場合、launch.json の cwd で指定されたディレクトリから実行します。そのため、cwd の設定を必ず確認してください。
    // 実行時のルートディレクトリにデータベースファイルがない場合、空のデータベースを作成します。
    private const string DataSource = @"Datasource=advent.db";

    /// <summary>
    /// 取得に関するメソッド
    /// </summary>
    public static void Query()
    {
        // DataSource 以外のプロパティを設定しないため SqliteConnectionStringBuilder を経由しません。
        // SqliteConnection にそのまま DataSource を渡します。
        using var connection = new SqliteConnection(DataSource);

        using var command = connection.CreateCommand();
        connection.Open();

        // 1. 複数行のデータを取得する場合（型指定あり）
        var sql1 = @"SELECT * FROM arima_kinen;";
        var rows = connection.Query<ArimaKinenDTO>(sql1);

        Console.WriteLine("\r\n複数行を取得し、全てのレコードを返します。");
        foreach (var row in rows)
        {
            Console.WriteLine($"{row.Wakuban} {row.Umaban} {row.Bamei} {row.Seibetu}{row.Barei} {row.Kinryo} {row.Kisyu} {row.Kyusya}");
        }

        // 2. 単一のデータを取得する場合（型指定あり）

        // QuerySingleOrDefault(QuerySingle)の場合、複数行を取得するSELECT文を投げるとエラーになります。かならず単一行を返すSELECT文を作成してください。
        var sql2 = @"SELECT * FROM arima_kinen WHERE umaban = 8;";
        var singleRow = connection.QuerySingleOrDefault<ArimaKinenDTO>(sql2);
        Console.WriteLine("\r\n1行を取得し、1行目のレコードを返します。");

        // 1行を取得する場合、取得したデータがnullかどうかをチェックして処理を分岐することがある
        if (singleRow == null)
        {
            // エラーの処理など
        }
        else
        {
            Console.WriteLine($"{singleRow.Wakuban} {singleRow.Umaban} {singleRow.Bamei} {singleRow.Seibetu}{singleRow.Barei} {singleRow.Kinryo} {singleRow.Kisyu} {singleRow.Kyusya}");
        }

        var sql3 = @"SELECT * FROM arima_kinen;";
        var firstRow = connection.QueryFirstOrDefault<ArimaKinenDTO>(sql3);
        Console.WriteLine("\r\n複数行を取得し、1行目のレコードを返します。");

        // 1行を取得する場合、取得したデータがnullかどうかをチェックして処理を分岐することがある
        if (firstRow == null)
        {
            // エラーの処理など
        }
        else
        {
            Console.WriteLine($"{firstRow.Wakuban} {firstRow.Umaban} {firstRow.Bamei} {firstRow.Seibetu}{firstRow.Barei} {firstRow.Kinryo} {firstRow.Kisyu} {firstRow.Kyusya}");
        }

        // 3. 複数のSELECT文を実行し、データを取得する場合（型指定あり）
        var sql4 = @"
            SELECT * FROM arima_kinen;
            SELECT * FROM arima_kinen WHERE umaban = 13;
            SELECT COUNT(*) FROM arima_kinen;
            ";

        // SELECT文をまとめて実行します。
        var multi = connection.QueryMultiple(sql4);

        // 戻り値の型を指定して1番目のSELECT文の取得結果を受け取ります。
        var allRows = multi.Read<ArimaKinenDTO>();

        // 戻り値の型を指定して2番目のSELECT文の取得結果を受け取ります。
        var firstReadRow = multi.ReadFirstOrDefault<ArimaKinenDTO>();

        // 戻り値の型を指定して3番目のSELECT文の取得結果を受け取ります。
        var count = multi.ReadFirstOrDefault<int>();

        Console.WriteLine("\r\n複数のクエリを実行します。");
        foreach (var row in allRows)
        {
            Console.WriteLine($"{row.Wakuban} {row.Umaban} {row.Bamei} {row.Seibetu}{row.Barei} {row.Kinryo} {row.Kisyu} {row.Kyusya}");
        }

        Console.WriteLine($"\r\n{firstReadRow?.Wakuban} {firstReadRow?.Umaban} {firstReadRow?.Bamei} {firstReadRow?.Seibetu}{firstReadRow?.Barei} {firstReadRow?.Kinryo} {firstReadRow?.Kisyu} {firstReadRow?.Kyusya}");

        Console.WriteLine($"\r\n2022年の有馬記念は計{count}頭が出走しました。");

        // 4. WHERE句の単一パラメーターを設定する
        var sql5 = @"SELECT * FROM arima_kinen WHERE umaban = @umaban;";

        // 匿名パラメーター(Anonymous Parameter)の場合
        // new {[カラム名] = [値]} でパラメーターを作成します。
        var param1 = 3;
        var apResult = connection.QueryFirstOrDefault<ArimaKinenDTO>(sql5, new { umaban = param1 });

        Console.WriteLine("\r\n馬番が3の馬を返します。");
        Console.WriteLine($"{apResult?.Wakuban} {apResult?.Umaban} {apResult?.Bamei} {apResult?.Seibetu}{apResult?.Barei} {apResult?.Kinryo} {apResult?.Kisyu} {apResult?.Kyusya}");

        // 動的パラメーター(Dynamic Parameters)の場合
        // Dynamic Parametersを作成し、Addメソッドでパラメーターを作成します。
        var parameters = new DynamicParameters();
        var param2 = "4";
        parameters.Add("@umaban", param2, DbType.Int32); // 第3引数はパラメータの型を指定します。 
        var dpResult = connection.QueryFirstOrDefault<ArimaKinenDTO>(sql5, parameters);

        Console.WriteLine("\r\n馬番が4の馬を返します。");
        Console.WriteLine($"{dpResult?.Wakuban} {dpResult?.Umaban} {dpResult?.Bamei} {dpResult?.Seibetu}{dpResult?.Barei} {dpResult?.Kinryo} {dpResult?.Kisyu} {dpResult?.Kyusya}");

        // 5. WHERE句のIN句パラメーターを設定する
        var sql6 = @"SELECT * FROM arima_kinen WHERE umaban in @umaban;";

        // in句に設定したい値で配列を作成します。new List<int> { 1, 5, 9 }; でもOK
        var numbers = new[] { 1, 5, 9 };
        var numbersList = new List<int> { 1, 5, 9 };

        // Anonymous Parameterで配列のパラメータを作成します。
        var targetRows = connection.Query<ArimaKinenDTO>(sql6, new { umaban = numbers });

        Console.WriteLine("\r\n馬番が1,5,9の馬を返します。");
        foreach (var row in targetRows)
        {
            Console.WriteLine($"{row.Wakuban} {row.Umaban} {row.Bamei} {row.Seibetu}{row.Barei} {row.Kinryo} {row.Kisyu} {row.Kyusya}");
        }
    }

}


