// ex 01
{
    let nome = "Miguel";
    let idade = 29;
    let ativo = true;
    let dataDeNascimento = new Date(1992, 10, 16);
    let matricula = 123;
    let universidade = "UDESC";
    let altura = 1.83;
    let peso = 84;

    console.log(nome);
    console.log(idade);
    console.log(ativo);
    console.log(dataDeNascimento);
    console.log(matricula);
    console.log(universidade);
    console.log(altura);
    console.log(peso);
}

{
    let nome = "Água";
    let descrição = "Sem gás";
    let preco = 2.5;
    let dataDeValidade = new Date(2023, 12, 12);
    let codigo = 1;
    let quantidadeEstoque = 5;
    let fornecedor = "Puris";
    let existeNoEstoque = true;

    console.log(nome);
    console.log(descrição);
    console.log(preco);
    console.log(dataDeValidade);
    console.log(codigo);
    console.log(quantidadeEstoque);
    console.log(fornecedor);
    console.log(existeNoEstoque);
}

{
    let nome = "Peugeot 360";
    let modelo = "P-360";
    let placa = "ABC-1234";
    let anoFabricacao = 2020;
    let anoModelo = 2015;
    let fabricante = "Peugeot";
    let tipo = "Carro";
    let licenciado = true;

    console.log(nome);
    console.log(modelo);
    console.log(placa);
    console.log(anoFabricacao);
    console.log(anoModelo);
    console.log(fabricante);
    console.log(tipo);
    console.log(licenciado);
}

// ex 02
{
    let arrayNumerico = [8.5, 7.9, 8.5, 5.6, 5.2, 3.1, 5, 7.9, 1.7, 8.2];
    let arrayPessoas = ["Brandon Goodman", "Emery Vincent", "Clara Carey", "Rogelio Hughes", "Andreas Hayes", "Kylan Whitney", "Jasper Henry", "Arjun Adkins", "Ishaan Rojas", "Paul Ortiz"];
    let arrayCarros = [
        { chassi: "8ZU j2L6gD yZ 1K8917", placa: "ABC-1234", ano: 2020 },
        { chassi: "6xa FXfTAw Fe 9A8412", placa: "ABC-1235", ano: 2022 },
        { chassi: "66A Nz205K D5 bd1974", placa: "ABC-1236", ano: 2021 },
        { chassi: "7Ya 6AmHMK 4w z42244", placa: "ABC-1237", ano: 2005 },
        { chassi: "1A4 SZuGAJ l5 xW2477", placa: "ABC-1238", ano: 2008 },
        { chassi: "6Al ULlkg4 B3 HL5800", placa: "ABC-1239", ano: 2005 },
        { chassi: "5Lt 08pw06 gf 3e1553", placa: "ABC-1240", ano: 2008 },
        { chassi: "8L5 C5v8Aj 4B HB1118", placa: "ABC-1241", ano: 2003 },
        { chassi: "87U 4jGVHf 7n gH6213", placa: "ABC-1242", ano: 2017 },
        { chassi: "2A4 ab35cp 23 yh0879", placa: "ABC-1243", ano: 2019 }
    ];

    console.log(arrayNumerico);
    console.log(arrayPessoas);
    console.log(arrayCarros);
}

// ex 03
{
let dia = 31;
let mes = 10-1; // outubro
let ano = 2022;
let data = new Date(ano, mes, dia)

console.log("Data completa: " + data);
console.log("Dia da semana: " + data.getDay());
console.log("Dia: " + data.getDate());
console.log("Mês: " + (data.getMonth()+1));
console.log("Ano: " + data.getFullYear());
}

// Data completa: Mon Oct 31 2022 00:00:00 GMT-0300 (GMT-03:00)
// Dia da semana: 1
// Dia: 31
// Mês: 10
// Ano: 2022