   M S B A M L   `   `   `  ����B  >bo1tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:bo1toolbo1tool  5   	   p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5   	   �_clr-namespace:System.Windows.Controls.Primitives;assembly=System.Windows.Controls.Input.Toolkit"System.Windows.Controls.Primitives 5
   	   o kMicrosoft.Expression.Prototyping.Runtime, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�iclr-namespace:Microsoft.Expression.Prototyping.Controls;assembly=Microsoft.Expression.Prototyping.Runtime)Microsoft.Expression.Prototyping.Controls 5   	   C ?WPFSpark, Version=1.4.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:WPFSpark;assembly=WPFSparkWPFSpark 5   	   S OColorWheel.Controls, Version=1.7.14.51712, Culture=neutral, PublicKeyToken=nullV>clr-namespace:ColorWheel.Controls;assembly=ColorWheel.ControlsColorWheel.Controls 6C   7 clr-namespace:bo1tool.Convertersbo1tool.Converters  5   	       bo1tool.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:bo1tool     5   	   :xctk)http://schemas.xceed.com/wpf/xaml/toolkit     5   	   j	Controls2Tclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit     5   	   @Custom-http://schemas.microsoft.com/wpf/2008/toolkit     5	   	   v
Primitives_clr-namespace:System.Windows.Controls.Primitives;assembly=System.Windows.Controls.Input.Toolkit     5
   	   ~Controlsiclr-namespace:Microsoft.Expression.Prototyping.Controls;assembly=Microsoft.Expression.Prototyping.Runtime     5   	   =WPFSpark(clr-namespace:WPFSpark;assembly=WPFSpark     5   	   T	Controls1>clr-namespace:ColorWheel.Controls;assembly=ColorWheel.Controls     6C   7
converters clr-namespace:bo1tool.Converters     5   	   -   5          �Name$  bo1tool��5   �    � Title$ BO1 Tool��5   	   $	��334��6   $	��545��6'      WindowStyle#���   63    � WindowStartupLocation$ CenterScreen=�6Y    � WindowStyle$
 None=�6~   $8��2/bo1tool;component/Resources/#ConduitITCStd Medium)�6�     DefaultBackground#���  6�   $	��416��6  $	��305��6)   � 
ResizeMode$ 	CanResize=�69    BackgroundOpaque#���  6P   � 	Resources 5       �� MergedDictionaries �� Source4   .bo1tool.Converters.BoolToOppositeBoolConverter  oppositeConverter&    bo1tool.Converters.MathConverter  mathConverter'  !bo1tool.Converters.ColorConverter  colorConvert*  $bo1tool.Converters.colorHexConverter  colorHexConvert�� 5   
    5      �� 5      $ 
Style.xaml?�6%   %t   &	       &	      &	 &     &	 9       5      65     5      6'     5      6(     5      6+   5      '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
   	   CaptionHeight$	 0Q�5   	   
   ResizeBorderThickness$
 3q�5   	      UseAeroCaptionButtons . 5    	   .��5"      � -   5         �Name$ mainGrid��5"      #���  6   $��0,5,0,2q�6O   .+�5#   
   �� -   5         ��Name$ closeButton��5#      $	��✕��6&   $��	0,-24,0,0q�62   $	��Top=�6E   
���   �$��24��6�   ���	#FF838383$��Right=�6�   $��24��6�   ��6]   Z� 6�   �� 5$   
   -   5        $ 	minButton��5$      $	��—��6$   $��
0,-24,26,0q�60   $	��Top=�6D   
���   �$��24��6�   ���	#FF707071$��Right=�6�   $��24��6�   ��6\   Z� 6�   �� 5%   
   -   5         ��Name$ AllPages��5%      $��14(�6@    �� SelectedIndex$ 0��6N   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6`   #���  6�   $��0,2,0,0q�6�   .@�5&      �� $
��MENU��6   .��5'      � -   5        $ menuGrid��5'      $��	0,0,-3,-5q�6)    J� Opacity$ 1Q�6<   .+�5(      � -   5        $ controlsGrid��5(      #���  61    J� Effect 5)      -  'System.Windows.Media.Effects.BlurEffect  5*         Radius$ 0Q�6)      RenderingBias$ Quality=�64   .+�5,      �� -   5        $ 
reloadGame��5,   !   $��Reload��65   $
��Left=�6F   $��
153,63,0,0q�6a   $	��Top=�6u   $	��225��6�   $��45��6�     DefaultBackgroundOpacity#���  6�     DefaultColor#���  6�   $��17(�6	  6  �� 5-      -	   5        $ loadAll��5-   !   $��Load all��62   $
��Left=�6E   $��153,112,0,0q�6`   $	��Top=�6u   $	��110��6�   $��36��6�   #���  6�   #���  6�   $��17(�6	  �� 5.      -
   5        $ saveAll��5.   !   $��Save all��62   $
��Left=�6E   $��268,112,0,0q�6`   $	��Top=�6u   $	��110��6�   $��36��6�   #���  6�   #���  6�   $��17(�6	  �� 5/      -   5        $ 
restoreAll��5/   !   $��Restore all��65   $
��Left=�6K   $��153,154,0,0q�6f   $	��Top=�6{   $	��174��6�   $��46��6�   #���  6�   #���  6�   $��17(�6  � 50      -   5        $ settingsButton��50      $
��Left=�67   $��46��6R   $��333,154,0,0q�6^   $	��Top=�6s   $��45��6�   #���  6�    � Cursor$
 Hand��6�   .+�51      (� $��13,13,11,12q�6&   .��52   "   �� $��24��6)   $��24��64   .+�53   &   F�  	 DefaultHighlightColor#��� 	 6+   ����� � ��� � ��  � ��g5 �g5 � �  �� ��g5 �g5 ����  � ��g5 �g5 � � ��� ��g5 �g5 �pz(�� Ӱ)� ��)$� ��) � ���)�� �)�� pz(�ا Ѡ�H��� �ВK���  VL� `�J�5� ���+�iP � (*�M p	& �K �"�M ����(\�0@�P\ �@�� `]V ��� @-Q ��� �\M Ѡ@�  �$ �`�� �C! p� �� ��� �� р�� �� ��Ŕ �� ��� �C! `��  �$ �P� �\M � �� @-Q �uy `]V ��q �P\ ���K �M Ӑ,H  �K �D �M  9B �iP Ѡ�# �5� �и! � 0�" ��� `�% ��� ѐ�E �ا �PE ��  �D ��  �D  � � �D $� PE � ��E �� �`�% p<� �0�" `�� и! �� ��# p � � 9B ���D p'!�,H �_"��K p'!р�q  ���uy �� �� �P� P� �`�� �HIӠ�� `�L�Ŕ ��O��� ��Oр�� ��O�p� ��O`�� `�L�@� �HI���� P� ���� ��@�� �����(\�0@ ���"p'!�p	&�_" (*p'!��+��`�Jp � � VL�� ВK`�� ��Hp<� �pz(�� 	$��24��6�   �� Stretch$
 Fill=�6�  $��24��6  54   #   55      56      57      � 58      -   5        $ colorControlsGrid��58      $
��Left=�66   $	��267��6Q   $��	313,0,0,0q�6^   $	��Top=�6q   $	��200��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $ 0Q�6�   z�59      V� 5:      .~�5;   "   ��  �� ScaleX$ 0.0001Q�61    �� ScaleY$ 0.0001Q�6A   �� 5<   "   �� 5=   "   T� 5>   "   5?      .+�5A      ��  
 DefaultBackgroundOpaque#��� 
 6$   $
��Left=�6U   $	��235��6p   $��	15,17,0,0q�6}   $	��Top=�6�   $	��170��6�    �� RadiusY$	 9.5��6�    �� RadiusX$	 9.5��6�    5B      3  -System.Windows.Media.Effects.DropShadowEffect  5C   "      
BlurRadius$ 25Q�63   5E      +  %ColorWheel.Controls.ColorWheelControl  5F      -   5          Name$ styleColorWheel��5F   6   $
��Left=�6O   $	��132��6�   $��	20,87,0,0q�6�   $	��Top=�6�   $	��130��6     Palette 6j   �� *	Palette+ �� RelativeSource �� *FindAncestor+  �� AncestorType	   bo1tool.MainWindow"  	 6   �� 5G      $��Theme��6    $
��Left=�60   $��	86,22,0,0q�6K   $	��Top=�6^   $��12(�6v   $8��2/bo1tool;component/Resources/#ConduitITCStd Medium)�6�   #��� 	 6�   	� 5H      -   5        $
��Dark��5H   &   $
��Left=�65   $��	25,37,0,0q�6P   $	��Top=�6c   ! d� 	IsChecked$
! TrueY�6{   #��� 	 6�   #���  6�   6�   	� 5I      -   5        $��Light��5I   &   $
��Left=�66   $��	80,37,0,0q�6Q   $	��Top=�6d   #��� 	 6}   #���  6�   6�   	� 5J      -   5        $	��Fnc��5J   &   $
��Left=�64   $��
133,37,0,0q�6O   $	��Top=�6c   #��� 	 6|   #���  6�   6�   �� 5K      $��Style��6    $
��Left=�60   $��	88,68,0,0q�6K   $	��Top=�6^   $��12(�6v   $8��2/bo1tool;component/Resources/#ConduitITCStd Medium)�6�   #��� 	 6�   �� 5L      $
��Left=�6$   $��5��6?   $��	32,60,0,0q�6J   $	��Top=�6]   $	��138��6u   #���  6�   
   bo1tool.aTextBox
  5M      -   5        " 
 Name$" styleColorHexBox��5M   )      bo1tool.aTextBox#   TextChanged$"# styleColorHexBox_TextChanged��62  $��1��6C   $
��Left=�6W   $��60,224,0,20q�6r   $ �� TextWrapping$
$ Wrap=�6�   $��80��6�   #���  6  ��6�   �� % �� ElementName$% styleColorWheel��& �� Path$ & Palette.Colors[0].RgbColor�' �� Mode$' TwoWay=�62  �� 5N      -   5        ( ��Name$ ( styleColorBrightnessSlider��5N   !   $
��Left=�6E   $��90,147,-40,0q�6`   $	��Top=�6v   $��22��6�   $	��150��6�   $ 0.5,0.5&�6�   ) � Maximum$	) 255Q�6�   * � Value$	* 255Q�6�   z�5O      V� 5P   "   .~�5Q   &   �� �� 5R   &   �� 5S   &   + �� Angle$	+ -90Q�66   T� 5T   &   5U   #   5W      5X      5Z      5[      �� 5\      -   5        , ��Name$, tabItem1��5\      $	��CFG��6(   $��2,0,-2,0q�65   $��0��6G   $��15(�6T   .��5]      � #���  6   $��	0,0,-3,-5q�6H   .+�5^      
  -   5        $" 	singleCfg��5^   %   -   MouseDoubleClick$- TextBox_MouseDoubleClick��6  $# singleCfg_TextChanged��6�  .   KeyUp$. singleCfg_KeyUp��6�  $��1��68   $��30��6L   $��10,10,100,0q�6X   $
$ Wrap=�6m   $	��Top=�6�   $��16(�6�   #��� 	 6�   
/ � Tag$/ Single command��6�   $��Segoe UI Semilight)�6�   0 �� 
CaretBrush#0 � 	 6=  1 
  HintText$1 Single command��6r  2 
  FocusedBrush#2 � 	 6�  3 
  ShowClearButton3 . #���  6  .��6G  4 � ContextMenu4 5_      �� 5`      #���  6*   $8��2/bo1tool;component/Resources/#ConduitITCStd Medium)�6[   5 �� HasDropShadow5 . $	��120��6�   .@�5a   "   m� -   5        $��
To CFG box��5a   +   $��17(�6?   $	��120��6M   $��30��6Y   6e   m� 5b   "   -   5        $��Copy All��5b   +   $��17(�6=   $	��120��6K   $��30��6W   6c   m� 5c   "   -   5        $��Copy selection��5c   +   $��17(�6C   $	��120��6Q   $��30��6]   6i   m� 5d   "   -   5        $��Paste��5d   +   $��17(�6:   $	��120��6H   $��30��6T   6`   m� 5e   "   -   5        $��Clear��5e   +   $��17(�6:   $	��120��6H   $��30��6T   6`   5f      .��5g   6   5h      �� 5i      -   5        $ 
sendSingle��5i      $
��Send��61   $��	0,10,10,0q�6@   $	��Top=�6S   $��30��6k   #���  6w   #���  6�   $
��Left=�6�   $	��Top=�6�   $��13(�6  $��Right=�6*  $��85��6F  6Q  
  5j      -   5        $" 	tScaleBox��5j   %   $- TextBox_MouseDoubleClick��6  $. TextBox_KeyUp��6C  $# TextBox_TextChanged��6Y  $��1��68   $��30��6L   $��10,47,100,0q�6X   $
$ Wrap=�6m   $	��Top=�6�   $��16(�6�   #��� 	 6�   $/  ��6�   $��Segoe UI Semilight)�6�   6 � ToolTip$6 	timescale��6  $1 	timescale��6�  3 . #���  6�  4 6{  �� *ContextMenu+$% 	singleCfg��6�  �� 5k      -   5        $ 
sendTscale��5k      $
��Send��61   $��	0,47,10,0q�6@   $	��Top=�6S   $��30��6k   #���  6w   #���  6�   $
��Left=�6�   $	��Top=�6�   $��13(�6  $��Right=�6*  $��85��6F  6Q     bo1tool.linkButton  5l      -   5        7  Name$7 loadCfg��5l   '      bo1tool.linkButton8   Click$8 loadCfg_Click��6�   $��Load CFG��68   $��
11,0,268,7q�6K   #���  6_   #���  6�   $��13(�6�   $��30��6�   $��Bottom=�6�   $��Center=�6  $	��124��6$  $
 Hand��60    5m      -   5        $7 sendCfg��5m   '   $8 sendCfg_Click��6�   $��Send CFG��68   $��140,0,140,7q�6K   #���  6`   #���  6�   $��13(�6�   $��30��6�   $��Bottom=�6�   $��Center=�6  $	��123��6%  $
 Hand��61    5n      -    5        $7 saveCfg��5n   '   $8 saveCfg_Click��6�   $��Save CFG��68   $��
269,0,10,7q�6K   #���  6_   #���  6�   $��13(�6�   $��30��6�   $��Bottom=�6�   $��Center=�6  $	��124��6$  $
 Hand��60  �� 5o      -!   5        9 ��Name$9 cfgBox��5o   "   $��10,82,10,42q�62   $��16(�6G   ": �� VerticalScrollBarVisibility$
: Auto=�6U   #��� 	 6x   $��Segoe UI Semilight)�6�   #���  6�   $/  ��6�   #���  61   5p      ; �� 
TargetType< �� Property= �� Value��%X   'J�       �� 5q      "; J�6$   .�5r   "   �� < �@��Margin$= 0q�6;   5s      5t      4 5u      �� 5v      #���  6*   $8��2/bo1tool;component/Resources/#ConduitITCStd Medium)�6[   5 . $	��120��6�   .@�5w   "   m� -"   5        $��Copy All��5w   +   $��17(�6=   $	��120��6K   $��30��6W   6c   m� 5x   "   -#   5        $��Copy selection��5x   +   $��17(�6C   $	��120��6Q   $��30��6]   6i   m� 5y   "   -$   5        $��Paste��5y   +   $��17(�6:   $	��120��6H   $��30��6T   6`   m� 5z   "   -%   5        $��Clear��5z   +   $��17(�6:   $	��120��6H   $��30��6T   6`   5{      . �5}      /� .T�5~      J� .*�6(   .*�5   "   �� $� ��6&   5�      5�      5�      5�      5�      �� 5�      $��THEATRE��6   $��2,0,-2,0q�6'   $��15(�69   .��5�      � #���  6   .+�5�      �� $��
Go to time��6   $
��Left=�62   $��	10,47,0,0q�6M   $	��Top=�6`   $	��190��6x   $��25��6�   #���  6�   #���  6�   � 5�      $
��Left=�6"   $��10��6=   $��	62,24,0,0q�6I   $	��Top=�6\   $	��336��6t   �� 5�      $
��Save��6   $
��Left=�6,   $��
207,47,0,0q�6G   $	��Top=�6[   $	��191��6s   $��25��6   #���  6�   #���  6�   �� 5�      $��00:00��6   $
��Left=�6,   $��	10,19,0,0q�6G   $	��Top=�6Z   $��17(�6r   #��� 	 6�   �� 5�      $
��Left=�6    $��7��6;   $��	10,77,0,0q�6F   $	��Top=�6Y   $	��388��6q   #���  6}   �� 5�      $��Green Screen��6   $
��Left=�63   $��	10,97,0,0q�6N   $	��Top=�6a   $��17(�6y     WPFSpark.ToggleSwitch  5�      -&   5        >  Name$> gsToggle��5�   ,   $��ToggleSwitch��6>   $
��Left=�6U   $��
112,97,0,0q�6p   $	��Top=�6�   ?   
AccentMode$
? User=�6�   ���	#FF5F5F5F@   AccentBrush#@ �  6�   A   ThumbBackgroundA �	#FF5F5F5F���	#FFB88259B   ThumbAccentBrush#B �  6<  $��20��6s  C   ThumbBorderThickness$C 2q�6  $��45��6�  $��45��6�  $��20��6�  $��16(�6�  D   CornerRadius$D 15��6�  ��6�   Z� 6�  �� 5�      $
��Left=�6    $��7��6;   $��
10,130,0,0q�6F   $	��Top=�6Z   $	��388��6r   #���  6~   �� 5�      $��Depth��6   $
��Left=�6,   $��
10,147,0,0q�6G   $	��Top=�6[   $��17(�6s     5�      -'   5        $> depthToggle��5�   ,   $��ToggleSwitch��6A   $
��Left=�6X   $��112,147,0,0q�6s   $	��Top=�6�   $
? User=�6�   ���	#FF5F5F5F#@ �  6�   A �	#FF5F5F5F���	#FFB88259#B �  6@  $��20��6w  $C 2q�6�  $��45��6�  $��45��6�  $��20��6�  $��16(�6�  $D 15��6�  ��6�   Z� 6  �� 5�      -(   5        $��1��5�      $
��Left=�62   $��20��6M   $��127,180,0,0q�6Y   $	��Top=�6o   $��60��6�   $
$ Wrap=�6�   $��16(�6�  
������ $��Center=�6�  $��-5,0,0,0q�6�  #��� 	 6  ��6�   �� *Value+$% depthDistanceSlider��E �� UpdateSourceTrigger$E PropertyChanged=�4 6  �� *ContextMenu+$% 	singleCfg��6  �� 5�      -)   5        $( depthDistanceSlider��5�      $
��Left=�6:   $��	7,200,0,0q�6U   $	��Top=�6h   $	��391��6�   $
* 2000Q�6�   ���	#FFF3DCDC$
) 4000Q�6�   6�   �� 5�      $��Depth Distance:��6   $
��Left=�66   $��
10,180,0,0q�6Q   $	��Top=�6e   $��17(�6}   �� 5�      $
��Left=�6    $��6��6;   $��	9,226,0,0q�6F   $	��Top=�6Y   $	��388��6q   #���  6}   �� 5�      $��Normal Pass��6   $
��Left=�62   $��	9,242,0,0q�6M   $	��Top=�6`   $��17(�6x   �� 5�      $
��Left=�6    $��8��6;   $��
10,270,0,0q�6F   $	��Top=�6Z   $	��388��6r   #���  6~   �� 5�      -*   5        F ��Name$F 
cg_drawGun��5�      $��
Remove Gun��63   $
��Left=�6H   $��
10,294,0,0q�6c   $	��Top=�6w   6�   �� 5�      -+   5        $F r_dobjlimit��5�      $��Remove Players��64   $
��Left=�6M   $��131,294,0,0q�6h   $	��Top=�6}   6�   �� 5�      -,   5        $F r_bloomTweaks��5�      $��Bloom Tweaks��66   $
��Left=�6M   $��292,320,0,0q�6h   $	��Top=�6}   6�   �� 5�      --   5        $F greenSkyToggle��5�      $��	Green Sky��67   $
��Left=�6K   $��292,294,0,0q�6f   $	��Top=�6{   6�   �� 5�      -.   5        $F 
rmvBarrier��5�      $��Remove Theatre Barrier��63   $
��Left=�6T   $��131,320,0,0q�6o   $	��Top=�6�   �� 5�      -/   5        $F fx_draw��5�      $��	Remove FX��60   $
��Left=�6D   $��
10,320,0,0q�6_   $	��Top=�6s   6�   	� 5�      -0   5        $
��None��5�   "   $
��Left=�61   $��108,244,0,0q�6L   $	��Top=�6a   #���  6y   #���  6�   $
! TrueY�6�   $/ 0��6�   6�   	� 5�      -1   5        $��Normal��5�   "   $
��Left=�63   $��172,244,0,0q�6N   $	��Top=�6c   #���  6{   $/ 1��6�   #���  6�   	� 5�      -2   5        $��Tangent��5�   "   $
��Left=�64   $��243,244,0,0q�6O   $	��Top=�6d   #���  6|   $/ 2��6�   #���  6�   	� 5�      -3   5        $��Binormal��5�   "   $
��Left=�65   $��315,244,0,0q�6P   $	��Top=�6e   #���  6}   $/ 3��6�   #���  6�   9� 5�      -4   5        G 9�Name$G 	gsColorEx��5�      $��      Clear Color��62   $��
166,90,0,0q�6M   #���  6a   $
��Left=�6�   $	��Top=�6�     Expander#���  6�   $
��Left=�6�   $	��Top=�6  $	��234��6$  $��27��60  $	��265��6<  $	��234��6L  $	��234��6[  $��30��6j  .��5�      � ��6   �� *ActualHeight+$% 	gsColorEx����6V   �� *ActualWidth+$% 	gsColorEx��.+�5�      �� #���  6(   $
��Left=�6R   $	��228��6m   $��	10,10,0,0q�6z   $	��Top=�6�   $	��213��6�   $
 19.5��6�   $
 19.5��6�    5�   "     5�   &   $ 19Q�67   H   ShadowDepth$H 0Q�6G   I   RenderingBias$I Quality=�6W   J   Opacity$	J 0.5Q�6o   5�        5�      -5   5        $ gsColorWheel��5�   :   $
��Left=�6�   $	��130��6�   $��	20,48,0,0q�6�   $	��Top=�6�   $	��130��6   6P   �� *	Palette+ �� *FindAncestor+"  	 6P  �� 5�      -6   5        $ cancelClearColor��5�   %   $��Cancel��6?   $
��Left=�6P   $��
20,193,0,0q�6k   $	��Top=�6   $��95��6�   $��25��6�   #���  6�   #���  6�   6  �� 5�      -7   5        $ okClearColor��5�   %   $��Ok��6;   $
��Left=�6H   $��120,193,0,0q�6c   $	��Top=�6x   $��95��6�   $��25��6�   #���  6�   �� 5�      -8   5        K ��Name$K gsR_textBox��5�   &   $��1��6;   $
��Left=�6O   $��26��6j   $��
155,70,0,0q�6v   $
$ Wrap=�6�   $	��Top=�6�   $��60��6�   
������ $��16(�6[    DefaultAccentColor#0 �  6i  ��6�   Z� ��6�   �� *Palette.Colors[0].R+L �� 	Converter#L [ $% gsColorWheel��6i  �� 5�      -9   5        $K gsG_textBox��5�   &   $��1��6<   $
��Left=�6P   $��25��6k   $��155,102,0,0q�6w   $
$ Wrap=�6�   $	��Top=�6�   $��60��6�   
������ $��16(�6[  #0 �  6i  ��6�   Z� ��6�   �� *Palette.Colors[0].G+#L [ $% gsColorWheel��6i  �� 5�      -:   5        $K gsB_textBox��5�   &   $��1��6<   $
��Left=�6P   $��26��6k   $��155,133,0,0q�6w   $
$ Wrap=�6�   $	��Top=�6�   $��60��6�   
������ $��16(�6[  #0 �  6i  ��6�   Z� ��6�   �� *Palette.Colors[0].B+#L [ $% gsColorWheel��6i  	� 5�      -;   5        M 	�Name$	M gsR��5�   *   $�� ��67   $
��Left=�6B   $��	75,18,0,0q�6]   $	��Top=�6p   
���  �����	#33FF00006�   	� 5�      -<   5        $	M gsG��5�   *   $�� ��67   $
��Left=�6B   $��	98,18,0,0q�6]   $	��Top=�6p   
��� � ����	#3300FF00$
! TrueY�6�   6�   	� 5�      -=   5        $	M gsB��5�   *   $�� ��67   $
��Left=�6B   $��
121,18,0,0q�6]   $	��Top=�6q   
����  ����	#330000FF6�   	� 5�      ->   5        $	M gsP��5�   *   $�� ��67   $
��Left=�6B   $��
144,18,0,0q�6]   $	��Top=�6q   
���� �����	#33FF00FF6�   5�      5�      5�      5�      �� 5�      $	��FOG��6   $��2,0,-2,0q�6#   $��15(�65   .��5�      � #���  6   .+�5�      �� -?   5        $��1��5�      $
��Left=�62   $��23��6M   $��	90,12,0,0q�6Y   $
$ Wrap=�6l   $	��Top=�6  $��62��64  #���  6V  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� $% fogStartSlider��$& Value���6?  Z� 6�  �� 5�      -@   5        $( fogStartSlider��5�      $
��Left=�65   $��
157,12,0,0q�6P   $	��Top=�6d   $	��280��6|   $
) 2000Q�6�   N � SmallChange$
N 0.01Q�6�   O � Minimum$O -1000Q�6�   $	* 900Q�6�   �� 5�      $��	FOG Start��6   $
��Left=�60   $��	10,12,0,0q�6K   $	��Top=�6^   $��17(�6v   �� 5�      -A   5        $( fogHeightSlider��5�      $
��Left=�66   $��
157,42,0,0q�6Q   $	��Top=�6e   $	��280��6}   $) 10000Q�6�   $
N 0.01Q�6�   $	* 900Q�6�   �� 5�      $��
FOG Height��6   $
��Left=�61   $��	10,42,0,0q�6L   $	��Top=�6_   $��17(�6w   �� 5�      -B   5        $��1��5�      $
��Left=�62   $��23��6M   $��	90,42,0,0q�6Y   $
$ Wrap=�6l   $	��Top=�6  $��62��60  #���  6R  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� *Value+$% fogHeightSlider����6;  Z� 6�    5�      -C   5        $ fogNearColorWheel��5�   2   $
��Left=�6�   $	��137��6�   $��
10,172,0,0q�6�   $	��Top=�6�   $	��138��6   6M   �� *	Palette+ �� *FindAncestor+"  	 6  �� 5�      $��FOG Near Color��6   $
��Left=�65   $��
56,142,0,0q�6P   $	��Top=�6d   $��17(�6|   #��� 	 6�   �� 5�      -D   5        $��1��5�      $
��Left=�62   $��23��6M   $��
137,72,0,0q�6Y   $
$ Wrap=�6m   $	��Top=�6>  $��62��6V  #���  6x  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� *Value+$% fogNearExpSlider��$' TwoWay=�P �� StringFormat$P {0:N2}����6a  Z� 6�  �� 5�      -E   5        $( fogNearExpSlider��5�      $
��Left=�67   $��
204,72,0,0q�6R   $	��Top=�6f   $	��233��6~   $) 16Q�6�   $
N 0.01Q�6�   $* 1Q�6�   �� 5�      $��FOG Near Exposure��6   $
��Left=�68   $��	10,72,0,0q�6S   $	��Top=�6f   $��17(�6~   �� 5�      -F   5        $( fogFarExpSlider��5�      $
��Left=�66   $��204,102,0,0q�6Q   $	��Top=�6f   $	��233��6~   $) 1Q�6�   $
N 0.01Q�6�   $* 1Q�6�   �� 5�      $��FOG Far Exposure��6   $
��Left=�67   $��
10,102,0,0q�6R   $	��Top=�6f   $��17(�6~   �� 5�      -G   5        $��1��5�      $
��Left=�62   $��23��6M   $��137,102,0,0q�6Y   $
$ Wrap=�6n   $	��Top=�6>  $��62��6V  #���  6x  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� *Value+$% fogFarExpSlider��$' TwoWay=�$P {0:N2}����6a  Z� 6�  �� 5�      -H   5        $��1��5�      $
��Left=�62   $��23��6M   $��152,186,0,0q�6Y   $
$ Wrap=�6n   $	��Top=�6S  $��56��6k  #���  6�  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� *Palette.Colors[0].R+#L [ $% fogNearColorWheel����6v  Z� 6�  �� 5�      -I   5        $��1��5�      $
��Left=�62   $��23��6M   $��152,229,0,0q�6Y   $
$ Wrap=�6n   $	��Top=�6S  $��56��6k  #���  6�  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� *Palette.Colors[0].G+#L [ $% fogNearColorWheel����6v  Z� 6�  �� 5�      -J   5        $��1��5�      $
��Left=�62   $��23��6M   $��152,271,0,0q�6Y   $
$ Wrap=�6n   $	��Top=�6S  $��56��6k  #���  6�  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� *Palette.Colors[0].B+#L [ $% fogNearColorWheel����6v  Z� 6�  �� 5�      -K   5        $( fogNearColorBrightness��5�      $
��Left=�6=   $��
10,314,0,0q�6X   $	��Top=�6l   $	��190��6�   $	) 255Q�6�   $
N 0.01Q�6�   $	* 255Q�6�     5�      -L   5        $ fogFarColorWheel��5�   2   $
��Left=�6�   $	��137��6�   $��238,172,0,0q�6�   $	��Top=�6�   $	��138��6   6L   �� *	Palette+ �� *FindAncestor+"  	 6  �� 5�      $��FOG Far Color��6   $
��Left=�64   $��292,142,0,0q�6O   $	��Top=�6d   $��17(�6|   #��� 	 6�   �� 5�      -M   5        $��1��5�      $
��Left=�62   $��23��6M   $��380,186,0,0q�6Y   $
$ Wrap=�6n   $	��Top=�6R  $��56��6j  #���  6�  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� *Palette.Colors[0].R+#L [ $% fogFarColorWheel����6u  Z� 6�  �� 5�      -N   5        $��1��5�      $
��Left=�62   $��23��6M   $��380,229,0,0q�6Y   $
$ Wrap=�6n   $	��Top=�6R  $��56��6j  #���  6�  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� *Palette.Colors[0].G+#L [ $% fogFarColorWheel����6u  Z� 6�  �� 5�      -O   5        $��1��5�      $
��Left=�62   $��23��6M   $��380,271,0,0q�6Y   $
$ Wrap=�6n   $	��Top=�6R  $��56��6j  #���  6�  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� *Palette.Colors[0].B+#L [ $% fogFarColorWheel����6u  Z� 6�  �� 5�      -P   5        $( fogFarColorBrightness��5�      $
��Left=�6<   $��238,314,0,0q�6W   $	��Top=�6l   $	��190��6�   $	) 255Q�6�   $
N 0.01Q�6�   $	* 255Q�6�   �� 5�      $
��Left=�6    $��7��6;   $��
32,130,0,0q�6F   $	��Top=�6Z   $	��383��6r   #���  6~   �� 5�      -Q   5        Q ��Name$Q linkColorsLine1��5�       $
��Left=�69   $��5��6T   $��162,151,0,0q�6_   $	��Top=�6t   $��48��6�     DisabledColor#���  6�   ��6�   Z� ��6�   Z� 6�   �� 5�      -R   5        $Q linkColorsLine2��5�       $
��Left=�69   $��5��6T   $��230,151,0,0q�6_   $	��Top=�6t   $��48��6�   #���  6�   ��6�   Z� ��6�   Z� 6�   � 5�      -S   5        $ 
LinkColors��5�      $
��Left=�6/   $��30��6J   $��197,138,0,0q�6V   $	��Top=�6k   $��45��6�   ���	#00616191$
 Hand��6�   .+�5�      (� $��	12,5,11,5q�6"   .��5�      �� $��24��6%   $��24��60   .+�5�   "   F� -T   5        R F�Name$R linkPath��5�   '   #���  69   �����`�;  � �`�; P� �P �͇ ��j �͇ ��ا �͇ ��ا ��j ���j ��j ׀�  �  @KL @KL ���j @f @KL @KL ��ا @f��ا `h� ���j `h� ��P `h� `�; �2� `�;  � � z @]� � $� @]� � $� �ا � z �ا � z @]� �@f��j �@]� ��j �@]� �͇ �@f�͇ ��}�͇ ��2P� ��2 � Ӡ�2�2� �}`h� @f`h� �@]� `h� �@]� @f�@f@f׀�O �  @KL @KL �@f��j  @KL @KL 	$
��10.2��6U  $
 Fill=�6c  $
��20.4��6r  
S �� Top$	S 7.8��6  T �� Left$	T 2.4��6�  5�      5�      5�      5�      5�      �� 5�      $	��SUN��6   $��2,0,-2,0q�6#   $��15(�65   .��5�      � -U   5        $ sunGrid��5�      #���  6(   .+�5�      �� -V   5        $F rmvFlare��5�      $��Remove Sun Flare��61   $
��Left=�6L   $��
99,244,0,0q�6g   $	��Top=�6{   6�      bo1tool.Dial  5�      -W   5        U  Name$U sunDirX��5�   !      bo1tool.DialV   ValueChanged$V sunDir_ValueChanged��6�   $
��Left=�62   $��80��6M   $��284,156,0,0q�6Y   $	��Top=�6n   $��80��6�   
W   Min$
W -360Q�6�   
X   Max$	X 360Q�6�     5�      -X   5        $ sunColorWheel��5�   2   $
��Left=�6�   $	��173��6�   $��	12,11,0,0q�6�   $	��Top=�6�   $	��176��6   6I   �� *	Palette+ �� *FindAncestor+"  	 6  �� 5�      -Y   5        $( r_lightTweakSunLight��5�      $
��Left=�6;   $��
12,189,0,0q�6V   $	��Top=�6j   $	��176��6�   $��24��6�   $ 0.5,0.5&�6�   $	) 255Q�6�   $* 32Q�6�   6�   �� 5�      $��Sky temperature��6   $
��Left=�66   $��
209,17,0,0q�6Q   $	��Top=�6e   $��17(�6}   �� 5�      -Z   5        $��1��5�      $
��Left=�62   $��23��6M   $��
318,15,0,0q�6Y   $
$ Wrap=�6m   $	��Top=�6  $��72��65  #���  6W  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� $% r_skyColorTemp��$& Value���6@  Z� 6�  �� 5�      -[   5        $( r_skyColorTemp��5�      $��207,43,10,0q�65   $	��Top=�6J   $
* 6500Q�6b   $) 25000Q�6o   6   �� 5�      $��Sky brightness��6   $
��Left=�65   $��
209,75,0,0q�6P   $	��Top=�6d   $��17(�6|   �� 5�      -\   5        $��1��5�      $
��Left=�62   $��22��6M   $��
318,73,0,0q�6Y   $
$ Wrap=�6m   $	��Top=�6&  $��72��6>  #���  6`  $��17(�6�  $��Center=�6�  #��� 	 6�  ��6�   �� $% r_sky_intensity_factor0��$& Value���6I  Z� 6�  �� 5�      -]   5        $( r_sky_intensity_factor0��5�      $��207,100,10,0q�6>   $	��Top=�6T   $) 32Q�6l   $* 1Q�6y   6�     5�      -^   5        $U sunDirY��5�   !   $V sunDir_ValueChanged��6�   $
��Left=�62   $��80��6M   $��414,156,0,0q�6Y   $	��Top=�6n   $��80��6�   $
W -360Q�6�   $	X 360Q�6�   �� 5�      -_   5        $��1��5�      $
��Left=�62   $��23��6M   $��
79,214,0,0q�6Y   $
$ Wrap=�6m   $	��Top=�6#  $��44��6;  $��Center=�6F  $��17(�6j  #��� 	 6�  ��6�   �� $% r_lightTweakSunLight��$& Value���6x  Z� 6�  �� 5�      -`   5        $F r_skyTransition��5�      $��
Transition��68   $
��Left=�6M   $��
10,245,0,0q�6h   $	��Top=�6|   6�   �� 5�      $��
Sun Pitch:��6   $
��Left=�61   $��284,130,0,0q�6L   $	��Top=�6a   $��17(�6y   �� 5�      $��Sun Yaw:��6   $
��Left=�6/   $��414,130,0,0q�6J   $	��Top=�6_   $��17(�6w   �� 5�      -a   5        $��1��5�      $
��Left=�62   $��23��6M   $��300,241,0,0q�6Y   $
$ Wrap=�6n   $	��Top=�6  $��48��6/  $��Center=�6:  $��17(�6^  #��� 	 6�  ��6�   �� $% sunDirX��$& Value���6l  Z� 6�  �� 5�      -b   5        $��1��5�      $
��Left=�62   $��23��6M   $��430,241,0,0q�6Y   $
$ Wrap=�6n   $	��Top=�6  $��48��6/  $��Center=�6:  $��17(�6^  #��� 	 6�  ��6�   �� $% sunDirY��$& Value���6l  Z� 6�  �� 5�      -c   5        $ 	sun_ToCfg��5�      $��
Add to CFG��60   $��10,273,10,0q�6E   $	��Top=�6Z   $��30��6r   #���  6~   6�   �� 5�      -d   5        $ resetSun��5�      $��Reset to default��6/   $��10,308,10,0q�6J   $	��Top=�6_   $��30��6w   #���  6�   #���  6�   6�   5�      5�      �� 5�      $	��DOF��6   $��2,0,-2,0q�6#   $��15(�65   .��5�      � #���  6   .+�5�      �� $��
DOF Enable��6   $
��Left=�61   $��	10,17,0,0q�6L   $	��Top=�6_   $��17(�6w     5�      -e   5        $> 	dofToggle��5�   ,   $��ToggleSwitch��6?   $
��Left=�6V   $��
102,17,0,0q�6q   $	��Top=�6�   $
? User=�6�   ���	#FF5F5F5F#@ �  6�   A �	#FF5F5F5F���	#FFB88259B �	#FF191919$��20��6Z  $C 2q�6f  $��45��6  $��45��6�  $��20��6�  $��16(�6�  $D 15��6�  ��6�   Z� 6�  � 5�      -f   5        $ dofGrid��5�      $	��388��6,   $��0,42,0,0q�69   $	��Top=�6K   {�6c   �� $% 	dofToggle��$& 	IsChecked�.+�5�      �� $��DOF Far Blur��6    $
��Left=�67   $��	10,12,0,0q�6R   $	��Top=�6e   $��17(�6}   �� 5�      -g   5        $K r_dof_farBlurTextBox��5�   "   $��1��6@   $
��Left=�6T   $��23��6o   $��	94,10,0,0q�6{   $
$ Wrap=�6�   $	��Top=�6�  $��53��6�  $��17(�6�  #���  6�  
������ ��6�   �� *Value+$% r_dof_farBlur��$' TwoWay=�$P {0:N2}��$E PropertyChanged=�6�  �� 5�      -h   5        $( r_dof_farBlur��5�   !   $��152,11,10,0q�68   $	��Top=�6M   $) 10Q�6e   $	* 1.8Q�6r   6~   �� 5�      $��DOF Far Start��6    $
��Left=�68   $��	10,47,0,0q�6S   $	��Top=�6f   $��17(�6~   �� 5�      -i   5        $��1��5�   "   $
��Left=�66   $��23��6Q   $��	94,45,0,0q�6]   $
$ Wrap=�6p   $	��Top=�6A  $��53��6Y  $��17(�6d  ��6�   �� *Value+$% r_dof_farStart��$' TwoWay=�$P {0:N2}��$E PropertyChanged=���6r  Z� �� 5      -j   5        $( r_dof_farStart��5   !   $��152,46,10,0q�69   $	��Top=�6N   $
) 7000Q�6f   $
* 1000Q�6u   $O -1000Q�6�   6�   �� 5     $��DOF Far End��6    $
��Left=�66   $��	10,82,0,0q�6Q   $	��Top=�6d   $��17(�6|   �� 5     -k   5        $��1��5  "   $
��Left=�66   $��23��6Q   $��	94,80,0,0q�6]   $
$ Wrap=�6p   $	��Top=�6>  $��53��6V  $��17(�6a  #���  6o  
������ ��6�   �� *Value+$% r_dof_farEnd��$E PropertyChanged=�6�  �� 5     -l   5        $( r_dof_farEnd��5  !   $��152,81,10,0q�67   $	��Top=�6L   $
) 7000Q�6d   $
* 7000Q�6s   $O -1000Q�6�   �� 5     $��DOF Near Blur��6    $
��Left=�68   $��
10,120,0,0q�6S   $	��Top=�6g   $��17(�6   �� 5     -m   5        $��1��5  "   $
��Left=�66   $��23��6Q   $��110,118,0,0q�6]   $
$ Wrap=�6r   $	��Top=�6Y  $��47��6q  $��17(�6|  #���  6�  
������ ��6�   �� *Value+$% r_dof_nearBlur��$P {0:N2}��$E PropertyChanged=�6�  �� 5     -n   5        $( r_dof_nearBlur��5  !   $��162,119,10,0q�69   $	��Top=�6O   $) 10Q�6g   $* 4Q�6t   6~   �� 5     $��DOF Near Start��6    $
��Left=�69   $��
10,155,0,0q�6T   $	��Top=�6h   $��17(�6�   �� 5     -o   5        $��1��5  "   $
��Left=�66   $��23��6Q   $��110,153,0,0q�6]   $
$ Wrap=�6r   $	��Top=�6Z  $��47��6r  $��17(�6}  #���  6�  
������ ��6�   �� *Value+$% r_dof_nearStart��$P {0:N2}��$E PropertyChanged=�6�  �� 5	     -p   5        $( r_dof_nearStart��5	  !   $��162,154,10,0q�6:   $	��Top=�6P   $
) 1000Q�6h   $* 10Q�6w   $
O -500Q�6�   �� 5
     $��DOF Near End��6    $
��Left=�67   $��
10,190,0,0q�6R   $	��Top=�6f   $��17(�6~   �� 5     -q   5        $��1��5  "   $
��Left=�66   $��23��6Q   $��110,188,0,0q�6]   $
$ Wrap=�6r   $	��Top=�6X  $��47��6p  $��17(�6{  #���  6�  
������ ��6�   �� *Value+$% r_dof_nearEnd��$P {0:N2}��$E PropertyChanged=�6�  �� 5     -r   5        $( r_dof_nearEnd��5  !   $��162,189,10,0q�68   $	��Top=�6N   $
) 1000Q�6f   $* 60Q�6u   $
O -500Q�6�   �� 5     $
��Left=�6$   $��7��6?   $��	9,108,0,0q�6J   $	��Top=�6]   $	��383��6u   #���  6�   �� 5     $��DOF ViewModel Start��6    $
��Left=�6>   $��
10,231,0,0q�6Y   $	��Top=�6m   $��17(�6�   �� 5     -s   5        $��1��5  "   $
��Left=�66   $��23��6Q   $��145,229,0,0q�6]   $
$ Wrap=�6r   $	��Top=�6_  $��47��6w  $��17(�6�  #���  6�  
������ ��6�   �� *Value+$% r_dof_viewModelStart��$P {0:N2}��$E PropertyChanged=�6�  �� 5     -t   5        $( r_dof_viewModelStart��5  !   $��196,230,10,0q�6?   $	��Top=�6U   $	) 128Q�6m   $* 2Q�6{   6�   �� 5     $��DOF ViewModel End��6    $
��Left=�6<   $��
10,266,0,0q�6W   $	��Top=�6k   $��17(�6�   �� 5     -u   5        $��1��5  "   $
��Left=�66   $��23��6Q   $��145,264,0,0q�6]   $
$ Wrap=�6r   $	��Top=�6]  $��47��6u  $��17(�6�  #���  6�  
������ ��6�   �� *Value+$% r_dof_viewModelEnd��$P {0:N2}��$E PropertyChanged=�6�  �� 5     -v   5        $( r_dof_viewModelEnd��5  !   $��196,265,10,0q�6=   $	��Top=�6S   $	) 128Q�6k   $* 10Q�6y   6�   �� 5     $
��Left=�6$   $��7��6?   $��
10,217,0,0q�6J   $	��Top=�6^   $	��383��6v   #���  6�   �� 5     $��DOF Bias��6    $
��Left=�63   $��
10,306,0,0q�6N   $	��Top=�6b   $��17(�6z   �� 5     -w   5        $��1��5  "   $
��Left=�66   $��23��6Q   $��110,304,0,0q�6]   $
$ Wrap=�6r   $	��Top=�6U  $��47��6m  $��17(�6x  #���  6�  
������ ��6�   �� *Value+$% 
r_dof_bias��$P {0:N2}��$E PropertyChanged=�6�  �� 5     -x   5        $( 
r_dof_bias��5  !   $��162,305,10,0q�65   $	��Top=�6K   $) 3Q�6c   $	* 0.5Q�6o   $	O 0.1Q�6{   6�   �� 5     -y   5        $ resetDof��5  !   $��Reset to default��63   $��13,354,206,0q�6N   $	��Top=�6d   $��30��6|   #���  6�   $��Center=�6�   $	��189��6�   #���  6   �� 5     -z   5        $ 	dof_ToCfg��5  !   $��
Add to CFG��64   $��209,354,11,0q�6I   $	��Top=�6_   $��30��6w   #���  6�   $��Center=�6�   $	��188��6�   #���  6�   5     5     5     �� 5     $��WEAPON��6   $��2,0,-2,0q�6&   $��15(�68   .��5     � #���  6   5     5      �� 5!  
   -{   5        Y ��Name$Y 	Indicator��5!     #���  6'   $
��Left=�6M   $��3��6h   $��	17,28,0,0q�6s   $	��Top=�6�   $��20��6�   $	 1.5��6�   $ 2��6�   5#     5$     