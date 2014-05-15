$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Home/CheckUser",
        data: "{ }",
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
        },
        error: function (xhr, err) {
            $("#hideme").hide();
        }
    });
    hi();
    var s = $(".currentTranslationId").val(); //parseInt(@Model.ThisTranslation.ID);
    console.log("current id is " + s);
    $("#empty").hide();
    //$("#hideme").hide();
    //$.template();
    $("#CommentTakki").click(function (ev) {
        var temp = $('#CommentText').val();
        ev.preventDefault;
        if (temp == "") {
            $("#empty").show();
            $("#empty").html("Input field can not be empty!");
        }
        else {
            $("#empty").hide();
            $("#CommentText").val("");
            $.ajax({
                type: "POST",
                url: "/Home/AddComment",
                data: { id: s, commentText: temp },
                datatype: "json",
                success: function (commentText) {
                    //alert("virkar");
                    hi();
                },
                error: function (xhr, err) {
                    //alert("vesen!!!");
                }
            });
        }
    });
});
function ConvertStringToJSDate(dt) {
    var dtE = /^\/Date\((-?[0-9]+)\)\/$/.exec(dt);
    if (dtE) {
        var dt = new Date(parseInt(dtE[1], 10));
        return dt;
    }
    return null;
}
function hi() {
    var k = $(".currentTranslationId").val();
    $.ajax({
        type: "GET",
        url: "/Home/GetAllComments",
        data: { id: k },
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            for (var i = 0; i < data.length; i++) {
                data[i].commentDate = ConvertStringToJSDate(data[i].commentDate);
            }

            var array2 = data;
            $('#commentList').loadTemplate($('#commentTemplate'), array2);

        },
        error: function (xhr, err) {
            //alert("vesen");
        }
    });
}