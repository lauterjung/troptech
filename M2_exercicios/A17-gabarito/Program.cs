using System;
using System.Collections;
using System.Collections.Generic;

namespace InterfacesExerc1
{
    class Program
    {
        static void Main(string[] args)
        {
            // A
            try
            {
                var quadradoA = new Quadrado(-4);
                Console.WriteLine("Cenário A: Falhou, não deveria permitir valor negativo para lado do quadrado.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Não é possível criar quadrado com lado negativo.")
                    Console.WriteLine("Cenário A: OK!");
                else
                    Console.WriteLine($"Cenário A: Falhou, o erro esperado não é igual ao recebido: {ex.Message}");
            }

            // B
            try
            {
                var quadradoA = new Quadrado(0);
                Console.WriteLine("Cenário B: Falhou, não deveria permitir valor zerado para lado do quadrado.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Não é possível criar quadrado com lado igual a zero.")
                    Console.WriteLine("Cenário B: OK!");
                else
                    Console.WriteLine($"Cenário B: Falhou, o erro esperado não é igual ao recebido: {ex.Message}");
            }

            // C
            var quadradoC = new Quadrado(5);
            var areaC = quadradoC.CalculaArea();
            if (areaC == 25)
                Console.WriteLine("Cenário C: OK!");
            else
                Console.WriteLine($"Cenário C: Falhou, o resultado esperado é 25 mas o recebido foi {areaC}");

            // D
            var quadradoD = new Quadrado(8.47);
            var areaD = quadradoD.CalculaArea();
            if (areaD == 71.74)
                Console.WriteLine("Cenário D: OK!");
            else
                Console.WriteLine($"Cenário D: Falhou, o resultado esperado é 71.74 mas o recebido foi {areaD}");

            // E
            try
            {
                var retanguloE = new Retangulo(-7, 5);
                Console.WriteLine("Cenário E: Falhou, não deveria permitir valor negativo para base do retângulo.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Não é possível criar retângulo com base negativa.")
                    Console.WriteLine("Cenário E: OK!");
                else
                    Console.WriteLine($"Cenário E: Falhou, o erro esperado não é igual ao recebido: {ex.Message}");
            }

            // F
            try
            {
                var retanguloF = new Retangulo(0, 10);
                Console.WriteLine("Cenário F: Falhou, não deveria permitir valor zerado para base do retângulo.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Não é possível criar retângulo com base zerada.")
                    Console.WriteLine("Cenário F: OK!");
                else
                    Console.WriteLine($"Cenário F: Falhou, o erro esperado não é igual ao recebido: {ex.Message}");
            }

            // G
            try
            {
                var retanguloG = new Retangulo(5, 0);
                Console.WriteLine("Cenário G: Falhou, não deveria permitir valor zerado para altura do retângulo.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Não é possível criar retângulo com altura zerada.")
                    Console.WriteLine("Cenário G: OK!");
                else
                    Console.WriteLine($"Cenário G: Falhou, o erro esperado não é igual ao recebido: {ex.Message}");
            }

            // H
            try
            {
                var retanguloH = new Retangulo(7, -5);
                Console.WriteLine("Cenário H: Falhou, não deveria permitir valor negativo para altura do retângulo.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Não é possível criar retângulo com altura negativa.")
                    Console.WriteLine("Cenário H: OK!");
                else
                    Console.WriteLine($"Cenário H: Falhou, o erro esperado não é igual ao recebido: {ex.Message}");
            }

            // I
            var retanguloI = new Retangulo(9, 10);
            var areaI = retanguloI.CalculaArea();
            if (areaI == 90)
                Console.WriteLine("Cenário I: OK!");
            else
                Console.WriteLine($"Cenário I: Falhou, o resultado esperado é 90 mas o recebido foi {areaI}");

            // J
            var retanguloJ = new Retangulo(9.7, 10.33);
            var areaJ = retanguloJ.CalculaArea();
            if (areaJ == 100.20)
                Console.WriteLine("Cenário I: OK!");
            else
                Console.WriteLine($"Cenário I: Falhou, o resultado esperado é 100.20 mas o recebido foi {areaJ}");

            // K
            try
            {
                var circuloK = new Circulo(-7);
                Console.WriteLine("Cenário K: Falhou, não deveria permitir valor negativo para raio do círculo.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Não é possível criar círculo com raio negativo.")
                    Console.WriteLine("Cenário K: OK!");
                else
                    Console.WriteLine($"Cenário K: Falhou, o erro esperado não é igual ao recebido: {ex.Message}");
            }

            // L
            try
            {
                var circuloL = new Circulo(0);
                Console.WriteLine("Cenário L: Falhou, não deveria permitir valor zerado para raio do círculo.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Não é possível criar círculo com raio zerado.")
                    Console.WriteLine("Cenário L: OK!");
                else
                    Console.WriteLine($"Cenário L: Falhou, o erro esperado não é igual ao recebido: {ex.Message}");
            }

            // M
            var circuloM = new Circulo(5);
            var areaM = circuloM.CalculaArea();

            if (areaM == 78.54)
                Console.WriteLine("Cenário M: OK!");
            else
                Console.WriteLine($"Cenário M: Falhou, resultado deveria ser 78.54 mas é {areaM}");

            // N
            var circuloN = new Circulo(5.33);
            var areaN = circuloN.CalculaArea();

            if (areaN == 89.25)
                Console.WriteLine("Cenário N: OK!");
            else
                Console.WriteLine($"Cenário N: Falhou, resultado deveria ser 89.25 mas é {areaN}");

        }
    }
}
