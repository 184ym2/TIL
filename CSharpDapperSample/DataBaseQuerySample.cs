using Dapper;
using System.Data;
using Microsoft.Data.Sqlite;

namespace CSharpDapperSample
{
    public class DataBaseQuerySample
    {
        // 相対パスの場合、実行するフォルダと同じ場所にデータベースファイルを置きます。
        // データベースファイルがない場合、空のデータベースを作成します。
        private const string DataSource = @"Datasource=advent.db";

        /// <summary>
        /// 取得に関するメソッド
        /// </summary>
        public void Query()
        {
            // DataSource 以外のプロパティを設定しないため SqliteConnectionStringBuilder を経由しません。
            // SqliteConnection にそのまま DataSource を渡します。
            using var connection = new SqliteConnection(DataSource);

            using (var command = connection.CreateCommand())
            {
                connection.Open();

                // 1. 複数行のデータを取得する場合
                var sql1 = @"SELECT * FROM arima_kinen;";
                var result = connection.Query<ArimaKinenDTO>(sql1);

                Console.WriteLine("\r\n複数行を取得し、全てのレコードを返します。");
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Wakuban} {item.Umaban} {item.Bamei} {item.Seibetu}{item.Barei} {item.Kinryo} {item.Kisyu} {item.Kyusya}");
                }

                // 2. 単一のデータを取得する場合
                // QuerySingleOrDefault(QuerySingle)の場合、複数行を取得するSELECT文を投げるとエラーになります。かならず単一行を返すSELECT文を作成してください。
                var sql2 = @"SELECT * FROM arima_kinen WHERE umaban = 8;";
                var result2 = connection.QuerySingleOrDefault<ArimaKinenDTO>(sql2);
                Console.WriteLine("\r\n1行を取得し、1行目のレコードを返します。");
                Console.WriteLine($"{result2.Wakuban} {result2.Umaban} {result2.Bamei} {result2.Seibetu}{result2.Barei} {result2.Kinryo} {result2.Kisyu} {result2.Kyusya}");

                var sql3 = @"SELECT * FROM arima_kinen;";
                var result3 = connection.QueryFirstOrDefault<ArimaKinenDTO>(sql3);
                Console.WriteLine("\r\n複数行を取得し、1行目のレコードを返します。");
                Console.WriteLine($"{result3.Wakuban} {result3.Umaban} {result3.Bamei} {result3.Seibetu}{result3.Barei} {result3.Kinryo} {result3.Kisyu} {result3.Kyusya}");

                // 3. 複数のSELECT文を実行し、データを取得する場合
                var sql4 = @"
                SELECT * FROM arima_kinen;
                SELECT * FROM arima_kinen WHERE umaban = 13;
                SELECT COUNT(*) FROM arima_kinen;
                ";
                // SELECT文をまとめて実行します。
                var multi = connection.QueryMultiple(sql4);

                // 戻り値の型を指定して1番目のSELECT文の取得結果を受け取ります。
                var all = multi.Read<ArimaKinenDTO>();

                // 戻り値の型を指定して2番目のSELECT文の取得結果を受け取ります。
                var first = multi.ReadFirstOrDefault<ArimaKinenDTO>();

                // 戻り値の型を指定して3番目のSELECT文の取得結果を受け取ります。
                var count = multi.ReadFirstOrDefault<int>();

                Console.WriteLine("\r\n複数のクエリを実行します。");
                foreach (var item in all)
                {
                    Console.WriteLine($"{item.Wakuban} {item.Umaban} {item.Bamei} {item.Seibetu}{item.Barei} {item.Kinryo} {item.Kisyu} {item.Kyusya}");
                }

                Console.WriteLine($"\r\n{first.Wakuban} {first.Umaban} {first.Bamei} {first.Seibetu}{first.Barei} {first.Kinryo} {first.Kisyu} {first.Kyusya}");

                Console.WriteLine($"\r\n2022年の有馬記念は計{count}頭が出走しました。");

                // 4. WHERE句の単一パラメーターを設定する
                var sql5 = @"SELECT * FROM arima_kinen WHERE umaban = @umaban;";

                // Anonymous Parameterの場合
                // new {[カラム名] = [値]} でパラメーターを作成します。
                var number = 3;
                var apResult = connection.QueryFirstOrDefault<ArimaKinenDTO>(sql5, new { umaban = number });

                Console.WriteLine("\r\n馬番が3の馬を返します。");
                Console.WriteLine($"{apResult.Wakuban} {apResult.Umaban} {apResult.Bamei} {apResult.Seibetu}{apResult.Barei} {apResult.Kinryo} {apResult.Kisyu} {apResult.Kyusya}");

                // Dynamic Parametersの場合
                // Dynamic Parametersを作成し、Addメソッドでパラメーターを作成します。
                var parameters = new DynamicParameters();
                var number2 = "4";
                parameters.Add("@umaban", number2, DbType.Int32); // 第3引数はパラメータの型を指定します。 
                var dpResult = connection.QueryFirstOrDefault<ArimaKinenDTO>(sql5, parameters);

                Console.WriteLine("\r\n馬番が4の馬を返します。");
                Console.WriteLine($"{dpResult.Wakuban} {dpResult.Umaban} {dpResult.Bamei} {dpResult.Seibetu}{dpResult.Barei} {dpResult.Kinryo} {dpResult.Kisyu} {dpResult.Kyusya}");

                // 5. WHERE句のIN句パラメーターを設定する
                var sql6 = @"SELECT * FROM arima_kinen WHERE umaban in @umaban;";

                // in句に設定したい値で配列を作成します。new List<int> { 1, 5, 9 }; でもOK
                var numbers = new[] { 1, 5, 9 };

                // Anonymous Parameterで配列のパラメータを作成します。
                var result6 = connection.Query<ArimaKinenDTO>(sql6, new { umaban = numbers });

                Console.WriteLine("\r\n馬番が1,5,9の馬を返します。");
                foreach (var item in result6)
                {
                    Console.WriteLine($"{item.Wakuban} {item.Umaban} {item.Bamei} {item.Seibetu}{item.Barei} {item.Kinryo} {item.Kisyu} {item.Kyusya}");
                }

            }
        }

    }
}

