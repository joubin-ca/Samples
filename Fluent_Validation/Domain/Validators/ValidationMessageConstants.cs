using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validators
{
    public class ValidationMessageConstants
    {
        public const string FIRST_NAME_CANNOT_BE_EMPTY_OR_NULL = "First name is required.";
        public const string FIRST_NAME_CANNOT_BE_SET_TO_ABC = "First name 'abc' is not valid.";
        public const string LAST_NAME_CANNOT_BE_EMPTY_OR_NULL = "Last name is required.";
        public const string USER_ADDRESS_COLLECTION_CANNOT_BE_EMPTY = "User Address collection cannot be empty.";
        public const string USER_ADDRESS_COLLECTION_COUNT_MUST_BE_EXACTLY_2 = "User Address collection count must be exactly 2.";
    }
}
