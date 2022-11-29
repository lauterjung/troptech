export class Customer {
    public id: number;
    public cpf: string;
    public fullName: string;
    public birthDate: Date;
    public address: string;
    public fidelityPoints: number;

    constructor(id: number, cpf: string, fullName: string, birthDate: Date, address: string, fidelityPoints: number) {
        this.id = id;
        this.cpf = cpf;
        this.fullName = fullName;
        this.birthDate = birthDate;
        this.address = address;
        this.fidelityPoints = fidelityPoints;
    }
}