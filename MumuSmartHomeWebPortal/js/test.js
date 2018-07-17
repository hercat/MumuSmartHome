/// <reference path="C:\工作\SourceCode\MumuSmartHome\MumuSmartHomeSolution\MumuSmartHomeWebPortal\jquery/jquery-3.3.1.min.js" />

$(document).ready(function () {
    
});

function ajaxTest() {
    $.ajax({
        url: '/AjaxTest/Hello.cspx',
        data: {},
        cache: false,
        method: 'get',
        success: function (json) {
            alert(json);
        }
    });
}

