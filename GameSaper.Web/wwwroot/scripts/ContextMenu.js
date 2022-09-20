//Отключение контекстного меню для кнопки и картин
function contextMenu (e) {
    var clickedEl = e.target.localName;
    if (clickedEl == "img" || clickedEl == "button") {
        return false;
    }
}

document.oncontextmenu = contextMenu;