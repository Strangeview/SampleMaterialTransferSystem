操作说明
方法一：
1：编译运行后 请依次点击 菜单 RailCreat->Rail1或者Rail2 或者Rail3进行三种轨道建模；点击菜单
     ModelBuild->CarBuild进行小车建模；
2：点击菜单CommandControl->AutoMove，此时小车可以沿着Rail运动；
3：点击窗口底部 pause 和 Resume按钮可以交互控制小车暂停与开始。
方法二：（注意此种方法暂时只有Rail1可以观察）
1：编译运行后请依次点击菜单RailCreat->Rail1进行轨道1建模，然后点击菜单ModelBuild->StationBuild进行
     站位建模，然后点击菜单ModelBuild->CarBuild进行小车建模；
2：点击菜单CommandControl->CreatCommand,此时CommandCreatWindow窗口出现；
3：然后点击 LoadStartStation进行StartStation加载，否则对应的下拉列表中没有元素；然后点击LoadTargetStation
    进行TargetStation加载，否则对应的下拉列表中没有元素；（注意此窗口中的LoadTargetCar按钮没有用处以及
    对应的交互窗口没有用处）
4：在StartStationSelect下拉列表中选择开始Station(开始Station只能选择0~~11)，此时对应的下边空白区域会显示
     该Station的坐标，在TargetStationSelect下拉列表中选择目的Station，此时对应的下边空白区域会显示该Station
     的坐标；
5：点击当前CommandCreatWindow窗口下边的四个按钮可以交互控制小车在指定Station间的运动。
