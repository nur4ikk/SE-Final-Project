   M S B A M L   `   `   `  ����V  RCRM System Development Plan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CRM_System_Development_PlanCRM_System_Development_Plan  5   	   5    /CRM_System_Development_Plan.EventManagementForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:CRM_System_Development_Plan     5   	     � Title$  Event Management��5   	   $	��700��6#   $
��1000��60    � WindowStartupLocation$ CenterScreen=�6=   ���#F5F5F5.��5	      � $��20q�6   .+�5   
   �� 
������� �� CornerRadius$ 10��6$    �� Padding$ 15q�66   ���#D3D3D3$��1q�6Y   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      �� $��Event Management��6   $��24(�64   $
��Bold"�6B   ���#333$��Center=�5      $��0,0,0,20q�69   �� 5      $��1��6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   $��	0,10,0,10q�6`   .+�5      �� $��Search by Event Name:��6   $��Center=�6<   $	��180��6W   $��0,0,10,0q�6c   �� 5      -   5         ��Name$ 	txtSearch��5      $	��250��61   $��5q�6=   $��0,0,10,0q�6I   �� 5      -   5        $��Search��5      $��80��6.   $��35��69   $��0,0,10,0q�6E   ���#2196F3
�������$
��Bold"�5       ���#2196F36D   5!      &   System.Windows.Controls.DataGrid  5#      -   5          Name$ dgEvents��5#      $��2��6-      AutoGenerateColumns .  $��	0,10,0,10q�6V   	   CanUserAddRows	 .  
   SelectionMode$
 Single=�5$   2   ���#D3D3D3$��1q�6_      
IsReadOnly .    Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Event ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *	EventID+6[     5(      $ 
Event Name��6-   $	 200 6_    6A   �� *	EventName+6_     5)      $ Category��6-   $	 150 6\    6?   �� *
Category+6\     5*      $
 Date��6-   $	 150 6T    6;   �� *Date+6T     5+      $ 
Attendance��6-   $	 100 6e    6A   �� *AttendanceCount+6e     5,      $ Location��6-   $	 200 6\    6?   �� *
Location+6\     5-      $ Description��6-   $	 300 6b    6B   �� *Description+6b   5/      �� 52      $��3��6   $ Vertical=�6*   $��0,10,0,0q�6A   .+�53      �� $ 
Horizontal=�6!   $	��0,5q�6:   .+�54      �� $��Event Name:��6    $	��120��66   $��Center=�6B   �� 55      -   5        $ txtEventName��55   "   $	��300��68   $��5q�6D   56      �� 57      $ 
Horizontal=�6!   $	��0,5q�6:   .+�58      �� $��	Category:��6    $	��120��64   $��Center=�6@   �� 59      -   5        $ txtCategory��59   "   $	��300��67   $��5q�6C   5:      �� 5;      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5<      �� $��Date:��6    $	��120��60   $��Center=�6<   (  "System.Windows.Controls.DatePicker  5=      -   5          Name$ dpDate��5=   %   $	��300��65   5>      �� 5?      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5@      �� $��Attendance Count:��6    $	��120��6<   $��Center=�6H   �� 5A      -   5        $ txtAttendance��5A   "   $	��300��69   $��5q�6E   5B      �� 5C      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5D      �� $��	Location:��6    $	��120��64   $��Center=�6@   �� 5E      -   5        $ txtLocation��5E   "   $	��300��67   $��5q�6C   5F      �� 5G      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5H      �� $��Description:��6    $	��120��67   $��Center=�6C   �� 5I      -	   5        $ txtDescription��5I   "   $	��300��6:   $��5q�6F   $��80��6R    �� TextWrapping$
 Wrap=�6^    �� AcceptsReturn . 6r   5J      �� 5M      $ 
Horizontal=�6!   $��Center=�6:   $��0,20,0,0q�6W   .+�5N      �� -
   5        $	��Add��5N   !   $	��100��6/   $��35��6;   $��10q�6G   ���#4CAF50
�������$
��Bold"�5O   4   ���#4CAF506\   �� 5P      -   5        $
��Edit��5P   !   $	��100��60   $��35��6<   $��10q�6H   ���#FFC107
�������$
��Bold"�5Q   4   ���#FFC1076\   �� 5R      -   5        $��Delete��5R   !   $	��100��62   $��35��6>   $��10q�6J   ���#F44336
�������$
��Bold"�5S   4   ���#F443366\   5T      5U      5V      5W      5X      5Y      