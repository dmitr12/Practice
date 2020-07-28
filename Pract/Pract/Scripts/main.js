$(function(){
    $('.slider_items').slick({
        nextArrow: '<button type="button" class="slick-btn slick-next"></button>',
        prevArrow: '<button type="button" class="slick-btn slick-prev"></button>'
    })
});

login = function () {
    if (document.getElementById("hide").style.display == "none" && document.getElementById("window").style.display == "none") {
        document.getElementById("hide").style.display = "block";
        document.getElementById("window").style.display = "block";
    }
    else {
        document.getElementById("hide").style.display = "none";
        document.getElementById("window").style.display = "none";
    }
    
}

closeLoginWindow = function () {
    document.getElementById("hide").style.display = "none";
    document.getElementById("window").style.display = "none";
}