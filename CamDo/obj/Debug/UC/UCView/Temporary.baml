   M S B A M L   `   `   `  ????@  <CamDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CamDo.UC.UCViewCamDo.UC.UCView  5          CamDo.UC.UCView.Temporary   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CamDo.UC.UCView     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $??
homeWindow??5      .  (System.Windows.Interactivity.Interaction    Triggers  5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded??6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   ?? *LoadedWindowCommand+   CommandParameter 5   $   ??  ?? ElementName$ 
mainWindow??5      .??5      ? ??5   
   ?? 5       ?? EndPoint$ 0.5,1&?6"    ?? 
StartPoint$ 0.5,0&?63   .??5      ?  ? Color$ #f5c1c1??6   	 ? Offset$		 0.2Q?6/   ? 5      $ #e7cfcf??6   $	 1Q?6/   5      
 ? ColumnDefinitions
 5   
   ?? 5      $??1* ?6   ?? 5       .+?5#   
   ?? $??0??6   $??Center=?5$      .+?5%      ?  ? RowDefinitions 5'      ?? 5(      ?? 5)      ?? 5*      ?? 5+      $
??auto ?6$   .+?5.      ? $??0??6   .+?5/      ?? $??Rose's??6    $??90(?50   $   $??Center=?51   $   $??Center=?52   $   53      ? 55      $??1??6   .+?56      ?? $??	Pawn shop??6    $??90(?57   $   $??Center=?58   $   $??Center=?59   $   5:      ? 5<      $??2??6   .+?5>      ?? $-??'pack://application:,,,/Picture/Rose.png??6   $	??350??5@      $??Center=?5A      $??Center=?5B      5C      5D      5E      ?? 5G   
   $??1??6   .+?5J      ?  5K      ?? 5L      ?? 5M      .+?5P      ? $??0??6   .+?5Q      ?? .+?5R      '  !MaterialDesignThemes.Wpf.PopupBox  $??Right=?5S      $??
0,0,19.8,0q?69      PlacementMode$ BottomAndAlignCentres=?5T   2      ToggleContent 5U      '  !MaterialDesignThemes.Wpf.PackIcon  5V   "      Kind$  ArrowDownDropCircleOutline=?6:   $	??120??6\   $	??120??6h   
???????$??
ExtraLight"?5W   M   6g      PopupContent. 5[      ?? .+?5\   "   ??  ? Cursor$
 Hand??6T   ??6)   ?? *EditAccountInfoCommand+.??5]   &   ??  ?? Orientation$ 
Horizontal=?61   $??Center=?6J   .+?5^   *     $ Account=?6B   $??25??6Q   $
??auto??6\   6l   ?? 5_   *   $??5 0 5 -4q?64   $??Center=?6F   Chỉnh sửa tài khoản6v   5`   '   5a   #   ?? 5c   "   $
 Hand??6R   ??6)   ?? *CreateAccountCommand+y?6`   ?? *UpdateVisibility+.??5d   &   ?? $ 
Horizontal=?61   $??Center=?6J   .+?5e   *     $ Information=?6B   $??25??6U   $
??auto??6`   6p   ?? 5f   *   $??5 0 5 -4q?64   $??Center=?6F   Tạo tài khoản6p   5g   '   5h   #   ?? 5j   "   -   5         ??Name$ btnLogin??5j   )   $
 Hand??5m   )   ??5k   )   ?? *LogoutCommand+??5l   )   ?? $ 
mainWindow??.??5n   &   ?? $ 
Horizontal=?61   $??Center=?6J   .+?5o   *     $ Logout=?6B   $??25??6P   $
??auto??6[   6k   ?? 5p   *   $??5 0 5 -4q?64   $??Center=?6F   Đăng xuất6l   5q   '   5r   #   5s      5t      5u      5v      ? 5x      $??1??6   $	??465??5y      $??Center=?5z      $??Center=?5{      .+?5}      ?? $??Center=?6!   $??Center=?5~   !   .+?5      ? 
 5?      ?? 5?   "   $
??auto ?63   ?? 5?   "   $
??auto ?63   .+?5?      ?? $??0??6)   .+?5?   "   ?? $??Welcome??6,   $??60(?5?   ,   5?      ?? 5?      $??1??6)   .+?5?   "   ?? $??60(?5?   ,   $??30,0,0,0q?5?   ,   ??5?   ,   ?? *Role+ ?? UpdateSourceTrigger$ PropertyChanged=?5?   ,   5?      5?      ? 5?      $??Center=?6   $??Center=?5?      .+?5?      ?? $??back online??6(   $??60(?5?   (   5?      5?      5?      5?      5?      5?      5?      5?      