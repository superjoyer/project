   M S B A M L   `   `   `  ����L  HBettingSummaryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:BettingSummaryApp.ViewModelsBettingSummaryApp.ViewModels  5   	   $    BettingSummaryApp.ReportWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:BettingSummaryApp.ViewModels     5   	     � Title$  
Отчет��5   	   $	��350��6   $	��920��6$    � 
ResizeMode$ NoResize=�60    � DataContext 5	      2  ,BettingSummaryApp.ViewModels.ReportViewModel  5
   
   .��5      � $��0,0,-6.333,-0.333q�6    � RowDefinitions 5   
   �� 5      $	��16* �6   6+   �� 5      $	��55* �6   6+   �� 5      $	��22* �6   �� 5      $	��47* �6   6+    � ColumnDefinitions 5   
   �� 5      $
��227* �6   6.   �� 5      $
��249* �6   6.   �� 5      $
��243* �6   6.   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dd��5   /      AutoGenerateColumns .  $��3��6`   $��10,26,19.667,10q�6t   $��4��6�   ��6;   �� *ReportSource+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Отдел��6U   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 90* 6d   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *departament.DepartamentName+6d     5      $# Начало действия��6b   $
	 110* 6{   
 6%   �� *actionStartDate+ �� StringFormat$ 
dd.MM.yyyy��6{     5      $ Окончание��6`   $		 150 6s   
 6%   �� *actionEndDate+$ 
dd.MM.yyyy��6s     5      $' !ФОТ отдела в месяц��6H   $		 170 6d   
 6%   �� *FOTdepartament+6d   5!      �� 5"   
   -   5         ��Name$ label��5"      $"��Итоговый отчет:��6   $
��Left=�69   $��10,1,0,0q�6T   $	��Top=�6f   5#      5$      