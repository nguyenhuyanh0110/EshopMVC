var filter = {
    init: function () {
        filter.registerEvent();
    },

    registerEvent: function () {
        $('#filter-product :checkbox').change(function () {
            if (this.checked) {
                var id = parseInt(this.value)
                $.ajax({
                    url: '/ProductClient/ListProduct',
                    data: {id : id},
                    type: 'GET',
                    success: function (res) {
                        if (res) {
                            window.location.href = '/san-pham/lap-top-' + id
                        }
                    }
                })
            }
        })
    }
}
filter.init();