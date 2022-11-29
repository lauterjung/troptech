import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from './order/order.model';

@Injectable({
    providedIn: 'root'
})
export class OrderService {
    private api: string = 'http://localhost:5000/api/Order';

    constructor(private httpClient: HttpClient) { }

    public saveOrder(order: Order): Observable<boolean> {
        return this.httpClient.post<boolean>(`${this.api}`, order);
    }

    public getOrder(id: string): Observable<Order> {
        return this.httpClient.get<Order>(`${this.api}/` + id);
    }

    public getAllOrders(): Observable<Order[]> {
        return this.httpClient.get<Order[]>(`${this.api}`);
    }

    public deleteOrder(id: string): Observable<boolean> {
        return this.httpClient.delete<boolean>(`${this.api}/` + id);
    }
}