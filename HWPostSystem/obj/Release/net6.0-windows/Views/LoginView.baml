   M S B A M L   `   `   `  ���� G  CHWPostSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HWPostSystem.CustomControlsHWPostSystem.CustomControls  7 clr-namespace:HWPostSystem.ViewsHWPostSystem.Views  A%clr-namespace:HWPostSystem.ViewModelsHWPostSystem.ViewModels  "    HWPostSystem.Views.LoginView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Dcustomcontrols)clr-namespace:HWPostSystem.CustomControls     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:HWPostSystem.Views     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;	viewModel%clr-namespace:HWPostSystem.ViewModels     -     � Title$  	LoginView��$	��500��$	��400�� � AllowsTransparency$
 True��
������  � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � DataContext ,   &HWPostSystem.ViewModels.LoginViewModel   � 	Resources    BooleanToVisibility��%   &	        �� y���  �� 	Converter# [   �� Mode$ TwoWay=�	 �� Path$	 IsViewVisible�.���� 
 �� CornerRadius$
 12������  �� ImageSource$ /Images/back-image.jpg�� j� Stretch$
 None=�._��� $��2q�$
 10�� J� Opacity$
 0.95Q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Offset$ 0Q� � Color$ #462AD8��� $
 0.75Q�$ #DA34AE��� $ 1Q�$ #8A16C1��._�� .+��  � ColumnDefinitions �� �� .+��� ���#6142b9$
 9,0,0,9��._��� $��0��$
��0,50q�.+��� $	��100��$	��100��$!��/Images/shop_white_logo.png���� $��Center=�$��
Montserrat)�$��25(�$��Medium"�
�������$��Smart POS tizimi���� $��1��
�������$
 0,9,9,0��._��  � RowDefinitions �� $��30 ��� .+�� $��0�� �� �� $��25 ��� $��25 ��� $��5 �.+��� -    ��Name$ btnMinimize��$��1��$��0q�$��-�� � Cursor$
 Hand��$��
Montserrat)�$��16(�
�����������  �� 
TargetType" ��.���  �� Property � �� �� Value �#DA34AE �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#C62DAE����  �� 
TargetType" ��.R��� $��18��$��18��#��z��$
 9��._��� $��Center=�$��Center=��� -   $ btnClose��$��2��$��0q�$��X��$
 Hand��$��
Montserrat)�$��12(�
����������� " ��.���  � �� �#DA34AE P�  �@J�IsMouseOver$
 True��. ���  � �� �#C62DAE���� " ��.R��� $��18��$��18��#��z��$
 9��._��� $��Center=�$��Center=��� $��1��$	��220�� �� Orientation$ Vertical=�.+��� $��
Montserrat)�$��25(�$��Medium"�
���   �$��Tizimga kirish�� �� TextAlignment$ Center=�$
��Wrap=��� $��0,15,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���   �$��Tashkilot kodi���� -    ��Name$ txtFactoryCode��$��28��$��0,5,0,0q�$��25,0,0,0q�$��Center=�
���   �$��0,0,0,2q�  �� 
CaretBrush
  �   �$��
Montserrat)�$��13(�$��Medium"�
���   ����� *CompanyCode+! �� UpdateSourceTrigger$! PropertyChanged=�.������ " j� 
AlignmentX$
" Left=�$ /Images/company-icon.png��$ Uniform=�.���� $��0,15,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���   �$��Username���� -   $ txtUser��$��28��$��0,5,0,0q�$��25,0,0,0q�$��Center=�
���   �$��0,0,0,2q�
  �   �$��
Montserrat)�$��13(�$��Medium"�
���   ����� *
Username+$! PropertyChanged=�.������ $
" Left=�$  /Images/user-icon-gray.png��$ Uniform=�.���� $��0,15,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���   �$��Password��5   /HWPostSystem.CustomControls.BindablePasswordBox  5   /HWPostSystem.CustomControls.BindablePasswordBox#   Loaded$ # BindablePasswordBox_Loaded��$��28��$��0,5,0,0q�$   Password$ �� *
Password+$ TwoWay=�$! PropertyChanged=��� $��0,10,0,0q�$��
Montserrat)�$��12(�$��Medium"����#D7596D$
��Wrap=����� *ErrorMessage+�� $��0,15,0,0q�$��Center=�$ 
Horizontal=�.+��� $��
Montserrat)�$��12(�$��Medium"�
���   �$��Parolni unutdingizmi?���� $��8,0,0,0q�$
 Hand��$��
Montserrat)�$��12(�$
��Bold"�
���   �$��Parolni tiklash���� -   $ btnLogin��$��0q�$��Kirish��$
 Hand��$��
Montserrat)�$��12(�$
��Bold"�
����������� *LoginCommand+���� " ��.���  � �� �#462AD8 P�  �@J�IsMouseOver$
 True��. ���  � �� �#28AEED���� " ��.R��� $	��150��$��40��#��z��$
 20��._��� $��Center=�$��Center=�