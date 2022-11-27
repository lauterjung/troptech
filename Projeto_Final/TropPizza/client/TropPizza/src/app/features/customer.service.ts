import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from './customer/customer.model';

@Injectable({
    providedIn: 'root'
})
export class CustomerService {
    private api: string = 'http://localhost:5000/api/customer';

    constructor(private httpClient: HttpClient) { }

    public saveCustomer(customer: Customer): Observable<boolean> {
        return this.httpClient.post<boolean>(`${this.api}`, customer);
    }

    public getCustomerById(id: string): Observable<Customer> {
        return this.httpClient.get<Customer>(`${this.api}/` + id);
    }

    public getCustomerByCpf(cpf: string): Observable<Customer> {
        return this.httpClient.get<Customer>(`${this.api}/cpf/` + cpf);
    }

    public getAllCustomers(): Observable<Customer[]> {
        return this.httpClient.get<Customer[]>(`${this.api}`);
    }

    public updateCustomer(customer: Customer): Observable<boolean> {
        return this.httpClient.patch<boolean>(`${this.api}`, customer);
    }

    public deleteCustomer(id: string): Observable<Customer> {
        return this.httpClient.delete<boolean>(`${this.api}/` + id);
    }
}