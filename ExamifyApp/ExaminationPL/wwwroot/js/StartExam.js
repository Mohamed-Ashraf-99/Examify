document.getElementById("current-date").innerText = getCurrentDate();

function getCurrentDate() {
    var currentDate = new Date();
    var dd = String(currentDate.getDate()).padStart(2, '0');
    var mm = String(currentDate.getMonth() + 1).padStart(2, '0'); // January is 0!
    var yyyy = currentDate.getFullYear();
    return dd + '-' + mm + '-' + yyyy;
}
