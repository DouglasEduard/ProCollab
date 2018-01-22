$(document).ready(function () {

        $("#poststable").DataTable(
            {
                ajax: {
                    url: "/api/posts",
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
                        data: "title"
                    },
                    {
                        data: "category.description"
                    },
                    {
                        data: "id",
                        render: function (data, type, post) {
                            return "<a href='/posts/Details/" + post.id + "'>" + "Details" + "</a>";                            
                        }
                    }
                ]
            }
        );
});