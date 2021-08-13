var base = {
    init: function () {
        base.registerEvent();
    },

    registerEvent: function () {
        $("#search-id").autocomplete({
            minLength: 0,
            source: function (req, res) {
                $.ajax({
                    url: '/ProductClient/SearchItem',
                    dataType: 'json',
                    data:
                    {
                        q: req.term
                    },
                    success: function (respone) {
                        res(respone.data)
                    }
                })
            },
            focus: function (event, ui) {
                $("#search-id").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#search-id").val(ui.item.label);
                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<div>" + item.label + "</div>")
                    .appendTo(ul);
            };
    }
}
base.init();