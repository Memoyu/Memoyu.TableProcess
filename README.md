## 商品配送明细表处理

#### 概述

​	应客户要求，将他们商城管理程序导出的商品配送明细Excel表进行读取，并展示到程序，然后进行未完善信息的数据进行修改，最后导出成根据路线进行分组的汇总拣货Excel表。 

#### 框架

​	程序由WPF开发，目前很简单，就是处理了表单的导入导出汇总，但是还是使用了容器、依赖注入等框架，主要是防止客户需要多加功能。

 * 参照了大佬的设计实现：[痕迹大佬的项目](https://github.com/HenJigg/WPF-Xamarin-Blazor-Examples)

​	* 界面：[Material Design In XAML Toolkit](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)

​	* 容器：[Autofac](https://github.com/autofac/Autofac)

​	* MVVM：[MvvmLight](https://archive.codeplex.com/?p=mvvmlight)

​ * Excel操作：[NPOI](https://github.com/dotnetcore/NPOI)

#### 效果

**主界面**
![Main](https://github.com/Memoyu/Memoyu.TableProcess/blob/master/Image/main.png "Main")

**读取Excel明细**
![Detail](https://github.com/Memoyu/Memoyu.TableProcess/blob/master/Image/detail.png "Detail")

**整体效果**
![Show](https://github.com/Memoyu/Memoyu.TableProcess/blob/master/Image/Table.gif "Show")

