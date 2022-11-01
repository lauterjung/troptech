const taskList = document.getElementById("taskList")!;
const formSubmitButton = document.getElementById("formSubmitButton")!;

class Task {
    number: number;
    description: string;
    isUrgent: boolean;

    constructor(number: number, description: string, isUrgent: boolean) {
        this.number = number;
        this.description = description;
        this.isUrgent = isUrgent;
    }

    toString(): string {
        return `${this.number} - ${this.description} - ${this.isUrgent ? "Sim" : "Não"}`;
    }
}

function createTask(): Task {
    const numberElement: HTMLInputElement = document.getElementById("taskNumber") as HTMLInputElement;
    const descriptionElement: HTMLInputElement = document.getElementById("taskDescription") as HTMLInputElement;
    const isUrgentElement: HTMLInputElement = document.getElementById("urgentCheckbox") as HTMLInputElement;

    let number: number = parseFloat(numberElement.value);
    let description: string = descriptionElement.value;
    let isUrgent: boolean = isUrgentElement.checked;

    return new Task(number, description, isUrgent);
}

function addToList(task: Task): void {
    var li = document.createElement("li");
    li.appendChild(document.createTextNode(task.toString()));
    taskList.appendChild(li);
};

formSubmitButton.addEventListener('click', event => {
    event.preventDefault();
    event.stopPropagation();
    addToList(createTask());
})
