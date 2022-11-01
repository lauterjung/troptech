var CarWash = /** @class */ (function () {
    function CarWash(car, washingType) {
        this._car = car;
        this._washingType = washingType;
    }
    Object.defineProperty(CarWash.prototype, "car", {
        get: function () {
            return this._car;
        },
        set: function (car) {
            this._car = car;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(CarWash.prototype, "washingType", {
        get: function () {
            return this._washingType;
        },
        set: function (washingType) {
            this._washingType = washingType;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(CarWash.prototype, "price", {
        get: function () {
            if (this._washingType === WashingType.Luxo) {
                return 65;
            }
            else if (this._washingType === WashingType.Polimento) {
                return 45;
            }
            else {
                return 25;
            }
        },
        enumerable: false,
        configurable: true
    });
    return CarWash;
}());
