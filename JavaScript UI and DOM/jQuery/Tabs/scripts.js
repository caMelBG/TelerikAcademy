$.fn.tabs = function () {
    var tabsContainer = $(this);
    tabsContainer.addClass("tabs-container");
    var tabItems = tabsContainer.children(".tab-item");
    var fistTab = tabItems.first();
    showCurrItem(fistTab);

    tabItems.on("click", function () {
        var currItem = $(this);
        showCurrItem(currItem);
    });

    function showCurrItem(currItem) {
        var otherItems = tabsContainer.children(".tab-item");

        otherItems.removeClass("current");
        currItem.addClass("current");

        otherItems.children(".tab-item-content").hide();
        currItem.children(".tab-item-content").show();
    }

    return tabsContainer;
};