   M S B A M L   `   `   `  ����Q  MElysium, Version=2.0.1042.4, Culture=neutral, PublicKeyToken=afa220db249e5b15D/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls  5   	    	Cella2015   Cella2015.LoginWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   DControls/clr-namespace:Elysium.Controls;assembly=Elysium     5   	   7params*http://schemas.codeplex.com/elysium/params   5   	     � Title$  Log In Cella System��5   	   $	��200��5   	   $	��400��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	      Elysium.Parameters.Design   Theme$ LightX�5   	       Elysium.Parameters.Manager   Theme$ LightX�5   	   $��1q�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��35px �6   �� 5      $
��26px �6   �� 5      $
��35px �6   �� 5      $
��26px �6   �� 5      $
��Auto �6   .+�5   
   �� $
��Name��6   $��Bottom=�6   $��12(�6:   $��0��6H   �� 5   
   -   5         ��Name$ txtLoginName��5      $��1��6(    �� 	MaxLength$ 30��65   $	��400��6D   $��1q�6P   $��-1,0,0,0q�6d   6v   �� 5   
   $��Password��6   $��Bottom=�6#   $��12(�6>   $��2��6L   G� 5   
   -   5         G�Name$ txtLoginPassword��5      	 G� 	MaxLength$	 30��60   $��3��6?   $	��400��6L   $��1q�6X   $��-1,0,0,0q�6l   6~   �� 5   
   -   5        
 ��Name$
 btnLogin��5      $��0q�6#   
�������$��4��6O   $	��400��6\   $��45��6h   $��-1,0,0,0q�6t   
���   �$��Log In��6�   6�   �� 5    
   -   5        $ txbErrorLog��5       $��DemiBold"�6'   
���  ��$��30��6N   $��-1,45,0,-30q�6Z   $��4��6o   $��0q�6|   $��14(�6�   $y�	Collapsed=�6�   5!      5"      