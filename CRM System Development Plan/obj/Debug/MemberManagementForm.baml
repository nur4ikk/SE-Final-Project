   M S B A M L   `   `   `  ����V  RCRM System Development Plan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CRM_System_Development_PlanCRM_System_Development_Plan  5   	   6    0CRM_System_Development_Plan.MemberManagementForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:CRM_System_Development_Plan     5   	     � Title$  Member Management��5   	   $	��700��6#   $
��1000��60    � WindowStartupLocation$ CenterScreen=�6=   ���#F5F5F5.��5	      � $��20q�6   .+�5   
   �� 
������� �� CornerRadius$ 10��6$    �� Padding$ 15q�66   ���#D3D3D3$��1q�6Y   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      �� $��Member Management��6   $��24(�65   $
��Bold"�6C   ���#333$��Center=�5      $��0,0,0,20q�65   �� 5      $��1��6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   $��	0,10,0,10q�6`   .+�5      �� $��Membership Type:��6   $��Center=�67   $	��120��6R   $��0,0,10,0q�6^   �� 5      -   5         ��Name$ cmbSearchMembershipType��5      $	��200��6@   $��0,0,10,0q�6L   .@�5      �� $	��All��6'   �� 5      $��Community Member��6'   �� 5      $��Key Access Member��6'   �� 5       $��Creative Workspace Member��6'   5!      �� 5$      $��Search by Name or Email:��6   $��Center=�6?   $	��180��6Z   $��0,0,10,0q�6f   �� 5%      -   5         ��Name$ 	txtSearch��5%      $	��250��61   $��5q�6=   $��0,0,10,0q�6I   �� 5(      -   5        $��Search��5(      $��80��6.   $��35��69   $��0,0,10,0q�6E   ���#2196F3
�������$
��Bold"�5)   ,   ���#2196F36T   5*      &   System.Windows.Controls.DataGrid  5-      -   5          Name$ 	dgMembers��5-      $��2��6.   	   AutoGenerateColumns	 .  $��	0,10,0,10q�6W   
   CanUserAddRows
 .     SelectionMode$ Single=�5.   .   ���#D3D3D3$��1q�6[      
IsReadOnly .    Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Member ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *
MemberID+6]     52      $
 Name��6-   $	 200 6T    6;   �� *Name+6T     53      $ 	Interests��6-   $	 200 6^    6@   �� *	Interests+6^     54      $ Demographics��6-   $	 150 6d    6C   �� *Demographics+6d     55      $ Membership Status��6-   $	 150 6m    6H   �� *MembershipStatus+6m     56      $ Joining Date��6-   $	 150 6`    6C   �� *
JoinDate+6`     57      $ Email��6-   $	 200 6V    6<   �� *Email+6V     58      $ Membership Type��6-   $	 200 6i    6F   �� *MembershipType+6i   5:      �� 5=      $��3��6   $ Vertical=�6*   $��0,10,0,0q�6A   .+�5>      �� $ 
Horizontal=�6!   $	��0,5q�6:   .+�5?      �� $��Name:��6    $	��120��60   $��Center=�6<   �� 5@      -   5        $ txtName��5@   "   $	��300��63   $��5q�6?   5A      �� 5B      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5C      �� $��
Interests:��6    $	��120��65   $��Center=�6A   �� 5D      -   5        $ txtInterests��5D   "   $	��300��68   $��5q�6D   5E      �� 5F      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5G      �� $��Demographics:��6    $	��120��68   $��Center=�6D   �� 5H      -   5        $ txtDemographics��5H   "   $	��300��6;   $��5q�6G   5I      �� 5J      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5K      �� $��Membership Status:��6    $	��120��6=   $��Center=�6I   �� 5L      -   5        $ cmbMembershipStatus��5L   #   $	��300��6@   $��5q�6L   .@�5M      �� $��Active��6+   �� 5N      $��Inactive��6+   �� 5O      $��Pending��6+   5P      5Q      �� 5R      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5S      �� $��Joining Date:��6    $	��120��68   $��Center=�6D   (  "System.Windows.Controls.DatePicker  5T      -	   5          Name$ 
dpJoinDate��5T   %   $	��300��69   5U      �� 5V      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5W      �� $��Email:��6    $	��120��61   $��Center=�6=   �� 5X      -
   5        $ txtEmail��5X   "   $	��300��64   $��5q�6@   5Y      �� 5Z      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5[      �� $��Membership Type:��6    $	��120��6;   $��Center=�6G   �� 5\      -   5        $��cmbMembershipType��5\   #   $	��300��6<   .@�5]      �� $��Community Member��6+    �� 
IsSelected . 6F   �� 5^      $��Key Access Member��6+   �� 5_      $��Creative Workspace Member��6+   5`      5a      �� 5d      $ 
Horizontal=�6!   $��Center=�6:   $��0,20,0,0q�6W   .+�5e      �� -   5        $	��Add��5e   !   $	��100��6/   $��35��6;   $��10q�6G   ���#4CAF50
�������$
��Bold"�5f   0   ���#4CAF506X   �� 5g      -   5        $
��Edit��5g   !   $	��100��60   $��35��6<   $��10q�6H   ���#FFC107
�������$
��Bold"�5h   0   ���#FFC1076X   �� 5i      -   5        $��Delete��5i   !   $	��100��62   $��35��6>   $��10q�6J   ���#F44336
�������$
��Bold"�5j   0   ���#F443366X   5k      5l      5m      5n      5o      5q      