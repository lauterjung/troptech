import { Customer } from "../customer/customer.model";
import { CartProduct, Product } from "../product/product.model";

enum OrderStatus {
    Pending = 0,
    Preparation = 1,
    Delivery = 2,
    Finished = 3
}

export class Order {
    public id: number;
    public statusEnum: OrderStatus;
    public status: string;
    public orderCustomer?: Customer;
    public cartProducts: Product[];
    public orderDateTime: Date;
    public totalPrice: number;

    constructor(id: number, statusEnum: OrderStatus, status: string, cartProducts: Product[], orderDateTime: Date, totalPrice: number, orderCustomer?: Customer) {
        this.id = id;
        this.statusEnum = statusEnum;
        this.status = status;
        this.orderCustomer = orderCustomer;
        this.cartProducts = cartProducts;
        this.orderDateTime = orderDateTime;
        this.totalPrice = totalPrice;
    }
}