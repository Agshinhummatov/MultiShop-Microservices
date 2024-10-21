using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Constants
{
    public static class CargoCompanyMessages
    {
        // Success Messages
        public const string CargoCompanyCreated = "Cargo company successfully created.";
        public const string CargoCompanyUpdated = "Cargo company successfully updated.";
        public const string CargoCompanyDeleted = "Cargo company successfully deleted.";
        public const string CargoCompanyFetched = "Cargo company details fetched successfully.";

        // Error Messages
        public const string CargoCompanyNotFound = "Cargo company not found.";
        public const string CargoCompanyCreationFailed = "Failed to create cargo company.";
        public const string CargoCompanyUpdateFailed = "Failed to update cargo company.";
        public const string CargoCompanyDeleteFailed = "Failed to delete cargo company.";
        public const string ServerError = "An internal server error occurred.";

        // Validation Messages
        public const string InvalidModelState = "The provided model is invalid.";
    }
}
