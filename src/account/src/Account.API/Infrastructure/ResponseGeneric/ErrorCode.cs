namespace Account.API.Infrastructure.ResponseGeneric
{
    public class ErrorCode
    {
        // common
        public const string Success = "00000000";
        public const string BadRequest = "00000001";
        public const string NotFound = "00000010";
        public const string InternalError = "00000100";
        public const string Forbiden = "00001000";
        // custom
        public const string Validator = "00010000";
        public const string DataEmpty = "00100000";
        public const string InvalidMinLength = "01000000";
        public const string InvalidMaxLength = "10000000";
        public const string InvalidVerifyPassword = "00000011";
        public const string InvalidUsernameFormat = "00000101";
        public const string ExistingUser = "00001001";

    }
}
