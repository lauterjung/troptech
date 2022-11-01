var Professor = /** @class */ (function () {
    function Professor(nome, disciplina) {
        var _this = this;
        this.ativar = function () {
            _this.ativo = true;
        };
        this.desativar = function () {
            _this.ativo = false;
        };
        this.gerarMatricula = function () {
            return 'P' + Math.floor(Math.random() * 9999);
        };
        this._nome = nome;
        this._disciplina = disciplina;
        this._ativo = true;
    }
    Object.defineProperty(Professor.prototype, "nome", {
        get: function () {
            return this._nome;
        },
        set: function (nome) {
            this._nome = nome;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Professor.prototype, "disciplina", {
        get: function () {
            return this._disciplina;
        },
        set: function (disciplina) {
            this._disciplina = disciplina;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Professor.prototype, "ativo", {
        get: function () {
            return this._ativo;
        },
        set: function (ativo) {
            this._ativo = ativo;
        },
        enumerable: false,
        configurable: true
    });
    return Professor;
}());
