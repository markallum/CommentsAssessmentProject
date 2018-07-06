$(document).ready(function () {
    $("#btnNewComment").click(function () {
        var url = "/home/post/";
        $.get(url, function (data) {
            $("#divCommentArea").html(data);
        });
        $(this).hide();
    });
});