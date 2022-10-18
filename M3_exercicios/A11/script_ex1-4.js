// ex 01
let numbersArray = [];
for (let i = 1; i < 101; i++) {
    numbersArray.push(i);
}

// for (let item of numbersArray) {
//     if ((item % 2) === 0) {
//         numbersArray.splice(numbersArray.indexOf(item),1)
//     }
// }

numbersArray.forEach(element => {
    if((element % 2) === 0){
        numbersArray.splice(numbersArray.indexOf(element),1)
    }
});
console.log(numbersArray);

// ex 02
let produtos = "REFRIGERANTE,CERVEJA,CARNE,SABÃO,BALA,IOGURTE,MARCARRÃO,CEBOLA,MAÇÃ,AMACIANTE";
let productItems = produtos.split(",")
console.log(productItems);
productItems.forEach(element => {
    if (element.startsWith("C")){
        console.log(element);
    }});

// ex 03
console.log(productItems.indexOf("CERVEJA"));
console.log(productItems.indexOf("CARNE"));
console.log(productItems.indexOf("MAÇÃ"));
console.log(productItems.indexOf("AMACIANTE"));

// ex 04
let states = ["Acre", "Alagoas", "Amapá", "Amazonas", "Bahia", "Ceará", "Espírito Santo", "Goiás", "Maranhão", "Mato Grosso", "Mato Grosso do Sul", "Minas Gerais", "Pará", "Paraíba", "Paraná", "Pernambuco", "Piauí", "Rio de Janeiro", "Rio Grande do Norte", "Rio Grande do Sul", "Rondônia", "Roraima", "Santa Catarina", "São Paulo", "Sergipe", "Tocantins", "Distrito Federal"];

console.log(states.sort(function (a, b) { return b.length - a.length })[0]);
console.log(states.sort(function (a, b) { return a.length - b.length })[0]);