﻿$(function () {
    $('input[name$=BornYear]').on('change', function () {
        szuletesiEvChange($(this));
    });
    $('#PosztId').on('change', function () {
        setRadio();
    });
});

$(document).ready(function () {
    $('.js-example-basic-single').select2();
});

function Cancel() {
    window.location = window.location.protocol + "/Home/About";
}

function szuletesiEvChange(control) {
    var ev = control.val();
    var aktev = new Date().getFullYear();
    $('input[name$=Age]').val(aktev - ev);
}

function checkRadio(groupName, value) {
    var radio = $('input:radio[name=' + groupName + '][value=' + value + ']');
    radio.prop('checked', true);
    radio.prev('.btn').trigger('click');
}

function submitForm() {
    var poszt;
    switch ($('input[id$=Poszt]').val()) {
        case 'Kapus':
            poszt = 0;
            break;
        case 'Védő':
            poszt = 1;
            break;
        case 'Középpályás':
            poszt = 2;
            break;
        case 'Csatár':
            poszt = 3;
            break;
        default:
            poszt = -1;
    }
    if (poszt !== -1) {
        var myData = { CsapatId: $('input[id$=CsapatId]').val(), Name: $('input[name$=Name]').val(), PosztId: poszt, BornYear: $('input[name$=BornYear]').val(), Age: $('input[name$=Age]').val() };
        $.ajax({
            type: 'POST',
            url: window.location.origin + '/Player/Add',
            data: { model: myData }
        }).done(function (data) {
            switch ($('input[id$=CsapatId]').val()) {
                case '0':
                    window.location = window.location.protocol + "/Player/FelnottIndex";
                    break;
                case '1':
                    window.location = window.location.protocol + "/Player/IfjusagiIndex";
                    break;
                case '2':
                    window.location = window.location.protocol + "/Player/NoiIndex";
                    break;
                default:
                    window.location = window.location.protocol + "/Home/About";
                    break;
                // code block
            }

        }).fail(function (data) { window.alert('Sikertelen mentés!'); });
    }
    else {
        window.alert('A poszt mezőben rossz érték van megadva! (Kapus,Védő,Középpályás,Csatár');
    }
}

function submitFormEdit() {
    var poszt;
    switch ($('input[id$=Poszt]').val()) {
        case 'Kapus':
            poszt = 0;
            break;
        case 'Védő':
            poszt = 1;
            break;
        case 'Középpályás':
            poszt = 2;
            break;
        case 'Csatár':
            poszt = 3;
            break;
        default:
            poszt = -1;
    }
    if (poszt !== -1) {
        var myData = { Id: $('input[id$=Id]').val(), CsapatId: $('input[id$=CsapatId]').val(), Name: $('input[name$=Name]').val(), PosztId: poszt, BornYear: $('input[name$=BornYear]').val(), Age: $('input[name$=Age]').val() };
        $.ajax({
            type: 'POST',
            url: window.location.origin + '/Player/Edit',
            data: { pm: myData }
        }).done(function (data) {
            switch ($('input[id$=CsapatId]').val()) {
                case '0':
                    window.location = window.location.protocol + "/Player/FelnottIndex";
                    break;
                case '1':
                    window.location = window.location.protocol + "/Player/IfjusagiIndex";
                    break;
                case '2':
                    window.location = window.location.protocol + "/Player/NoiIndex";
                    break;
                default:
                    window.location = window.location.protocol + "/Home/About";
                    break;
                // code block
            }

        }).fail(function (data) { window.alert('Sikertelen mentés!'); });
    } else {
        window.alert('A poszt mezőben rossz érték van megadva! (Kapus,Védő,Középpályás,Csatár)');
    }
}