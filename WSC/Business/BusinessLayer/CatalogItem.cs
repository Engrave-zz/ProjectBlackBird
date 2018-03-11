using System;
using System.Collections.Generic;
using BusinessLayer.Enumerations;
using DataAccessLayer;

namespace BusinessLayer
{
    public class CatalogItem
    {
        public CatalogItem(Guid catalogItemId)
        {
            CatalogItemId = catalogItemId;
            UpdateNumberInStock();
        }

        public Guid CatalogItemId { get; set; }
        public string ItemName { get; set; }
        public string Manufacturer { get; set; }
        public int NumberInscriptionLines { get; set; }
        public int NumberLineCharacters { get; set; }
        public decimal ItemCost { get; set; }
        public decimal ItemRetailPrice { get; set; }
        public InscriptionType InscriptionType { get; set; }
        public int NumberInStock { get; set; }

        public void UpdateNumberInStock()
        {
            DataAccessObjects _dataAccessLayer = new DataAccessObjects();
            NumberInStock = _dataAccessLayer.GetCatalogItemStockCount(CatalogItemId);
        }

        // My equivalent of a ToString method.  This will return a string list with each string in the list
        // containing one of the inventory item's attributes, to be used to display an inventory item into 
        // a textbox, etc.
        public List<string> ToItemDescription()
        {
            List<string>  itemDescription = new List<string>();
            itemDescription.Add("Catalog Item ID: " + CatalogItemId.ToString());
            itemDescription.Add("Item Name: " + ItemName);
            itemDescription.Add("Number In Stock: " + NumberInStock.ToString());
            itemDescription.Add("Item Manufacturer: " + Manufacturer);
            itemDescription.Add("Number of Inscription Lines: " + NumberInscriptionLines.ToString());
            itemDescription.Add("Characters Per Line: " + NumberLineCharacters.ToString());
            itemDescription.Add("Item Cost: " + ItemCost.ToString("C"));
            itemDescription.Add("Retail Price: " + ItemRetailPrice.ToString("C"));
            itemDescription.Add("Inscription Type: " + InscriptionType.ToString());

            return itemDescription;
        }
    }
}
