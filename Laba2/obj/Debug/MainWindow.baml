   M S B A M L   `   `   `  ����@  <Laba2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba2Laba2  5   	       Laba2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Laba2     5   	     � Title$  
MainWindow��5   	   $	��355��6   $��546.667��6)   .��5	      �  J� RenderTransformOrigin$ 0.252,0.481&�6   .+�5
   
   �� -   5         ��Name$ label��5
      $��Select File: ��6   $
��Left=�67   $��
10,106,0,0q�6R   $	��Top=�6f   $��70��6~   $��23��6�   �� 5   
   -   5         ��Name$ 	filesList��5       �� PanningMode$
 Both=�6%   $
��Left=�6h   $��37��6�   $��
10,134,0,0q�6�   $	��Top=�6�   $	��257��6�   ��6E   ��  �� Path$ Files�6�   �� 5   
   $��15��6   $��26,348,-205,-38q�6    $	��Top=�69   $ 0.411,-0.146&�6Q   $
��Left=�6v   $	��718��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -89.777Q�6&   T� 5       T� X$ -52.013Q�6)    T� Y$ 76.983Q�65   5      5      �� 5   
   -   5        $ Original_Files_Section��5      $$��Creating and choosinf Files : ��60   $
��Left=�6Y   $��	10,10,0,0q�6t   $	��Top=�6�   $	��246��6�   �� 5   
   -   5        	 ��Name$	 fileName��5      $
��Left=�6$   $��23��6?   $��	10,71,0,0q�6K   
 �� TextWrapping$

 Wrap=�6^   $	��Top=�6r   $	��136��6�   6�   �� 5   
   -   5        $ Create_New_File_Label��5      $��Create New File: ��6/   $
��Left=�6K   $��	10,43,0,0q�6f   $	��Top=�6y   $	��120��6�   $��23��6�   �� 5   
   -   5         ��Name$ CreateFile_btn��5      {�. $��Create��6:   $
��Left=�6K   $��
151,71,0,0q�6f   $	��Top=�6z   $	��116��6�   6�   �� 5   
   -   5        $	 fileContent��5      $

 Wrap=�6'    �� AcceptsReturn . $
��Left=�6P   $��10,204,0,36q�6k   $+��%Enter Text(not less than 500 symbols)��6�   $	��257��6�   $��13.333(�6�   �� 5   
   -   5        $ Enter_File_Text_Label��5      $7��1Enter your file Text(not less than 500 symbols): ��6/   $
��Left=�6k   $��
10,176,0,0q�6�   $	��Top=�6�   $	��257��6�   $��28��6�   �� 5   
   -	   5        $!	 Encrypted_Decrypted_TextBox��5      $��291,126,12,36q�67   $

 Wrap=�6N   $(��"Encrypted/Decrypted File text here��6b   �� 5   
   -
   5        $! Original_Files_Section_Copy��5      $#��Encrypted and Decrypted Text:��65   $
��Left=�6]   $��
291,10,0,0q�6x   $	��Top=�6�   $	��246��6�   �� 5   
   -   5        $  Create_New_File_Label_Copy��5      $��Enter key: ��64   $
��Left=�6J   $��
291,36,0,0q�6e   $	��Top=�6y   $	��105��6�   $��26��6�   �� 5   
   -   5        $ Encrypt_Button��5      $��Encrypt��6)   $
��Left=�6;   $��
402,41,0,0q�6V   $	��Top=�6j   $	��127��6�   6�   �� 5    
   -   5        $! Create_New_File_Label_Copy1��5       $+��%Encrypted/Decrypted Text from file : ��65   $
��Left=�6e   $��
291,95,0,0q�6�   $	��Top=�6�   $	��236��6�   $��26��6�   �� 5!   
   -   5        $	 Password_Text��5!      $
��Left=�6)   $��23��6D   $��
291,67,0,0q�6P   $

 Wrap=�6d   $	��Top=�6x   $	��238��6�   $��Your secret key��6�   �� 5"   
   -   5        $ Decrypt_Button��5"      $��Decrypt��6)   $��	291,0,0,9q�6;   $��22��6k   $��Bottom=�6w   $
��Left=�6�   $	��127��6�   �� 5#   
   -   5        $ 	Save_File��5#      $
��Save��6$   $
��Left=�63   $��10,0,0,9q�6N   $	��127��6`   $��22��6�   $��Bottom=�6�   5%      5&      