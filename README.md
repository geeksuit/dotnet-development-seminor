# 第1回 .NET Framework C#プログラミングの基礎

## .NET Framework の歴史

https://learn.microsoft.com/ja-jp/dotnet/framework/get-started/overview

### .NET Frameworkの歴史とバージョン
.NET Frameworkは2002年に初めてリリースされました。以降、複数のバージョンがリリースされ、機能が追加されてきました。  
当プロジェクトでは.NET framework 4.8(1) をターゲットにして開発します。

### .NET Coreの登場
2016年には、クロスプラットフォーム対応の.NET Coreがリリースされました。.NET Coreは、Windowsだけでなく、LinuxやmacOSでも動作するように設計されており、より柔軟な開発が可能となりました。

### .NET 5以降
2020年には、.NET Coreと.NET Frameworkを統合した新しいプラットフォームとして、.NET 5がリリースされました。.NET 5以降は、単に「.NET」と呼ばれ、クロスプラットフォーム対応が強化され、パフォーマンスの向上や新機能の追加が行われています。

https://learn.microsoft.com/ja-jp/dotnet/core/whats-new/dotnet-5

### CLR (Common Language Runtime) の役割
CLRは、.NET Frameworkの中核を成すランタイム環境です。  
プログラムの実行時にコードを管理し、様々なサービスを提供します。  
例えば、メモリ管理では、不要になったオブジェクトを自動的に解放するガベージコレクションを行います。これにより、メモリリークのリスクを減らすことができます。また、例外処理機能により、エラーが発生した際に適切に対処することができます。さらに、セキュリティ機能により、悪意のあるコードの実行を防ぐことができます。

https://learn.microsoft.com/ja-jp/dotnet/standard/CLR

### BCL (Base Class Library) の概要
BCLは、.NET Frameworkに含まれる標準ライブラリで、基本的なデータ型、コレクション、I/O操作、ネットワーキングなど、さまざまな機能を提供します。これにより、開発者は共通のタスクを簡単に実行できます。

https://learn.microsoft.com/ja-jp/dotnet/standard/base-types/common-type-system

## 開発言語
.NET Frameworkでは、C#、VB.NET、F#など、複数のプログラミング言語を使用して開発を行うことができます。これらの言語は、.NET Frameworkのランタイム環境であるCLR上で動作し、共通のライブラリやツールを利用することができます。

### C# の特徴
C#は、.NET Frameworkで最も広く使用されているプログラミング言語です。以下に、C#の主な特徴を示します。

https://learn.microsoft.com/ja-jp/dotnet/csharp/tour-of-csharp/

- **オブジェクト指向プログラミング (OOP)**: クラスやオブジェクトを使用してプログラムを構築するオブジェクト指向プログラミングをサポートしています。これにより、コードの再利用性や保守性が向上します。
- **強い型付け**: C#は、変数の型を明確に定義する強い型付けの言語です。これにより、コンパイル時に多くのエラーを検出でき、バグの発生を減らすことができます。
- **LINQ (Language Integrated Query)**: LINQを使用することで、コレクションやデータベースに対して直感的なクエリを実行できます。これにより、データ操作が簡単になります。
- **非同期プログラミング**: async/awaitキーワードを使用して、非同期プログラミングを簡単に実装できます。これにより、UIの応答性を保ちながら、バックグラウンドで時間のかかる操作を実行できます。
- **豊富なライブラリ**: .NET FrameworkのBCLをはじめとする豊富なライブラリを利用することで、さまざまな機能を簡単に実装できます。
- **クロスプラットフォーム**: .NET Coreや.NET 5以降を使用することで、Windowsだけでなく、LinuxやmacOSでも動作するアプリケーションを開発できます。

https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/tutorials/oop
https://learn.microsoft.com/ja-jp/dotnet/csharp/linq/
https://learn.microsoft.com/ja-jp/dotnet/csharp/asynchronous-programming/async-scenarios

## .NET Framework の概要

### アプリケーションモデル (Windows Forms, WPF, ASP.NET)
.NET Frameworkには、Windows Forms、WPF、ASP.NETなど、さまざまなアプリケーションモデルがあります。これらを使用して、デスクトップアプリケーションやWebアプリケーションを開発できます。

https://learn.microsoft.com/ja-jp/dotnet/desktop/wpf/?view=netdesktop-9.0

## 開発環境

### IDE

C#の開発には、JetBrains Rider、Microsoft Visual Studio、Microsoft VSCodeなどの統合開発環境（IDE）を使用できます。これらのIDEは、コード編集、デバッグ、テストなどの機能を提供します。

https://visualstudio.microsoft.com/ja/
https://code.visualstudio.com/

### 簡単なコンソールアプリケーションの作成と演習問題

- Hello Worldアプリケーションの作成
  - 最初のC#プログラムとして、Hello Worldアプリケーションを作成します。これは、コンソールに「Hello, World!」と表示するシンプルなプログラムです。
- 基本的な入出力操作
  - コンソールからの入力を受け取り、出力を表示する基本的な操作を学びます。これには、Console.ReadLine()やConsole.WriteLine()の使用が含まれます。
- 演習問題: CSVファイルの読み込みと書き出し
  - CSVファイルを読み込み、データを処理し、結果を新しいCSVファイルに書き出す演習問題を通じて、ファイル操作の基本を学びます。
