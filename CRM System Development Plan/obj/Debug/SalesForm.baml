   M S B A M L   `   `   `  ����V  RCRM System Development Plan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CRM_System_Development_PlanCRM_System_Development_Plan  5   	   +    %CRM_System_Development_Plan.SalesForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:CRM_System_Development_Plan     5   	     � Title$  Sales��5   	   $	��700��6   $
��1000��6$    � WindowStartupLocation$ CenterScreen=�61   ���#F5F5F5.��5	      � $��20q�6   .+�5   
   �� 
������� �� CornerRadius$ 10��6$    �� Padding$ 15q�66   ���#D3D3D3$��1q�6Y   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      �� $��Sales Management��6   $��24(�64   $
��Bold"�6B   ���#333$��Center=�5      $��0,0,0,20q�69   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgSales��5      $��1��6,      AutoGenerateColumns .  $��	0,10,0,10q�6U      CanUserAddRows .     SelectionMode$ Single=�5   2   ���#D3D3D3$��1q�6_   	   
IsReadOnly	 . 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Sale ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *SaleID+6Y     5      $ 	Member ID��6-   $ 70 6]    6@   �� *
MemberID+6]     5      $ Member Name��6-   $	 200 6a    6B   �� *
MemberName+6a     5      $ Event ID��6-   $ 70 6[    6?   �� *	EventID+6[     5       $ Event��6-   $	 150 6Z    6<   �� *	EventName+6Z     5!      $
 Date��6-   $	 150 6X    6;   �� *
SaleDate+6X     5"      $ Amount��6-   $	 100 6X    6=   �� *Amount+6X   5$      �� 5'      $��2��6    �� Orientation$ Vertical=�6*   $��0,10,0,0q�6A   .+�5(      �� $ 
Horizontal=�6!   $	��0,5q�6:   .+�5)      �� $��Member:��6    $	��120��62   $��Center=�6>   �� 5*      -   5         ��Name$ cbMember��5*   #   $	��300��65   $��5q�6A   5+      �� 5,      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5-      �� $��Event:��6    $	��120��61   $��Center=�6=   �� 5.      -   5        $ cbEvent��5.   #   $	��300��64   $��5q�6@   5/      �� 50      $ 
Horizontal=�6!   $	��0,5q�6:   .+�51      �� $��Amount:��6    $	��120��62   $��Center=�6>   �� 52      -   5         ��Name$ 	txtAmount��52   "   $	��300��65   $��5q�6A   53      �� 54      $ 
Horizontal=�6!   $	��0,5q�6:   .+�55      �� $��
Sale Date:��6    $	��120��65   $��Center=�6A   (  "System.Windows.Controls.DatePicker  56      -   5          Name$ 
dpSaleDate��56   %   $	��300��69   57      �� 5:      $ 
Horizontal=�6!   $��Center=�6:   $��0,20,0,0q�6W   .+�5;      �� -   5        $	��Add��5;   !   $	��100��6/   $��35��6;   $��10q�6G   ���#4CAF50
�������$
��Bold"�5<   4   ���#4CAF506\   �� 5=      -   5        $
��Edit��5=   !   $	��100��60   $��35��6<   $��10q�6H   ���#FFC107
�������$
��Bold"�5>   4   ���#FFC1076\   �� 5?      -   5        $��Delete��5?   !   $	��100��62   $��35��6>   $��10q�6J   ���#F44336
�������$
��Bold"�5@   4   ���#F443366\   5A      5B      5C      5D      5E      5F      