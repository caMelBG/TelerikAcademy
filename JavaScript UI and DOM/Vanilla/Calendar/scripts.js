function createCalendar(selector, events) {
    var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

    var currDate = new Date(),
        date = new Date(currDate.getFullYear(), currDate.getMonth(), 1),
        dayOfWeek = date.getDay(),
        monthIndex = date.getMonth(),
        year = date.getFullYear(),
        maxDaysPerMonth = daysInMonth(monthIndex + 1, year),
        maxDaysPerWeek = 7,
        calendarContainer = document.querySelector(selector),
        table = document.createElement("TABLE"),
        tableBody = document.createElement("TBODY"),
        tableRow = document.createElement("TR");

    if (dayOfWeek > 0) {
        for (var index = 0; index < dayOfWeek; index++) {
            var emptyTableData = document.createElement("TD");
            emptyTableData.setAttribute("id", "empty-table-data");
            tableRow.appendChild(emptyTableData);
        }
    }

    for (var index = 1; index <= maxDaysPerMonth; index++) {
        var tableData = document.createElement("TD");
        var dateTitle = document.createElement("DIV");
        dateTitle.setAttribute("class", "date-title");
        dateTitle.innerText =
            WEEK_DAY_NAMES[(index + dayOfWeek - 1) % maxDaysPerWeek].toString() + " " +
            index.toString() + " " +
            MONTH_NAMES[monthIndex].toString() + " " +
            year;

        var dateEvents = document.createElement("DIV");
        for (var e = 0; e < events.length; e++) {
            if (events[e].date == index.toString()) {
                dateEvents.innerText = events[e].hour + " " + events[e].title;
            }
        }

        tableData.appendChild(dateTitle);
        tableData.appendChild(dateEvents);
        tableRow.appendChild(tableData);

        if ((index + dayOfWeek) % maxDaysPerWeek == 0 || index == maxDaysPerMonth) {
            tableBody.appendChild(tableRow);
            tableRow = document.createElement("TR");
        }
    }

    table.appendChild(tableBody);
    calendarContainer.appendChild(table);

    function daysInMonth(month, year) {
        return new Date(year, month, 0).getDate();
    }
}