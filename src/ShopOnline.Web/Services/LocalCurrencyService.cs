using ShopOnline.Web.Services.Contracts;
using System.Globalization;

namespace ShopOnline.Web.Services
{
    public class LocalCurrencyService : ILocalCurrencyService
    {
        private const string CultureISO = "tl-PH";

        public LocalCurrencyService()
        {
        }

        public string CurrencyTranslate(decimal money, string format)
        {
            return string.Format(CultureInfo.GetCultureInfo(CultureISO), $"{{0:{format}}}", money);
        }
    }
}
