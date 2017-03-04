function solve() {
    var root = $("#root");
    var itemsControls = $("<div/>").addClass("items-control").appendTo(root);
    var addControls = $("<div/>").addClass("add-controls").appendTo(itemsControls);
    var addControlsLabel = $("<label/>").html("Enter Text").appendTo(addControls);
    var addControlsInput = $("<input/>").attr("type", "text").appendTo(addControls);
    var button = $("<input/>").attr("type", "submit").attr("value", "Add").addClass("button").appendTo(addControls);
    var searchControls = $("<div/>").addClass("search-controls").appendTo(itemsControls);
    var searchControlsLabel = $("<label/>").html("Search").appendTo(searchControls);
    var searchControlsInput = $("<input/>").attr("type", "text").appendTo(searchControls);
    var resultControls = $("<div/>").addClass("result-controls").appendTo(itemsControls);

    button.on("click", function () {
        var inputText = addControlsInput.val();
        var listItem = $("<div/>").addClass("list-item").html(inputText).appendTo(resultControls);
        $("<input/>").attr("type", "submit").attr("value", "X").addClass("button").appendTo(listItem);
    });

    resultControls.on("click", function (element) {
        $(this).hide();
    });

    searchControlsInput.on("input", function () {
        var searchText = searchControlsInput.val();
        resultControls.children(".list-item").each(function () {
            var $this = $(this);
            if ($this.text().indexOf(searchText) != -1) {
                $this.show();
            } else {
                $this.hide();
            }
        })
    });

    return function (selector, isCaseSensitive) {
    };
}
