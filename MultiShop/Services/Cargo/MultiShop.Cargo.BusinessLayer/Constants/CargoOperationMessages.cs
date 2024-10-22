using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Constants
{
    public static class CargoOperationMessages
    {
        // Success Messages
        public const string CargoOperationCreated = "Cargo operation successfully created.";
        public const string CargoOperationUpdated = "Cargo operation successfully updated.";
        public const string CargoOperationDeleted = "Cargo operation successfully deleted.";
        public const string CargoOperationFetched = "Cargo operation successfully fetched.";

        // Error Messages
        public const string CargoOperationNotFound = "Cargo operation not found.";
        public const string CargoOperationCreationFailed = "Failed to create cargo operation.";
        public const string CargoOperationUpdateFailed = "Failed to update cargo operation.";
        public const string CargoOperationDeleteFailed = "Failed to delete cargo operation.";
        public const string ServerError = "An internal server error occurred.";

        // Validation Messages
        public const string InvalidModelState = "The provided model is invalid.";
    }
}
