   M S B A M L   `   `   `  ????I  EWorkoutTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WorkoutTrackerWorkoutTracker  5   	   "    WorkoutTracker.WorkoutWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WorkoutTracker     5   	   -   5          ? Title$  WorkoutWindow??5   	   $	??450??6   $	??300??6,   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $??50 ?6   ?? 5      $??50 ?6   ?? 5       ? ColumnDefinitions 5   
   ?? 5      ?? 5      .+?5   
   ?? -   5         ??Name$ lblWorkoutName??5      $??2??6(   $??Center=?6<   $??Center=?6`   $
??Bold"?6?   $??18(?6?   $??10,0,9.6,0.4q?6?   .??6?   Workout Name6?   ?? 5   
   -   5         ??Name$ btnAdd??5      $??1??6!   $??0??6.   $??20??6>   $??60??6J   $
??Left=?6U   $??10,0,0,0q?6p   .??6?   Add6?   ?? 5   
   -   5        $ btnEdit??5      $??1??6"   $??2??6/   $??20??6D   $??60??6P   $??Center=?6[   .??6?   Edit6?   ?? 5   
   -   5        $ 	btnDelete??5      $??1??6$   $??1??61   $??20??6A   $??60??6M   $??Right=?6X   $??0,0,10,0q?6t   .??6?   Delete6?   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datExercisestat??5      $??2??6,   $??2??69      
IsReadOnly . 6a   5      5      