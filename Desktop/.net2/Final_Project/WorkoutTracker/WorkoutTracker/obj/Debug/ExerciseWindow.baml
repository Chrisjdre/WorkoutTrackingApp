   M S B A M L   `   `   `  ????I  EWorkoutTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WorkoutTrackerWorkoutTracker  5   	   #    WorkoutTracker.ExerciseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WorkoutTracker     5   	   -   5          ? Title$  ExerciseWindow??5   	   $	??450??6    $	??800??6-   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $	??100 ?6   ?? 5      $	??300 ?6   .+?5   
   ?? -   5         ??Name$ lblExerciseName??5      $??0??6)   $??Center=?66   $??Center=?6X   $??40(?6|   $
??Bold"?6?   .??6?   
Exercise6?   ?? 5   
   -   5         ??Name$ txtExerciseDescription??5      $??1??62   $??20(?6?    ?? TextWrapping$
 Wrap=?6M    ?? 
IsReadOnly . .??6s   	Example6}   5      5      