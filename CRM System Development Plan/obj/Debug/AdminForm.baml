   M S B A M L   `   `   `  ����V  RCRM System Development Plan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CRM_System_Development_PlanCRM_System_Development_Plan  5   	   +    %CRM_System_Development_Plan.AdminForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:CRM_System_Development_Plan     5   	     � Title$  	AdminForm��5   	   $	��700��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   .��5	      � $��20q�6   .+�5   
   ��  �� Orientation$ Vertical=�6   $
��Left=�6,   $	��Top=�6G   .+�5      �� $��Filter by Membership Type��6   $
��Bold"�69   $��0,0,0,10q�6K   �� 5      -   5         ��Name$ MembershipTypeFilter��5      $
��Left=�65   $	��200��6P   $��0,0,0,20q�6\   .@�5      �� $	��All��6   �� 5      $��Community Members��6   �� 5      $��Key Access Members��6   �� 5      $ ��Creative Workspace Members��6   5      5      �� 5   
   -   5         ��Name$ MembersListView��5      $��Stretch=�6,   $	��Top=�6J   $��0,60,0,0q�6b   $	��150��6t    �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$	 200��6Y    �� DisplayMemberBinding 63   �� *Name+6Y   �� 5      $��Membership Type��6%   $	 150��6n    6>   �� *MembershipType+6n   5      5      �� 5!   
   $ Vertical=�6   $
��Left=�6,   $	��Top=�6G   $��
0,220,0,10q�6_   .+�5"      �� $"��Search Events or Time Period��6   $
��Bold"�6<   $��0,0,0,5q�6N   � 5#      $
��Left=�6   $	��Top=�6.   $	��500��6F   .+�5$      �� -   5         ��Name$ EventSearchBox��5$      $��Center=�62   $
��Left=�6M   $	��200��6h   �� 5%      -   5        	 ��Name$	 EventSearchWatermark��5%      $��Center=�6:   $
��Left=�6U   $��5,0,0,0q�6p   
�������
 J� IsHitTestVisible
 .  5'      �� 5(      -   5        $��Search��5(      $
��Left=�6*   $	��Top=�6E   $��75��6]   $��	220,0,0,0q�6h   6{   5)      5+      �� 5.   
   -   5        $ EventsListView��5.      $��Stretch=�6+   $	��Top=�6I   $��	0,280,0,0q�6a   $	��150��6t    5/      �� 50      .P�51      �� $��
Event Name��6%   $	 200��6d    69   �� *	EventName+6d   �� 52      $
��Date��6%   $	 150��6Y    63   �� *Date+6Y   �� 53      $��Attendance Count��6%   $	 150��6p    6?   �� *AttendanceCount+6p   54      56      �� 59   
   $ Vertical=�6   $
��Left=�6,   $	��Top=�6G   $��
0,440,0,10q�6_   .+�5:      �� $��Search Members or Guests��6   $
��Bold"�68   $��0,0,0,5q�6J   � 5;      $
��Left=�6   $	��Top=�6.   $	��500��6F   .+�5<      �� -   5        $ MemberSearchBox��5<      $��Center=�63   $
��Left=�6N   $	��200��6i   �� 5=      -   5        $	 MemberSearchWatermark��5=      $��Center=�6;   $
��Left=�6V   $��5,0,0,0q�6q   
�������
 .  5?      �� 5@      -	   5        $��Search��5@      $
��Left=�6*   $	��Top=�6E   $��75��6]   $��	220,0,0,0q�6h   6{   5A      5C      �� 5F   
   -
   5        $ EngagementsListView��5F      $��Stretch=�60   $	��Top=�6N   $��	0,490,0,0q�6f   $	��130��6y    5G      �� 5H      .P�5I      �� $
��Name��6%   $	 200��6Y    63   �� *Name+6Y   �� 5J      $��
Event Name��6%   $	 200��6d    69   �� *	EventName+6d   �� 5K      $��Engagement Date��6%   $	 150��6n    6>   �� *EngagementDate+6n   5L      5N      5P      5R      