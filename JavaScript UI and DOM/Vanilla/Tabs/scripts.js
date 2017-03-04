function makeTabs (selector) {
    var tabsContainer = document.getElementById(selector),
        tabItems = tabsContainer.getElementsByClassName("tab-item");

    showCurrentTab(tabItems[0]);

    tabsContainer.setAttribute("class", "tabs-container");

    tabsContainer.onclick = function (element) {
        showCurrentTab(element.target.parentElement);
    }

    function showCurrentTab(element) {
        for (var index = 0; index < tabItems.length; index++) {
            var tabItemContent = tabItems[index].getElementsByClassName("tab-item-content")[0];
            tabItemContent.style.display = "none";
            tabItems[index].className = "tab-item";
        }

        element.className = "tab-item current";
        element.getElementsByClassName("tab-item-content")[0].style.display = "";
    }
};
