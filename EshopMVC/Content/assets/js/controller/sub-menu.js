var subMenu = {
    init: function () {
        subMenu.registerEvent();
    },

    registerEvent: function () {
        $('#ProductCategory').change(function () {
            $('#SubMenu').empty();
            var category = $('#ProductCategory').val();
            $.ajax({
                url: '/Product/SubMenu',
                type: 'POST',
                data:
                {
                    id: category
                },
                success: function (res) {
                    if (res.status == true) {
                        $.each(res.id, function (i, value) {
                            /* $('#SubMenu').append("<option>" + value + " - " + res.SubName[i] + "</option>");*/
                            $('#SubMenu').append($('<option>', {
                                value: value,
                                text: value +' - '+ res.SubName[i]
                            }));
                        });
                    }
                }
            })
        })
    },

    resetValue: function () {
        $('#SubMenu').append('');
    }
}
subMenu.init()