$(document).ready(function () {

    var table =
    $("#postcommenttable").DataTable(
        {
            ajax: {
                url: "/api/postcomments",
                dataSrc: "",
                data: {
                    postID: $("#postID").val()
                }
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
                },
                {
                    data: "id",
                    render: function (data, type, comment) {

                        if (comment.canBeDeleted === 1) {
                            return "<button class='btn-link js-delete' data-comment-id=" + data + ">Delete</button>";
                        }                            
                        else {
                            return "";
                        }                            
                    }
                }
            ]
        }
    );

    $("#postcommenttable").on("click", ".js-delete", function () {

        var button = $(this);

        if (confirm("Are you sure you want to delete this comment?")) {
            $.ajax({
                url: "/api/postcomments/" + button.attr("data-comment-id"),
                method: "DELETE",
                success: function () {
                    table.row(button.parents("tr")).remove().draw();
                },
                error: function () {
                    toastr.error("Something unexpected happened.");
                }
            });
        }
    });
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
            toastr.success("Comment successfully recorded.");            
            $("#txtAddComment").empty();
            $('#postcommenttable').DataTable().ajax.reload();
        },
        error: function () {
            toastr.error("Something unexpected happened.");
        }
    });
}