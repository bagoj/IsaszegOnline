$(function () {
    $grid = $("#jqGrid").jqGrid({
        url: '@Url.Action("GetPlayer","Player")',
        mtype: 'GET',
        datatype: 'json',
        colModel: [
            { label: 'Név', name: 'Name' },
            { label: 'Cím', name: 'Address' },
            { label: 'Város', name: 'City' },
        ],
        loadonce: true
    });
});

function getGrid(csapat) {
    $grid = $("#jqGrid").jqGrid({
        url: '@Url.Action("' + csapat + '","Player")',
        mtype: 'GET',
        datatype: 'json',
        colModel: [
            { label: 'Id', name: 'Id', hidden: true },
            { label: 'Név', name: 'Name' },
            { label: 'Poszt', name: 'PosztId' },
            { label: 'Kor', name: 'Age' },
            { label: 'Születési év', name: 'Bornyear' }
        ],
        loadonce: true
    });
}