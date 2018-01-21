$(document).ready(function () {

    var table =
        $("#poststable").DataTable(
            {
                ajax: {
                    url: "/api/posts",
                    dataSrc: ""
                },
                searching: true,
                //"dom": '<"top"i>rt<"bottom"flp><"clear">',
                "dom": '<"pull-left"f><"pull-right"l> tip',                
                "bLengthChange": false,
                columns: [
                    {
                        data: "title",
                        render: function (data, type, post) {
                            return "<a href='/posts/edit/'" + post.id + "'>" + post.title + "</a>";
                        }
                    },
                    {
                        data: "category.description"
                    },
                    {
                        data: "id",
                        render: function (data) {
                            return "<button class='btn-link js-delete' data-post-id=" + data + ">Delete</button>";
                        }
                    }
                ]
            }
        );


    $("#poststable").on("click", ".js-delete", function () {

        var button = $(this);

        if (confirm("Are you sure you want to delete this post?")) {
            $.ajax({
                url: "/api/posts/" + button.attr("data-post-id"),
                method: "DELETE",
                success: function () {
                    table.row(button.parents("tr")).remove().draw();
                }
            });
        }
    });
});