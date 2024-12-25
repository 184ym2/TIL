using Dapper;
using CSharpDapperAndSQLSample.Repository;
using CSharpDapperAndSQLSample.Model;
using CSharpDapperAndSQLSample.DapperSettings.TypeHandler;
using CSharpDapperAndSQLSample.DapperSettings.SetTypeMap;

namespace CSharpDapperAndSQLSample;

class Program
{
    static void Main(string[] args)
    {
        // 取得、集計の例
        //ArimaKinenRepository.Execute();
        
        // 追加、更新、削除の例
        //TakarazukaKinenRepository.Execute();

        // 型ハンドラーの設定
        TypeHandlerSettings.ConfigureDapperTypeHandlers();

        // カスタムマッピングの設定
        CustomPropertyMapper.ConfigureDubaiSheemaClassicMappings();


        // 型ハンドラーを使用した取得、追加
        TokyoYushunRepository.Execute();
 
        // 型ハンドラー + カスタムマッピングを使用した取得、追加
        //DubaiSheemaClassicRepository.Execute();
    }

}
