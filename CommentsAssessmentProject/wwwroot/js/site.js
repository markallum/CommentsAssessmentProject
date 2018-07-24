

$(document).ready(function () {


    $(".btnReply").click(function () {

        // Hide existing comment forms and show hidden reply buttons
        $(".divReplyArea").html("");
        $(".btnReply").show();

        // Load add comment partial view and place next to the appropriate comment
        var commentId = $(this).attr("data-id");
        var url = "/home/post?parentid=" + commentId;
        $(".divReplyArea[data-id=" + commentId + "]").load(url, function () {
            // Once partial view is loaded, clear previous form validation and setup new form validation
            $("form").removeData('validator');
            $("form").removeData('unobtrusiveValidation');
            $("form").each(function () { $.data($(this)[0], 'validator', false); }); //enable to display the error messages
            $.validator.unobtrusive.parse("form");
        });

        $(this).hide();
    });
    
    
    // Post vote change and reload page
    $(".vote-button").click(function () {
        var commentId = $(this).data("id");
        var positive = $(this).data("positive");
        $.ajax({
            url: "home/vote?commentId=" + commentId + "&positive=" + positive,
            type: "POST",
            async: true,
            success: function (res) { 
                $(".vote-count[data-id=" + commentId + "]").html(res);

            },
            error: function () {
                console.log('failed');
            }
        });
    });
    

    
});






