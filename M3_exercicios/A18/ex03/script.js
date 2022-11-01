var taskList = document.getElementById("taskList");
var formSubmitButton = document.getElementById("formSubmitButton");
var Task = /** @class */ (function () {
    function Task(number, description, isUrgent) {
        this.number = number;
        this.description = description;
        this.isUrgent = isUrgent;
    }
    Task.prototype.toString = function () {
        return "".concat(this.number, " - ").concat(this.description, " - ").concat(this.isUrgent ? "Sim" : "Não");
    };
    return Task;
}());
function createTask() {
    var numberElement = document.getElementById("taskNumber");
    var descriptionElement = document.getElementById("taskDescription");
    var isUrgentElement = document.getElementById("urgentCheckbox");
    var number = parseFloat(numberElement.value);
    var description = descriptionElement.value;
    var isUrgent = isUrgentElement.checked;
    return new Task(number, description, isUrgent);
}
function addToList(task) {
    var li = document.createElement("li");
    li.appendChild(document.createTextNode(task.toString()));
    taskList.appendChild(li);
}
;
formSubmitButton.addEventListener('click', function (event) {
    event.preventDefault();
    event.stopPropagation();
    addToList(createTask());
});
