//导航栏固定
//$(function () {
//    $(document).scroll(function () {
//        var top = $(document).scrollTop();
//        if (top > 500) {
//            $('.header').css({ "position": "fixed", "top": "0", "left": "0", "right": "0", "z-index": "1" });
//        } else {
//            $('.header').css({ "position": "relative" });
//        }
//    })
//})

//回到顶部按钮
$(function () {
    $('#to-top').hide();
    $(document).scroll(function () {
        var top = $(document).scrollTop();
        console.log(top);
        if (top > 550) {
            $('#to-top').show();
        } else {
            $('#to-top').hide();
        }
    })
    $("#to_top-images").click(function () {
        $("html, body").animate({ scrollTop: 0 }, 300)
    })
    $("#to_top-images").mouseover(function () {
        $("#to_top-images").css("opacity", "1");
    })
    $("#to_top-images").mouseout(function () {
        $("#to_top-images").css("opacity", "0.6");
    })
})

//导游展示效果
$(function () {
    $(".guide-img").mouseover(function () {
        $(this).css("opacity", "0.6");
        console.log(1)
    })
    $(".guide-img").mouseout(function () {
        $(this).css("opacity", "1");
        console.log(2)
    })
})