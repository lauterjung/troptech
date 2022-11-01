class Poupanca extends ContaBancaria {

    constructor(numero: string, agencia: string, cpf: string) {
        super(numero, agencia, cpf);
        this._tipo = TipoConta.Poupança;
    }
}