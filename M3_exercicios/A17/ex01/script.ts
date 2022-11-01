
const c_programmingLanguagesList = document.getElementById("programmingLanguagesList")!;
const c_checkboxes = document.querySelectorAll(".form-check-input");

Array.from(c_checkboxes).forEach(checkbox => {
    checkbox.addEventListener('change', function () {
        let str: string = this.value;
        if (this.checked) {
            addCheckBoxChild(str);
        } else {
            removeCheckBoxChild(str)
        }
    })
});

function addCheckBoxChild(str: string): void {
    var li = document.createElement("li");
    li.appendChild(document.createTextNode(str));
    c_programmingLanguagesList.appendChild(li);
};

function removeCheckBoxChild(str: string): void {
    for (let child of c_programmingLanguagesList.children) {
        if (child.textContent === str) {
            c_programmingLanguagesList.removeChild(child);
        }
    }
};