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
        }
        else window.alert('Sikertelen bejelentkezés!');
            //itt nem
        });
}

function logOut() {
    $('#UserMenu').addClass('hidden');
    window.alert('Sikeres kijelentkezés!');
}