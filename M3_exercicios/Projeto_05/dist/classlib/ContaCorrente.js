var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var ContaCorrente = /** @class */ (function (_super) {
    __extends(ContaCorrente, _super);
    function ContaCorrente(numero, agencia, cpf, limite) {
        var _this = _super.call(this, numero, agencia, cpf) || this;
        _this._limite = limite;
        _this._tipo = TipoConta.ContaCorrente;
        return _this;
    }
    Object.defineProperty(ContaCorrente.prototype, "saldo", {
        get: function () {
            return this._saldo + this._limite;
        },
        enumerable: false,
        configurable: true
    });
    return ContaCorrente;
}(ContaBancaria));
