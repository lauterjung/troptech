using System;
using TropPizza.Domain.Exceptions.ProductExceptions;


namespace TropPizza.Domain.Features.Products
{
    public class InventoryProduct : Product
    {
        public bool IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
#nullable enable
        public string? ImageName { get; set; }
        public bool HasImage
        {
            get { return CheckHasImage(); }
        }
        public double TotalPrice
        {
            get { return CalculateTotalPrice(); }
        }
        public bool IsVisible
        {
            get { return CheckVisibility(); }
        }

        public InventoryProduct()
        {
            IsActive = true;
            Quantity = 0;
        }

        public double CalculateTotalPrice()
        {
            return Quantity * UnitPrice;
        }

        public void AddToInventory(int quantity)
        {
            Quantity += quantity;
        }

        public void RemoveFromInventory(int quantity)
        {
            if (quantity > Quantity)
            {
                throw new InsufficientQuantity();
            }

            Quantity -= quantity;
        }

        private bool CheckVisibility()
        {
            return (IsActive && Quantity > 0) ? true : false;
        }

        private bool CheckHasImage()
        {
            return !String.IsNullOrEmpty(ImageName) ? true : false;
        }

        private bool CheckValidName()
        {
            return !String.IsNullOrEmpty(Name) ? true : false;
        }

        private bool CheckValidDescription()
        {
            return Description.Length >= 3 ? true : false;
        }

        private bool CheckValidUnitPrice()
        {
            return UnitPrice > 0 ? true : false;
        }

        private bool CheckValidExpirationDate()
        {
            return ExpirationDate > DateTime.Now.Date ? true : false;
        }

        private bool CheckValidQuantity()
        {
            return Quantity >= 0 ? true : false;
        }

        public bool Validate()
        {
            if (CheckValidName() == false)
            {
                throw new InvalidName();
            }
            if (CheckValidDescription() == false)
            {
                throw new InvalidDescription();
            }
            if (CheckValidUnitPrice() == false)
            {
                throw new InvalidUnitPrice();
            }
            if (CheckValidExpirationDate() == false)
            {
                throw new InvalidExpirationDate();
            }
            if (CheckValidQuantity() == false)
            {
                throw new InvalidQuantity();
            }

            return true;
        }
    }
}