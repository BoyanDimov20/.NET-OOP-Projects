   M S B A M L   `   `   `  ����J  FCashdeskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CashdeskManagerCashdeskManager  5   	        CashdeskManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CashdeskManager     5   	     � Title$  CashDeskManager��5   	   $
��1080��6!   $
��1920��6/    � WindowStartupLocation$ CenterScreen=�6<    � WindowState$ 	Maximized=�6a    � 
ResizeMode$ CanResizeWithGrip=�5	   	   .��5      �� $
��Auto=�6   .��5   
   � $
��1920��6   $
��1080��6   ��5      �� 5       �� ImageSource$q kC:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\Resources\background2.jpg��6    � RowDefinitions 5      �� 5      $
��107* �6   �� 5      .+�5   
   � $��10,10,1439,361q�6   .+�5      �� $
��Bold"�6   $��20(�6&   $��Manager Information:��64   $��0,14,149,649q�6S   �� 5      $��10,50,149,545q�6   .+�5      �� -   5         ��Name$ UserId��5      $��15(�6,   Id: 16A   �� 5      -   5        $ FullName��5      $��15(�6.   Full Name: Boyan Ivov Dimov6Y   �� 5      -   5        $ Username��5      $��15(�6.   Username: SorionN6O   �� 5       -   5        $ IsAdmin��5       $��15(�6-   Role: Administrator6P   �� 5!      -   5        $ WorkingHours��5!      $��15(�62   Working Hours: 0:03:256X   5"      �� 5#      -   5         ��Name$ Camera��5#      $��
7,296,7,97q�6(   $t��nC:\Users\Boyan\Documents\GitHub\.NET-OOP-Projects\CashdeskManager\CashdeskManager\Resources\missing camera.png��6<   $y�Hidden=�6�   �� 5$      -   5        $ CameraMissingError��5$      
���  ��$�� ��6[   $
��Wrap=�6c   $��354,602,25,51q�6w   $y�Visible=�6�   ��64   Z� 6�   5%      �� 5&   
   $
��Bold"�6   $��30(�6"   $��Control Panel:��60   $y�Visible=�6I   $��10,618,1439,64q�6^   �� 5'   
   -   5        
�������$��25(�5'   $   $��Add Customer��62   $��20,722,1674,264q�6I   6b   �� 5(   
   -	   5        
�������$��25(�5(   $   $��Remove Customer��62   $��20,829,1674,157q�6L   6e   �� 5)   
   -
   5        
�������$��25(�5)   $   $��Show Camera��62   $��518,936,1212,64q�6H   6a   ,   &CashdeskManager.CashMachineUserControl  5*   
   -   5          Name$ CashMachine1��5*   A   $��518,388,1163,535q�6'   6A     5+   
   -   5        $ CashMachine2��5+   @   $��840,388,840,535q�6'   6@     5,   
   -   5        $ CashMachine3��5,   A   $��1164,388,517,535q�6'   6A     5-   
   -   5        $ CashMachine4��5-   A   $��1487,388,194,535q�6'   6A     5.   
   -   5        $ CashMachine5��5.   A   $��518,118,1163,805q�6'   6A     5/   
   -   5        $ CashMachine6��5/   @   $��840,118,840,805q�6'   6@     50   
   -   5        $ CashMachine7��50   A   $��1164,118,517,805q�6'   6A     51   
   -   5        $ CashMachine8��51   A   $��1487,118,194,805q�6'   6A   �� 52   
   $��1714,10,10,1020q�6   .+�53      c� .@�54      o� $	��166��6   .@�55      m� $��Settings��6   $	��164��61   .@�56      m� -   5        $��Register User��56   #   6:   m� 57      -   5        $��Show Report��57   #   68   m� 58      -   5        $��	Config UI��58   #   66   m� 59      -   5        $��Logout��59   #   63   5:      5;      5<      5=      �� 5>   
   $	��100��6   $	��100��6   5@      5A      5C      