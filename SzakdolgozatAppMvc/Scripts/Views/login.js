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

function Cancel() {
    href('Home/Index');
}

function submitForm() {
    if ($('#Pswd').val() !== $('#Pswd2').val())
        window.alert('Nem egyezik a két jelsző');
    else {
        var model = {
            UserName: "Shyju",
            Location: "Detroit",
            Interests: ["Code", "Coffee", "Stackoverflow"]
        };
        var stri = JSON.stringify(model);
        $.ajax(
            {
                type: "POST", //HTTP POST Method  
                url: "Regisztracio", // Controller/View   
                data: { eredmeny: stri },
                processData: false,
                contentType: false,

            });
    } 
}