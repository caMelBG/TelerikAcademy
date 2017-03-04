function createGallery(selector, imagesPerRow) {
    var gallery = document.getElementById(selector),
        galleryList = gallery.getElementsByClassName("gallery-list")[0];
        selected = gallery.getElementsByClassName("selected"),
        imageContainer = gallery.getElementsByClassName("image-container"),
        previousImage = gallery.getElementsByClassName("previous-image")[0],
        currentImage = gallery.getElementsByClassName("current-image")[0],
        nextImage = gallery.getElementsByClassName("next-image")[0];

    groupImages();
    hideSelectedImages();
    gallery.className = "gallery";


    galleryList.onclick = function (element) {
        var index = element.target.getAttribute("data-info");
        updateImagesSource(index);

        var backgroundDisabled = document.createElement("DIV");
        backgroundDisabled.className = "disabled-background";
        gallery.appendChild(backgroundDisabled);

        galleryList.className += " blurred";
    };

    previousImage.onclick = function () {
        var prevImg = previousImage.getElementsByTagName("img")[0];
        var index = prevImg.getAttribute("data-info");
        updateImagesSource(index);
    };

    nextImage.onclick = function () {
        var nextImg = nextImage.getElementsByTagName("img")[0];
        var index = nextImg.getAttribute("data-info");
        updateImagesSource(index);
    };

    currentImage.onclick = function () {
        hideSelectedImages();

        var backgroundDisabled = gallery.getElementsByClassName("disabled-background")[0];
        gallery.removeChild(backgroundDisabled);
        galleryList.className = "gallery-list";
    }

    function updateImagesSource(currentIndex) {
        currentIndex = parseInt(currentIndex);
        var previousIndex = getPreviusImageIndex(currentIndex);
        var nextIndex = getNextImageIndex(currentIndex);

        var prevImg = previousImage.getElementsByTagName("IMG")[0];
        var currImg = currentImage.getElementsByTagName("IMG")[0];
        var nextImg = nextImage.getElementsByTagName("IMG")[0];

        prevImg.setAttribute("src", "imgs/" + previousIndex.toString() + ".jpg");
        currImg.setAttribute("src", "imgs/" + currentIndex.toString() + ".jpg");
        nextImg.setAttribute("src", "imgs/" + nextIndex.toString() + ".jpg");

        prevImg.setAttribute("data-info", previousIndex.toString());
        currImg.setAttribute("data-info", currentIndex.toString());
        nextImg.setAttribute("data-info", nextIndex.toString());

        showSelectedImages();
    }

    function getNextImageIndex(currentIndex) {
        currentIndex++;
        if (currentIndex > imageContainer.length) {
            currentIndex = 1;
        }

        return currentIndex;
    }

    function getPreviusImageIndex(currentIndex) {
        currentIndex--;
        if (currentIndex == 0) {
            currentIndex = imageContainer.length;
        }

        return currentIndex;
    }

    function groupImages() {
        for (var index = 0; index < imageContainer.length; index++) {
            if (index % imagesPerRow == 0) {
                imageContainer[index].className += " clearfix";
            }
        }
    }

    function hideSelectedImages() {
        for (var index = 0; index < selected.length; index++) {
            selected[index].style.display = "none";
        }
    }

    function showSelectedImages() {
        for (var index = 0; index < selected.length; index++) {
            selected[index].style.display = "";
        }
    }
}