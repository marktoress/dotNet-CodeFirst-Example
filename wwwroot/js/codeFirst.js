$(document).ready(function () {

    $('#sentData').on('click', function () {
        let person = {};
        person.name = $('#name').val();
        person.age = $('#age').val();
        GoBD(person);
    });

    function GoBD(user) {
        if (user != null) {
            $.ajax({
                url: 'http://localhost:51214/write/getDataDB',
                method: 'POST',
                data: user,
                success: function (response) {
                    if (response == 1) {
                        ShowCurrentMessage("Данные сохранены успешно", true);
                    }
                    else {
                        ShowCurrentMessage("Ошибка! Данные не были отправлены", false);
                    }
                },
                error: function () {
                    ShowCurrentMessage("Ошибка запроса", false);
                }
            });
        }
    }
    function ClearFields() {
        $('#name').val('');
        $('#age').val('');
        $('#currentMessage').text('');
    }

    function ClearCurrentMessage() {
        setTimeout(ClearFields, 2000);
    }

    function ShowCurrentMessage(message, success) {
        if (success) {
            $('#currentMessage').css('color', 'green').text(message);
        }
        else {
            $('#currentMessage').css('color', 'red').text(message);
        }
        ClearCurrentMessage();
    }
});