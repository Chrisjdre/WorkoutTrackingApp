   M S B A M L   `   `   `  ????I  EWorkoutTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WorkoutTrackerWorkoutTracker  5   	   +    %WorkoutTracker.AddExerciseStatsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WorkoutTracker     5   	   -   5          ? Title$  AddExerciseStatsWindow??5   	   $	??500??6(   $	??400??65   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5       ? ColumnDefinitions 5   
   ?? 5      ?? 5      .+?5   
   ?? $??2??6   $??Center=?6$   $??Center=?6A   $??Center=?6\   $??40??6?   $	??200??6?   .??6?   
Exercise6?   ?? 5   
   -   5         ??Name$ cboExercises??5      $??2??6)   $??Center=?6=   $??Bottom=?6Z   $??30??6u   $	??200??6?   $??97,0,96.6,9.6q?6?   ?? 5   
   $??2??6   $??1??6$   $??Center=?61   $??Center=?6N   $??Center=?6i   $??40??6?   $	??200??6?   .??6?   Weight6?   ?? 5   
   -   5         ??Name$ 	txtWeight??5      $??1??6%   $??2??62   $??Center=?6F   $??Bottom=?6c   $??40??6~   $	??200??6?   6?   ?? 5   
   $??2??6   $??2??6$   $??Center=?61   $??Center=?6N   $??Center=?6i   $??40??6?   $	??200??6?   .??6?   Sets6?   ?? 5   
   -   5        $ txtSets??5      $??2??6#   $??2??60   $??Center=?6D   $??Bottom=?6a   $??40??6|   $	??200??6?   6?   ?? 5    
   $??2??6   $??3??6$   $??Center=?61   $??Center=?6N   $??Center=?6i   $??40??6?   $	??200??6?   .??6?   Reps6?   ?? 5!   
   -   5        $ txtReps??5!      $??3??6#   $??2??60   $??Center=?6D   $??Bottom=?6a   $??40??6|   $	??200??6?   6?   ?? 5#   
   -   5         ??Name$ btnSave??5#      $??0??6"   $??4??62   $??50??6?   $	??100??6K   .??6m   Save6s   ?? 5$   
   -   5        $ Cancel??5$      $??1??6!   $??4??61   $??50??6>   $	??100??6J   .??6k   Cancel6s   5%      5&      