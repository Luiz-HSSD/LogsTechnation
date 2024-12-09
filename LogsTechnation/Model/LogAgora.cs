using System;
using System.ComponentModel.DataAnnotations;

namespace LogsTechnation.Model
{
    public class LogAgora
    {
        [Key]
        public long IdLogAgora { get; set; }
        public string log { get; set; }
        public DateTime data { get; set; }

        public string ConverteProAtual(string log)
        {
            var entradas = log.Split("|");
            var retorno = "\"MINHA CDN\" ";

            retorno += entradas[3].Replace("\"","") + " ";

            retorno += Math.Round( double.Parse(entradas[4])) + " ";
            
            retorno += entradas[0] + " ";

            retorno += entradas[2] + Environment.NewLine;
            
            return retorno;
        }
    }
}
