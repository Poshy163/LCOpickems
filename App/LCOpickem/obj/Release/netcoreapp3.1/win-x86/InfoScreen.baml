   M S B A M L   `   `   `  ���� D  @LCOpickem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LCOpickem	LCOpickem      LCOpickem.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:LCOpickem     -     � Title$  
MainWindow��$	��500��$	��800�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=����#181735 � WindowStartupLocation$ CenterScreen=� � Icon$ /Images/LCO_Logo.png��.���  � RowDefinitions �� $��25 ���  � ColumnDefinitions �� �� .+�� -   ���#0f0f2d$��2�� �� �� �� �� �� �� �� �� .+��� $��
LCO pickem��
�������$��0��$��Center=�$��15(�$��Fonts/#Dosis)�$
��Bold"�$��Center=��� -   $
��BACK��
�������$��10(�$��Medium"�$��0,0,0,0q�$��6��$��1������  �� 
TargetType" ��.���  �� Property � ��	 �� Value$	 Fonts/#Dosis)���  � ��	 �#39385D��  �@�Cursor$
	 Hand��
 �� Triggers
 P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � ��	 �#3a3952����  �� 
TargetType" ��.R��� $��75��$��15�� �� CornerRadius$ 8��#��z��._��� $��Center=�$��Center=��� -   $��X��
�������$��10(�$��Medium"�$��0,0,0,0q�$��12��$��2������ " ��.���  � ��$	 Fonts/#Dosis)���  � ��	 �#FE6584��  �@�Cursor$
	 Hand��
 P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#FF4C70���� " ��.R��� $��75��$��15��$ 8��#��z��._��� $��Center=�$��Center=��� -    ��Name$ 	InfoPanel��$��1��$��Center=�$��60q�$y�Visible=�.+��� .+���  �� Orientation$ 
Horizontal=�$��0,0,0,15q�.+��� $��75��$��75��$��images/LCO_Logo.png���� $�� LCO pickem��
�������$��35(�$��Medium"�$��Center=�$��Fonts/#Dosis)��� $��Made For Fans.��
�������$��Medium"�$��Fonts/#Dosis)�$��40(�$��0,10,0,0q��� $��By Fans.��
�������$��Medium"�$��Fonts/#Dosis)�$��40(�$��0,10,0,0q��� $��Blah blah blah��
�������$��Medium"�$��Fonts/#Dosis)�$��12(�$
��Wrap=�$��0,10,0,0q��� $ 
Horizontal=�$��0,15,0,0q�.+��� -   $��Login��
�������$��15(�$��Medium"�$��0,0,10,0q����� " ��.���  � ��$	 Fonts/#Dosis)���  � ��	 �#FE6584��  �@�Cursor$
	 Hand��
 P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#FF4C70���� " ��.R��� $	��100��$��25��$ 12��#��z��._��� $��Center=�$��Center=��� -   $��Register��
�������$��15(�$��Medium"����� " ��.���  � ��$	 Fonts/#Dosis)���  � ��	 �#39385D��  �@�Cursor$
	 Hand��
 P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#3a3952���� " ��.R��� $	��100��$��25��$ 12��#��z��._��� $��Center=�$��Center=��� -   $ 
LoginPanel��$��1��$��Center=�$��60q�$y�Hidden=�.+��� .+��� $ 
Horizontal=�$��0,0,0,15q�.+��� $��75��$��75��$��images/LCO_Logo.png���� $�� LCO pickem��
�������$��35(�$��Medium"�$��Center=�$��Fonts/#Dosis)��� $��Username/Email��
�������$��Medium"�$��Fonts/#Dosis)�$��25(�$��0,10,0,0q��� -	    ��Name$ UsernameBox��$��Fonts/#Dosis)��� $��Password��
�������$��Medium"�$��Fonts/#Dosis)�$��25(�$��0,10,0,0q��� -
   $ PasswordBox��$��Fonts/#Dosis)��� $ 
Horizontal=�$��0,15,0,0q�.+��� -   $��Login��
�������$��15(�$��Medium"�$��0,0,10,0q����� " ��.���  � ��$	 Fonts/#Dosis)���  � ��	 �#FE6584��  �@�Cursor$
	 Hand��
 P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#FF4C70���� " ��.R��� $	��100��$��25��$ 12��#��z��._��� $��Center=�$��Center=��� -   $ RegisterPanel��$��1��$��Center=�$��60q�$y�Hidden=�.+��� .+��� $ 
Horizontal=�$��0,0,0,15q�.+��� $��75��$��75��$��images/LCO_Logo.png���� $�� LCO pickem��
�������$��35(�$��Medium"�$��Center=�$��Fonts/#Dosis)��� $��Username��
�������$��Medium"�$��Fonts/#Dosis)�$��25(�$��0,10,0,0q��� -   $ RusernameBox��$��Fonts/#Dosis)��� $��Email��
�������$��Medium"�$��Fonts/#Dosis)�$��25(�$��0,10,0,0q��� -   $ 	RemailBox��$��Fonts/#Dosis)��� $��Password��
�������$��Medium"�$��Fonts/#Dosis)�$��25(�$��0,10,0,0q��� -   $ RpasswordBox��$��Fonts/#Dosis)��� $ 
Horizontal=�$��0,15,0,0q�.+��� -   $��Register��
�������$��15(�$��Medium"�$��0,0,10,0q����� " ��.���  � ��$	 Fonts/#Dosis)���  � ��	 �#FE6584��  �@�Cursor$
	 Hand��
 P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#FF4C70���� " ��.R��� $	��100��$��25��$ 12��#��z��._��� $��Center=�$��Center=��� -    ��Name$ glassBallPanel��$	��400��$	��600�����#18123a$y�Hidden=� K� ZIndex$ 1��$
}�True�� �� Left$	 162��
 �� Top$ 58��$��100,37,0,38q�$��1��$��2��$
��Left=�.+��� $:��4Who do you think will win the LCO 2022 spring split?��
�������$��Medium"� �� TextAlignment$ Center=�$��Fonts/#Dosis)�$��25(�$ 2��$ 8��$��35�� �� 
LineHeight$ 6��$	��596���� -   $	��PGG��$	��100��$	��100��$ 25��$ 75��
������ $��0q�.���� $��images/teams/PGG.png���� -   $��DW��$	��100��$	��100��$	 175��$ 75��
������ $��0q�.���� $��images/teams/DW.png���� -   $	��CHF��$	��100��$	��100��$	 325��$ 75��
������ $��0q�.���� $��images/teams/CHF.png���� -   $	��GRV��$	��100��$	��100��$	 475��$ 75��
������ $��0q�.���� $��images/teams/GRV.png���� -   $	��LGC��$	��100��$	��100��$ 25��$	 200��
������ $��0q�.���� $��images/teams/LGC.png���� -   $	��MMM��$	��100��$	��100��$	 175��$	 200��
������ $��0q�.���� $��images/teams/MMM.png���� -   $	��PCE��$	��100��$	��100��$	 325��$	 200��
������ $��0q�.���� $��images/teams/PCE.png���� -   $	��ORD��$	��100��$	��100��$	 475��$	 200��
������ $��0q�.���� $��images/teams/ORD.png���� -    ��Name$ LockInButton��$��Lock in!��
�������$��25(�$��Medium"�$��0,0,10,0q�$	 328��$	��600��$��70������ " ��.���  � ��$	 Fonts/#Dosis)���  � ��	 �#FE6584��  �@�Cursor$
	 Hand��
 P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#FF4C70���� " ��.R��� $	��200��$��50��$ 12��#��z��._��� $��Center=�$��Center=�� $��1��$��2��$��160, -365, -610, 85q�$ -1��z���  �� Angle$ 50Q�.+��� $ 
Horizontal=�$��-365, 250, -255, 250q�.+��� .+��� $	��700��$��35�����#3DDDC2$��	150,0,0,0q�$ 20���� $	��700��$��35�����#FC6586$��0,15,0,0q�$ 20���� $	��700��$��35�����#383660$��	75,15,0,0q�$ 20���� .+��� $	��700��$��35�����#3DDDC2$��	150,0,0,0q�$ 20���� $	��700��$��35�����#FC6586$��0,15,0,0q�$ 20���� $	��700��$��35�����#383660$��	75,15,0,0q�$ 20��