   M S B A M L   `   `   `  ����P  LRacetimeTrackerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RacetimeTrackerClientRacetimeTrackerClient  5   	   &     RacetimeTrackerClient.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RacetimeTrackerClient     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��400��6)   ��5	      �� 5
   
    �� 
TargetType" �6    �� BasedOn# [B�6$   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��2��6$   $��Center=�68   $��36(�6U   $��10q�6c   $��
Montserrat)�6o   RaceTime Tracker6�   �� 5   
   $��2��6   $��Resources/race.png��6$   $
��Auto��6@   $	��200��6M   $��1��6Z   $��10q�6g   6u   �� 5   
   $��	Username:��6   $��Center=�6%   $��2��6@   $��2��6T   $��0��6a   $��5, 50, 5, 5q�6q   �� 5    
   -   5         ��Name$ UsernameTextBox��5       $��2��6+   $��3��6?   $��0��6L   $��5q�6\   �� 5#   
   $��	Password:��6   $��2��6%   $��Center=�69   $��4��6T   $��0��6a   $��5q�6q   G� 5$   
   -   5         G�Name$ PasswordBox��5$      $��2��6+   $��5��6?   $��0��6L   $��5q�6\   �� 5'   
   -   5        $��Login��5'      $��6��6!   $��0��6.   $��5, 10, 5, 5q�6>   $	��100��5(      6   �� 5*   
   -   5        $��Register��5*      $��6��6$   $��1��61   $��5, 10, 5, 5q�6A   $	��100��5+      6   �� 5.   
   -   5         ��Name$ FeedbackTextBlock��5.      $��7��6/   $��0��6<   $��2��6L   $�� ��5/      
���  ��$��Center=�6-   $��10q�6J   $��16(�6V   $
��Bold"�6d   50      51      