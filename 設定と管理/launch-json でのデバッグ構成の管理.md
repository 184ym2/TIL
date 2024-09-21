# launch.json について

`launch.json` は、Visual Studio Code（VSCode）でデバッグ構成を管理するための設定ファイルです。このファイルを使って、どのようにプログラムをデバッグするかを設定できます。例えば、プログラムのエントリーポイント、環境変数、デバッグ時に使用するコマンドライン引数などを指定します。

## VSCodeで `launch.json` を使用する典型的な流れ

1. **作成場所**  
   `launch.json`は、VSCodeのワークスペースフォルダ内の `.vscode` フォルダに配置されます。`launch.json`は自動で生成されることもあり、手動で編集することも可能です。

2. **基本的な構造**

   `launch.json` は JSON形式で書かれており、いくつかの基本的な項目があります。C#の例を下記に示します。

   ```json
    {
        "version": "0.2.0", // ファイルのバージョンを指定　通常は "0.2.0" 
        "configurations": [ // 複数のデバッグ構成を持つことができ、それぞれが独立した設定となる
        {
            "name": ".NET Core Launch (console)",  // 必須
            "type": "coreclr", // 必須
            "request": "launch", // 必須
            "preLaunchTask": "build",              
            "program": "${workspaceFolder}/bin/Debug/net6.0/MyApp.dll", // 必須
            "args": [],                            
            "cwd": "${workspaceFolder}", // 必須
            "stopAtEntry": false,                  
            "console": "internalConsole", // 必須
            "logging": {
                "engineLogging": false,
                "trace": true,
                "moduleLoad": false
            },
            "internalConsoleOptions": "openOnSessionStart",
            "env": {
                "ASPNETCORE_ENVIRONMENT": "Development"
            }
        }
     ]
    }

   ```

### launch.json の解説メモ

# launch.json 解説メモ

| 項目              | 説明                                                                                                                                                                      | 
| ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | 
| `"name"`          | この構成の名前です。VS Codeのデバッグパネルで表示される名前です。複数のデバッグ構成がある場合に識別するために使います。                                                                                                         | 
| `"type"`          | デバッグする言語や環境を指定します。C#の場合は `"coreclr"` を指定し、これは .NET Core デバッガを使用することを意味します。他の例では、Node.jsは `"node"`, Pythonは `"python"` です。                                                                                  | 
| `"request"`       | デバッグセッションのタイプを指定します。`"launch"` はプログラムを新たに起動してデバッグすることを意味します。一方で、既存のプロセスにアタッチする場合は `"attach"` を指定します。                                                                    | 
| `"preLaunchTask"` | デバッグを開始する前に実行するタスクを指定します。`"build"` は、プロジェクトをビルドするタスクが実行されます。特定のビルドコマンドや他のタスクも指定可能です。                                                             | 
| `"program"`       | デバッグ対象のプログラムのパスを指定します。`${workspaceFolder}` は現在のワークスペースのフォルダを指します。この例では、デバッグ対象のDLLファイルのパスを指定していますが、他のプラットフォームや言語では異なるファイルパスを指定します。 | 
| `"args"`          | プログラムに渡す引数を指定します。ここでは空の配列 `[]` が指定されており、引数はありませんが、必要に応じてコマンドライン引数を指定できます。                                                                              | 
| `"cwd"`           | プログラムの実行時のカレントディレクトリを指定します。`${workspaceFolder}` は現在のワークスペースのフォルダを指します。通常、デバッグ対象のファイルが存在するフォルダを指定します。                                                    | 
| `"stopAtEntry"`   | プログラムのエントリーポイントでデバッガを停止するかどうかを指定します。`false` に設定されているため、エントリーポイントでは停止しません。`true` に設定すると、デバッグ開始時に最初の行で停止します。                                 | 
| `"console"`       | プログラムの出力を表示するコンソールのタイプを指定します。`"internalConsole"` はVS Codeの内部コンソールを使用することを意味します。他に、`"integratedTerminal"`（統合ターミナル）や `"externalTerminal"`（外部ターミナル）も指定可能です。                                        | 
| `"logging"`       | デバッグ時にロギングの詳細を指定します。例として `"engineLogging": true` は、デバッグエンジンの詳細なログを出力します。これにより、デバッグがうまくいかない場合に詳細な情報を確認することができます。 |
| `"internalConsoleOptions"` | デバッグセッション開始時にコンソールを自動で開くかどうかを指定します。例えば `"openOnSessionStart"` はデバッグセッション開始時にコンソールを自動で開きます。 |
| `"env"`           | 環境変数を指定します。例えば、ASP.NET Core の開発環境を設定するために、`"ASPNETCORE_ENVIRONMENT": "Development"` というように設定することができます。複数の環境変数を定義する場合は、複数のキーと値を追加します。 |
