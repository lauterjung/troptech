class CarWash {
    private _car: Car;
    private _washingType: WashingType;
    private _price: number;

    constructor(car: Car, washingType: WashingType) {
        this._car = car;
        this._washingType = washingType;
    }

    public get car(): Car {
        return this._car;
    }

    public set car(car: Car) {
        this._car = car;
    }

    public get washingType(): WashingType {
        return this._washingType;
    }

    public set washingType(washingType: WashingType) {
        this._washingType = washingType;
    }

    public get price(): number {
        if (this._washingType === WashingType.Luxo) {
            return 65;
        } else if (this._washingType === WashingType.Polimento) {
            return 45;
        } else {
            return 25;
        }
    }

    // public set price(price: number) {
    //     this._price = price;
    // }
}
