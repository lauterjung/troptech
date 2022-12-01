import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InventoryProduct } from './product/product.model';

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    private api: string = 'http://localhost:5000/api/product';

    constructor(private httpClient: HttpClient) { }

    public saveProduct(inventoryProduct: InventoryProduct): Observable<boolean> {
        return this.httpClient.post<boolean>(`${this.api}`, inventoryProduct);
    }

    public getProduct(id: string): Observable<InventoryProduct> {
        return this.httpClient.get<InventoryProduct>(`${this.api}/` + id);
    }

    public getAllProducts(): Observable<InventoryProduct[]> {
        return this.httpClient.get<InventoryProduct[]>(`${this.api}`);
    }

    public getVisibleProducts(): Observable<InventoryProduct[]> {
        return this.httpClient.get<InventoryProduct[]>(`${this.api}/visible`);
    }

    public updateProduct(inventoryProduct: InventoryProduct): Observable<boolean> {
        return this.httpClient.patch<boolean>(`${this.api}`, inventoryProduct);
    }

    public deleteProduct(id: string): Observable<boolean> {
        return this.httpClient.delete<boolean>(`${this.api}/` + id);
    }
}