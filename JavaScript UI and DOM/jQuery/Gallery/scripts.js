/* globals $ */
$.fn.gallery = function (imagesPerRow) {
    if (imagesPerRow == null) {
        imagesPerRow = 4;
    }

    var galery = this.addClass("gallery");
    var galleryList = this.children(".gallery-list");
    var selected = this.children(".selected");
    var imageContainers = galleryList.children(".image-container").children("img");
    var prevSelectedImage = selected.children(".previous-image").children("#previous-image");
    var currSelectedImage = selected.children(".current-image").children("#current-image");
    var nextSelectedImage = selected.children(".next-image").children("#next-image");
    selected.hide();

    function updateImageInformation(element) {
        function getPrevImageIndex(index) {
            index--;
            if (index == 0) {
                index = 12;
            }

            return index;
        }

        function getNextImageIndex(index) {
            index++;
            if (index > 12) {
                index = 1;
            }

            return index;
        }

        var currImageDataInfo = parseInt(element.attr("data-info"));
        var pervImageDataInfo = getPrevImageIndex(currImageDataInfo);
        var nextImageDataInfo = getNextImageIndex(currImageDataInfo);

        prevSelectedImage.attr("data-info", pervImageDataInfo);
        currSelectedImage.attr("data-info", currImageDataInfo);
        nextSelectedImage.attr("data-info", nextImageDataInfo);

        prevSelectedImage.attr("src", "imgs/" + pervImageDataInfo + ".jpg");
        currSelectedImage.attr("src", "imgs/" + currImageDataInfo + ".jpg");
        nextSelectedImage.attr("src", "imgs/" + nextImageDataInfo + ".jpg");
    }

    imageContainers.on("click", function () {
        galery.append("<div class=\"disabled-background\"></div>");
        galleryList.addClass("blurred");

        updateImageInformation($(this));

        selected.show();
    });

    imageContainers.each(function (index, value) {
        if (index % imagesPerRow == 0) {
            $(value).addClass("clearfix");
        }
    });

    currSelectedImage.on("click", function () {
        selected.hide();
		galleryList.removeClass("blurred");
        $(".disabled-background").remove();
    });

    nextSelectedImage.on("click", function () {
        updateImageInformation($(this));
    });

    prevSelectedImage.on("click", function () {
        updateImageInformation($(this));
    });

    return $(this);
};