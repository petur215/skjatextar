$(document).ready(function () {
    GetAllComments();

    $("#CommentClick").click(function (comment) {
        comment.preventDefault;

        var myComment = $("#CommentText").val();
        if (myComment == "") {
            alert("Input field can not be empty!");
        }
        else {
            $('#CommentText').val("");
            $.ajax({
                type: "GET",
                //contentType: "application/json; charset=utf8",
                url: "/Home/AddComment",
                data: { commentText: myComment },
                dataType: "json",
                success: function (commentText) {
                    //$(".list-group").empty();
                    GetAllComments();
                }
            });
        }
    });
});

function GetAllComments() {
    $.ajax({
        type: "GET",
        //contentType: "application/json; charset=utf8",
        url: "/Home/GetAllComments",
        data: "{}",
        dataType: "json",
        success: function (comment) {
            for (var i = 0; i < comment.length; i++) {
                comment[i].CommentDate = ConvertStringToJSDate(comment[i].CommentDate);
            }
            var myArray = comment;
            $('#commentListi').loadTemplate($('#commentTemplate'), myArray);
        },
    });
}
function ConvertStringToJSDate(dt) {
    var dtE = /^\/Date\((-?[0-9]+)\)\/$/.exec(dt);
    if (dtE) {
        var dt = new Date(parseInt(dtE[1], 10));
        return dt;
    }
    return null;
}