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
                        data: "UserNickName"
                    },
                    {
                        data: "Comment"
                    }
                ]
            }
        );
});