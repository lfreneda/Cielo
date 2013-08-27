using System;

namespace Cielo.Requests
{
    public class Pedido
    {
        public string Id { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }

        public Pedido(string id, decimal valor, DateTime data, string descricao = "")
        {
            Id = id;
            Valor = valor;
            Data = data;
            Descricao = descricao;
        }
    }
}