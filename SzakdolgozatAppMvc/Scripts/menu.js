var menuMapping = [];

$(function () {
    dragablefalse();
    markActiveMenuItem();
});

function dragablefalse() {
    $('.sidebar-nav .menu-item .list-group-item').attr('draggable', false);
    $('.sidebar-nav .menu-item .list-group-item').attr('ondragstart', 'return false;');
}

function markActiveMenuItem() {
    var menuItems = $('.sidebar-nav .menu-item .list-group-item');
    var activeMenuItem = getActiveMenuItem(window.location.pathname, menuItems);
    if (activeMenuItem == null) return;
    if (activeMenuItem.length === 0) {
        var end = document.referrer.indexOf('?');
        if (end === -1) end = document.referrer.length;
        activeMenuItem = getActiveMenuItem(window.location.pathname, menuItems);
        if (activeMenuItem == null) return;
    }
    activeMenuItem.addClass('active');
    var lgi = activeMenuItem;
    while (lgi.length > 0) {
        var mi = lgi.parent('.menu-item');
        mi.attr('aria-expanded', true);
        var pc = mi.parent('.panel-collapse');
        pc.addClass('show');
        lgi = pc.prev('.list-group-item');
    }
}

function getActiveMenuItem(mapHrefParam, menuItems) {
    var href = mapHref(mapHrefParam);
    if (href === getBasePath()) return null;
    if (!window.UrlConfig || !window.UrlConfig.config || !window.UrlConfig.config.virtualPath) return null;
    if (href === window.UrlConfig.config.virtualPath || href === window.UrlConfig.config.virtualPath + "/") return null;
    while (href.indexOf('//') > -1) {
        href = href.replace('//', '/');
    }
    var activeMenuItem = menuItems.filter('[href*="' + href + '"]');
    return activeMenuItem;
}

function mapHref(href) {
    return href in menuMapping ?
           menuMapping[href] :
           href.replace('Edit', 'Index');
}

function getOrigin() {
    var virtualPath = "";
    if (window.UrlConfig && window.UrlConfig.config && window.UrlConfig.config.virtualPath) {
        virtualPath = window.UrlConfig.config.virtualPath;
    }
    
    return window.location.protocol + "/" + window.location.host + "/" + virtualPath;
}
function getBasePath() {
    var basePath = window.location.href.substr(getOrigin().length + 1);
    if (basePath === "") {
        basePath = "/";
    }
    return basePath;
}

function collapseMenuNavigate(element) {
    var menuItems = element;
    if (element.next().hasClass('show')) {
        element.next().hide();
        element.next().removeAttribute('style');
    }
    else element.next().show();
}