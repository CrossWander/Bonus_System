   M S B A M L   `   `   `  ����G  CBonus System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Bonus_System.ViewsBonus_System.Views  5      !    Bonus_System.Views.CardView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Bonus_System.Views     5        � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resourses/Buttons.xaml?�6%   �� 5      $ /Resourses/Texts.xaml?�6%   %    5      .��5      � .+�5   
   �� $��Center=�6   $��Center=�63    �� TextAlignment$ Center=�5      .+�5      (�  (� Stretch$ Uniform=�6   $	��500��6(   $	��550��65   .��5      � $	��344��6   $	��697��6$   .+�5      �� 
������� �� RadiusX$ 10��6.    �� RadiusY$ 10��6;   $��
151,24,0,0q�6H   $��2��6\   ��5      �� 5       �� ImageSource$ /Assets/card_back.PNG��6)    j� Stretch$
 Fill=�6M   	 j� TileMode$
	 None=�6\   5      �� 5      $ 10��6    $ 10��6-   $��
0,0,151,24q�6:   $	��320��6N   $��2��6[   
���������5      �� 5      $ /Assets/card_front.PNG��6)   $
	 None=�6N   5!      �� 5"      $��0,0,520,194q�6    ��5#      �� 5$      $1 +pack://application:,,,/Assets/Logo/logo.png��6)   5&      �� 5*      -   5        
 ��Name$
 Client��5*       $��Иванов Иван��61   $��-12,243,387,56q�6D   $��26(�6\   $��Italic$�5+   &   $	��322��69   $��Bahnschrift)�6E   $
��Bold"�6^   �� 5,      $!��Бонусная карта��6    $��214,10,322,304q�66   �� 5-      -   5        $
 
CardNumber��5-       $��0 0 0 0 0 0��64   $��45,184,427,101q�6G   $��34(�6_   $��Normal$�5.   &   $��59��69   $��Normal"�6E   
�������$��AcmeFont)�6l   �� 5/      $��Expiration date ��6    $��321,177,210,134q�68   $��25(�6Q   $��Italic$�50   '    J� RenderTransformOrigin$ 0.5,0.5&�6:   �� 51      -   5        $
 
EndingData��51       $��mm/yy��64   $��334,217,236,94q�6A   $��25(�6Y   $��Italic$�52   '   $	��127��6:   $ 0.5,0.5&�6F   �� 54      $��	Bonuses :��6    $��224,78,312,207q�61   $��30(�6I   $��Italic$�55   &   $��59��69   �� 56      -   5        $
 Bonuses��56       $��XXXXXX��61   $��355,78,181,207q�6?   $��30(�6W   $��Italic$�57   '   $��59��6:   �� 59      -   5         ��Name$ 	AmountAdd��59         TextBoxPlaceHolder#��[  62   $��559,60,0,238q�5:      $��Center=�64   $
��Left=�6V   
 � Tag$ amount��5;      $��SemiBold"�6+   $��Courier New)�6A   $��82��6Z   �� 5<      -   5         ��Name$ AddToBalance��5<        
CardButton#��[ 64   $	��Add��6X   $��39��6f   $��554,111,51,194q�6r   �� 5>      -   5        $ AmountWithdraw��5>      #��[  67   $��559,156,0,142q�5?      $��Center=�60   $
��Left=�6R   $ amount��5@      $��SemiBold"�6&   $��Courier New)�6<   $��82��6U   �� 5A      -   5        $ WithdrawBalance��5A      #��[ 66   $��Withdraw��6Z   $��39��6m   $��554,206,51,99q�6y   5D      5E      5H      5I      5J      