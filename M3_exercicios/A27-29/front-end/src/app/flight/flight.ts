import { Ticket } from "../ticket/ticket"

export class Flight {
    id?: number
    clientCpf: string
    isRoundTrip: boolean
    originTicket: Ticket
    returnTicket?: Ticket
    isActive: boolean

    constructor(clientCpf: string, originTicket: Ticket, isActive: boolean, returnTicket?: Ticket) {
        this.clientCpf = clientCpf;
        this.isRoundTrip = returnTicket? true : false;
        this.originTicket = originTicket;
        this.returnTicket = returnTicket;
        this.isActive = isActive;
    }
}