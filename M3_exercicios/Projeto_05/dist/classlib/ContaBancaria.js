var ContaBancaria = /** @class */ (function () {
    function ContaBancaria(numero, agencia, cpf) {
        this._numero = numero;
        this._agencia = agencia;
        this._cpf = cpf;
        this._saldo = 0;
    }
    Object.defineProperty(ContaBancaria.prototype, "numero", {
        get: function () {
            return this._numero;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(ContaBancaria.prototype, "agencia", {
        get: function () {
            return this._agencia;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(ContaBancaria.prototype, "tipo", {
        get: function () {
            return this._tipo;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(ContaBancaria.prototype, "cpf", {
        get: function () {
            return this._cpf;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(ContaBancaria.prototype, "saldo", {
        get: function () {
            return this._saldo;
        },
        enumerable: false,
        configurable: true
    });
    ContaBancaria.prototype.sacar = function (quantidade) {
        if (quantidade > this.saldo) {
            return false;
        }
        else {
            this._saldo -= quantidade;
            return true;
        }
    };
    ContaBancaria.prototype.depositar = function (quantidade) {
        this._saldo += quantidade;
        return true;
    };
    return ContaBancaria;
}());
