using Mc2.CrudTest.Presentation.Server.Application.Common.Interfaces;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Server.Infrastructure.Services
{
    public class StringService : IStringService
    {
        public bool IsValidPhoneNumber(string telephoneNumber)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            string countryCode = "US";
            PhoneNumber phoneNumber = phoneUtil.Parse(telephoneNumber, countryCode);
            return phoneUtil.IsValidNumber(phoneNumber); // returns true for valid number    
        }
    }
}