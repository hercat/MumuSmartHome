var g_msgboxTitle = "";

function menuHideOrShow() {
    var menu = $('.nav').css('display');
    if (menu == "block" || menu == "") {
        $('.nav').css('display', 'none');
        $('#splitter').html('<img src="../images/sources/fullscreen.png" />');
        $('.right_container').css('marginLeft', '36px');
        $('.left_container').css('width', '34px');
    }
    else {
        $('.nav').css('display', 'block');
        $('#splitter').html('<img src="../images/sources/narrow.png" />');
        $('.right_container').css('marginLeft', '182px');
        $('.left_container').css('width', '180px');
    }
}