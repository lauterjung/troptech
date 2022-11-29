import { Customer } from "../customer/customer.model";
import { Product } from "../product/product.model";

enum OrderStatus {
    Pending = 0,
    Preparation = 1,
    Delivery = 2,
    Finished = 3
}

export class Order {
    public id: number;
    public orderStatus: OrderStatus;
    public customer?: Customer;
    public products: Product[];
    public orderDateTime: Date;

    constructor(id: number, orderStatus: OrderStatus, products: Product[], orderDateTime: Date, customer?: Customer) {
        this.id = id;
        this.orderStatus = orderStatus;
        this.customer = customer;
        this.products = products;
        this.orderDateTime = orderDateTime;
    }
}