   M S B A M L   `   `   `  ���� ?  ;KCK2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KCK2KCK2      	KCK2.Game   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $localclr-namespace:KCK2       N� Title$
  Game��.��� .+��� $��Images/bricks.png��$
��Fill=��� -    ��Name$ 
GameScreen��|�. 
������ .+��� -   $��bowLeft��$��Images/bow.png��$
��Fill=�
 �� Top$	 305��$��Center=�$	��Top=�$	��180��$	��100�� �� Left$	 -16���� -   $��bowTop��$��Images/bow.png��$
��Fill=�$	 -55��$
��Left=�$��Center=�$	��180��$	��100��$	 366�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ 91.61Q�T� �� -   $��bowRight��$��Images/bow.png��$
��Fill=�$	 299��$
��Left=�$��Center=�$	��180��$	��100��$	 733��$ 0.5,0.5&�z�V� .~��� �� �� $ 180.919Q�T� �� -   $��	bowBottom��$��Images/bow.png��$
��Fill=�$	 666��$��Center=�$	��Top=�$	��180��$	��100��$	 364��$ 0.5,0.5&�z�V� .~��� �� �� $ -88.792Q�T� �� -   $��Gracz��$	 365��$	 357�����	#FF0CFF00$	��100��$	��100��$
��Left=�$	��Top=��� -   $��	scoreText��$��Odbite strzały: 0��$��20(�$	 581��$ 91��$��Segoe UI Black)�$
��Bold"�$��42��$	��239��$
��Left=�$��Center=�
���   � J� OpacityMask
 �   ��� -   $��	speedText��$��Speed: 3��$��18(�$
��Bold"�
�������$ 9��$ 35���� -	   $��	limitText��$��	Limit: 30��$��18(�$
��Bold"�
�������$ 9��$ 63��$��Center=�$��Center=��� -
   $��timeText��$��Time: 0��$��18(�$
��Bold"�
�������$ 12��$ 91��$��Center=�$	��Top=��� -   $��Health��$	 581��$ 18��
���  ��$	��221��$��68��$
��Left=�$��Center=��� -   $��GameOver��$	 184��$ 62��
���  ��$	��442��$	��315��$
��Left=�$	��Top=��� -   $��Pauza��$D��>Włączono pauzę. Naciśnij klawisz Esc, aby ją wyłączyć.��$��20(�$	 142��$	 310��$��Segoe UI Black)�$
��Bold"�$��42��$	��546��$
��Left=�$	��Top=����	#FFFFA600
 �   � J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  �� -   $	��Tak��$	 200��$	 572��$	��100��$��68��$
��Left=�$��Center=�$	��Tak�����	#FF8BDAE8$��24(�$��Segoe UI Black)����	#FF8BDAE8   �� -   $	��Nie��$	 520��$	 572��$	��100��$��68��$	��Nie�����	#FF8BDAE8$��24(�$��Segoe UI Black)�$
��Left=�$��Center=����	#FF8BDAE8   �� -   $��tutorial��$	 215��$	 442��
���  ��$	��400��$	��300��$��Center=�$	��Top=��� -   $��deflect��$	 385��$	 377��
�������$��60��$��60��$
��Left=�$	��Top=��� -   $��question��$ ��Zapisać wynik w rankingu?��$��24(�$
��Bold"�
���   �$	 252��$	 505��$
��Left=�$	��Top=�$��Segoe UI Black)��� -   $��typeName��$��Podaj swoje imię:��$��24(�$
��Bold"�
���   �$	 305��$	 505��$
��Left=�$��Center=�$��Segoe UI Black)�$	��220���� -    ��Name$ ImieTextBox��$��30(�$	 313��$	 552��$	��200��$��40��$
��Left=�$��Center=����	#FF0041A7$��Impact)����	#FFFCFFB9.��   .���� -   $��	Zatwierdz��$	 334��$	 606��$	��158��$��68��$
��Left=�$��Center=�$��
Zatwierdź�����	#FF8BDAE8$��24(�$��Segoe UI Black)����	#FF8BDAE8   �� -   $��
saveResult��$��Wynik zapisano.��$��24(�$
��Bold"�
���   �$	 309��$	 495��$��Center=�$	��Top=�$��Segoe UI Black)��� -   $��
BackToMenu��$	 300��$	 640��$	��220��$��68��$��Center=�$	��Top=�$��Menu Główne�����	#FF8BDAE8$��24(�$��Segoe UI Black)����	#FF8BDAE8   �� -   $��	PlayAgain��$	 300��$	 552��$	��220��$��68��$��Center=�$	��Top=�$��Zagraj Ponownie�����	#FF8BDAE8$��24(�$��Segoe UI Black)����	#FF8BDAE8   