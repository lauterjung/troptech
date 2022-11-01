class Salesman extends Employee {
    private _commissionPercentage: number;
    private _department: Department;

    constructor(name: string, salary: number, department: Department, commissionPercentage: number) {
        super(name, salary);
        this._department = department;
        this._commissionPercentage = commissionPercentage;
    }

    public get commissionPercentage(): number {
        return this._commissionPercentage;
    }

    public set commissionPercentage(commissionPercentage: number) {
        this._commissionPercentage = commissionPercentage;
    }

    public get salary(): number {
        return this._salary * (1 + this._commissionPercentage);
    }
}