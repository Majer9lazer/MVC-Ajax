$(document).ready(function () {
    $("ul.speaker a").click(function ()
    {
        $("#indicator").show();
        var url = $(this).attr("href");
        console.log(url);

        $.getJSON(url, null, function (data) {
            console.log(data);

            $("#indicator").hide();
                
            var html = "<h3>" + data.FirstName + " " + data.LastName + "</h3><img src='" + data.PicUrl + "' />";
    
            $("#speakersDetails").html(html);

        });

        return false;
    })
})