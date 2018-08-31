/// <reference path="C:\工作\SourceCode\MumuSmartHome\MumuSmartHomeSolution\MumuSmartHomeWebPortal\jquery/jquery-1.9.0.js" />

//控制菜单收缩和展开功能func
function menuToggle(e) {    
    //console.log($(e).siblings('.menu_item_content').css('width'));
    //console.log($(e).siblings('.menu_item_content').css('display'));
    var display = $(e).siblings('.menu_item_content').css('display');
    if (display == "none" || display == "")
        $(e).siblings('.menu_item_content').css('display', 'block');
    else
        $(e).siblings('.menu_item_content').css('display', 'none');
}