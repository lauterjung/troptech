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
    public status: OrderStatus;
    public orderCustomer?: Customer;
    public products: Product[];
    public orderDateTime: Date;

    constructor(id: number, status: OrderStatus, products: Product[], orderDateTime: Date, orderCustomer?: Customer) {
        this.id = id;
        this.status = status;
        this.orderCustomer = orderCustomer;
        this.products = products;
        this.orderDateTime = orderDateTime;
    }
}