export class Sale {
    salesId: number;
    price: number;
    clientName: string;

    constructor(salesId: number, price: number, clientName: string) {
        this.salesId = salesId;
        this.price = price;
        this.clientName = clientName;
    }
}