   M S B A M L   `   `   `  ����P  LIntelligentTranslator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:IntelligentTranslator.Converters IntelligentTranslator.Converters  5   	   &     IntelligentTranslator.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   E
converters.clr-namespace:IntelligentTranslator.Converters     5   	     � Title$'  !Intelligent Translator | NTT Data��5   	   $	��450��63   $	��525��6@      TranslationViewModel � DataContext# [  5	   	    � 	Resources 5
      ?   9IntelligentTranslator.Converters.LanguageCultureConverter  LanguageCultureConverterA   ;IntelligentTranslator.Converters.TextBoxBackgroundConverter  TextBoxBackgroundConverter��%:   &	       &	        5   
   6.     5   
   60   5      .��5      ��  �� Padding$ 10q�6   ._�5   
   �� $
��Auto=�6   .��5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��
Translate:��6    $
��Bold"�62   $��10,0,0,0q�6D   �� 5      $��5,0,2,0q�6   .��6.   Language autodetect6C   �� 5      -   5         ��Name$ InputLanguage��5       $��DemiBold"�6�    �� Padding$ 0,0,0,0q�6�   ��67   �� *TranslatedWordLanguage+ �� 	Converter# [ 6�   5      �� 5      $��10q�6q   $
 0 10q�6}   
�������$��1q�6�   ��6   �� *	WordFound+# [ ._�5      � .+�5      �� -   5        $ TranslateWatermark��5   $   
�����w�$
��Left=�6�   $��8,0,0,0q�6�   ��6]   ��  �� Path$ TranslationPlaceholder�6�   �� 5      -   5        	 ��Name$	 TranslateTextBox��5   "   
������ $��5,0,0,0q�6�   $��0q�6�   $��Stretch=�6�   ��6<   �� $ TranslationWord�
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      5      �� 5      $��Translation:��6   $
��Bold"�60   $��	10,20,0,5q�6B   �� 5      -   5         ��Name$ ResultListView��5      $
��auto��6\   $��	10,0,10,0q�6j   ��63   �� *WordTranslations+ 5        �� 
TargetType �� Property �� Value��%T   '��       �� 5!      " ��6    .�5"      ��  � ��$
 Left=�6K   5#      5$       �� View 5%      �� 5&      .P�5'      ��  �� Width$ 80��6�   $��Language��6�    �� DisplayMemberBinding 6.   �� $ culture�# [ 6�   �� 5(      $
��Word��6X   $	 400��6f    6-   �� $
 word�6f   5)      5+      �� 5-      $��Similar words:��6   $
��Bold"�62   $��	10,20,0,5q�6D   �� 5.      -   5        $ SimilarWordsListView��5.      $
��auto��6^   $��	10,0,10,0q�6l   ��69   �� *SimilarWords+ 5/      �� 50      .P�51      �� $	 480��6-   52      54      55      56      57      58      