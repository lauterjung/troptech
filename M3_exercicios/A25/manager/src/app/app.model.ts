export class Client {
    public name: string;
    public cpf: string;
    public phoneNumber: string;

    constructor(name: string, cpf: string, phoneNumber: string) {
        this.name = name;
        this.cpf = cpf;
        this.phoneNumber = phoneNumber;
    }
}

export class Product {
    public name: string;
    public price: number;

    constructor(name: string, price: number) {
        this.name = name;
        this.price = price;
    }
}
