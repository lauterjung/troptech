class ContaCorrente extends ContaBancaria {
    private _limite: number;

    constructor(numero: string, agencia: string, cpf: string, limite: number) {
        super(numero, agencia, cpf);
        this._limite = limite;
        this._tipo = TipoConta.ContaCorrente;
    }

    public get saldo(): number {
        return this._saldo + this._limite;
    }
}