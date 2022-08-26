namespace Dojo.Bakery.BuildingBlocks.Commons
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error)
        { }
        public static void When(bool hasError, string error, params object[] parameters)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(string.Format(error, parameters));
            }
        }
        public const string RequiredValueMessage = "{0} value is required";
    }
}
