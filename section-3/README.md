# 第3回: .NET Standardライブラリの利用とパッケージ管理
.NET Standardライブラリの作成と利用、パッケージの管理

## .NET Standardの概要

### .NET Standardとは
.NET Standardは、すべての.NET実装で利用可能な.NET APIの仕様です。これにより、以下のような利点があります：

- **クロスプラットフォーム互換性**: .NET Framework、.NET Core、Xamarinなど、異なる.NET実装間でコードを共有できます
- **バージョン管理**: .NET Standard 2.0、2.1などのバージョンごとに利用可能なAPIが定義されています
- **将来性の確保**: 新しい.NET実装でも既存のライブラリを利用できます

### .NET Standardのバージョン
- **.NET Standard 1.0-1.6**: 基本的なAPIセット
- **.NET Standard 2.0**: 大幅に拡張されたAPIセット（推奨）
- **.NET Standard 2.1**: async/await、Span<T>などの新機能を含む

### どの.NET実装がサポートされているか
| .NET Standard | .NET Framework | .NET Core | .NET 5+ |
|---------------|----------------|-----------|---------|
| 2.0           | 4.6.1+         | 2.0+      | 5.0+    |
| 2.1           | N/A            | 2.1+      | 5.0+    |

## NuGetパッケージ

### NuGetとは
NuGetは.NETのパッケージマネージャーです。ライブラリやツールを簡単にプロジェクトに追加できます。

### NuGetの主な機能
- **パッケージの検索**: [nuget.org](https://www.nuget.org/)でパッケージを検索
- **依存関係の管理**: 必要な依存関係を自動的に解決
- **バージョン管理**: セマンティックバージョニングによる適切なバージョン管理

### よく使われるNuGetパッケージ
```xml
<!-- JSON処理 -->
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />

<!-- HTTP通信 -->
<PackageReference Include="Microsoft.Extensions.Http" Version="7.0.0" />

<!-- ロギング -->
<PackageReference Include="Serilog" Version="3.0.1" />

<!-- テスト -->
<PackageReference Include="xunit" Version="2.4.2" />
<PackageReference Include="xunit.runner.visualstudio" Version="2.4.5" />
```

### パッケージの管理コマンド
```bash
# パッケージの追加
dotnet add package PackageName

# パッケージの削除
dotnet remove package PackageName

# パッケージの復元
dotnet restore

# パッケージの更新
dotnet list package --outdated
dotnet add package PackageName --version 新しいバージョン
```

## ライブラリの作成

### .NET Standardライブラリプロジェクトの作成
```bash
# 新しい.NET Standardライブラリプロジェクトを作成
dotnet new classlib -n MyLibrary -f netstandard2.0

# プロジェクトディレクトリに移動
cd MyLibrary
```

### ライブラリのプロジェクトファイル例
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
    <PackageId>MyLibrary</PackageId>
    <PackageVersion>1.0.0</PackageVersion>
    <Authors>Your Name</Authors>
    <Description>My custom library for .NET Standard</Description>
    <PackageTags>utility;library</PackageTags>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
  </ItemGroup>

</Project>
```

### サンプルライブラリクラス
```csharp
using System;
using Newtonsoft.Json;

namespace MyLibrary
{
    public class JsonHelper
    {
        /// <summary>
        /// オブジェクトをJSON文字列に変換します
        /// </summary>
        /// <param name="obj">変換するオブジェクト</param>
        /// <returns>JSON文字列</returns>
        public static string ToJson(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        /// <summary>
        /// JSON文字列をオブジェクトに変換します
        /// </summary>
        /// <typeparam name="T">変換先の型</typeparam>
        /// <param name="json">JSON文字列</param>
        /// <returns>変換されたオブジェクト</returns>
        public static T FromJson<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentException("JSON string cannot be null or empty", nameof(json));

            return JsonConvert.DeserializeObject<T>(json);
        }
    }

    public class StringHelper
    {
        /// <summary>
        /// 文字列を逆順にします
        /// </summary>
        /// <param name="input">入力文字列</param>
        /// <returns>逆順の文字列</returns>
        public static string Reverse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        /// <summary>
        /// 文字列が回文かどうかを判定します
        /// </summary>
        /// <param name="input">判定する文字列</param>
        /// <returns>回文の場合true</returns>
        public static bool IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            string cleaned = input.ToLowerInvariant().Replace(" ", "");
            return cleaned == Reverse(cleaned);
        }
    }
}
```

### ライブラリのビルドとパッケージ化
```bash
# ライブラリをビルド
dotnet build

# NuGetパッケージを作成
dotnet pack

# 生成されたパッケージは bin/Debug/ または bin/Release/ にあります
```

## ライブラリの利用

### 作成したライブラリを他のプロジェクトで使用する

#### 1. ローカルNuGetパッケージの参照
```bash
# コンソールアプリケーションを作成
dotnet new console -n MyApp
cd MyApp

# ローカルのNuGetパッケージを参照
dotnet add package MyLibrary --source ../MyLibrary/bin/Debug/
```

#### 2. プロジェクト参照による利用
```bash
# プロジェクト参照を追加
dotnet add reference ../MyLibrary/MyLibrary.csproj
```

### 利用例のコンソールアプリケーション
```csharp
using System;
using MyLibrary;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== MyLibrary Demo ===\n");

            // JSONHelperのテスト
            TestJsonHelper();

            // StringHelperのテスト
            TestStringHelper();
        }

        static void TestJsonHelper()
        {
            Console.WriteLine("--- JSON Helper Test ---");
            
            var person = new { Name = "田中太郎", Age = 30, City = "東京" };
            
            // オブジェクトをJSONに変換
            string json = JsonHelper.ToJson(person);
            Console.WriteLine("JSON:");
            Console.WriteLine(json);
            
            // JSONをオブジェクトに変換
            var restored = JsonHelper.FromJson<dynamic>(json);
            Console.WriteLine($"\nRestored: Name={restored.Name}, Age={restored.Age}");
            Console.WriteLine();
        }

        static void TestStringHelper()
        {
            Console.WriteLine("--- String Helper Test ---");
            
            string[] testStrings = { "hello", "racecar", "A man a plan a canal Panama" };
            
            foreach (string str in testStrings)
            {
                string reversed = StringHelper.Reverse(str);
                bool isPalindrome = StringHelper.IsPalindrome(str);
                
                Console.WriteLine($"Original: '{str}'");
                Console.WriteLine($"Reversed: '{reversed}'");
                Console.WriteLine($"Is Palindrome: {isPalindrome}");
                Console.WriteLine();
            }
        }
    }
}
```

### プロジェクトファイルでの依存関係管理
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <!-- ローカルプロジェクト参照 -->
    <ProjectReference Include="..\MyLibrary\MyLibrary.csproj" />
    
    <!-- または NuGetパッケージ参照 -->
    <!-- <PackageReference Include="MyLibrary" Version="1.0.0" /> -->
  </ItemGroup>

</Project>
```

## 演習

### 演習1: 計算ライブラリの作成
**目標**: 基本的な数学計算を行う.NET Standardライブラリを作成しましょう。

#### 手順:
1. `MathLibrary`という名前で.NET Standard 2.0ライブラリを作成
2. 以下の機能を持つ`Calculator`クラスを実装:
   - 四則演算（Add, Subtract, Multiply, Divide）
   - 累乗計算（Power）
   - 平方根計算（SquareRoot）
   - 階乗計算（Factorial）

```csharp
// 実装例のヒント
public class Calculator
{
    public static double Add(double a, double b) => a + b;
    public static double Subtract(double a, double b) => a - b;
    // 他のメソッドも実装してください
}
```

### 演習2: ライブラリのテスト
**目標**: 作成したライブラリの動作を確認するテストを作成しましょう。

#### 手順:
1. xUnitテストプロジェクトを作成
2. Calculatorクラスの各メソッドをテスト
3. 境界値やエラーケースもテスト

```bash
# テストプロジェクトの作成
dotnet new xunit -n MathLibrary.Tests
cd MathLibrary.Tests
dotnet add reference ../MathLibrary/MathLibrary.csproj
dotnet add package Microsoft.NET.Test.Sdk
```

### 演習3: コンソールアプリケーションでの利用
**目標**: 作成したライブラリを使用する簡単な電卓アプリを作成しましょう。

#### 要件:
- ユーザーから2つの数値と演算子を入力
- 計算結果を表示
- 継続的に計算を実行できる
- 'q'で終了

```csharp
// 実装例のヒント
while (true)
{
    Console.Write("数値1を入力: ");
    if (!double.TryParse(Console.ReadLine(), out double num1))
        continue;
    
    Console.Write("演算子を入力 (+, -, *, /, q=終了): ");
    string op = Console.ReadLine();
    
    if (op == "q") break;
    
    // 演算の実行と結果表示
}
```
