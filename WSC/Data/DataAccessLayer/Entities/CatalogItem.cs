using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class CatalogItem
    {
        public Guid CatalogItemId { get; set; }
        public string ItemName { get; set; }
        public string Manufacturer { get; set; }
        public int NumberInscriptionLines { get; set; }
        public int NumberLineCharacters { get; set; }
        public decimal ItemCost { get; set; }
        public decimal ItemRetailPrice { get; set; }
        public int InscriptionTypeId { get; set; }
    }
}
