var register = {
    init: function () {
        register.registerEvents();
    },

    registerEvents: function () {
        $('#register').off('click').on('click', function () {
            var name = $('#name').val();
            var email = $('#email').val();
            var phone = $('#phone').val();
            var password = $('#password').val();
            var ConfirmPassword = $("#confirm").val();
            $.ajax({
                url: '/Register/CreateUser',
                type: 'POST',
                dataType: 'json',
                data:{
                    name : name,
                    email: email,
                    phone : phone,
                    password: password,
                    ConfirmPassword: ConfirmPassword
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Đăng ký tài khoản thành công')
                        register.resetValue();
                    }
                    else if (res.status == false)
                    {
                        window.alert('Đăng ký không thành công');
                        register.resetValue();
                    }
                }
            })
        })
    },

    resetValue: function () {
        $('#name').val('');
        $('#email').val('');
        $('#password').val('');
        $('#confirm-password').val('');
    }
}
register.init();