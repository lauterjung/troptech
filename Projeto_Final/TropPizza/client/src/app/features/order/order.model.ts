import { Customer } from "../customer/customer.model";
import { CartProduct } from "../product/product.model";

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
    public cartProducts: CartProduct[];
    public orderDateTime: Date;
    public totalPrice: number;

    constructor(id: number, statusEnum: OrderStatus, status: string, cartProducts: CartProduct[], orderDateTime: Date, totalPrice: number, orderCustomer?: Customer) {
        this.id = id;
        this.statusEnum = statusEnum;
        this.status = status;
        this.orderCustomer = orderCustomer;
        this.cartProducts = cartProducts;
        this.orderDateTime = orderDateTime;
        this.totalPrice = totalPrice;
    }
}