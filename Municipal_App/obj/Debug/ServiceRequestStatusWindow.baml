   M S B A M L   `   `   `  ����  Municipal_App.    (Municipal_App.ServiceRequestStatusWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Service Request Status��5   	   $	��500��6(   $	��800��65   
������� � 	Resources 5       �� 
TargetType �� Property �� Value��%  '��       �� 5   
   " ��6   .�5	      ��  � ��$ 14(�6)   �� 5
       � ��$ 10q�6(   �� 5       � ��$ 10q�6'   �� 5       � ��
 �����6+   �� 5       � ��
 ���� 6,   �� 5       � �� �#2196F36+   5      5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��5q�6;   .+�5      �� -   5        $��Sort by Status��5      $	��120��6.   $��5q�6:   6E   �� 5      -   5        $��Sort by Category��5      $	��139��60   $��5q�6<   6G   5      �� 5"   
   $ 
Horizontal=�6   $��1��6.   $��5q�6;   .+�5#      �� -   5         ��Name$ txtSearchByID��5#      $	��150��6-   $��5q�69   �� 5$      -   5        $��Search by ID��5$      $	��120��6,   $��5q�68   6C   �� 5&      -   5        $ txtSearchByCategory��5&      $	��150��63   $��5q�6?   �� 5'      -   5        $��Search by Category��5'      $	��150��62   $��5q�6>   6I   �� 5)      -   5        $ txtSearchByStatus��5)      $	��150��61   $��5q�6=   �� 5*      -   5        $��Search by Status��5*      $	��150��60   $��5q�6<   6G   5+      �� 5.   
   $ 
Horizontal=�6   $��2��6.   $��Center=�6;   $��5q�6X   .+�5/      �� -	   5        $��Clear��5/      $	��120��6%   61   50      &   System.Windows.Controls.DataGrid  53   
   -
   5          Name$ dgServiceRequests��53      $��3��6.   	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     HeadersVisibility$ Column=�54      $��	0,10,0,10q�6.    55      )  #System.Windows.Controls.DataGridRow �� Triggers �� Binding �� Value��%|  '        �� 56      "  6    57      �� 58       6&   �� *Status+ Pending6A   .a�59      ��  � ��
 ����6;   5:      �� 5;       6&   �� *Status+ In Progress6A   .a�5<      ��  � ��
 ��ح�6;   5=      �� 5>       6&   �� *Status+ 	Completed6A   .a�5?      ��  � ��
 �����6;   5@      5B      5C         Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Request ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	RequestID+6W     5F      $ Status��6%   $ * 6P    65   �� *Status+6P     5G      $ Progress Description��6%   $ * 6k    6C   �� *ProgressDescription+6k     5H      $ Description��6%   $ 2* 6Z    6:   �� *Description+6Z     5I      $ Category��6%   $ * 6T    67   �� *
Category+6T   5K      �� 5N   
   -   5        $
��Back��5N      $��80��6    $��Right=�6+   $��4��6G   6T   5O      5P      