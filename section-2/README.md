# ## 第2回: デスクトップアプリケーションとMVVMパターン
Xamarin/WPFを使用したデスクトップアプリケーションとMVVMパターン

## WPF/Xamarinの基本

### WPF
WPF（Windows Presentation Foundation）は、Windowsデスクトップアプリケーションを開発するためのフレームワークです。WPFは、リッチなユーザーインターフェースを構築するための強力なツールセットを提供し、XAML（Extensible Application Markup Language）を使用してUIを定義します。

- **データバインディング**: 強力なデータバインディング機能を提供し、UIとビジネスロジックを分離します。
- **スタイルとテンプレート**: スタイルとテンプレートを使用してUIの外観をカスタマイズできます。
- **アニメーションとグラフィックス**: アニメーションや2D/3Dグラフィックスをサポートし、リッチなビジュアルエフェクトを実現します。
- **イベントハンドリング**: ルーティングイベントを使用して、イベントハンドリングを柔軟に行えます。

[WPF公式ドキュメント](https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/)

### Xamarin
Xamarinは、クロスプラットフォームのモバイルアプリケーション開発フレームワークです。Xamarinを使用すると、C#と.NETを使用してiOS、Android、およびWindows向けのアプリケーションを開発できます。Xamarin.Formsを使用すると、単一の共有コードベースから複数のプラットフォーム向けにUIを構築できます。

- **クロスプラットフォーム開発**: 単一のコードベースで複数のプラットフォーム向けにアプリケーションを開発できます。
- **ネイティブパフォーマンス**: 各プラットフォームのネイティブAPIを使用して、高いパフォーマンスを実現します。
- **XAMLサポート**: XAMLを使用してUIを定義できます。
- **豊富なライブラリとツール**: 豊富なライブラリとツールを提供し、開発を効率化します。

[Xamarin公式ドキュメント](https://docs.microsoft.com/ja-jp/xamarin/)

## XAMLの基本

### 基本構文と要素
XAMLの基本構文と主要な要素について説明します。

[XAMLの概要](https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/xaml/)

### コントロールの配置とプロパティ
XAMLでのコントロールの配置方法とプロパティの設定方法について説明します。

[WPFコントロール](https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/controls/)

### スタイルとテンプレート
XAMLでのスタイルとテンプレートの使用方法について説明します。

[スタイルとテンプレート](https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/controls/styling-and-templating/)

## MVVMパターン
MVVMパターン（Model-View-ViewModel）は、UIとビジネスロジックを分離するための設計パターンです。Modelはデータとビジネスロジックを管理し、Viewはユーザーインターフェースを担当します。ViewModelはViewとModelの仲介役として機能し、データバインディングを通じてViewとModelを連携させます。これにより、コードの再利用性が向上し、テストが容易になります。

[MVVMパターンの概要](https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/enterprise-application-patterns/mvvm)

## 演習

### デスクトップアプリケーションの作成
Xamarinを使った簡単なデスクトップアプリケーションを作成

```sh
dotnet new install Microsoft.Maui.Templates
dotnet new maui -n MauiApp
cd MauiApp
sudo dotnet workload restore
sudo dotnet workload install maui
sudo dotnet workload install maui-maccatalyst
dotnet build
dotnet run
```

[Xamarinのチュートリアル](https://docs.microsoft.com/ja-jp/xamarin/get-started/first-app/)

### MVVMパターンにリファクタリング
作成したアプリケーションをMVVMパターンを用いてリファクタリングします。

[MVVMパターンの実践](https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/enterprise-application-patterns/mvvm)

### データバインディングとイベントハンドリングの実践
データバインディングとイベントハンドリングの実践演習を行います。

[データバインディングの実践](https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/data/data-binding-overview/)

[イベントハンドリングの実践](https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/advanced/routed-events-overview/)