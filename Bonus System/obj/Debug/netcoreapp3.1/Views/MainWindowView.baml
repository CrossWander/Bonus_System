   M S B A M L   `   `   `  ����G  CBonus System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Bonus_System.ViewsBonus_System.Views  5   	   '    !Bonus_System.Views.MainWindowView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Bonus_System.Views     5   	   -   5        $��	AppWindow��5   
     � Title$  Bonus System��6   $	��600��60   $	��900��6=    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�6.    � 
ResizeMode$ NoResize=�5
   	   
������  � AllowsTransparency$
 True��68   .��5      ��  �� CornerRadius$ 20��6   
����������	#FF55B2FF$	��0.5q�6J   ._�5   
   �  � RowDefinitions 5      �� 5      $��30 �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $	��180 �6#   �� 5      $��* �6#   �� 5      $	��130 �6#   .+�5      � $��1��6   .+�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $��/Assets/BonusSystem.png��6   $��50��6=   �� 5      $��Bonus System��6    ���	#FF666666$��25,0,0,0q�6K   $
��Left=�5      $��Center=�67   $��22(�5      $��HarvestItal)�6*   �� 5       $ Vertical=�6!   $��0,5,0,0q�68   .+�5!      	� -   5        	 	�Name$	 
SearchCard��5!   &   
 d� 	IsChecked$

 TrueY�6:   
 � Tag$ /Assets/Icons/search.png��6K    	� 	GroupName$ MenuButtons��6j   $��Search Bonus Card��6�      MenuButtonStyle#��[  6�   $��0,35,0,0q�6�   	� 5(      -   5        $	 
CreateCard��5(   &   $ MenuButtons��6:   $��Create Bonus Card��6R   $ /Assets/Icons/add.png��6n   #��[  6�   $��0,5,0,0q�6�   5)      5+      � 5,      $��Bottom=�6   $��Center=�62   $��0,0,0,50q�6O   $  ��6a    � ToolTip$ Contact with Developer��6h    5-      �� 5.      $
��Auto �6+   �� 5/      $��* �6+   .+�52      A� $��36��6   $��36��6*   $
��Left=�65   $��Center=�53      ��55      �� 56       �� ImageSource$ /Assets/profile.jpg��6)    �� BitmapScalingMode$
 Fant=�6K    j� Stretch$ UniformToFill=�6r   58      � 59      $��1��6   $��14,0,0,0q�6+   $��96��6=    5:      �� 5;      �� 5<      .+�5>      �� $��0��6$   $��Dykalo Pavlo��61     MainText#��[ 6F   �� 5?      $��1��6$   $'��!Your Friendly Neighbour Developer��61   $��WrapWithOverflow=�6Z     	TitleText#��[ 6z   5@      5A      5C      � 5D      -   5        $��1��5D      $��0��6#   ���#EFF2F86E   � 5E      $��1��6   $��1��6    ���#EFF2F8.+�5G      �� -   5         ��Name$ 
ActiveItem��5G   !   5I      � 5J      $��2��6    5K      �� 5L      $
��Auto �6$   �� 5M      $��* �6$   .+�5O      �� $��0��6   $��2��6*   $ 
Horizontal=�6:   $��Right=�6S   $��0,0,8,0q�6o   .+�5P      �� -   5         ��Name$ Minimize��5P      $��0,5,5,0q�6/     	MinButton#��[ 6@   6c   �� 5Q      -   5        $
 Exit��5Q      $��0,5,5,0q�6+     
ExitButton#��[ 6<   6`   5R      �� 5T      $��2��6   $��/Assets/picture.png��6%   $
 Fant=�6B   $��Bottom=�6j   $��0,0,0,50q�6�   5U      5W      5X      5Y      