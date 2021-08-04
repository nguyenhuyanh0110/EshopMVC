var cart = {
    init: function () {
        cart.regEvent();
    },
    regEvent: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });

        $('.input-number').off('click').on('click', function () {
            var quantity = $('.txtQuantity');
            var CartList = [];
            $.each(quantity, function (i, item) {
                CartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        PRODUCTID: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Cart/IncreaseQuantity',
                data: { CartModel: JSON.stringify(CartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href="/order"
                    }
                }
            })
        })

        $('.icon-delete').off('click').on('click', function () {
            $.ajax({
                data: { Id: $(this).data('id') },
                url: '/Cart/DeleteItem',
                type: 'POST',
                dataType: 'json',
                success: function(res) {
                    if (res.status = true) {
                        window.location.href = "/order";
                    }
                }
            })
        })
    }
}
cart.init();