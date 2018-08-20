//var AjaxDemo = function () {

//    return
//    {
//        initAjax: function()
//        {
//            alert("test");
//        }
//    }

//}();

$(document).ready(function () {
    $("#CommentForm").submit(function () {
        event.preventDefault();
        var data = $(this).serialize();
        var url = $(this).attr("action");

        $.post(url, data, function (responce) {
            $("#comments").append(responce);
        })
    });


    //$("#privacyLink").click(function () {
    //    event.preventDefault();
    //    var url = $(this).attr("href");

    //    $("#privacy").load(url);
    //})

});