import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

import { Observable } from "rxjs";
import { Flight } from "./flight";

@Injectable()
export class FlightService {
    private api: string = 'https://localhost:7145';

    constructor(private httpClient: HttpClient) { }

    public saveFlight(flight: Flight): Observable<boolean> {
        return this.httpClient.post<boolean>(`${this.api}/Flight`, flight);
    }

    public getFlights(): Observable<Flight[]> {
        return this.httpClient.get<Flight[]>(`${this.api}/Flight`);
    }
}