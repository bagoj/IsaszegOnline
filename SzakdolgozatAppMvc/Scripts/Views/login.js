function bejelentkezes() {
    var username = $('#UserName').val();
    var pswd = $('#Password').val();
    
    $.ajax({
        url: window.location.origin + '/Login/GetFelhasznalo',
        data: { username: username, pswd: pswd }
    }).done(function (data) {
        if (data === true || data === 'true') {
            //itt kéne megcsinálni a profil fület
        }
        else
            //itt nem
        });
}