function bejelentkezes() {
    var username = $('#UserName').val();
    var pswd = $('#Password').val();
    
    $.ajax({
        url: window.location.origin + '/Login/GetFelhasznalo',
        data: { username: username, pswd: pswd }
    }).done(function (data) {
        if (data === true || data === 'true' || data == 'True') {
            $('#UserMenu').removeClass('hidden');
            document.getElementById('Felhasznalonev').innerHTML = "Bagó József";
            var bej = document.getElementById('bejelentkezve');
            bej.setAttribute('value', true);
        }
        else {
            window.alert('Sikertelen bejelentkezés!');
            bej.setAttribute('value', false);
        }
        });
}

function logOut() {
    $('#UserMenu').addClass('hidden');
    window.alert('Sikeres kijelentkezés!');
}