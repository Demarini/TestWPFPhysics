   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   k gGalaSoft.MvvmLight.Extras.WPF45, Version=4.1.24.16411, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef7pQclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF45GalaSoft.MvvmLight.Command 5   	    TestPhysics   TestPhysics.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ^ePclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   acmdQclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF45     5   	     � Title$  
MainWindow��5   	   $	��650��6   $	��950��6)   
���   �.   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ PreviewKeyDown��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5	      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 6!   �� *KeyDownCommand+6e   5
        5   
   $ PreviewKeyUp��6   . 5         .  6!   �� *KeyUpCommand+6c   5      .��5      � ��6   �� *Height+��6%   �� *Width+.+�5   
   �� -   5         ��Name$ canvas��5      
������� J� Opacity$ 50Q�64   ��6A   �� *Height+��6[   �� *Width+ 5        5      $ PreviewMouseMove��6!   . 5         .  6)   �� *MouseMovedCommand+6p   5        5      $ PreviewKeyDown��6!   . 5         .  6)   �� *KeyDownCommand+6m   5      .+�5      A� -   5         A�Name$ ellipse��5      
���   ���6'   �� *CircleWidth+��6E   �� *CircleHeight+	 �� Left	 6r   �� *X+

 �� Top
 6�   �� *Y+ 5        5      $ PreviewMouseDown��6%   . 5         .  6-   �� *MouseDownCommand+6s   5        5      $ PreviewMouseUp��6%   . 5         .  6-   �� *MouseUpCommand+6q   5       5"      �� 5#      $��30��6   $	��100��6$   $	 10��61   
���   �
 6B   �� *	PlayerY+ 5$        5%      $ PreviewMouseDown��6%   . 5&         .  6-   �� *PlayerMouseDownCommand+6y   5'        5(      $ PreviewMouseUp��6%   . 5)         .  6-   �� *PlayerMouseUpCommand+6w   5*      5,      �� 5-      $��30��6   $	��100��6$   $		 860��61   
���   �
 6C   �� *	ComputerY+6s   �� 5.      $		 300��6   $	
 250��6*   $	��100(�6<   
���   �$ 20Q�6v   ��6K   �� *Score1+6�   �� 5/      $		 600��6   $	
 250��6*   $	��100(�6<   
���   �$ 20Q�6v   ��6K   �� *Score2+6�   50      52      53      