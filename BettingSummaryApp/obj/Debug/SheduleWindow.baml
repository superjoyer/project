   M S B A M L   `   `   `  ����L  HBettingSummaryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:BettingSummaryApp.ViewModelsBettingSummaryApp.ViewModels  5   	   E'clr-namespace:BettingSummaryApp.ClassesBettingSummaryApp.Classes  5   	   %    BettingSummaryApp.SheduleWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:BettingSummaryApp.ViewModels     5   	   :extern'clr-namespace:BettingSummaryApp.Classes     5   	     � Title$  Расписание��5	   	   $	��350��6   $	��920��6)    � 
ResizeMode$ NoResize=�65    � DataContext 5
      3  -BettingSummaryApp.ViewModels.SheduleViewModel  5   
   y�5      �� 5   
    �� Path$ CloseCommand�6    � 	Resources 5         validationErrorTemplate �� Orientation �� TextAlignment � ToolTip �� ElementName	 ��Name��%�  &	        �� 5   
   .R�5      ]� .+�5      �� $ 
Horizontal=�6   $��Bottom=�66   .+�5      � $��10��6   $��10��6&   .+�5      A� $��10��6"   $��10��6-   
���  ��$��Center=�6D   $��Center=�6a   6~   �� 5      
�������$��Heavy"�67   $��6(�6J   $��Center=�6W   $��Center=�6t   $ Center=�6�    5       �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�X6�   5      �� 5      
���  ��$��2,0,0,0q�62   ��6C   �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      �� 5      $	 ErrorAdorner��6,   6E   5      5      5      .��5       � $��0,0,-6.333,-0.333q�6   
 � RowDefinitions
 5!   
   �� 5"      $	��16* �6   �� 5#      $	��55* �6   �� 5$      $	��22* �6   �� 5%      $	��47* �6    � ColumnDefinitions 5(   
   �� 5)      $
��227* �6   6.   �� 5*      $
��249* �6   6.   �� 5+      $
��243* �6   6.   .+�5-   
   �� -   5         ��Name$ position��5-      $��Должность:��6"   $
��Left=�67   $��10,2,0,0q�6R   $	��Top=�6d   $��26��6|   $��85��6�   �� 5.   
   -   5        $ 	startDate��5.      $.��(Дата начала действия: ��6#   $
��Left=�6D   $��	251,2,0,0q�6_   $	��Top=�6r   $��26��6�   $	��139��6�   $��2��6�   �� 5/   
   -   5        $ salary��5/      $��Количество:��6    $
��Left=�66   $��90.667,2,0,0q�6Q   $	��Top=�6g   $��26��6   $��76��6�   $��2��6�   &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ dd��50   /      AutoGenerateColumns .  $��3��6a   $��10,34.333,19.667,10q�6u   $��3��6�   $��1��6�   ��6;   �� *SheduleSource+   Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Отдел��6U      Width5  /System.Windows.Controls.DataGridLengthConverter$	 90* 6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *departament.DepartamentName+6d     53      $ Должность��6O   $
 110* 6b    6%   �� *position.PositionName+6b     54      $# Начало действия��6b   $	 150 6{    6%   �� *actionStartDate+ �� StringFormat$ 
dd.MM.yyyy��6{     55      $ Количество��6E   $	 170 6Y    6%   �� *countPerson+6Y   57      �� 58   
   -   5         ��Name$ comboBoxPosition��58       �� SelectedIndex$ 0��6-   $
��Left=�59   t   $��95,8,0,0q�6�   $	��Top=�5:      $	��151��6+   $��22��67   $��2��6C   ��58   @   �� *PositionSource+ �� SelectedValue 59      �� *SelectedPositionItem+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5:   C   �� 5;   
   -   5        $ comboBoxDepart��5;      $ 0��6+   $
��Left=�5<   r   $��117.333,0.333,0,0q�6�   $	��Top=�5=      $	��146��6+   $��29��67   $��1��6C   $��1��6S   ��5;   >   �� *DepartamentSource+ 5<      �� *SelectedDepartItem+$ TwoWay=�$ PropertyChanged=�5=   S   �� 5@   
   -   5        $ dateProp��5@      $��1��6%   $��117.333,8,55.333,6.667q�65    �� ItemStringFormat$ 
dd.MM.yyyy��6}   $ 0��6�    �� DisplayMemberPath$ 	dateParam��5A   d   ��5@   U   �� *DatesBettSource+ 5A      �� *SelectedDateItem+$ PropertyChanged=�6d   �� 5C   
   -   5         ��Name$ textBoxCountPerson��5C      $��2��6F   $
��Left=�5D      $��23��6-   $��171.667,5,0,0q�69    �� TextWrapping$
 Wrap=�6P   $	��Top=�6d   $	��120��6|    =� ErrorTemplate# [  6�    5C   .   �� .��5D   �   ��5E      �� 5F      $ PeopleCount�6   $ Default=�6-    �� ValidationRules 5G      1  +BettingSummaryApp.Classes.IntValidationRule  5H      5J      .��5K      5L      �� 5M   
   -	   5         ��Name$ button1��5M      $&�� Добавить запись...��6"   $
��Left=�5N      $��95,0.333,0,0q�6,   $��1��6B   $	��Top=�6O   $	��151��5O      $��29��6   $��2��6)   ��5M   ?   �� * InsertParametersToTableShedule+5O   )   �� 5P   
   -
   5        $ label��5P      $��Отдел:��6   $��1��60   $
��Left=�6@   $��54.333,1.333,0,0q�6[   $	��Top=�6u   $��1��6�   5R      5S      