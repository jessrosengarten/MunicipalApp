   M S B A M L   `   `   `  ����  Municipal_App0    *Municipal_App.EventsAndAnnouncementsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$"  EventsAndAnnouncementsWindow��5   	   $	��450��6.   $	��800��6;    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $' !EventsAndAnnouncementsStyles.xaml?�6%   %    5
      .��5      � 
�������$��20q�6"    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Events and Announcements��6!   $��28(�6A   $
��Bold"�6O   
���   �$��Center=�6t   $��10q�6�   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   $��	10,0,0,10q�6V   .+�5       �� $��Search by Date:��6   $��Center=�6/   $��0,0,10,0q�6J   $��16(�6\   
���   �$
��Bold"�6}   (  "System.Windows.Controls.DatePicker  5!      -   5          Name$ dpSearchByDate��5!      $	��140��61   
������ ���#666$��14(�6i   $��	10,0,20,0q�5"      
���   �$��1q�6?   �� 5$      $��Search by Category:��6   $��Center=�63   $��0,0,10,0q�6N   $��16(�6`   
���   �$
��Bold"�6�   �� 5%      -   5         ��Name$ 
cbCategory��5%      $	��160��6+   
������ ���#666$��14(�6c   $��	10,0,20,0q�5&      
���   �$��1q�6=   .@�5'      �� $��Music��6   �� 5(      $��Meetings��6   �� 5)      $	��Art��6   �� 5*      $��Sports��6   �� 5+      $��
Technology��6   �� 5,      $��Health��6   �� 5-      $��Culture��6   �� 5.      $
��Food��6   5/      �� 52      -   5        $��Search��52      $��90��6&   $	��5,0q�61   $��40��6>   
�������$��14(�53   (   $��5q�66   ���#2196F354   -   �� 55      -   5        $��Clear��55      $��90��6%   $	��5,0q�60   $��40��6=   
�������$��14(�56   )   $��5q�67   ���#2196F357   ,   58      �� 5;   
   $��2��6   $ Vertical=�6"   $
��Left=�69   $��	10,0,0,10q�6T   .+�5<      �� $��Top Categories:��6   $��0,0,0,5q�6/   $��16(�6@   
���   �$
��Bold"�6a   �� 5=      -   5         ��Name$ lbRecommendations��5=      $	��250��61   $	��120��6=   
������ ���#666
���   �$��1q�5>   U   5?      &   System.Windows.Controls.DataGrid  5B   
   -   5        	  Name$	 dgEvents��5B       $��3��6   
   AutoGenerateColumns
 .     CanUserAddRows .  $��10q�5C      $��Stretch=�6   $��Stretch=�65   
����������#DDD
���   �$��14(�5D   I      AlternatingRowBackground
 �����   RowBackground
 �����   HeadersVisibility$ Column=�5E   F      Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Event Date��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6p   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Date+ �� StringFormat$ MMMM dd, yyyy��6p     5H      $ 
Event Name��6%   $ * 6S    69   �� *Title+6S     5I      $ Event Category��6%   $ * 6Z    6=   �� *
Category+6Z     5J      $ Event Description��6%   $ 2* 6`    6@   �� *Description+6`   5L      �� 5P   
   -   5        $��4��5P      $
��Back��6   $��Right=�6-   $��Bottom=�6I   $	��120��5Q      $��40��6   $��10q�6)   
�������$��16(�5R      $��5q�6   ���#2196F36B   5S      5T      