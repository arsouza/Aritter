;(function(){

'use strict';

angular.module('aritter').run(['$templateCache', function($templateCache) {

  $templateCache.put('404/404.html', '<div class="four-zero"><h2>SEX!</h2><small>Nah.. it\'s 404</small><footer><a href="#" ng-click="back()"><i class="zmdi zmdi-arrow-back"></i></a> <a ui-sref="main.home"><i class="zmdi zmdi-home"></i></a></footer></div>');

  $templateCache.put('login/login.html', '<div class="lc-block" id="l-login" ng-class="{ \'toggled\': loginCtrl.viewMode.login }" ng-if="loginCtrl.viewMode.login"><div class="input-group m-b-20"><span class="input-group-addon"><i class="zmdi zmdi-account"></i></span><div class="fg-line"><input type="text" class="form-control" ng-model="user.username" placeholder="Username"></div></div><div class="input-group m-b-20"><span class="input-group-addon"><i class="zmdi zmdi-male"></i></span><div class="fg-line"><input type="password" class="form-control" ng-model="user.password" placeholder="Password"></div></div><div class="clearfix"></div><div class="checkbox"><label><input type="checkbox" ng-model="user.keepSignedIn"> <i class="input-helper"></i> Keep me signed in</label></div><a href="" class="btn btn-login btn-danger btn-float" ng-click="loginCtrl.login(user)"><i class="zmdi zmdi-arrow-forward"></i></a><ul class="login-navigation"><li data-block="#l-register" class="bgm-red" ng-click="loginCtrl.switchViewMode(\'register\')">Register</li><li data-block="#l-forget-password" class="bgm-orange" ng-click="loginCtrl.switchViewMode(\'forgot\')">Forgot Password?</li></ul></div><!-- Register --><div class="lc-block" id="l-register" ng-class="{ \'toggled\': loginCtrl.viewMode.register }" ng-if="loginCtrl.viewMode.register"><div class="input-group m-b-20"><span class="input-group-addon"><i class="zmdi zmdi-account"></i></span><div class="fg-line"><input type="text" class="form-control" placeholder="Username"></div></div><div class="input-group m-b-20"><span class="input-group-addon"><i class="zmdi zmdi-email"></i></span><div class="fg-line"><input type="text" class="form-control" placeholder="Email Address"></div></div><div class="input-group m-b-20"><span class="input-group-addon"><i class="zmdi zmdi-male"></i></span><div class="fg-line"><input type="password" class="form-control" placeholder="Password"></div></div><div class="clearfix"></div><div class="checkbox"><label><input type="checkbox" value=""> <i class="input-helper"></i> Accept the license agreement</label></div><a href="" class="btn btn-login btn-danger btn-float"><i class="zmdi zmdi-arrow-forward"></i></a><ul class="login-navigation"><li data-block="#l-login" class="bgm-green" ng-click="loginCtrl.switchViewMode(\'login\')">Login</li><li data-block="#l-forget-password" class="bgm-orange" ng-click="loginCtrl.switchViewMode(\'forgot\')">Forgot Password?</li></ul></div><!-- Forgot Password --><div class="lc-block" id="l-forget-password" ng-class="{ \'toggled\': loginCtrl.viewMode.forgot }" ng-if="loginCtrl.viewMode.forgot"><p class="text-left">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla eu risus. Curabitur commodo lorem fringilla enim feugiat commodo sed ac lacus.</p><div class="input-group m-b-20"><span class="input-group-addon"><i class="zmdi zmdi-email"></i></span><div class="fg-line"><input type="text" class="form-control" placeholder="Email Address"></div></div><a href="" class="btn btn-login btn-danger btn-float"><i class="zmdi zmdi-arrow-forward"></i></a><ul class="login-navigation"><li data-block="#l-login" class="bgm-green" ng-click="loginCtrl.switchViewMode(\'login\')">Login</li><li data-block="#l-register" class="bgm-red" ng-click="loginCtrl.switchViewMode(\'register\')">Register</li></ul></div>');

  $templateCache.put('main/main.html', '<ar-layout menu-items="mainCtrl.menu" chat-users="mainCtrl.chatUsers" logout="mainCtrl.logout()"><div class="container" ui-view></div></ar-layout>');

  $templateCache.put('main/home/home.html', '<div class="block-header"><h2>Dashboard</h2><ul class="actions"><li><a href=""><i class="zmdi zmdi-trending-up"></i></a></li><li><a href=""><i class="zmdi zmdi-check-all"></i></a></li><li class="dropdown" uib-dropdown><a href="" uib-dropdown-toggle><i class="zmdi zmdi-more-vert"></i></a><ul class="dropdown-menu dropdown-menu-right"><li><a href="">Refresh</a></li><li><a href="">Manage Widgets</a></li><li><a href="">Widgets Settings</a></li></ul></li></ul></div>');

  $templateCache.put('main/users/user-profile.html', '<div class="block-header"><h2>User Profile</h2><ul class="actions"><li><a href=""><i class="zmdi zmdi-trending-up"></i></a></li><li><a href=""><i class="zmdi zmdi-check-all"></i></a></li><li class="dropdown" uib-dropdown><a href="" uib-dropdown-toggle><i class="zmdi zmdi-more-vert"></i></a><ul class="dropdown-menu dropdown-menu-right"><li><a href="">Refresh</a></li><li><a href="">Manage Widgets</a></li><li><a href="">Widgets Settings</a></li></ul></li></ul></div>');

  $templateCache.put('shared/layout/layout.html', '<data><ar-header></ar-header><section id="main"><ar-sidebar></ar-sidebar><ma-chat id="chat"></ma-chat><section id="content" ng-transclude></section></section><ar-footer id="footer"></ar-footer></data>');

  $templateCache.put('shared/layout/chat/chat.html', '<aside ng-class="{ \'toggled\': $layout.chatToggled }"><div class="chat-search"><div class="fg-line"><input type="text" ng-model="searchText" class="form-control" placeholder="Search People"></div></div><div class="listview"><a class="lv-item" href="" ng-repeat="user in $layout.chatUsers | filter:searchText track by user.name"><div class="media"><div class="pull-left" ng-class="{ \'p-relative\': user.status }"><img class="lv-img-sm" ng-src="{{::user.avatar}}" alt=""> <i ng-if="user.status" ng-class="{\n            \'chat-status-busy\': user.status === \'busy\',\n            \'chat-status-online\': user.status === \'online\',\n            \'chat-status-offline\': user.status === \'offline\'\n          }"></i></div><div class="media-body"><div class="lv-title" ng-bind="user.name"></div><small class="lv-small" ng-bind="user.state"></small></div></div></a></div></aside>');

  $templateCache.put('shared/layout/footer/footer.html', '<footer>Copyright &copy; 2016 Material Admin - Anderson Ritter<ul class="f-menu"><li><a href="">Home</a></li><li><a href="">Dashboard</a></li><li><a href="">Reports</a></li><li><a href="">Support</a></li><li><a href="">Contact</a></li></ul></footer>');

  $templateCache.put('shared/layout/header/header.html', '<header id="header" ng-class="{ \'search-toggled\': $layout.searchToggled }" data-current-skin="{{$layout.currentSkin}}"><ul class="header-inner clearfix"><li id="menu-trigger" ng-click="$layout.sidebarToggled = !$layout.sidebarToggled" ng-class="{ \'open\': $layout.sidebarToggled }"><div class="line-wrap"><div class="line top"></div><div class="line center"></div><div class="line bottom"></div></div></li><li class="logo hidden-xs"><a ui-sref="main.home" ng-click="$layout.resetSidebar($event);">Material Admin</a></li><li class="pull-right"><ul class="top-menu"><li id="toggle-width"><div class="toggle-switch"><input id="tw-switch" type="checkbox" hidden ng-model="$app.layoutToggled" ng-change="$app.layoutToggle()"><label for="tw-switch" class="ts-helper"></label></div></li><li id="top-search"><a href="" ng-click="$layout.searchToggled = !$layout.searchToggled"><i class="tm-icon zmdi zmdi-search"></i></a></li><li class="dropdown" uib-dropdown><a uib-dropdown-toggle href=""><i class="tm-icon zmdi zmdi-email"></i> <i class="tmn-counts">6</i></a><div class="dropdown-menu dropdown-menu-lg stop-propagate pull-right"><div class="listview"><div class="lv-header">Messages</div><div class="lv-body"><a class="lv-item" ng-href="" ng-repeat="w in $app.notifications.list"><div class="media"><div class="pull-left"><img class="lv-img-sm" ng-src="assets/img/profile-pics/{{ w.img }}" alt=""></div><div class="media-body"><div class="lv-title">{{ w.user }}</div><small class="lv-small">{{ w.text }}</small></div></div></a></div><div class="clearfix"></div><a class="lv-footer" href="">View All</a></div></div></li><li class="dropdown" uib-dropdown><a uib-dropdown-toggle href=""><i class="tm-icon zmdi zmdi-notifications"></i> <i ng-hide="$app.notifications.list.length === 0" class="tmn-counts">{{$app.notifications.list.length}}</i></a><div class="dropdown-menu dropdown-menu-lg stop-propagate pull-right"><div class="listview" id="notifications" ng-class="{ \'empty\': $app.notifications.list.length === 0 }"><div class="lv-header">Notifications<ul class="actions"><li ng-hide="$app.notifications.list.length === 0"><a href="" ng-click="$app.clearNotifications($event)"><i class="zmdi zmdi-check-all"></i></a></li></ul></div><div class="lv-body"><a class="lv-item" ng-class="{ \'animated fadeOutRightBig\': w.removed }" ng-href="" ng-repeat="w in $app.notifications.list"><div class="media"><div class="pull-left"><img class="lv-img-sm" ng-src="assets/img/profile-pics/{{ w.img }}" alt=""></div><div class="media-body"><div class="lv-title">{{ w.user }}</div><small class="lv-small">{{ w.text }}</small></div></div></a></div><div class="clearfix"></div><a class="lv-footer" href="">View Previous</a></div></div></li><li class="dropdown hidden-xs" uib-dropdown><a uib-dropdown-toggle href=""><i class="tm-icon zmdi zmdi-view-list-alt"></i> <i class="tmn-counts">2</i></a><div class="dropdown-menu pull-right dropdown-menu-lg"><div class="listview"><div class="lv-header">Tasks</div><div class="lv-body"><div class="lv-item"><div class="lv-title m-b-5">HTML5 Validation Report</div><div class="progress"><div class="progress-bar" role="progressbar" aria-valuenow="95" aria-valuemin="0" aria-valuemax="100" style="width: 95%"><span class="sr-only">95% Complete (success)</span></div></div></div><div class="lv-item"><div class="lv-title m-b-5">Google Chrome Extension</div><div class="progress"><div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%"><span class="sr-only">80% Complete (success)</span></div></div></div><div class="lv-item"><div class="lv-title m-b-5">Social Intranet Projects</div><div class="progress"><div class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" style="width: 20%"><span class="sr-only">20% Complete</span></div></div></div><div class="lv-item"><div class="lv-title m-b-5">Bootstrap Admin Template</div><div class="progress"><div class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 60%"><span class="sr-only">60% Complete (warning)</span></div></div></div><div class="lv-item"><div class="lv-title m-b-5">Youtube Client App</div><div class="progress"><div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%"><span class="sr-only">80% Complete (danger)</span></div></div></div></div><div class="clearfix"></div><a class="lv-footer" href="">View All</a></div></div></li><li class="dropdown" uib-dropdown><a uib-dropdown-toggle href=""><i class="tm-icon zmdi zmdi-more-vert"></i></a><ul class="dropdown-menu dm-icon pull-right"><li class="skin-switch hidden-xs"><span ng-repeat="w in $layout.skinList | limitTo : 6" class="ss-skin bgm-{{ w }}" ng-click="$layout.skinSwitch(w)"></span></li><li class="divider hidden-xs"></li><li><a href=""><i class="zmdi zmdi-face"></i> Privacy Settings</a></li><li><a href=""><i class="zmdi zmdi-settings"></i> Other Settings</a></li></ul></li><li class="hidden-xs" ng-click="$layout.chatToggled = !$layout.chatToggled" ng-class="{ \'open\': $layout.chatToggled }"><a href=""><i class="tm-icon zmdi zmdi-comment-alt-text"></i></a></li></ul></li></ul><!-- Top Search Content --><div id="top-search-wrap"><div class="tsw-inner"><i id="top-search-close" class="zmdi zmdi-arrow-left" ng-click="$layout.searchToggled = !$layout.searchToggled"></i> <input type="text" ng-focus="$layout.searchToggled"></div></div></header>');

  $templateCache.put('shared/layout/sidebar/sidebar-menu.html', '<ul><li ng-repeat="item in $menu.items" ng-class="{\n      \'active\': $layout.$state.includes(item.state),\n      \'toggled\': item.hasChildren && (item.submenuToggled || $layout.$state.includes(item.state)),\n      \'sub-menu\': item.hasChildren\n    }"><a ng-if="!item.hasChildren" ui-sref="{{::item.state}}" ng-click="$layout.resetSidebar($event)"><i ng-class="item.icon"></i> {{::item.title}} </a><a ng-if="item.hasChildren" href="" ng-click="toggleSubmenu($event, item)"><i ng-class="item.icon"></i> {{::item.title}}</a><ma-sidebar-menu ng-if="item.hasChildren" items="item.children"></ma-sidebar-menu></li></ul>');

  $templateCache.put('shared/layout/sidebar/sidebar.html', '<aside id="sidebar" ng-class="{ \'toggled\': $layout.sidebarToggled }"><div class="sidebar-inner c-overflow" ar-scrollbar><div class="profile-menu" ng-class="{ \'toggled\': $layout.profileMenuToggled }"><a href="" ng-click="$layout.profileMenuToggled = !$layout.profileMenuToggled"><div class="profile-pic"><img ng-src="assets/img/profile-pics/1.jpg" alt=""></div><div class="profile-info">Malinda Hollaway <i class="zmdi zmdi-caret-down"></i></div></a><ul class="main-menu"><li><a ui-sref="main.userProfile({ username: \'arsouza\' })" ng-click="$layout.resetSidebar($event)"><i class="zmdi zmdi-account"></i> View Profile</a></li><li><a ui-sref="login" ng-click="logout()"><i class="zmdi zmdi-time-restore"></i> Logout</a></li></ul></div><ma-sidebar-menu class="main-menu" items="$layout.menuItems"></ma-sidebar-menu></div></aside>');

}]);

})();