using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Constants
{
    public static class CargoCustomerMessages
    {
        // Success Messages
        public const string CargoCustomerCreated = "Cargo customer successfully created.";
        public const string CargoCustomerUpdated = "Cargo customer successfully updated.";
        public const string CargoCustomerDeleted = "Cargo customer successfully deleted.";
        public const string CargoCustomerFetched = "Cargo customer details fetched successfully.";

        // Error Messages
        public const string CargoCustomerNotFound = "Cargo customer not found.";
        public const string CargoCustomerCreationFailed = "Failed to create cargo customer.";
        public const string CargoCustomerUpdateFailed = "Failed to update cargo customer.";
        public const string CargoCustomerDeleteFailed = "Failed to delete cargo customer.";
        public const string ServerError = "An internal server error occurred.";

        // Validation Messages
        public const string InvalidModelState = "The provided model is invalid.";
    }
}
