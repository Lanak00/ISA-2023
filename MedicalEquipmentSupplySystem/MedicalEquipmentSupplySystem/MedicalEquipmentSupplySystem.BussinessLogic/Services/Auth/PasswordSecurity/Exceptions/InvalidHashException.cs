namespace BloodTransfusionBank.BussinessLogic.Services.Auth.PasswordSecurity.Exceptions
{
    class InvalidHashException : Exception
    {
        public InvalidHashException() { }
        public InvalidHashException(string message)
            : base(message) { }
        public InvalidHashException(string message, Exception inner)
            : base(message, inner) { }
    }
}
