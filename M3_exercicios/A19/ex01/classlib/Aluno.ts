class Aluno {
    private _nome: string;
    private _idade: number;
    private _ativo: boolean;

    constructor(nome: string, idade: number) {
        this._nome = nome;
        this._idade = idade;
        this._ativo = true;
    }

    public get nome(): string {
        return this._nome;
    }

    public set nome(nome: string) {
        this._nome = nome;
    }

    public get idade(): number {
        return this._idade;
    }

    public set idade(idade: number) {
        this._idade = idade;
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
        return 'A' + Math.floor(Math.random() * 9999);
    }
}