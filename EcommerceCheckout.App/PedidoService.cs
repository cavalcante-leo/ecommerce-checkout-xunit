using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceCheckout.App
{
    public class PedidoService
    {
        private int valorFidalidade = 10;
        private int pontosPorValorFildade = 2;
        private int valorMinFreteGratis = 200;

        public string GerarCodigoRastreio(string regiao, int numeroPedido)
        { return $"{regiao}-{numeroPedido:D4}"; }
        public int CalcularPontosFidelidade(int valor)
        { 
            int totalPontos = 0;
            
            if(valor < valorFidalidade)
            { return totalPontos; }

            int totalParcelas = valor / valorFidalidade;
            totalPontos = totalParcelas * pontosPorValorFildade;

            return totalPontos; 
        }
        public bool TemDireitoAFreteGratis(int valorTotal, bool isClienteVIP)
        {
            if (valorTotal >= valorMinFreteGratis || isClienteVIP)
            { return true; }
            else 
            { return false; }
        }
    }
}