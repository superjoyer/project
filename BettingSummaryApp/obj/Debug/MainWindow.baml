   M S B A M L   `   `   `  ����L  HBettingSummaryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:BettingSummaryApp.ViewModelsBettingSummaryApp.ViewModels  5   	   E'clr-namespace:BettingSummaryApp.ClassesBettingSummaryApp.Classes  5   	   "    BettingSummaryApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:BettingSummaryApp.ViewModels     5   	   :extern'clr-namespace:BettingSummaryApp.Classes     5   	     � Title$  Ставки��5	   	   $	��350��6   $	��920��6%    � 
ResizeMode$ NoResize=�61    � DataContext 5
      4  .BettingSummaryApp.ViewModels.BettingsViewModel  5   
    � 	Resources 5         validationErrorTemplate �� Orientation �� TextAlignment � ToolTip �� ElementName �� Path	 ��Name��%�  &	        �� 5   
   .R�5      ]� .+�5      �� $ 
Horizontal=�6   $��Bottom=�66   .+�5      � $��10��6   $��10��6&   .+�5      A� $��10��6"   $��10��6-   
���  ��$��Center=�6D   $��Center=�6a   6~   �� 5      
�������$��Heavy"�67   $��6(�6J   $��Center=�6W   $��Center=�6t   $ Center=�6�    5       �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�X6�   5      �� 5      
���  ��$��2,0,0,0q�62   ��6C   �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      �� 5      $	 ErrorAdorner��6,   6E   5      5      5      .��5      � $��0,0,-6.333,-0.333q�6   
 � RowDefinitions
 5   
   �� 5      $	��16* �6   6+   �� 5       $	��55* �6   6+   �� 5!      $	��22* �6   �� 5"      $	��47* �6   6+    � ColumnDefinitions 5%   
   �� 5&      $
��227* �6   6.   �� 5'      $
��249* �6   6.   �� 5(      $
��243* �6   6.   .+�5*   
   �� -   5         ��Name$ position��5*      $��Должность:��6"   $
��Left=�67   $��10,2,0,0q�6R   $	��Top=�6d   $��26��6|   $��85��6�   �� 5+   
   -   5        $ 	startDate��5+      $.��(Дата начала действия: ��6#   $
��Left=�6D   $��23.667,2,0,0q�6_   $	��Top=�6u   $��26��6�   $	��139��6�   $��1��6�   �� 5,   
   -   5        $ salary��5,      $��Ставка:��6    $
��Left=�62   $��51.333,3,0,0q�6M   $	��Top=�6c   $��26��6{   $��53��6�   $��2��6�   &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ dd��5-   /      AutoGenerateColumns .  $��3��6a   $��10,34.333,105.333,9.667q�6u   $��3��6�   $��1��6�   ��6;   �� *BittingSource+   Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ Должность��6B      Width5  /System.Windows.Controls.DataGridLengthConverter$ 100*  6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
position+6U     50      $# Начало действия��6g   $	 220 6�    6%   �� *actionStartDate.Date+ �� StringFormat$ 
dd.MM.yyyy��6�     51      $# Значение ставки��6@   $	 170 6Y    6%   �� *Salary+6Y   53      �� 54   
   -   5         ��Name$ comboBoxPosition��54       �� SelectedIndex$ 0��6-   $
��Left=�55   t   $��95,8,0,0q�6�   $	��Top=�56      $	��151��6+   $��22��67   $��2��6C   ��54   @   �� *PositionSource+ �� SelectedValue 55      �� *SelectedPositionItem+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�58      �� 5;   
   -   5         ��Name$ textBoxDate��5;      $��1��6?   $
��Left=�6O   $��24��6j   $��162.667,6,0,0q�6v    �� TextWrapping$
 Wrap=�5<      $	��Top=�6&   $	��120��6>   $��2��5=       =� ErrorTemplate# [  6&    5;   '   �� .��5=   j   ��5>      �� 5?      $ ActionStartDate�6   $ {0:dd.MM.yyyy}��61   $ 	LostFocus=�6R    �� ValidatesOnExceptions .  �� NotifyOnValidationError .  �� ValidationRules 5@      2  ,BettingSummaryApp.Classes.DateValidationRule  5A      5C      .��5D      5E      �� 5F   
   -   5        $ textBox1��5F      $��2��6<   $
��Left=�5G      $��23��6-   $��104.333,7,0,0q�69   $
 Wrap=�6P   $	��Top=�6d   $	��120��6|   # [  6�    5F   $   �� .��5G   �   ��5H      �� 5I      $ BettingNumber�6   $ Default=�6/    .  .  5J      1  +BettingSummaryApp.Classes.IntValidationRule  5K      5M      .��5N      5O      �� 5R   
   -   5         ��Name$ button��5R      $��Расписание��6!   $��2��6^   $��210.667,34.333,9.667,0q�6n   $��1��6�   $	��Top=�6�   $��29��6�   ��66   �� *OpenSheduleCommand+6�   �� 5S   
   -	   5        $ buttonReport��5S      $��
Отчет��6'   $��2��6]   $��210.667,68.333,9.667,0q�6m   $��1��6�   $	��Top=�6�   $��29��6�   ��67   �� *OpenReportCommand+6�   �� 5T   
   -
   5        $ button1��5T      $&�� Добавить запись...��6"   $
��Left=�5U      $��95,0.333,0,0q�6,   $��1��6B   $	��Top=�6O   $	��151��5V      $��29��6   $��2��6)   ��5T   ?   �� * InsertParametersToTableBetting+$ TwoWay=�5V   )   5X      5Y      