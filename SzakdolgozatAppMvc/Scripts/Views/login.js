

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
        bee = true;
        }).fail(function (data) { window.alert('Sikertelen bejelentkezés!');});
}

function logOut() {
    $('#UserMenu').addClass('hidden');
    bee = false;
    window.alert('Sikeres kijelentkezés!');
}

function Cancel() {
    href('Home/Index');
}

function submitForm() {
    if ($('input[name$=Pswd]').val() !== $('input[name$=Pswd2]').val())
        window.alert('Nem egyezik a két jelsző');
    else {
        var myData = { UserName: $('input[id$=UserName]').val(), Name: $('input[id$=BornName]').val(), Password: $('input[name$=Password]').val(), Address: $('input[name$=Address]').val(), City: $('input[name$=City]').val() };
        
        $.ajax(
            {
                type: "POST", //HTTP POST Method  
                url: "Regisztracio", // Controller/View   
                data: { eredmeny: myData },

            });
    } 
}