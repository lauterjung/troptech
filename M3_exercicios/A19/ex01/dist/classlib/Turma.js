var Turma = /** @class */ (function () {
    function Turma(sala, ano, professor, alunos) {
        var _this = this;
        this.adicionarAluno = function (aluno) {
            _this.alunos.push(aluno);
        };
        this.removerAluno = function () {
            _this.alunos.pop();
        };
        this._sala = sala;
        this._ano = ano;
        this._professor = professor;
        this._alunos = alunos;
    }
    Object.defineProperty(Turma.prototype, "sala", {
        get: function () {
            return this._sala;
        },
        set: function (sala) {
            this._sala = sala;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Turma.prototype, "ano", {
        get: function () {
            return this._ano;
        },
        set: function (ano) {
            this._ano = ano;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Turma.prototype, "professor", {
        get: function () {
            return this._professor;
        },
        set: function (professor) {
            this._professor = professor;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Turma.prototype, "alunos", {
        get: function () {
            return this._alunos;
        },
        enumerable: false,
        configurable: true
    });
    return Turma;
}());
