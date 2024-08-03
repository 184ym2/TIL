<div align="center">

# 𝕌𝕟𝕧𝕖𝕚𝕝𝕚𝕟𝕘 𝕥𝕙𝕖 𝕊𝕖𝕔𝕣𝕖𝕥𝕤 𝕠𝕗 𝕋𝕖𝕒
![ライセンス](https://img.shields.io/github/license/184ym2/til)
![ソースコードサイズ](https://img.shields.io/github/languages/code-size/184ym2/til)

学習用サンプルコード保管庫です。</br>
Sample code repository for learning.</br>
</div>

# 

### コンソールプログラムについて

下記のURLを参考にしています。

* [VSCode Debugging](https://code.visualstudio.com/docs/editor/debugging)<br>

* [Visual Studio Code で .NET を使用する](https://code.visualstudio.com/docs/languages/dotnet)<br>

* [チュートリアル: Visual Studio Code を使用して .NET コンソール アプリケーションを作成する](https://learn.microsoft.com/ja-jp/dotnet/core/tutorials/with-visual-studio-code?pivots=dotnet-6-0)<br>

* [チュートリアル: Visual Studio Code を使用して .NET コンソール アプリケーションをデバッグする](https://learn.microsoft.com/ja-jp/dotnet/core/tutorials/debugging-with-visual-studio-code?pivots=dotnet-6-0)<br>

#### launch.json の解説メモ

| 項目              | 説明                                                                                                                                                                      | 
| ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | 
| `"name"`          | この構成の名前です。VS Codeのデバッグパネルで表示される名前です。                                                                                                         | 
| `"type"`          | デバッガのタイプを指定します。`"coreclr"`は.NET Coreデバッガを使用することを意味します。                                                                                  | 
| `"request"`       | デバッグセッションのタイプを指定します。`"launch"`はプログラムを起動してデバッグすることを意味します。                                                                    | 
| `"preLaunchTask"` | デバッグを開始する前に実行するタスクを指定します。`"build"`は、プロジェクトをビルドするタスクが実行されます。                                                             | 
| `"program"`       | デバッグ対象のプログラムのパスを指定します。`${workspaceFolder}`は現在のワークスペースのフォルダを指します。この例では、デバッグ対象のDLLファイルのパスを指定しています。 | 
| `"args"`          | プログラムに渡す引数を指定します。ここでは空の配列 `[]` が指定されており、引数はありません。                                                                              | 
| `"cwd"`           | プログラムの実行時のカレントディレクトリを指定します。`${workspaceFolder}`は現在のワークスペースのフォルダを指します。                                                    | 
| `"stopAtEntry"`   | プログラムのエントリーポイントでデバッガを停止するかどうかを指定します。`false`に設定されているため、エントリーポイントでは停止しません。                                 | 
| `"console"`       | プログラムの出力を表示するコンソールのタイプを指定します。`"internalConsole"`はVS Codeの内部コンソールを使用することを意味します。                                        | 




