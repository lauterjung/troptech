class Professor {
    private _nome: string;
    private _disciplina: string;
    private _ativo: boolean;

    constructor(nome: string, disciplina: string) {
        this._nome = nome;
        this._disciplina = disciplina;
        this._ativo = true;
    }

    public get nome(): string {
        return this._nome;
    }

    public set nome(nome: string) {
        this._nome = nome;
    }

    public get disciplina(): string {
        return this._disciplina;
    }

    public set disciplina(disciplina: string) {
        this._disciplina = disciplina;
    }

    public get ativo(): boolean {
        return this._ativo;
    }

    public set ativo(ativo: boolean) {
        this._ativo = ativo;
    }

    public ativar = () => {
        this.ativo = true;
    };

    public desativar = () => {
        this.ativo = false;
    };

    gerarMatricula = () => {
        return 'P' + Math.floor(Math.random() * 9999);
    }
}