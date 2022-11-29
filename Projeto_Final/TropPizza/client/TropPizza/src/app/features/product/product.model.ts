export class Product {

    public id: number;
    public name: string;
    public description: string;
    public isActive: boolean;
    public expirationDate: Date;
    public quantity: number;
    public unitPrice: number;
    public imagePath: string;
    public totalPrice: number;
    public isVisible: boolean;
    // hasImage
    
    constructor(id: number, name: string, description: string, isActive: boolean, expirationDate: Date, quantity: number, unitPrice: number, imagePath: string, totalPrice: number, isVisible: boolean,) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.isActive = isActive;
        this.expirationDate = expirationDate;
        this.quantity = quantity;
        this.unitPrice = unitPrice;
        this.imagePath = imagePath;
        this.totalPrice = totalPrice;
        this.isVisible = isVisible;
    }
}