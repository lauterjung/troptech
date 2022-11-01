var Aluno = /** @class */ (function () {
    function Aluno(nome, idade) {
        var _this = this;
        this.ativar = function () {
            _this.ativo = true;
        };
        this.desativar = function () {
            _this.ativo = false;
        };
        this.gerarMatricula = function () {
            return 'A' + Math.floor(Math.random() * 9999);
        };
        this._nome = nome;
        this._idade = idade;
        this._ativo = true;
    }
    Object.defineProperty(Aluno.prototype, "nome", {
        get: function () {
            return this._nome;
        },
        set: function (nome) {
            this._nome = nome;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Aluno.prototype, "idade", {
        get: function () {
            return this._idade;
        },
        set: function (idade) {
            this._idade = idade;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Aluno.prototype, "ativo", {
        get: function () {
            return this._ativo;
        },
        set: function (ativo) {
            this._ativo = ativo;
        },
        enumerable: false,
        configurable: true
    });
    return Aluno;
}());
