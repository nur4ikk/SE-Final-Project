   M S B A M L   `   `   `  ����V  RCRM System Development Plan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CRM_System_Development_PlanCRM_System_Development_Plan  5   	   ,    &CRM_System_Development_Plan.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:CRM_System_Development_Plan     5   	     � Title$  
MainWindow��5   	   $	��400��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�66   ���#F5F5F5.��5	      � $��20q�6   .+�5
   
   �� 
������� �� CornerRadius$ 10��6$    �� Padding$ 15q�66   ���#D3D3D3$��1q�6Y   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� $��Main Window��6   $��24(�6/   $
��Bold"�6=   ���#333$��Center=�5      $��Center=�69   $��0��6T   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��0,20,0,0q�6S   $��1��6e   .+�5      �� -   5        $��MEMBER��5      $	��200��6.   $	��100��6:   $��10q�6G   ���#4CAF50
�������$
��Bold"�5   0   ���#4CAF506X   �� 5      -   5        $��EVENT��5      $	��200��6-   $	��100��69   $��10q�6F   ���#4CAF50
�������$
��Bold"�5   0   ���#4CAF506X   �� 5      -   5        $��SALES��5      $	��200��6-   $	��100��69   $��10q�6F   ���#4CAF50
�������$
��Bold"�5   0   ���#4CAF506X   5      �� 5!      $ 
Horizontal=�6   $��Center=�66   $��0,20,0,-247q�6S   $��1��6h   .+�5"      �� -   5        $��ENGAGEMENTLOG��5"      $	��200��65   $	��100��6A   $��10q�6N   ���#4CAF50
�������$
��Bold"�5#   0   ���#4CAF506X   �� 5$      -   5        $��	ANALYTICS��5$      $	��200��61   $	��100��6=   $��10q�6J   ���#4CAF50
�������$
��Bold"�5%   0   ���#4CAF506X   �� 5&      -   5        $��
_AdminForm��5&   g   $��ADMIN��6   $	��200��6-   $	��100��69   $��10q�6F   ���#4CAF50
�������$
��Bold"�5'   0   ���#4CAF506X   5(      5)      5*      5+      5-      