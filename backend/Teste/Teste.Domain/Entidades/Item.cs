using System;
using System.ComponentModel.DataAnnotations;

namespace Teste.Domain.Entidades
{
    public class Item
    {
        public int Id { get; set; }
        //[RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem válida. (gif,jpg, jpeg, bmp ou png)")]
        public string Imagem { get; set; }

        public int NumItem { get; set; }
        
        public string Grupo { get; set; }
        
        public string SubGrupo { get; set; }
        
        public string CentroDeCusto { get; set; }
      
        public string ItemDesc { get; set; }
        public string Localizacao { get; set; }
        public string Frota { get; set; }
     
        public int TaxaDepreciacao { get; set; }
     
        public int VidaUtilEstimada { get; set; }
 
        public int NotaFiscalEntrada { get; set; }
       
        public string Fornecedor { get; set; }
     
        public string DataEntrada { get; set; }

        public string DataEmissao { get; set; }
    
        public int ValorAquisicao { get; set; }
       
        public int ICMS { get; set; }
   
        public int PIS { get; set; }
     
        public int COFINS { get; set; }

        public bool CIAP { get; set; }
 
        public bool IsValidated { get; set; }
    }
}
