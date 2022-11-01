class Car {
    private _brand: string;
    private _licensePlate: string;
    private _owner: string;

    constructor(brand: string, licensePlate: string, owner: string) {
        this._brand = brand;
        this._licensePlate = licensePlate;
        this._owner = owner;
    }

    public get brand(): string {
        return this._brand;
    }

    public set brand(brand: string) {
        this._brand = brand;
    }

    public get licensePlate(): string {
        return this._licensePlate;
    }

    public set licensePlate(licensePlate: string) {
        this._licensePlate = licensePlate;
    }

    public get owner(): string {
        return this._owner;
    }

    public set owner(owner: string) {
        this._owner = owner;
    }
}