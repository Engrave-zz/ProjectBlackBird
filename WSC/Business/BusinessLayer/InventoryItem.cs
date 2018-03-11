// Date created 5/30/14
// Author: Adam Fike
// Description: This class represents an Inventoy Item object.  An Inventory Item is any item that is sold by WSC.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Enumerations;
using DataAccessLayer;

namespace BusinessLayer
{
    public class InventoryItem : CatalogItem
    {
        // class variables, getters & setters
        internal Guid _inventoryItemId;
        public Guid InventoryItemId { get { return _inventoryItemId; } set { _inventoryItemId = value; } }
        internal InventoryItemStatus _inventoryItemStatus;
        public InventoryItemStatus InventoryItemStatus { get { return _inventoryItemStatus; } set { _inventoryItemStatus = value; } }
        public new Guid CatalogItemId { get { return base.CatalogItemId; } set { base.CatalogItemId = value; } }
        public Guid OrderId { get; set; }        
        public new InscriptionType InscriptionType { get { return base.InscriptionType; } set { base.InscriptionType = value; } }
        public new string ItemName { get { return base.ItemName; } set { base.ItemName = value; } }
        public new string Manufacturer { get { return base.Manufacturer; } set { base.Manufacturer = value; } }
        public new int NumberInscriptionLines { get { return base.NumberInscriptionLines; } set { base.NumberInscriptionLines = value; } }
        public new int NumberLineCharacters { get { return base.NumberLineCharacters; } set { base.NumberLineCharacters = value; } }
        public new decimal ItemCost { get { return base.ItemCost; } set { base.ItemCost = value; } }
        public new decimal ItemRetailPrice { get { return base.ItemRetailPrice; } set { base.ItemRetailPrice = value; } }
        public new int NumberInStock { get { return base.NumberInStock; } set { base.NumberInStock = value; } }


        // constructor with zero arguments
        public InventoryItem(Guid catalogItemId)
            : base(catalogItemId)
        {
            _inventoryItemId = new Guid();            
        }

        // constructor for NEW Inventory Item - This constructor creates a GUID for the new Item
        public InventoryItem(string inventoryItemName, 
                             Guid catalogItemId, InventoryItemStatus inventoryItemStatus, string itemManufacturer, int numberInscriptionLines,
                             int numberLineCharacters, decimal itemCost, decimal itemRetailPrice, InscriptionType inscriptionType)
            : base(catalogItemId)
        {
            _inventoryItemId = Guid.NewGuid();
            InventoryItemStatus _inventoryItemStatus = inventoryItemStatus;
            base.ItemName = inventoryItemName;
            base.CatalogItemId = catalogItemId;
            base.Manufacturer = itemManufacturer;
            base.NumberInscriptionLines = numberInscriptionLines;
            base.NumberLineCharacters = numberLineCharacters;
            base.ItemCost = itemCost;
            base.ItemRetailPrice = itemRetailPrice;
            base.InscriptionType = inscriptionType;
        }

        // constructor for loading an EXISTING Inventory Item - This constructor DOES NOT create a new GUID
        public InventoryItem(Guid inventoryItemId, InventoryItemStatus inventoryItemStatus, string inventoryItemName, int numberInStock,
                             Guid catalogItemId, string itemManufacturer, int numberInscriptionLines,
                             int numberLineCharacters, decimal itemCost, decimal itemRetailPrice, InscriptionType inscriptionType)
            : base(catalogItemId)
        {
            _inventoryItemId = inventoryItemId;
            InventoryItemStatus _inventoryItemStatus = inventoryItemStatus;
            base.ItemName = inventoryItemName;
            base.CatalogItemId = catalogItemId;
            base.Manufacturer = itemManufacturer;
            base.NumberInscriptionLines = numberInscriptionLines;
            base.NumberLineCharacters = numberLineCharacters;
            base.ItemCost = itemCost;
            base.ItemRetailPrice = itemRetailPrice;
            base.InscriptionType = inscriptionType;
        }

        // My equivalent of a ToString method.  This will return a string list with each string in the list
        // containing one of the inventory item's attributes, to be used to display an inventory item into 
        // a textbox, etc.
        public new List<string> ToItemDescription()
        {
            List<string>  itemDescription = new List<string>();
            itemDescription.Add("Item ID: " + _inventoryItemId.ToString());
            itemDescription.Add("Item Name: " + ItemName);
            itemDescription.Add("Number In Stock: " + NumberInStock.ToString());
            itemDescription.Add("Catalog ID: " + CatalogItemId.ToString());
            itemDescription.Add("Item Manufacturer: " + Manufacturer);
            itemDescription.Add("Number of Inscription Lines: " + NumberInscriptionLines.ToString());
            itemDescription.Add("Characters Per Line: " + NumberLineCharacters.ToString());
            itemDescription.Add("Item Cost: " + ItemCost.ToString("C"));
            itemDescription.Add("Retail Price: " + ItemRetailPrice.ToString("C"));
            itemDescription.Add("Inscription Type: " + InscriptionType.ToString());
            itemDescription.Add("Inventory Item Status: " + _inventoryItemStatus.ToString());

            return itemDescription;
        }

        public new void UpdateNumberInStock()
        {
            base.UpdateNumberInStock();
        }
    }
}
