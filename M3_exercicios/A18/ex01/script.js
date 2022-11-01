var Person = /** @class */ (function () {
    function Person(name, age, weight, height) {
        this.name = name;
        this.age = age;
        this.weight = weight;
        this.height = height;
    }
    Object.defineProperty(Person.prototype, "overweight", {
        get: function () {
            var imc = this.weight / (this.height ^ 2);
            var classification = "";
            if (imc < 18.5) {
                classification = "Magreza";
            }
            else if (imc < 25) {
                classification = "Normal";
            }
            else if (imc < 30) {
                classification = "Sobrepeso";
            }
            else if (imc < 40) {
                classification = "Obesidade";
            }
            else {
                classification = "Obesidade grave";
            }
            return classification;
        },
        enumerable: false,
        configurable: true
    });
    Person.prototype.toString = function () {
        return "teste";
    };
    return Person;
}());
var person1 = new Person("A", 20, 80, 1.80);
var person2 = new Person("A", 20, 80, 1.90);
var person3 = new Person("A", 20, 120, 1.90);
var person4 = new Person("A", 20, 60, 1.80);
console.log(person1);
console.log(person2.toString());
console.log(person3);
console.log(person4);
console.log(person1.overweight);
console.log(person2.overweight);
console.log(person3.overweight);
console.log(person4.overweight);
