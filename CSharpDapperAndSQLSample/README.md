## Program Name（プログラム名） 👻
CSharpDapperSample

## Overview（概要） 👻
C# Dapper サンプルコード<br>

2022年12月25日作成<br>
Created on December 25, 2022

## Description（説明） 👻
Qiita C# Advent Calendar 2022 25日目 の記事で使用したサンプルコードです。<br>
Sample code used in the article for the 25th day of the Qiita C# Advent Calendar 2022.

## Execution Environment（実行環境） 👻
* Visual Studio Code<br>
* .NET SDK (global.json を反映):<br>
Version:   8.0.401<br>

* ランタイム環境:<br>
 OS Name:     Windows 11 Pro<br>
 OS Version:  23H2<br>
 OS build:    22631.4169<br>

* 必要な nuget パッケージ:<br>
https://www.nuget.org/packages/Dapper<br>
https://www.nuget.org/packages/Microsoft.Data.Sqlite


## Executable Procedure（実行手順） 👻

#### sqlite の実行 🌟
https://www.sqlite.org/download.html<br>
上記のURLから「Precompiled Binaries for Windows」の「sqlite-tools-win-x64-xxx.zip」をダウンロードします。解凍後、適当なフォルダに移動し、バージョンを確認します。

Download “sqlite-tools-win-x64-xxx.zip” of “Precompiled Binaries for Windows” from the above URL. After unzipping, move to an appropriate folder and check the version.

```
E:\...\SQLite>sqlite3 --version
3.40.0 2022-11-16 12:10:08 89...
```
テスト用データベースはこのプログラムフォルダに含まれています。パスを指定してDBを開きます。`sqlite3 [フォルダパス\テーブル名].db` が実行コマンドです。

The test database is contained in this program folder. Open the DB by specifying the path. `sqlite3 [folder path\table name].db` is the execution command.

```
E:\...\SQLite>sqlite3 E:\...\advent.db
SQLite version 3.40.0 2022-11-16 12:10:08
Enter ".help" for usage hints.
sqlite>
```
テスト用データベースにテーブルがあるかどうかを確認します。`.tables` を実行します。 `arima_kinen` が表示された場合、テスト用テーブルが存在します。テーブルがない場合、DDLからCREATE文をコピーして実行してください。

Check if there are tables in the test database. Run `.tables`. If you see `arima_kinen`, the test table exists. If the table does not exist, copy the CREATE statement from DDL and execute it.
```
sqlite> .tables
arima_kinen
```
テーブルにデータがあるかどうかを確認します。データがある場合、SELECT文の実行後にデータが表示されます。
データがない場合、DMLからINSERT文をコピーして実行してください。

Checks to see if there is data in the table. If there is data, the data will be displayed after the SELECT statement is executed.
If there is no data, copy the INSERT statement from the DML and execute it.
```
sqlite> SELECT * FROM arima_kinen;
```

#### `dotnet run` を使用する場合 🌟

https://learn.microsoft.com/ja-jp/dotnet/core/tools/dotnet-run
VSCodeのターミナル(Command Prompt)で dotnet run を実行します。

Execute `dotnet run` in the VSCode terminal(Command Prompt).

```
xxx\til\CSharpDapperAndSQLSample>dotnet run
```

#### `Visual Studio Code` の 実行とデバッグ(F5) を使用する場合 🌟

この方法を使用する場合、一度 launch.json に設定が存在するかどうかを確認してください。設定はプログラム名と同じ名前で作成しています。正しい設定が存在する場合、F5または▷キーの押下でプログラムが実行できます。

If you use this method, check once to see if the configuration exists in launch.json.
The configuration is created with the same name as the program name.
If the correct settings exist, the program can be executed by pressing F5 or the ▷ key.
