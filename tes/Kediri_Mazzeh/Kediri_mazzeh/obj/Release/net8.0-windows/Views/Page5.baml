   M S B A M L   `   `   `  ����   Aplikasi_Kediri_Mazzeh(    "Aplikasi_Kediri_Mazzeh.Views.Page5   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Komentar Pengunjung��$	��500��$	��800��.��� $��10q�����  �� ImageSource$ Asset/Gambar/black.jpg�� j� Stretch$
 Fill=�.+��� $��10q�.+��� $��	Kategori:�����	#A0FFFFFF�� -   $��kategoriComboBox��.@��� $��Kuliner���� $��
Pariwisata���� $��
Nama Item:��$��0,10,0,0q����	#A0FFFFFF�� -   $��itemComboBox���� $��	Komentar:��$��0,10,0,0q����	#A0FFFFFF�� -   $��komentarTextBox��$��60����  �� Orientation$ 
Horizontal=�$��0,10,0,0q�$
��Left=����	#A0FFFFFF.+��� -   $��Tambah Komentar��$	��150���� -   $��Edit Komentar��$	��150��$��10,0,0,0q��� -   $��Update Komentar��$	��150��$��10,0,0,0q��� -   $��Hapus Komentar��$	��150��$��10,0,0,0q��� -   $��Kembali��$	��100��$��10,0,0,0q�&   System.Windows.Controls.DataGrid  -	     Name$ komentarDataGrid��   AutoGenerateColumns$ False��$	��200��$��10q�$��Bottom=�   SelectionMode$ Single=����	#A0FFFFFF   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Kategori��	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *
Kategori+  $
 Item��$	 * 
 �� *Item+  $ Komentar��$	 2* 
 �� *KomentarText+