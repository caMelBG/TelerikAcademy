function solve() {
    var root = document.getElementById("root"),
        itemsControl = document.createElement("DIV"),
        addButton = document.createElement("INPUT"),
        addControls = document.createElement("DIV"),
        searchControls = document.createElement("DIV"),
        resultControls = document.createElement("DIV"),
        addLabel = document.createElement("LABEL"),
        addInput = document.createElement("INPUT"),
        searchLabel = document.createElement("LABEL"),
        searchButton = document.createElement("INPUT"),
        searchInput = document.createElement("INPUT");

    root.appendChild(itemsControl);
    addLabel.textContent = "Enter text";
    searchLabel.textContent = "Search";
    addButton.className = "button";
    addButton.type = "submit";
    addButton.value = "Add";
    searchButton.className = "button";
    searchButton.type = "submit";
    searchButton.value = "Go";
    itemsControl.className = "items-control";
    searchControls.className = "search-controls";
    resultControls.className = "result-controls";
    addControls.className = "add-controls";
    addControls.appendChild(addLabel);
    addControls.appendChild(addInput);
    addControls.appendChild(addButton);
    searchControls.appendChild(searchLabel);
    searchControls.appendChild(searchInput);
    searchControls.appendChild(searchButton);
    itemsControl.appendChild(addControls);
    itemsControl.appendChild(searchControls);
    itemsControl.appendChild(resultControls);

    addButton.onclick = function () {
        var listItem = document.createElement("DIV");
        var deleteBtn = document.createElement("INPUT");
        var itemText = document.createElement("STRONG");
        deleteBtn.className = "button";
        deleteBtn.type = "submit";
        deleteBtn.value = "X";
        listItem.className = "list-item";
        itemText.textContent = addInput.value;
        listItem.appendChild(deleteBtn);
        listItem.appendChild(itemText);
        resultControls.appendChild(listItem);
    };

    searchButton.onclick = function () {
        var searchedText = searchInput.value;
        var listItems = resultControls.getElementsByClassName("list-item");
        for (var index = 0; index < listItems.length; index++) {
            if (listItems[index].textContent.indexOf(searchedText) != -1) {
                listItems[index].style.display = "";
            } else {
                listItems[index].style.display = "none";
            }
        }
    };

    resultControls.onclick = function (element) {
        if (element.target.className == "button") {
            element.target.parentElement.outerHTML = "";
        }
    };
}
