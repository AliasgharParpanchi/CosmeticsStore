
$(document).ready(function () {
    $('#backButton').click(function () {
        window.history.back();
    });
});

function inputEmail() {

    var hasMessage = $('#messageId').text() == "" ? false : true;

    if (hasMessage) {
        $('#error').removeClass('hidden');
    }
    else {
        $('#error').addClass('hidden');
    }
}

function validEmail() {
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    var email = $('#EmailIn').val();

    if (email.match(regex)) {
        $('#subBtn').removeAttr('disabled');
    }
    else {
        $('#subBtn').attr({ 'disabled': 'disabled' });
    }
}

function validPassword() {

    var hasMessage = $('#messageError').text() == "" ? false : true;

    if (hasMessage) {
        $('#error').removeClass('hidden');
    }
    else {
        $('#error').addClass('hidden');
    }
    validAgainPassword();
    disableBtn();
}

function validAgainPassword() {

    var hasError = !($('#PasswordAgain').val() == $('#PasswordIn').val());

    if (hasError) {
        $('#error1').removeClass('hidden');
        $('#messageError1').text('رمز ورود مطابقت ندارد');

    }
    else {
        $('#error1').addClass('hidden');
        $('#messageError1').text('');
    }
    disableBtn();
}

function disableBtn() {
    if ($('#error1').hasClass('hidden') &&
        $('#error').hasClass('hidden') &&
        $('#PasswordAgain').val() != '' &&
        $('#PasswordIn').val() != '') {

        $('#subBtn').removeAttr('disabled');
    }
    else {
        $('#subBtn').attr({ 'disabled': 'disabled' });
    }

}

function disableLoginBtn() {
    if ($('#PasswordIn').val().length > 4) {
        $('#subBtn').removeAttr('disabled');
    }
    else {
        $('#subBtn').attr({ 'disabled': 'disabled' });
    }
}