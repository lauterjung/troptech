export abstract class Product {
    public id: number;
    public name: string;
    public description: string;
    public quantity: number;
    public unitPrice: number;

    constructor(id: number, name: string, description: string, quantity: number, unitPrice: number) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.quantity = quantity;
        this.unitPrice = unitPrice;
    }
}

export class InventoryProduct extends Product {
    public isActive: boolean;
    public expirationDate: Date;
    public imageName: string;
    public isVisible: boolean;
    public hasImage: boolean;

    constructor(id: number, name: string, description: string, isActive: boolean, expirationDate: Date, quantity: number, unitPrice: number, imageName: string, isVisible: boolean, hasImage: boolean) {
        super(id, name, description, quantity, unitPrice);

        this.isActive = isActive;
        this.expirationDate = expirationDate;
        this.quantity = quantity;
        this.unitPrice = unitPrice;
        this.imageName = imageName;
        this.isVisible = isVisible;
        this.hasImage = hasImage;

        super(id, name, description, quantity, unitPrice);
    }
}

export class CartProduct extends Product {
    public totalPrice: number;

    constructor(id: number, name: string, description: string, quantity: number, unitPrice: number, totalPrice: number) {
        super(id, name, description, quantity, unitPrice);

        this.id = id;
        this.name = name;
        this.description = description;
        this.quantity = quantity;
        this.unitPrice = unitPrice;
        this.totalPrice = totalPrice;
    }
}