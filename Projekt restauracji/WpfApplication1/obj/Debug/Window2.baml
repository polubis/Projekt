   M S B A M L   `   `   `  ����  WpfApplication1    WpfApplication1.Window2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Window2��5   	   $	��341��6   $	��578��6&    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ Close��5      5        5
   
   -   5        $
 Open��5
      5      .��5   
   � .+�5   
   ]� .+�5      o� $��Right=�6   $��	0,0,0,286q�6*   .@�5      m� $��Opcje��6   $��Center=�6*   $��73��6G   .@�5      m� $��
Kalkulator��6    m� Command$
 Open��63    m� InputGestureText$ CTRL+K��6B    m� Icon 5      �� 5      $��Pictures/calcIcon.png��6$   $��15��6C   5      �� 5      m� 5      $��Wyjście��6   $ Close��60    5      �� 5      $��Pictures/exitIcon.png��6    $��21��6?   5       5!      5"      5#      �� 5%   
   -   5        $��listaDan��5%      $��0,21,0,0q�6#   $��Script MT Bold)�65   $��SemiBold"�6Q   $��20(�6g   &   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6u   ��5&      �� 5'       �� ImageSource$ Pictures/przystan.jpg��6    �� View 5)      �� 5*      	 �� AllowsColumnReorder	 . P�5+      �� 5,      $��ID��6)   
 �� Width$
 50��65    �� DisplayMemberBinding 5-      �� *ID+�� 5.      $��Danie��6)   $

  200��68    5/      �� *Danie+�� 50      $
��Cena��6)   $
 50��67    51      �� *Cena+53       �� 
GroupStyle 55      (  "System.Windows.Controls.GroupStyle  56         HeaderTemplate 57      �� 58      .R�59      �� $
��Bold"�6(   $��15(�6:   ��6H   �� *Danie+5:      5<      5?      5@      5A      