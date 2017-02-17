$(document).ready(function () {


$(function () {
    $("#PopInShow").click(function () {
    //$("#PopInShow").attr
    var popin = "connect_popin";
    $("[data-popin='" + popin + "']").addClass("displayed");
    })
    $("[data-popin] .popin-backlayer, [data-popin] .popin-close").click(function () {
        $(this).parents(".popin").removeClass("displayed");
    });
    $("#mobile-menu-btn, #mobile-close-btn, #mobile-back-layer").click(function () {
        $("body").toggleClass("mobile-menu-open");
    });

});










$("#nav").on('click', 'li', function () {
    console.log("ici");
    $('#nav li.active').removeClass('active');
    console.log("ok");
    $("this").addClass('active');
});