   M S B A M L   `   `   `  ����V  RCRM System Development Plan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CRM_System_Development_PlanCRM_System_Development_Plan  5   	   3    -CRM_System_Development_Plan.EngagementLogForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:CRM_System_Development_Plan     5   	     � Title$  Engagement Log��5   	   $	��700��6    $
��1000��6-    � WindowStartupLocation$ CenterScreen=�6:   ���#F5F5F5.��5	      � $��20q�6   .+�5   
   �� 
������� �� CornerRadius$ 10��6$    �� Padding$ 15q�66   ���#D3D3D3$��1q�6Y   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      �� $��Engagement Log Management��6   $��24(�6=   $
��Bold"�6K   ���#333$��Center=�5      $��0,0,0,20q�69   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgEngagementLogs��5      $��1��65      AutoGenerateColumns .  $��	0,10,0,10q�6^      CanUserAddRows .     SelectionMode$ Single=�5   #   	   SelectionUnit$	 FullRow=�6;   ���#D3D3D3$��1q�6i   
   
IsReadOnly
 .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Log ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *LogID+6W     5      $ 	Member ID��6-   $ 70 6]    6@   �� *
MemberID+6]     5      $ Member Name��6-   $	 150 6a    6B   �� *
MemberName+6a     5      $ Event ID��6-   $ 70 6[    6?   �� *	EventID+6[     5       $ Event��6-   $	 150 6Z    6<   �� *	EventName+6Z     5!      $
 Type��6-   $	 150 6^    6;   �� *EngagementType+6^     5"      $
 Date��6-   $	 100 6^    6;   �� *EngagementDate+6^   5$      �� 5'      $��2��6    �� Orientation$ Vertical=�6*   $��0,10,0,0q�6A   .+�5(      �� $ 
Horizontal=�6!   $	��0,5q�6:   .+�5)      �� $��Member:��6    $	��120��62   $��Center=�6>   �� 5*      -   5         ��Name$ cbMember��5*   #   $	��300��65   $��5q�6A   5+      �� 5,      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5-      �� $��Event:��6    $	��120��61   $��Center=�6=   �� 5.      -   5        $ cbEvent��5.   #   $	��300��64   $��5q�6@   5/      �� 50      $ 
Horizontal=�6!   $	��0,5q�6:   .+�51      �� $��Engagement Type:��6    $	��120��6;   $��Center=�6G   �� 52      -   5        $ cbEngagementType��52   #   $	��300��6=   $��5q�6I   .@�53      �� .��6+   	Meeting64   �� 54      .��6+   
Phone Call67   �� 55      .��6+   Email62   �� 56      .��6+   Event Attendance6=   57      58      �� 59      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5:      �� $��Engagement Date:��6    $	��120��6;   $��Center=�6G   (  "System.Windows.Controls.DatePicker  5;      -   5          Name$ dpEngagementDate��5;   %   $	��300��6?   5<      �� 5?      $ 
Horizontal=�6!   $��Center=�6:   $��0,20,0,0q�6W   .+�5@      �� -   5        $	��Add��5@   !   $	��150��6/   $��35��6;   $��10q�6G   ���#4CAF50
�������$
��Bold"�5A   4   ���#4CAF506\   �� 5B      -   5        $
��Edit��5B   !   $	��150��60   $��35��6<   $��10q�6H   ���#FFC107
�������$
��Bold"�5C   4   ���#FFC1076\   �� 5D      -   5        $��Delete��5D   !   $	��150��62   $��35��6>   $��10q�6J   ���#F44336
�������$
��Bold"�5E   4   ���#F443366\   5F      5G      5J      5K      5L      5M      