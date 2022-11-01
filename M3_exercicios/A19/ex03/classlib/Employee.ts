class Employee {
    protected _name: string;
    protected _salary: number;

    constructor(name: string, salary: number) {
        this._name = name;
        this._salary = salary;
    }

    public get name(): string {
        return this._name;
    }

    public set name(name: string) {
        this._name = name;
    }

    public get salary(): number {
        return this._salary;
    }

    public set salary(salary: number) {
        this._salary = salary;
    }
}