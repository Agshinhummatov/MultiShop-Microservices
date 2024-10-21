using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Constants
{
    public static class CargoDetailMessages
    {
        // Success Messages
        public const string CargoDetailCreated = "Cargo detail successfully created.";
        public const string CargoDetailUpdated = "Cargo detail successfully updated.";
        public const string CargoDetailDeleted = "Cargo detail successfully deleted.";
        public const string CargoDetailFetched = "Cargo detail successfully fetched.";

        // Error Messages
        public const string CargoDetailNotFound = "Cargo detail not found.";
        public const string CargoDetailCreationFailed = "Failed to create cargo detail.";
        public const string CargoDetailUpdateFailed = "Failed to update cargo detail.";
        public const string CargoDetailDeleteFailed = "Failed to delete cargo detail.";
        public const string ServerError = "An internal server error occurred.";

        // Validation Messages
        public const string InvalidModelState = "The provided model is invalid.";
    }
}
