$(document).ready(function () {
    $("#postcommenttable").DataTable(
        {
            ajax: {
                url: "/api/postcomments",
                dataSrc: ""
            },
            searching: true,
            "dom": '<"pull-left"f><"pull-right"l> tip <"clear">',
            "bLengthChange": false,
            columns: [
                {
                    data: "userNickName"
                },
                {
                    data: "comment"
                }
            ]
        }
    );
});

function postNewComment() {
    var NewComment = {
            Post_ID: $("#postID").val(),
            Comment: $("#txtAddComment").val()
    };

    $.ajax({
        url: "/api/PostComments",
        method: "post",
        data: NewComment,
        success: function (result) {
            toastr.success("Rentals successfully recorded.");
            $('#postcommenttable').DataTable().ajax.reload();
        }        
    })
}