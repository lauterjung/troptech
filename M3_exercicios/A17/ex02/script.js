var dropDownMenu = document.querySelector(".form-select");
var cell_0 = document.getElementById("cell-0");
var cell_1 = document.getElementById("cell-1");
var cell_2 = document.getElementById("cell-2");
dropDownMenu.addEventListener('change', function () {
    resetCells();
    if (dropDownMenu.value == "1") {
        cell_0.style.backgroundColor = "red";
    }
    else if (dropDownMenu.value == "2") {
        cell_1.style.backgroundColor = "yellow";
    }
    else {
        cell_2.style.backgroundColor = "green";
    }
});
function resetCells() {
    cell_0.style.backgroundColor = "rgb(65, 65, 65)";
    cell_1.style.backgroundColor = "rgb(65, 65, 65)";
    cell_2.style.backgroundColor = "rgb(65, 65, 65)";
}
