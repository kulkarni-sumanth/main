$(document).ready(function(){
    $(".dropdown-button").click(function() {
        $(this).next().toggle();
    });
    $(".dropdown-content li").click(function() {
        $(this).parent().prev().text($(this).text());
        $(this).parent().prev().val($(this).text());
        $(this).parent().hide();
    });
});