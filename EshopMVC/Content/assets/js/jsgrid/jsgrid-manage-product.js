(function($) {
    "use strict";
    $("#basicScenario").jsGrid({
        width: "100%",
        filtering: true,
        editing: true,
        inserting: true,
        sorting: true,
        paging: true,
        autoload: true,
        pageIndex: true,
        pActionSize: 15,
        pActionButtonCount: 5,
        deleteConfirm: "Do you really want to delete the client?",
        controller: {
            loadData: function () {
                return $.ajax({
                    type: "GET",
                    url: "/Category/GetCategory",
                    dataType: "json",
                });
            }
        },
        fields: [
            { name: "CATEGORYID", type: "text", title: "Category Id", width: 50 },
            { name: "CATEGORYNAME", type: "text", title: "Category Name" ,width: 100 },
            { type: "control" }
        ]
    });
})(jQuery);
