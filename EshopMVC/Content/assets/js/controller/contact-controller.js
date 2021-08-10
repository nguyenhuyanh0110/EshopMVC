var contact = {
    init: function () {
        contact.registerEvents();
    },

    registerEvents: function () {
        $('#send-contact').off('click').on('click', function () {
            var name = $('#txtname').val();
            var phone = $('#txtphone').val();
            var email = $('#txtemail').val();
            var message = $('#txtmessage').val();
            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    phone: phone,
                    email: email,
                    message: message
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Đã gửi thông tin liên hệ')
                        contact.resetValue();
                    }
                }
            });
        })
    },
    resetValue: function () {
        $('#txtname').val('');
        $('#txtphone').val('');
        $('#txtemail').val('');
        $('#txtmessage').val('');
    }
}
contact.init();