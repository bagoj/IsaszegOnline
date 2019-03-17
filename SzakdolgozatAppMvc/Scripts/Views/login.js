function bejelentkezes() {
    var username = $('#UserName').val();
    var pswd = $('#Password').val();
    
    $.ajax({
        url: window.location.origin + '/Login/GetFelhasznalo',
        data: { username: username, pswd: pswd }
    }).done(function (data) {
            $('#UserMenu').removeClass('hidden');
            document.getElementById('Felhasznalonev').innerHTML = data.Name;
            var bej = document.getElementById('bejelentkezve');
            bej.setAttribute('value', true);
            bej.innerHTML = "true";
        }).fail(function (data) { window.alert('Sikertelen bejelentkezés!');});
}

function logOut() {
    $('#UserMenu').addClass('hidden');
    window.alert('Sikeres kijelentkezés!');
}