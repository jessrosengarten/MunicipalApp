   M S B A M L   `   `   `  ����   Municipal_App0    *Municipal_App.EventsAndAnnouncementsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$"  EventsAndAnnouncementsWindow��$	��450��$	��800�� � 	Resources  �� MergedDictionaries �� Source��  �� $' !EventsAndAnnouncementsStyles.xaml?�%    .��� 
�������$��20q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��Events and Announcements��$��24(�$
��Bold"�$��Center=�$��10q��� $��1�� �� Orientation$ 
Horizontal=�$
��Left=�$��	10,0,0,10q�.+��� $��Search by Date:��$��Center=�$��0,0,10,0q�$��14(�(  "System.Windows.Controls.DatePicker  -     Name$ dpSearchByDate��$	��120��$��	10,0,20,0q�$��14(��� $��Search by Category:��$��Center=�$��0,0,10,0q�$��14(��� -    ��Name$ 
cbCategory��$	��150��$��	10,0,20,0q�.@��� $��Music���� $��Meetings���� $	��Art���� $��Sports���� $��
Technology���� $��Health���� $��Culture���� $
��Food���� -   $��Search��$��80��$	��5,0q�$��50���� -   $��Clear��$��80��$	��5,0q�$��50���� $��2��$ Vertical=�$
��Left=�$��	10,0,0,10q�.+��� $(��"Recommendations of Top Categories:��$��0,0,0,5q�$��14(��� -    ��Name$ lbRecommendations��$	��300��$	��150��&   System.Windows.Controls.DataGrid  -   	  Name$	 dgEvents��$��3��
   AutoGenerateColumns
 .     CanUserAddRows .  $��10q�$��Stretch=�$��Stretch=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Event Date��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Date+  $ 
Event Name��$ *  �� *Title+  $ Event Category��$ *  �� *
Category+  $ Event Description��$ 2*  �� *Description+�� -   $��4��$
��Back��$��Right=�$��Bottom=�$	��100��$��40��$��10,10,10,10q�