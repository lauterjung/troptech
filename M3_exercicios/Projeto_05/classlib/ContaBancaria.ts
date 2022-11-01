class ContaBancaria {
    protected _numero: string;
    protected _agencia: string;
    protected _tipo: TipoConta;
    protected _cpf: string;
    protected _saldo: number;

    constructor(numero: string, agencia: string, cpf: string) {
        this._numero = numero;
        this._agencia = agencia;
        this._cpf = cpf;
        this._saldo = 0;
    }

    public get numero(): string {
        return this._numero;
    }

    public get agencia(): string {
        return this._agencia;
    }

    public get tipo(): TipoConta {
        return this._tipo;
    }

    public get cpf(): string {
        return this._cpf;
    }

    public get saldo(): number {
        return this._saldo;
    }

    public sacar(quantidade: number): boolean {
        if (quantidade > this.saldo) {
            return false;
        } else {
            this._saldo -= quantidade;
            return true;
        }
    }

    public depositar(quantidade: number): boolean {
            this._saldo += quantidade;
            return true;
    }

}