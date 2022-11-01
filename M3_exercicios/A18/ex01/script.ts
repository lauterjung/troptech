class Person {
    name: string;
    age: number;
    weight: number;
    height: number;

    constructor(name: string, age: number, weight: number, height: number) {
        this.name = name;
        this.age = age;
        this.weight = weight;
        this.height = height;
    }

    public get overweight(): string {
        let imc: number = this.weight / (this.height ^ 2);
        let classification: string = "";

        if (imc < 18.5) {
            classification = "Magreza";
        } else if (imc < 25) {
            classification = "Normal";
        } else if (imc < 30) {
            classification = "Sobrepeso";
        } else if (imc < 40) {
            classification = "Obesidade";
        } else {
            classification = "Obesidade grave";
        }

        return classification;
    }

    public toString(): string {
        return `teste`;
    }
}

let person1 = new Person("A", 20, 80, 1.80);
let person2 = new Person("A", 20, 80, 1.90);
let person3 = new Person("A", 20, 120, 1.90);
let person4 = new Person("A", 20, 60, 1.80);

console.log(person1);
console.log(person2.toString());
console.log(person3);
console.log(person4);

console.log(person1.overweight);
console.log(person2.overweight);
console.log(person3.overweight);
console.log(person4.overweight);