   M S B A M L   `   `   `  ����A  =Oblig3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Oblig3Oblig3  5   	       Oblig3.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Oblig3     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��260* �6   6.   �� 5      �� 5      $
��540* �6   .+�5   
   �� -   5        $��TestListView��5      $��40q�6'   $��
0,-10,0,10q�64   $��3��6`   $��2��6t   ��6H   ��  �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$	 120��63    �� DisplayMemberBinding 6?   ��  �� Path$ Studentname��� 5      $��Grade��6%   $	 120��64    6@   �� $ Grade1��� 5      $��Course��6%   $	 120��65    6A   �� $ 
Coursename�5      5      �� 5   
   -   5         ��Name$ CourseAlternatives��5       �� DisplayMemberPath$ 
Coursename��6H    �� SelectedValuePath$ 
Coursename��6i   $��0��6�   $��11,81,11,287q�6�   	 �� Text$	 Select coursename��6�   
 �� 
IsEditable$

 True��6�   $��Center=�6�   $��Center=�6�   $��155px��6  ��6/   �� 6Z  �� 5   
   -   5         ��Name$ StudNameTextBox��5      $��Center=�6J   $	��Top=�6g   $��0,45,0,0q�6   $��22��6�   $	��155��6�   �� 5   
   -   5        $��DisplayFailures��5      $��20��6(   $	��200��64   $��0��6@   $��2��6P   .��6�   Display Failures6�   �� 5   
   -   5        $ SelectGrades��5      $ Grade1��6B   $ Grade1��6_   $��	0,130,0,0q�6{   $	 Select a grade��6�   $

 True��6�   $��Center=�6�   $	��Top=�6�   $��155px��6�   ��6)   �� 6�   �� 5   
   -   5        $ 
SelectName��5      $ Studentname��6@   $ Studentname��6b   $��	0,263,0,0q�6�   $	 Select a name��6�   $

 True��6�   $��Center=�6�   $	��Top=�6�   $��155px��6�   ��6'   �� 6  �� 5    
   -   5        $ SelectCourse��5       $ 
Coursename��6B   $ 
Coursename��6c   $��	0,290,0,0q�6�   $	 Select a course��6�   $

 True��6�   $��Center=�6�   $	��Top=�6�   $��155px��6�   $y�	Collapsed=�6  ��6)   �� 6  5%      5(      