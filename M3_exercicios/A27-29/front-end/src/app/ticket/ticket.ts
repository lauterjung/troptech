export class Ticket {
    id: number;
    departureSite: string;
    arrivalSite: string;
    departureDate: string;
    arrivalDate: string;
    isAvailable: boolean;

    constructor(id: number, departureSite: string, arrivalSite: string, departureDate: string, arrivalDate: string, isAvailable: boolean) {
        this.id = id;
        this.departureSite = departureSite;
        this.arrivalSite = arrivalSite;
        this.departureDate = departureDate;
        this.arrivalDate = arrivalDate;
        this.isAvailable = isAvailable; 
    }
    public toString(): string{
        return `${this.departureSite} (${this.departureDate}) - ${this.arrivalSite} (${this.departureDate})`;
    }
}