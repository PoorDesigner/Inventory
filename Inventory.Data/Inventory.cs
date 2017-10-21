using System;

namespace Inventory.Data
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }

    public class Brand
    {
        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int CategoryName { get; set; }

        public string BrandName { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }

    public class Item
    {
        public int ItemId { get; set; }

        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ItemName { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int AvailableStock { get; set; }

        public int TotalStock { get; set; }
    }
}