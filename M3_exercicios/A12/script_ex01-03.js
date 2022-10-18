// // ex 01

// var a = 2;
// var b = 3;
// var c = 4;

// // comum
// function function_type1(a, b, c) {
//     return (a + b) * c - (c + a) / 2;
// }
// const result_type1 = function_type1(a, b, c);

// //IIFE
// const result_type2 = function (a, b, c) {
//     return (a + b) * c - (c + a) / 2;
// }(2, 3, 4)

// //arrow
// const result_type3 = (a = 2, b = 3, c = 4) => { return (a + b) * c - (c + a) / 2; }

// console.log(result_type1);
// console.log(result_type2);
// console.log(result_type3());

// // ex 02
// var numerosAleatorios = [12, 45, 55, 65, 77, 98, 43, 33, 28, 61, 75];

// // ex 02a
// var numerosPares = numerosAleatorios.filter(numerosAleatorios => numerosAleatorios % 2 === 0);
// var numerosImpares = numerosAleatorios.filter(numerosAleatorios => numerosAleatorios % 2 !== 0);

// console.log(numerosPares);
// console.log(numerosImpares);

// // ex 02b
// numerosAleatorios.forEach(element => {
//     if (element > 50) {
//         console.log(element);
//     };
// });

// // ex 02c
// sortedList = numerosAleatorios.sort((a,b) => b-a);
// console.log(sortedList);

// // ex 02d
// function substituteFunction(x) {
//     return x < 50 ? 0 : x;
// }

// newList = numerosAleatorios.map(function substituteFunction(x) {
//     return x < 50 ? 0 : x;});
//     console.log(newList);

// newList = numerosAleatorios.map(substituteFunction);
//     console.log(newList);

// newList = numerosAleatorios.map((x) => {
//     return x < 50 ? 0 : x;});
// console.log(newList);

// // ex 02e
// searchedElement = numerosAleatorios.find(numerosAleatorios => numerosAleatorios === 98);
// console.log(searchedElement);

// ex 03
function cronometer() {
    let time = 0;

    let interval = setInterval(() => {
        time += 1;

        if(time === 59) {
            clearInterval(interval);
        }
        
        document.querySelector("#chronometer").textContent = `Tempo: ${time} s`;

    }, 1000);
}

cronometer();