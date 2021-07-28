(function ($) {
    "use strict";
    $("#basicScenario").jsGrid({
        width: "100%",
        filtering: true,
        editing: true,
        inserting: true,
        sorting: true,
        paging: true,
        autoload: true,
        pActionSize: 15,
        pActionButtonCount: 5,
        loadIndication: true,
        loadIndicationDelay: 500,
        loadMessage: "Đang thực hiện lấy dữ liệu...",
        loadShading: true,
        deleteConfirm: function (item) {
            return "Do you really want to delete \"" + item.CATEGORYNAME + "\" ?";
        },
        controller: {
            loadData: function (filter) {
                return $.ajax({
                    type: "GET",
                    url: "/Category/GetCategory",
                    dataType: "json",
                    data: filter
                });
            },
            updateItem: function (item) {
                return $.ajax({
                    type: "POST",
                    url: "/Category/Edit",
                    data: item,
                    dataType: "json",
                    success: function () {
                        alert('Cập nhật danh mục thành công');
                        $("#basicScenario").jsGrid("loadData");
                    }
                });
            },
            deleteItem: function (item) {
                return $.ajax({
                    type: "POST",
                    url: "/Category/Delete",
                    data: item,
                    success: function () {
                        alert('Xóa danh mục thành công');
                        $("#basicScenario").jsGrid("loadData");
                    }
                });
            }
        },
        fields: [
            { name: "CATEGORYID", type: "text", title: "Mã số", width: 50, editing: false, readOnly: true },
            { name: "CATEGORYNAME", type: "text", title: "Tên", width: 100, validate: "required", autosearch: true },
            { type: "control" }
        ]
    });
})(jQuery);
