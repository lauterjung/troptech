import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

import { Observable } from "rxjs";

import { Product } from "./products.model";

@Injectable()
export class ProductService {
    private api: string = 'https://localhost:7145';

    constructor(private httpClient: HttpClient) { }

    public saveProduct(product: Product): Observable<boolean> {
        return this.httpClient.post<boolean>(`${this.api}/Product`, product);
    }

    public getProducts(): Observable<Product[]> {
        return this.httpClient.get<Product[]>(`${this.api}/Product`);
    }
}