import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from './product/product.model';

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    private api: string = 'http://localhost:5000/api/product';

    constructor(private httpClient: HttpClient) { }

    public saveProduct(product: Product): Observable<boolean> {
        return this.httpClient.post<boolean>(`${this.api}`, product);
    }

    public getProduct(id: string): Observable<Product> {
        return this.httpClient.get<Product>(`${this.api}/` + id);
    }

    public getAllProducts(): Observable<Product[]> {
        return this.httpClient.get<Product[]>(`${this.api}`);
    }

    public updateProduct(product: Product): Observable<boolean> {
        return this.httpClient.patch<boolean>(`${this.api}`, product);
    }

    public deleteProduct(id: string): Observable<Product> {
        return this.httpClient.delete<boolean>(`${this.api}/` + id);
    }
}