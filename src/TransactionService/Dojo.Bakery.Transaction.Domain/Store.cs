using Dojo.Bakery.BuildingBlocks.Commons;

namespace Dojo.Bakery.Transaction.Domain
{
    public class Store : AggregateRoot
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string City { get; private set; }
        public string Email { get; private set; }
        public string Country { get; private set; }
        public string DocumentNumber { get; private set; }
        public TimeSpan OpenTime { get; private set; }
        public TimeSpan CloseTime { get; private set; }
        private Store() { }
        public Store(string name, string address, string phone, string city, string email, string country, string documentNumber, TimeSpan openTime, TimeSpan closeTime)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
            DomainExceptionValidation.When(string.IsNullOrEmpty(address), DomainExceptionValidation.RequiredValueMessage,nameof(address));
            DomainExceptionValidation.When(string.IsNullOrEmpty(phone), DomainExceptionValidation.RequiredValueMessage,nameof(phone));
            DomainExceptionValidation.When(string.IsNullOrEmpty(city), DomainExceptionValidation.RequiredValueMessage,nameof(city));
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), DomainExceptionValidation.RequiredValueMessage,nameof(email));
            DomainExceptionValidation.When(string.IsNullOrEmpty(country), DomainExceptionValidation.RequiredValueMessage,nameof(country));
            DomainExceptionValidation.When(string.IsNullOrEmpty(documentNumber), DomainExceptionValidation.RequiredValueMessage,nameof(documentNumber));
            DomainExceptionValidation.When(openTime >= closeTime, "Close and Open Time are incorrect");
            Name = name;
            Address = address;
            Phone = phone;
            City = city;
            Email = email;
            Country = country;
            DocumentNumber = documentNumber;
            OpenTime = openTime;
            CloseTime = closeTime;
            Id = IdentityGenerator.NewSequentialGuid();
        }
        public void ChangeName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage,nameof(name));
            Name = name;
        }
        public void ChangeAddress(string address)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(address), DomainExceptionValidation.RequiredValueMessage,nameof(address));
            Address = address;
        }
        public void ChangePhone(string phone)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(phone), DomainExceptionValidation.RequiredValueMessage,nameof(phone));
            Phone = phone;
        }
        public void ChangeCity(string city)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(city), DomainExceptionValidation.RequiredValueMessage,nameof(city));
            City = city;
        }
        public void ChangeEmail(string email)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), DomainExceptionValidation.RequiredValueMessage,nameof(email));
            Email = email;
        }
        public void ChangeCountry(string country)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(country), DomainExceptionValidation.RequiredValueMessage,nameof(country));
            Country = country;
        }
        public void ChangeDocumentNumber(string documentNumber)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(documentNumber), DomainExceptionValidation.RequiredValueMessage,nameof(documentNumber));
            DocumentNumber = documentNumber;
        }
        public void ChangeOpenCloseTime(TimeSpan openTime, TimeSpan closeTime)
        {
            DomainExceptionValidation.When(openTime >= closeTime, "Close and Open Time are incorrect");
            OpenTime = openTime;
            CloseTime = closeTime;
        }
    }
}
