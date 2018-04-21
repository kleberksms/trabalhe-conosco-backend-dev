using System.Collections.Generic;

namespace PicPay.Application.ViewModel.HAL
{
    /**
     * O Dot Net Framework não promove um middleware para responsa com HALJson nativo,
     * assim tem que completar com pacote de terceiro e fazer uma abstração de resposta
     */
    public class ListItemsInHalJsonViewModel
    {
        public int Total { get; set; }
        public int TotalPerPage { get; set; }
        public object Content { get; set; }
        public string ContentListName { get; set; }
        public string ItemRouter { get; set; }
        public string SelfRouter { get; set; }
        public Dictionary<string, string> Paramters { get; set; }
    }
}
