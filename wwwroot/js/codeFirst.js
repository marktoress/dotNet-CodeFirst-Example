$(document).ready(function () {

    $('#sentData').on('click', function () {
        let person = {};
        person.name = $('#name').val();
        person.age = $('#age').val();
        GoBD(person);
    });

    $('#getData').on('click', function () {
        GetDataFromDB();
    });

    function GoBD(user) {
        if (user != null) {
            $.ajax({
                url: 'http://localhost:51214/write/saveDataDB',
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(user),
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

    function GetDataFromDB() {
        $.ajax({
            url:'http://localhost:51214/write/getData',
            method: 'GET',
            success: function (persons) {
                ShowData(persons);
            },
            error: function () {
                ShowCurrentMessage("Ошибка запроса", false);
            }
        });
    }

    function ShowData(data) {

        let children = $('#dataFromDB').children();
        for (let i = 0; i < children.length; i++) {
            children[i].remove();
        }

        for (let i = 0; i < data.length; i++) {

            let p = document.createElement('p');
            p.innerText = '';

            p.innerText += `${data[i].name} | `;
            p.innerText += `${data[i].age} `;

            $('#dataFromDB').append(p);
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