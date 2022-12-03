import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from './order/order.model';

@Injectable({
    providedIn: 'root'
})
export class OrderService {
    private api: string = 'http://localhost:5000/api/order';

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

    public getLastKey(): Observable<number> {
        return this.httpClient.get<number>(`${this.api}/key`);
    }

    public updateOrder(order: Order): Observable<boolean> {
        return this.httpClient.patch<boolean>(`${this.api}`, order);
    }

    public deleteOrder(id: string): Observable<boolean> {
        return this.httpClient.delete<boolean>(`${this.api}/` + id);
    }
}