   M S B A M L   `   `   `  ����E  ATenderView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TenderView.UI.ModelViewTenderView.UI.ModelView  5   	   #    TenderView.UI.View.TenderView   5   	   e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	   5	modelView%clr-namespace:TenderView.UI.ModelView  5   	     � Title$  Tender View��5
   	   $	��720��6   $
��1080��6*    � 	Resources 5       �� 
TargetType �� Property �� Value��%  '��       '�� H     '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 20��6&   �� 5       � ��$ 20��6'   5      5       � DataContext 5      ,   &TenderView.UI.ModelView.TradeViewModel  5   
   .��5      ]� .+�5   
   �� $	��Top=�6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   $��5q�6^   .+�5      �� $!��Номер тендера: ��6   �� 5       �� 	MaxLength$ 10��5      $	��100��5      ��5      �� *InputTradeId+ �� UpdateSourceTrigger$ PropertyChanged=�.��5   "   .  (System.Windows.Interactivity.Interaction	   Triggers	 5       /  )System.Windows.Interactivity.EventTrigger  5!      
   	EventName$
 PreviewTextInput��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5"      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ NumberValidator��6G      TargetObject 6.   �� 6G   5#      .��5$   *   5%      �� 5&      ��6   �� *
AddTrade+��5'      �� *InputTradeId+.��6?   +5)      5*      � 5,   
   ���#F5F5F5 � ColumnDefinitions 5-      �� 5.      $
��0.3* �6#   �� 5/      $��* �6#   �� 50      $
��0.4* �6#   �� 51      $
��0.4* �6#   .+�54      ]� $��0��6   .+�55      �� $	��Top=�6   $��Тендеры��61   $
��Thin"�6@    �� TextAlignment$ Center=�6R   �� 56      ��6   �� *Trades+ �� SelectedItem 57      �� *SelectedTrade+��58      �� 59      .R�5:      �� $��5q�6)   .+�5;   "   �� $��18(�6,   $
��Bold"�6Y   ��6:   ��  �� Path$ Trade.id�6Y   �� 5<   "   ��6,   �� $ Trade.tradeStateName�5=      5>      5@      5A      ]� 5B      $��1��6   .+�5C      �� $	��Top=�6   $��Описание��61   $
��Thin"�6A   $ Center=�6S   �� 5D      $��5,5,0,0q�6C    6   �� *SelectedTrade+.+�5E      �� $��Номер тендера��6    $
��Bold"�65   �� 5F      ��6    �� *
Trade.id+$ PropertyChanged=��� 5G      $%��Название тендера��6    $
��Bold"�68   �� 5H      $
��Wrap=�5I       ��5H       �� *Trade.tradeName+$ PropertyChanged=�5I       �� 5J      $��Статус��6    $
��Bold"�6.   �� 5K      ��6    �� *Trade.tradeStateName+$ PropertyChanged=��� 5L      $��Заказчик��6    $
��Bold"�60   �� 5M      $
��Wrap=�5N       ��5M       �� *Trade.customerFullName+$ PropertyChanged=�5N       �� 5O      $:��4Начальная максимальная цена��6    $
��Bold"�6C   �� 5P      ��6    �� *Trade.initialPrice+$ PropertyChanged=��� 5Q      $!��Место поставки��6    $
��Bold"�66   �� 5R      $
��Wrap=�5S       ��5R       �� *TradeDetail.deliveryAddress+$ PropertyChanged=�5S       �� 5T      $#��Дата публикации��6    $
��Bold"�67   �� 5U      ��6    �� *Trade.publicationDate+$ PropertyChanged=��� 5V      $;��5Дата окончания подачи заявок��6    $
��Bold"�6D   �� 5W      ��6    �� *!Trade.fillingApplicationEndDate+$ PropertyChanged=�5X      5Y      ]� 5[      $��2��6   .+�5\      �� $	��Top=�6   $��Лоты��61   $
��Thin"�6=   $ Center=�6O   �� 5]      $��Disabled=�5_      ��5]      �� *+)SelectedTrade.TradeDetail.purchaseObjects+ 5^      �� *%#SelectedTrade.SelectedTradeDocument+��5`      �� 5a      .R�5b      �� $��5q�6)   .+�5c   "   �� $��Название:��6,   $
��Bold"�6=   �� 5d   "   $
��Wrap=�6G   ��6,   �� $
 name�6G   �� 5e   "   $��Колличество:��6,   $
��Bold"�6@   �� 5f   "   ��6,   �� $ quantity��� 5g   "   $��Ед. измерения:��6,   $
��Bold"�6B   �� 5h   "   ��6,   �� $ unitName��� 5i   "   $��Цена за штуку:��6,   $
��Bold"�6B   �� 5j   "   ��6,   �� $ priceForOne�5k      5l      5n      5o      ]� 5q      $��3��6   .+�5r      �� $	��Top=�6   $��
Файлы��61   $
��Thin"�6>   $ Center=�6P   �� 5s      $��Disabled=�5u      ��5s      �� *SelectedTrade.TradeDocuments+ 5t      �� *%#SelectedTrade.SelectedTradeDocument+	 5v        5w      $
 MouseDoubleClick��6)   . 5x      6  0System.Windows.Interactivity.InvokeCommandAction     Command 5y   !   ��  �� Mode$ OneWay=�$ OpenFileInBrowser�   CommandParameter 5z   !   �� *)'SelectedTrade.SelectedTradeDocument.url+5{      ��5}      �� 5~      .R�5      �� $��5q�6)   .+�5�   "   �� $��15(�6,   $
��Bold"�5�   ,   $
��Wrap=�6>   ��5�   :   �� $
 type�5�   >   �� 5�   "   $��10(�6,   $
��Wrap=�5�   ,   ��5�   :   �� $ fileName�5�   ,   5�      5�      5�      5�      5�      5�      5�      