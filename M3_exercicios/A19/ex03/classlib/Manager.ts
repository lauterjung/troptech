class Manager extends Employee{
    private _department: Department;

    constructor(name: string, salary: number, department: Department) {
        super(name, salary);
        this._department = department;
    }

    public get department(): Department {
        return this._department;
    }

    public set department(department: Department) {
        this._department = department;
    }

    // public get salary(): number {
    //     return this._salary * (1 + this._commissionPercentage);
    // }
}