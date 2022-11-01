var Car = /** @class */ (function () {
    function Car(brand, licensePlate, owner) {
        this._brand = brand;
        this._licensePlate = licensePlate;
        this._owner = owner;
    }
    Object.defineProperty(Car.prototype, "brand", {
        get: function () {
            return this._brand;
        },
        set: function (brand) {
            this._brand = brand;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Car.prototype, "licensePlate", {
        get: function () {
            return this._licensePlate;
        },
        set: function (licensePlate) {
            this._licensePlate = licensePlate;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Car.prototype, "owner", {
        get: function () {
            return this._owner;
        },
        set: function (owner) {
            this._owner = owner;
        },
        enumerable: false,
        configurable: true
    });
    return Car;
}());
