namespace A8
{
    public abstract class Voucher
    {
        public abstract double Saldo { get; protected set; }
        public Voucher(){}

        // public override string ToString()
        // {
        //     return $"[{Empresa}]: ${Gasto} utilizado em {Produto} - Saldo restante: {Saldo} ";
        // }

        public void UsarVoucher(double valor)
        {
            if (valor > Saldo)
            {
                System.Console.WriteLine("Saldo insuficiente!");
            }
            else
            {
                Saldo -= valor;
            }
        }


    }
}