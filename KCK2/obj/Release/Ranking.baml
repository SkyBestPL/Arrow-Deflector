   M S B A M L   `   `   `  ���� ?  ;KCK2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KCK2KCK2      KCK2.Ranking   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $localclr-namespace:KCK2       N� Title$  Ranking�� � 	Resources    RankingListBoxStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� 
ResourceId �� TypeInTargetAssembly	 J� SnapsToDevicePixels  RankingListBoxItemStyle��%g  &	        &	 �     �� " ��.���  � ��
 ���� ��  � ��
 ���� ��  � ��$ 0q���  � �� �� " ��.R��� $��Border��#��z��#��z��#��z��$ 10��._��� $��0q�#��z����C� *�� $ ScrollViewerStyle��" �+.���� #	 z	 �� " ��.���  � ��
 ���� ��  � ��
 ���� ��  � �� �� " ��.R��� .��� .+��� $��Images/ranking-bg.png��$
��Fill=��� -   
 ��Name$
 RankingScreen��|�. 
������ .+��� $��Images/ranking.png��$
��Fill=� �� Left$	 240��
 �� Top$ 48��$��Center=�$	��Top=� J� RenderTransformOrigin$ 
0.51,0.693&��� -   $��	EasyLabel��$��Poziom Łatwy��$��24(�$
��Bold"����	#FF028600$ 72��$	 169��$
��Left=�$��Center=�$��Segoe Script)��� -   $��MediumLabel��$��Poziom Normalny��$��24(�$
��Bold"����	#FFB58A00$	 292��$	 169��$
��Left=�$��Center=�$��Segoe Script)��� -   $��	HardLabel��$��Poziom Trudny��$��24(�$
��Bold"����	#FFBB0000$	 542��$	 169��$
��Left=�$��Center=�$��Segoe Script)��� -   $��Powrot��$	 336��$	 683��$	��158��$��68��$
��Left=�$��Center=�$��Powrót��$��36(�$��MV Boli)�$
��Bold"����	#FF8F2121
������ 
������ $��0q����� " ��.���  � �� �� " ��.R��� #��z��#��z��#��z��$ 15��._��� $��Center=�$��Center=��� -    ��Name$ EasyRankingListBox��$��Center=�$	��Top=�$	��230��$	��475��$ 72��$	 222��#��[  #��[ 
���   �$��Ink Free)�$��20(�$
��Bold"����� .R��  � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��5q�����  �� Path$ Score��� $��5q�$��1������ $ 
PlayerName��� -   $ MediumRankingListBox��$��Center=�$	��Top=�$	��230��$	��475��$	 307��$	 222��#��[  #��[ 
���   �$��Ink Free)�$��20(�$
��Bold"����� .R��  �� $
��Auto ��� $��* �.+��� $��5q����� $ Score��� $��5q�$��1������ $ 
PlayerName��� -   $ HardRankingListBox��$��Center=�$	��Top=�$	��230��$	��475��$	 542��$	 222��#��[  #��[ 
���   �$��Ink Free)�$��20(�$
��Bold"����� .R��  �� $
��Auto ��� $��* �.+��� $��5q����� $ Score��� $��5q�$��1������ $ 
PlayerName�