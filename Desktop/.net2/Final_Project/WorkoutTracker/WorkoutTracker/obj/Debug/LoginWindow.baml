   M S B A M L   `   `   `  ????I  EWorkoutTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WorkoutTrackerWorkoutTracker  5   	       WorkoutTracker.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WorkoutTracker     5   	     ? Title$  Login??5   	   $	??200??6   $	??400??6$    ? WindowStartupLocation$ CenterOwner=?60   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $??50 ?6   ?? 5      $??50 ?6   ?? 5      $??50 ?6    ? ColumnDefinitions 5   
   ?? 5      ?? 5      .+?5   
   ?? -   5         ??Name$ lblEmail??5      $??30??6"   $??85??6.   $??Right=?69   .??6U   Email Address6d   ?? 5   
   -   5         ??Name$ txtEmail??5      $??1??6$   $??20??64   $	??150??6@   6N   ?? 5   
   -   5        $ lblPassword??5      $??1??6%   $??30??62   $??60??6>   $??Right=?6I   .??6e   
Password6o   G? 5   
   -   5         G?Name$ txtPassword??5      $??1??6+   $??1??68   $??20??6H   $	??150??6T   6b   ?? 5   
   -   5         ??Name$ btnLogin??5      $??0??6#   $??2??63   $??Right=?6A   $??20??6]   $??60??6i   $??0,0,5,0q?6t   .??6?   Login6?   ?? 5   
   -   5        $ 	btnCancel??5      $??1??6$   $??2??64   $
??Left=?6A   $??20??6\   $??60??6h   $??5,0,0,0q?6s   .??6?   Cancel6?   5      5       