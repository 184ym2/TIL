using System.Data;
using Dapper;

namespace CSharpDapperAndSQLSample;

class Program
{
    static void Main(string[] args)
    {
        // 取得の例
        DataBaseQuerySample.Query();

        // 追加、更新、削除、集計の例
        DataBaseExecuteSample.Execute();

        // UmaBanの型ハンドラーを追加
        // 作成した型ハンドラーを使用するためには、SqlMapper.AddTypeHandlerを使用する   
        SqlMapper.AddTypeHandler(new UmaBanTypeHandler());
    }
}
