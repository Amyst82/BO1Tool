   M S B A M L   `   `   `  ���� B  >bo1tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:bo1toolbo1tool  p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls �_clr-namespace:System.Windows.Controls.Primitives;assembly=System.Windows.Controls.Input.Toolkit"System.Windows.Controls.Primitives C ?WPFSpark, Version=1.4.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:WPFSpark;assembly=WPFSparkWPFSpark S OColorWheel.Controls, Version=1.7.14.51712, Culture=neutral, PublicKeyToken=nullV>clr-namespace:ColorWheel.Controls;assembly=ColorWheel.ControlsColorWheel.Controls 7 clr-namespace:bo1tool.Convertersbo1tool.Converters      bo1tool.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:bo1tool     :xctk)http://schemas.xceed.com/wpf/xaml/toolkit     j	Controls2Tclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit     @Custom-http://schemas.microsoft.com/wpf/2008/toolkit     v
Primitives_clr-namespace:System.Windows.Controls.Primitives;assembly=System.Windows.Controls.Input.Toolkit     =WPFSpark(clr-namespace:WPFSpark;assembly=WPFSpark     SControls>clr-namespace:ColorWheel.Controls;assembly=ColorWheel.Controls     7
converters clr-namespace:bo1tool.Converters     -     �Name$  bo1tool�� � Title$ BO1 Tool��$	��411��$	��635��   WindowStyle#���    � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�$8��2/bo1tool;component/Resources/#ConduitITCStd Medium)�  DefaultBackground#���  $	��416��$	��305�� � 
ResizeMode$ 	CanResize=� � 	Resources  �� MergedDictionaries �� Source4   .bo1tool.Converters.BoolToOppositeBoolConverter  oppositeConverter&    bo1tool.Converters.MathConverter  mathConverter'  !bo1tool.Converters.ColorConverter  colorConvert��  �� $ 
Style.xaml?�%-   &	       &	      &	 
           '  !System.Windows.Shell.WindowChrome   WindowChrome   	   CaptionHeight$	 0Q�
   ResizeBorderThickness$
 3q�   UseAeroCaptionButtons . .��� -    �Name$ mainGrid��#���  $��0,5,0,2q�.+��� -    ��Name$ closeButton��$	��✕��$��	0,-24,0,0q�$	��Top=�
���   �$��24�����	#FF838383$��Right=�$��24����Z� �� -   $ 	minButton��$	��—��$��
0,-24,26,0q�$	��Top=�
���   �$��24�����	#FF707071$��Right=�$��24����Z� �� -    ��Name$ AllPages��$��14(� �� SelectedIndex$ 0��$ �� IsSynchronizedWithCurrentItem$
 TrueY����	#FF0E0F1A$��0,2,0,0q�.@��� -    ��Name$ tabItem1��$	��CFG��$��2,0,-2,0q�$��0��$��15(�.��� #���  $��	0,0,-3,-5q�.+�   bo1tool.aTextBox  -     Name$ 	singleCfg��   bo1tool.aTextBox   MouseDoubleClick$ TextBox_MouseDoubleClick��   TextChanged$ singleCfg_TextChanged��   KeyUp$ singleCfg_KeyUp��$��1��$��30��$��10,10,100,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��16(�  DefaultHighlightColor#���  
 � Tag$ Single command��$��Segoe UI Semilight)� �� 
CaretBrush# �     HintText$ Single command��   FocusedBrush# �     ShowClearButton . .�� � ContextMenu �� #���  $8��2/bo1tool;component/Resources/#ConduitITCStd Medium)� �� HasDropShadow . $	��120��.@�m� -   $��
To CFG box��$��17(�$	��120��$��30��m� -	   $��Copy All��$��17(�$	��120��$��30��m� -
   $��Copy selection��$��17(�$	��120��$��30��m� -   $��Paste��$��17(�$	��120��$��30��m� -   $��Clear��$��17(�$	��120��$��30��.���� -   $ 
sendSingle��$
��Send��$��	0,10,10,0q�$	��Top=�$��30��  DefaultColor#���    DefaultBackgroundOpacity#���  $
��Left=�$	��Top=�$��13(�$��Right=�$��85��  -   $ 	tScaleBox��$ TextBox_MouseDoubleClick��$ TextBox_KeyUp��$ TextBox_TextChanged��$��1��$��30��$��10,47,100,0q�$
 Wrap=�$	��Top=�$��16(�#���  $  ��$��Segoe UI Semilight)� � ToolTip$ 	timescale��$ 	timescale�� .  �� *ContextMenu+ �� ElementName$ 	singleCfg���� -   $ 
sendTscale��$
��Send��$��	0,47,10,0q�$	��Top=�$��30��#���  #���  $
��Left=�$	��Top=�$��13(�$��Right=�$��85��   bo1tool.linkButton  -      Name$  loadCfg��   bo1tool.linkButton!   Click$! loadCfg_Click��$��Load CFG��$��
11,0,268,7q�#���  #���  $��13(�$��30��$��Bottom=�$��Center=�$	��124��" � Cursor$
" Hand��  -   $  sendCfg��$! sendCfg_Click��$��Send CFG��$��140,0,140,7q�#���  #���  $��13(�$��30��$��Bottom=�$��Center=�$	��123��$
" Hand��  -   $  saveCfg��$! saveCfg_Click��$��Save CFG��$��
269,0,10,7q�#���  #���  $��13(�$��30��$��Bottom=�$��Center=�$	��124��$
" Hand���� -   # ��Name$# cfgBox��$��10,82,10,42q�$��16(�"$ �� VerticalScrollBarVisibility$
$ Auto=�#���  $��Segoe UI Semilight)�#���  $  �����	#FF303355 % �� 
TargetType& �� Property' �� Value��%3   'J�       �� "% J�.��� & �@��Margin$' 0q� �� #���  $8��2/bo1tool;component/Resources/#ConduitITCStd Medium)� . $	��120��.@�m� -   $��Copy All��$��17(�$	��120��$��30��m� -   $��Copy selection��$��17(�$	��120��$��30��m� -   $��Paste��$��17(�$	��120��$��30��m� -   $��Clear��$��17(�$	��120��$��30��. �/� .T�J� .*�.*��� $� ���� $��THEATRE��$��2,0,-2,0q�$��15(�.��� ���	#FF0E0F1A.+��� -   ( ��Name$( depthB��$��1��$
��Left=�$��25��$��132,177,0,0q�$
 Wrap=�$	��Top=�$��50��$��16(�
������ $��Center=�$��-5,0,0,0q�#���  ���� *Value+$ slider1��) �� StringFormat$) {0:N2}��* �� UpdateSourceTrigger$* PropertyChanged=� �� *ContextMenu+$ 	singleCfg���� -   + ��Name$+ slider1��$
��Left=�$��	7,199,0,0q�$	��Top=�$	��391��, � Value$, 50Q����	#FFD7D9EA#���  �� $��
Go to time��$
��Left=�$��	10,47,0,0q�$	��Top=�$	��190��$��25��#���  #���  � $
��Left=�$��10��$��	62,24,0,0q�$	��Top=�$	��336���� $
��Save��$
��Left=�$��
207,47,0,0q�$	��Top=�$	��191��$��25��#���  #���  �� $��00:00��$
��Left=�$��	10,19,0,0q�$	��Top=�$��17(�#���  �� $
��Left=�$��7��$��	10,77,0,0q�$	��Top=�$	��388��#���  �� $��Green Screen��$
��Left=�$��	10,97,0,0q�$	��Top=�$��17(�	  WPFSpark.ToggleSwitch	  -   - 	 Name$- gsToggle��$��ToggleSwitch��$
��Left=�$��
112,97,0,0q�$	��Top=�. 	  
AccentMode$
. User=����	#FF5F5F5F/ 	  AccentBrush#/ �  0 	  ThumbBackground0 �	#FF5F5F5F���	#FFB882591 	  ThumbAccentBrush1 �	#FF191919$��20��2 	  ThumbBorderThickness$2 2q�$��45��$��45��$��20��$��16(�3 	  CornerRadius$3 15����Z� �� $
��Left=�$��7��$��
10,130,0,0q�$	��Top=�$	��388��#���  �� $��Depth��$
��Left=�$��
10,147,0,0q�$	��Top=�$��17(�	  -   $- depthToggle��$��ToggleSwitch��$
��Left=�$��112,147,0,0q�$	��Top=�$
. User=����	#FF5F5F5F#/ �  0 �	#FF5F5F5F���	#FFB882591 �	#FF191919$��20��$2 2q�$��45��$��45��$��20��$��16(�$3 15����Z� �� $��Depth Bightness:��$
��Left=�$��
10,179,0,0q�$	��Top=�$��17(��� -   $��1��$
��Left=�$��25��$��132,230,0,0q�$
 Wrap=�$	��Top=�$��50��$��16(�
������ $��Center=�$��-5,0,0,0q�#���  ���� *Value+$ slider1��$) {0:N2}��$* PropertyChanged=� �� *ContextMenu+$ 	singleCfg���� -   $+ slider1_Copy��$
��Left=�$��	7,252,0,0q�$	��Top=�$	��391��$, 50Q����	#FFF3DCDC�� $��Depth Distance:��$
��Left=�$��
10,232,0,0q�$	��Top=�$��17(��� $
��Left=�$��7��$��
10,282,0,0q�$	��Top=�$	��388��#���  �� $��Normal Pass��$
��Left=�$��
10,298,0,0q�$	��Top=�$��17(��� $
��Left=�$��8��$��
11,327,0,0q�$	��Top=�$	��388��#���  �� -   4 ��Name$4 
cg_drawGun��$��
Remove Gun��$
��Left=�$��
11,351,0,0q�$	��Top=��� -   $4 r_dobjlimit��$��Remove Players��$
��Left=�$��132,351,0,0q�$	��Top=��� -    $4 r_bloomTweaks��$��Bloom Tweaks��$
��Left=�$��293,377,0,0q�$	��Top=��� $��	Green Sky��$
��Left=�$��293,351,0,0q�$	��Top=��� -!   $4 
rmvBarrier��$��Remove Theatre Barrier��$
��Left=�$��132,377,0,0q�$	��Top=��� -"   $4 fx_draw��$��	Remove FX��$
��Left=�$��
11,377,0,0q�$	��Top=�	� -#   $
��None��$
��Left=�$��109,300,0,0q�$	��Top=�#���  #���  5 d� 	IsChecked$
5 TrueY�$ 0��	� -$   $��Normal��$
��Left=�$��173,300,0,0q�$	��Top=�#���  $ 1��#���  	� -%   $��Tangent��$
��Left=�$��244,300,0,0q�$	��Top=�#���  $ 2��#���  	� -&   $��Binormal��$
��Left=�$��316,300,0,0q�$	��Top=�#���  $ 3��#���  9� -'   6 9�Name$6 	gsColorEx��$��      Clear Color��$��
166,90,0,0q�#���  $
��Left=�$	��Top=�  Expander#���  $
��Left=�$	��Top=�$	��234��$��27��$	��265��$	��234��$	��234��$��30��.��� ���� *ActualHeight+$ 	gsColorEx������ *ActualWidth+$ 	gsColorEx��.+���  	 BackgroundOpaque#��� 	 $
��Left=�$	��228��$��	10,10,0,0q�$	��Top=�$	��213��7 �� RadiusY$
7 19.5��8 �� RadiusX$
8 19.5��9 J� Effect9 3
  -System.Windows.Media.Effects.DropShadowEffect
  : 
  
BlurRadius$: 25Q�; 
  ShadowDepth$; 0Q�< 
  RenderingBias$< Quality=�= 
  Opacity$	= 0.5Q�+  %ColorWheel.Controls.ColorWheelControl  -(   >  Name$> gsColorWheel��$
��Left=�$	��130��$��	20,48,0,0q�$	��Top=�$	��130��?   Palette? �� *	Palette+@ �� RelativeSource@ �� *FindAncestor+A �� AncestorType   bo1tool.MainWindow"A  �� -)   $ cancelClearColor��$��Cancel��$
��Left=�$��
20,193,0,0q�$	��Top=�$��95��$��25��#���  #���  �� -*   $ okClearColor��$��Ok��$
��Left=�$��120,193,0,0q�$	��Top=�$��95��$��25��#���  �� -+   $( gsR_textBox��$��1��$
��Left=�$��26��$��
155,70,0,0q�$
 Wrap=�$	��Top=�$��60��
������ $��16(� 
 DefaultAccentColor# � 
 ��Z� ���� *Palette.Colors[0].R+B �� 	Converter#B [ $ gsColorWheel���� -,   $( gsG_textBox��$��1��$
��Left=�$��25��$��155,102,0,0q�$
 Wrap=�$	��Top=�$��60��
������ $��16(�# � 
 ��Z� ���� *Palette.Colors[0].G+#B [ $ gsColorWheel���� --   $( gsB_textBox��$��1��$
��Left=�$��26��$��155,133,0,0q�$
 Wrap=�$	��Top=�$��60��
������ $��16(�# � 
 ��Z� ���� *Palette.Colors[0].B+#B [ $ gsColorWheel��	� -.   C 	�Name$	C gsR��$�� ��$
��Left=�$��	75,18,0,0q�$	��Top=�
���  �����	#33FF0000	� -/   $	C gsG��$�� ��$
��Left=�$��	98,18,0,0q�$	��Top=�
��� � ����	#3300FF00$
5 TrueY�	� -0   $	C gsB��$�� ��$
��Left=�$��
121,18,0,0q�$	��Top=�
����  ����	#330000FF	� -1   $	C gsP��$�� ��$
��Left=�$��
144,18,0,0q�$	��Top=�
���� �����	#33FF00FF�� $	��FOG��$��2,0,-2,0q�$��15(�.��� ���	#FF0E0F1A.+��� $��1��$
��Left=�$��23��$��
27,202,0,0q�$
 Wrap=�$	��Top=�$��55������ $ slider2��D �� Path$D Value�$) {0:N2}���� -2   $+ slider2��$
��Left=�$��
97,202,0,0q�$	��Top=�$	��285���� $	��SUN��$��2,0,-2,0q�$��15(�.��� #���  .+��� -3   $4 rmvFlare��$��Remove Sun Flare��$
��Left=�$��
99,244,0,0q�$	��Top=�   bo1tool.Dial  $
��Left=�$��80��$��284,156,0,0q�$	��Top=�$��80��  -4   $> sunColorWheel��$
��Left=�$	��173��$��	12,11,0,0q�$	��Top=�$	��176��? �� *	Palette+@ �� *FindAncestor+"A  �� -5   $+ r_lightTweakSunLight��$
��Left=�$��
12,189,0,0q�$	��Top=�$	��176��$��24��E J� RenderTransformOrigin$E 0.5,0.5&�F � Maximum$	F 255Q�$, 32Q��� $��Sky temperature��$
��Left=�$��
209,17,0,0q�$	��Top=�$��17(��� -6   $��1��$
��Left=�$��23��$��
318,15,0,0q�$
 Wrap=�$	��Top=�$��72��#���  $��17(�$��Center=�#���  ���� $ r_skyColorTemp��$D Value���Z� �� -7   $+ r_skyColorTemp��$��207,43,10,0q�$	��Top=�$
, 6500Q�$F 25000Q��� $��Sky brightness��$
��Left=�$��
209,75,0,0q�$	��Top=�$��17(��� -8   $��1��$
��Left=�$��22��$��
318,73,0,0q�$
 Wrap=�$	��Top=�$��72��#���  $��17(�$��Center=�#���  ���� $ r_sky_intensity_factor0��$D Value���Z� �� -9   $+ r_sky_intensity_factor0��$��207,100,10,0q�$	��Top=�$F 32Q�$, 1Q�  $
��Left=�$��80��$��414,156,0,0q�$	��Top=�$��80���� -:   $��1��$
��Left=�$��23��$��
79,214,0,0q�$
 Wrap=�$	��Top=�$��44��$��Center=�$��17(�#���  ���� $ r_lightTweakSunLight��$D Value���Z� �� -;   $4 r_skyTransition��$��
Transition��$
��Left=�$��
10,245,0,0q�$	��Top=��� $��
Sun Pitch:��$
��Left=�$��284,130,0,0q�$	��Top=�$��17(��� $��Sun Yaw:��$
��Left=�$��414,130,0,0q�$	��Top=�$��17(��� -<   $��1��$
��Left=�$��23��$��300,241,0,0q�$
 Wrap=�$	��255��$	��Top=�$��48��$��Center=�$��17(�#���  ��Z� �� -=   $��1��$
��Left=�$��23��$��430,241,0,0q�$
 Wrap=�$	��255��$	��Top=�$��48��$��Center=�$��17(�#���  ��Z� �� $��
Add to CFG��$��10,273,10,0q�$	��Top=�$��30��#���  �� $��Reset to default��$��10,308,10,0q�$	��Top=�$��30��#���  #���  �� $	��DOF��$��2,0,-2,0q�$��15(�.��� #���  .+��� $��
DOF Enable��$
��Left=�$��	10,17,0,0q�$	��Top=�$��17(�	  ->   $- 	dofToggle��$��ToggleSwitch��$
��Left=�$��
102,17,0,0q�$	��Top=�$
. User=����	#FF5F5F5F#/ �  0 �	#FF5F5F5F���	#FFB882591 �	#FF191919$��20��$2 2q�$��45��$��45��$��20��$��16(�$3 15����Z� � -?   $ dofGrid��$	��388��$��0,42,0,0q�$	��Top=�{��� $ 	dofToggle��$D 	IsChecked�.+��� $��DOF Far Blur��$
��Left=�$��	10,12,0,0q�$	��Top=�$��17(��� -@   $��1��$
��Left=�$��23��$��	94,10,0,0q�$
 Wrap=�$	��Top=�$��53��$��17(�#���  
������ ���� *Value+$ r_dof_farBlur��$) {0:N2}��$* PropertyChanged=��� -A   $+ r_dof_farBlur��$��152,11,10,0q�$	��Top=�$F 10Q�$	, 1.8Q��� $��DOF Far Start��$
��Left=�$��	10,47,0,0q�$	��Top=�$��17(��� -B   $��1��$
��Left=�$��23��$��	94,45,0,0q�$
 Wrap=�$	��Top=�$��53��$��17(�#���  
������ ���� *Value+$ r_dof_farStart��$* PropertyChanged=��� -C   $+ r_dof_farStart��$��152,46,10,0q�$	��Top=�$
F 7000Q�$
, 1000Q�G � Minimum$G -1000Q��� $��DOF Far End��$
��Left=�$��	10,82,0,0q�$	��Top=�$��17(��� -D   $��1��$
��Left=�$��23��$��	94,80,0,0q�$
 Wrap=�$	��Top=�$��53��$��17(�#���  
������ ���� *Value+$ r_dof_farEnd��$* PropertyChanged=��� -E   $+ r_dof_farEnd��$��152,81,10,0q�$	��Top=�$
F 7000Q�$
, 7000Q�$G -1000Q��� $��DOF Near Blur��$
��Left=�$��
10,120,0,0q�$	��Top=�$��17(��� -F   $��1��$
��Left=�$��23��$��110,118,0,0q�$
 Wrap=�$	��Top=�$��47��$��17(�#���  
������ ���� *Value+$ r_dof_nearBlur��$) {0:N2}��$* PropertyChanged=��� -G   $+ r_dof_nearBlur��$��162,119,10,0q�$	��Top=�$F 10Q�$, 4Q��� $��DOF Near Start��$
��Left=�$��
10,155,0,0q�$	��Top=�$��17(��� -H   $��1��$
��Left=�$��23��$��110,153,0,0q�$
 Wrap=�$	��Top=�$��47��$��17(�#���  
������ ���� *Value+$ r_dof_nearStart��$) {0:N2}��$* PropertyChanged=��� -I   $+ r_dof_nearStart��$��162,154,10,0q�$	��Top=�$
F 1000Q�$, 10Q�$
G -500Q��� $��DOF Near End��$
��Left=�$��
10,190,0,0q�$	��Top=�$��17(��� -J   $��1��$
��Left=�$��23��$��110,188,0,0q�$
 Wrap=�$	��Top=�$��47��$��17(�#���  
������ ���� *Value+$ r_dof_nearEnd��$) {0:N2}��$* PropertyChanged=��� -K   $+ r_dof_nearEnd��$��162,189,10,0q�$	��Top=�$
F 1000Q�$, 60Q�$
G -500Q��� $
��Left=�$��7��$��	9,108,0,0q�$	��Top=�$	��383��#���  �� $��DOF ViewModel Start��$
��Left=�$��
10,231,0,0q�$	��Top=�$��17(��� -L   $��1��$
��Left=�$��23��$��145,229,0,0q�$
 Wrap=�$	��Top=�$��47��$��17(�#���  
������ ���� *Value+$ r_dof_viewModelStart��$) {0:N2}��$* PropertyChanged=��� -M   $+ r_dof_viewModelStart��$��196,230,10,0q�$	��Top=�$	F 128Q�$, 2Q��� $��DOF ViewModel End��$
��Left=�$��
10,266,0,0q�$	��Top=�$��17(��� -N   $��1��$
��Left=�$��23��$��145,264,0,0q�$
 Wrap=�$	��Top=�$��47��$��17(�#���  
������ ���� *Value+$ r_dof_viewModelEnd��$) {0:N2}��$* PropertyChanged=��� -O   $+ r_dof_viewModelEnd��$��196,265,10,0q�$	��Top=�$	F 128Q�$, 10Q��� $
��Left=�$��7��$��
10,217,0,0q�$	��Top=�$	��383��#���  �� $��DOF Bias��$
��Left=�$��
10,306,0,0q�$	��Top=�$��17(��� -P   $��1��$
��Left=�$��23��$��110,304,0,0q�$
 Wrap=�$	��Top=�$��47��$��17(�#���  
������ ���� *Value+$ 
r_dof_bias��$) {0:N2}��$* PropertyChanged=��� -Q   $+ 
r_dof_bias��$��162,305,10,0q�$	��Top=�$F 3Q�$	, 0.5Q�$	G 0.1Q��� -R   $ loadDof��$��Load preset��$��4,354,270,0q�$	��Top=�$��30��#���  $��Center=�$	��126���� -S   $ saveDof��$��Save preset��$��135,354,138,0q�$	��Top=�$��30��#���  $��Center=�$	��127���� -T   $ 	dof_ToCfg��$��
Add to CFG��$��267,354,7,0q�$	��Top=�$��30��#���  $��Center=�$	��126��  -U   $  resetDof��$! resetDof_Click��$��Reset to default��$
��Left=�$��
158,15,0,0q�$	��Top=�$	��232��$��25��
������ $
" Hand���� $��WEAPON��$��2,0,-2,0q�$��15(�.��� #���  �� -V   H ��Name$H 	Indicator��#���  $
��Left=�$��3��$��	17,28,0,0q�$	��Top=�$��20��$	7 1.5��$8 2��