   M S B A M L   `   `   `  ����Q  MElysium, Version=2.0.1042.4, Culture=neutral, PublicKeyToken=afa220db249e5b15D/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls  5   	    	Cella2015   Cella2015.LogoutWindow   5   	   3metro)http://schemas.codeplex.com/elysium/theme  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   BControls/clr-namespace:Elysium.Controls;assembly=Elysium    5   	   7params*http://schemas.codeplex.com/elysium/params   5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Logout��5   	   $	��200��6   $	��500��6%    � WindowStartupLocation$ CenterScreen=�5	   	      Elysium.Parameters.Design   Theme$ LightX�5
   	       Elysium.Parameters.Manager   Theme$ LightX�5   	   $��1q�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      �  � ShowGridLines .   � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��60 �6   �� 5      $��30 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��340 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ lblLogoutMessage��5   -   $��1��6   $��1��6   $?��9Are you sure you want to quit application and logout now?��6G   $��Center=�6�   $��DemiBold"�6�   �� 5   
   -   5        	 ��Name$	 btnLogoutCancel��5      $��1��6*   $��2��6:   $��100px��6G   $��Cancel��6U   $
��Left=�6f   6�   �� 5   
   -   5        $	 btnLogoutSubmit��5      $��1��6*   $��2��6:   $��100px��6G   $��Logout��6U   $
��Left=�6f   $��	120,0,0,0q�6�   6�   �� 5   
   -   5        $	 btnLogoutExit��5      $��1��6(   $��2��68   $��100px��6E   $
��Exit��6S   $
��Left=�6b   $��	240,0,0,0q�6}   6�   5      5       