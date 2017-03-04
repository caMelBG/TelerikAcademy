function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        // you are welcome :)
        var date = new Date();
        console.log(date.getDayName());
        console.log(date.getMonthName());
        ///////////////////////////////////



        var $this = $(this);
        var root = $this.parent();
        var rootHtml = root.html();
        root.empty();

        root.append("<div class=\"datepicker-wrapper\"></div>");

        var datePickerWrapper = root.children(".datepicker-wrapper");
        datePickerWrapper.append(rootHtml);
        datePickerWrapper.append("<div class=\"picker\"></div>");

        var picker = datePickerWrapper.children(".picker");
        picker.append("<div class=\"controls\"></div>");
        picker.append("<div class=\"current-date\"></div>");
        picker.append("<table class=\"calendar\"></table>");

        //
        initTable();
        //

        var currDate = picker.children(".current-date");
        currDate.append("<div class=\"current-date-link\"></div>");
        var currDateLink = currDate.children(".current-date-link");
        currDateLink.append(date.getDay() + " " + date.getMonthName() + " " + date.getYear());


        var controls = picker.children(".controls");
        controls.append("<div class=\"current-month\"></div>");
        controls.append("<div class=\"btn\"></div>");

        var inputTag = datePickerWrapper.children("#date");
        inputTag.addClass("datepicker");

        inputTag.on("click", function () {
            picker.addClass("picker-visible");
            picker.toggleClass('picker-visible');
        });

        function initTable() {
            var table = picker.children(".calendar");
            var tableHead = "<thead>";
            var tableBody = "<tbody>";
            for (var i = 0; i < 7; i++) {
                tableHead = tableHead + "<th>" + WEEK_DAY_NAMES[i] + "</th>"
            }

            tableHead = tableHead + "</thead>";
            table.append(tableHead);

            for (var i = 0; i < 6; i++) {
                var tableRowString = "<tr>";
                var tableDataString = "";
                for (var j = 0; j < 7; j++) {
                    tableDataString = tableDataString + "<td>";
                    tableDataString = tableDataString + j.toString();
                    tableDataString = tableDataString + "</td>";
                }

                tableRowString = tableRowString + tableDataString + "</tr>";
                console.log(tableRowString);
                tableBody = tableBody + tableRowString;
                console.log(table.html());
            }

            tableBody = tableBody + "</tbody>";
            table.append(tableBody);
        }

        return $this;
    };
};