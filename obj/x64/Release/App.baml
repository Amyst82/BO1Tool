   M S B A M L   `   `   `  ���� B  >bo1tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:bo1toolbo1tool      bo1tool.App   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     'localclr-namespace:bo1tool       �� 	Resources   $   Expander.MouseOver.Circle.Stroke �� Color " Expander.MouseOver.Circle.Fill # Expander.MouseOver.Arrow.Stroke " Expander.Pressed.Circle.Stroke   Expander.Pressed.Circle.Fill ! Expander.Pressed.Arrow.Stroke # Expander.Disabled.Circle.Stroke ! Expander.Disabled.Circle.Fill " Expander.Disabled.Arrow.Stroke 	 Expander.Static.Circle.Fill !
 Expander.Static.Circle.Stroke   Expander.Static.Arrow.Stroke  ExpanderRightHeaderStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding J� SnapsToDevicePixels � RowDefinitions	 � LayoutTransform
 �� Angle A�Name F�Name �� Triggers P� Property P� Value �� 
TargetName  ExpanderUpHeaderStyle � ColumnDefinitions  ExpanderLeftHeaderStyle  ExpanderHeaderFocusVisual �� StrokeDashArray  ExpanderDownHeaderStyle  Expander �� CornerRadius d�Name � FocusVisualStyle d� 	IsChecked �� Mode �� RelativeSource ��Name��%  &	        &	      &	 .     &	 C     &	 Z     &	 q     &	 �     &	 �     &	 �     &		 �     &	
 �     &	 �     &	     7 
 7  7   7  7  7  7  7  7  7  7  &	 �    7 	 7 
 7  7   7  7  7  7  7  7  7  7  &	 �    7 	 7 
 7  7   7  7  7  7  7  7  7  7  &	 j    &	 �    7 	 7 
 7  7   7  7  7  7  7  7  7  7  &	     7  7  7  7  7  �� $ Transparent���� $ Transparent���� $ 	#FF191919���� $ Transparent���� $ Transparent���� $ 	#FF000000���� $ Transparent���� $ Transparent���� $ 	#FF707070���� $ Transparent���� $ Transparent���� $ 	#FF333333���� " d�.���  � �� �� " d�.R��� # z��._�� 
������  .   �� $��19 ��� $��* �.+�� 	 V� ~�X� �� $	
 -90Q�.+�A� $ circle��#��z��$��Center=�$��19��8��  $��Center=�$��19��F� $ arrow��"����@B `� � �D @KL � z `� 	$��Center=� .  8�� $��2��$��Center=��� $��Center=�$��0,4,0,0q�$��1����.  . $	��Top=� P�  �@d�	IsChecked$
 trueY�. ��� $ arrow�� � ��" ��@B  �D � �D @B � z  �D 	P�  �@J�IsMouseOver . . ��� $ circle��8   � ���� $ circle��8   � ���� $ arrow��8   � ��P�  � �� . . ��� $ circle��8   � ���� $ circle�� � ��$	 1.5���� $ circle��8   � ���� $ arrow��8   � ��P�  � {� .  . ��� $ circle��8   � ���� $ circle��8 	  � ���� $ arrow��8 
  � ���� " d�.���  � �� �� " d�.R��� # z��._�� 
������  .   �� $��19 ��� $��* �.+�� 	 V� ~�X� �� $	
 180Q�.+�A� $ circle��8��  $��Center=�$��19��8�� $��Center=�$��19��F� $ arrow��"����@B `� � �D @KL � z `� 	$��Center=� .  8�� $��2��$��Center=��� $��1��$
��Left=�$��4,0,0,0q���.  . $��Center=� P�  �@d�	IsChecked$
 trueY�. ��� $ arrow�� � ��" ��@B  �D � �D @B � z  �D 	P�  �@J�IsMouseOver . . ��� $ circle��8   � ���� $ circle��8   � ���� $ arrow��8   � ��P�  � �� . . ��� $ circle��8   � ���� $ circle�� � ��$	 1.5���� $ circle��8   � ���� $ arrow��8   � ��P�  � {� .  . ��� $ circle��8 	  � ���� $ circle��8 
  � ���� $ arrow��8   � ���� " d�.���  � �� �� " d�.R��� # z��._�� 
������  .   �� $��19 ��� $��* �.+�� 	 V� ~�X� �� $
 90Q�.+�A� $ circle��8��  $��Center=�$��19��8�� $��Center=�$��19��F� $ arrow��"����@B `� � �D @KL � z `� 	$��Center=� .  8�� $��2��$��Center=��� $��Center=�$��0,4,0,0q�$��1����.  . $	��Top=� P�  �@d�	IsChecked$
 trueY�. ��� $ arrow�� � ��" ��@B  �D � �D @B � z  �D 	P�  �@J�IsMouseOver . . ��� $ circle��8   � ���� $ circle��8   � ���� $ arrow��8   � ��P�  � �� . . ��� $ circle��8   � ���� $ circle�� � ��$	 1.5���� $ circle��8   � ���� $ arrow��8   � ��P�  � {� .  . ��� $ circle��8 	  � ���� $ circle��8 
  � ���� $ arrow��8   � ���� .���  � �� �� .R��� ._��� $��0q� . 
���   �$��1��$	 1 2R��� " d�.���  � �� �� " d�.R��� # z��._�� 
������  .  .+�A� $ circle��8��  $��Center=�$��19��8�� $��Center=�$��19��F� $ arrow��$��	-70,5,0,0q�"����@B `� � �D @KL � z `� 	$��Center=� .  8�� $��2��$��Center=��� $��1��$��0,4,0,0q���.  . $��Center=�$��Center=� P�  �@d�	IsChecked$
 TrueY�. ��� $ arrow�� � ��" ��@B  �D � �D @B � z  �D 	P�  �@J�IsMouseOver . . ��� $ circle��8   � ���� $ circle��8   � ���� $ arrow��8   � ��P�  � �� . . ��� $ circle��8   � ���� $ circle�� � ��$	 1.5���� $ circle��8   � ���� $ arrow��8   � ��P�  � {� .  . ��� $ circle��8 	  � ���� $ circle��8 
  � ���� $ arrow��8   � ���� " 9�.���  � ��# � ����  � ��
 ���� ��  � ��$ Stretch=���  � ��$ Stretch=���  � ��
 ���� ��  � ��$ 1q���  � �� �� Control��" 9�.R��� #��z��#��z��#��z��$ 3�� . ._�]� .+�d� $ 
HeaderSite��#��z��#��z��#��z��$	��Top=�#��z��#��z��8   #��z��#��z��#��z��#��z��#��z��$��1q�$��0��$��0��#��z��8�� #��z�����	#002B2B2B �� *
IsExpanded+$ TwoWay=� �� *TemplatedParent+�� $ 
ExpandSite��$��Bottom=�|�.  #��z��#��z��$y�	Collapsed=�#��z�� P�  �@9�
IsExpanded . . ��� $ 
ExpandSite�� � y�$ Visible=�P�  �@9�ExpandDirection$ Right=�. ��� $ 
ExpandSite�� � ��$ Right=��� $ 
HeaderSite�� � ��$
 Left=��� $ 
HeaderSite��8   � ��P�  �@9�ExpandDirection$ Up=�. ��� $ 
ExpandSite�� � ��$	 Top=��� $ 
HeaderSite�� � ��$ Bottom=��� $ 
HeaderSite��8   � ��P�  �@9�ExpandDirection$
 Left=�. ��� $ 
ExpandSite�� � ��$
 Left=��� $ 
HeaderSite�� � ��$ Right=��� $ 
HeaderSite��8   � ��P�  � {� .  . ��� # � �� � ��