var c_programmingLanguagesList = document.getElementById("programmingLanguagesList");
var c_checkboxes = document.querySelectorAll(".form-check-input");
Array.from(c_checkboxes).forEach(function (checkbox) {
    checkbox.addEventListener('change', function () {
        var str = this.value;
        if (this.checked) {
            addCheckBoxChild(str);
        }
        else {
            removeCheckBoxChild(str);
        }
    });
});
function addCheckBoxChild(str) {
    var li = document.createElement("li");
    li.appendChild(document.createTextNode(str));
    c_programmingLanguagesList.appendChild(li);
}
;
function removeCheckBoxChild(str) {
    for (var _i = 0, _a = c_programmingLanguagesList.children; _i < _a.length; _i++) {
        var child = _a[_i];
        if (child.textContent === str) {
            c_programmingLanguagesList.removeChild(child);
        }
    }
}
;
