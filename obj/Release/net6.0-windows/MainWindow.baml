   M S B A M L   `   `   `  ���� L  HCosmosLauncherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CosmosLauncherAppCosmosLauncherApp  E'clr-namespace:CosmosLauncherApp.LanguesCosmosLauncherApp.Langues  K*clr-namespace:CosmosLauncherApp.ComponentsCosmosLauncherApp.Components  "    CosmosLauncherApp.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:CosmosLauncherApp     5p'clr-namespace:CosmosLauncherApp.Langues     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   9Cosmos*clr-namespace:CosmosLauncherApp.Components   -     �Name$  Window��0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle$
 True�� � Title$ Cosmos Battle Royale��$	��500��$	��888�� � Icon$ /img/Logo.png�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=�$��0q�����  �� ImageSource$ img/Background.png��.��� -    �Name$ Fenetre��.+�0   *CosmosLauncherApp.Components.ButtonControl  -     Name$ Username_btn��0   *CosmosLauncherApp.Components.ButtonControl	   	MouseDown$	 Username_btn_MouseDown��
   Icon$
 Account=�$��Right=�$��
45 15 45 0q�$	��Top=�  -   $ Discord_btn��$	 Discord_btn_Click��   Text$ Discord��$
 Discord=�$��
45,0,45,15q�$��Bottom=�$
��Left=�  -   $ Settings_btn��$	 Settings_btn_MouseDown��$��
45,0,45,15q�$   CosmosLauncherApp.Langues.Lang   Settings# Z $	
 Cog=�$��36��$��Bottom=�$��Right=�  $	 Launch_btn_Click��$��Bottom=�$��Center=�$

 Play=�   Launch# Z $��0,0,0,15q���  �� CornerRadius$ 5�����#6500A3$��45,0,100,65q�$��Bottom=�._��� -    ��Name$ Folder_Label��
������ " �� VerticalScrollBarVisibility$ Visible=�$ �� HorizontalScrollBarVisibility$ Visible=� �� 
IsReadOnly$
 True�� �� TextWrapping$
 Wrap=�$��0q�$��16(�$	��7.5q�  -   $ 
Folder_btn��$	 Folder_btn_Click��$	 ...��$
 Folder=�$��Bottom=�$��	0,0,45,65q�$��Right=��� -    ��Name$ Version_Label��$��Version 1.0��$��0,0,4,2q�$��10(�$��Right=�$��50��$��13��$��Bottom=�