function FormChanges(formNameId) {
    var form = $('#'+formNameId);
    if (!form || !form.nodeName || form.nodeName.toLowerCase() !== "form") {
        // Megkeresem
        form = $('#content-body form');
        form = form[0];
        if (!form || !form.nodeName || form.nodeName.toLowerCase() !== "form") return false;
    }
    var dropClasses = [
        'select2-chosen',
        'select2-focusser',
        'select2-input'
    ];

    var changedCtrl = [];
    var changed = false;
    for (var e = 0, el = form.elements.length; e < el; e++) {
        var ctrl = form.elements[e];
        var c = false;
        var id = ctrl.getAttribute('Id');
        if (id !== null && id.includes('999999')) break;
        var def, o, ol, opt;
        switch (ctrl.nodeName.toLowerCase()) {
            // select boxes
            case 'select':
                def = 0;
                for (o = 0, ol = ctrl.options.length; o < ol; o++) {
                    opt = ctrl.options[o];
                    c = c || (opt.selected !== opt.defaultSelected);
                    if (opt.defaultSelected) def = o;
                }
                if (ctrl.getAttribute('data-kodtetel')) {
                    c = (ctrl.getAttribute('aria-invalid') === 'false');
                    break;
                }
                if (c && !ctrl.multiple) c = (def !== ctrl.selectedIndex);
                break;
            case 'textarea':
            case 'input':
                switch (ctrl.type.toLowerCase()) {
                    case 'checkbox':
                    case 'radio':
                        //c = (ctrl.checked != ctrl.defaultChecked);
                        break;
                    default:
                        var dropped = false;
                        for (var i = 0; i < dropClasses.length; i++) {
                            if (ctrl.classList.contains(dropClasses[i])) {
                                dropped = true;
                                break;
                            }
                        }

                        if (dropped) {
                            break;
                        }

                        if (ctrl.classList.contains('select2-offscreen')) {
                            c = (ctrl.getAttribute('data-modified') === 'true');
                            break;
                        }
                        if (ctrl.className === 'ui-pg-input') {
                            break;
                        }
                        // standard values
                        c = (ctrl.value !== ctrl.defaultValue);
                        break;
                }
                break;
        }
        if (c) changedCtrl.push(ctrl);
    }
    return (changedCtrl.length > 0);
}