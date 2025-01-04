namespace ShopOnline.Web.Services.Contracts
{
    public interface ILocalCurrencyService
    {
        string CurrencyTranslate(decimal money, string format);
    }
}
