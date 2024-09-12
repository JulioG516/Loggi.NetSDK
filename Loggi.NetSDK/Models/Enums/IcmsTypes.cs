namespace Loggi.NetSDK.Models.Enums
{
    /// <summary>
    /// Valores que representa se um pacote terá tributação de ICMS.
    /// </summary>
    public static class IcmsTypes
    {
        /// <summary>
        /// Taxado.
        /// </summary>
        public const string Taxed = "ICMS_TAXED";

        /// <summary>
        /// Nao Taxado.
        /// </summary>
        public const string NotTaxed = "ICMS_NOT_TAXED";

        /// <summary>
        /// Livre de impostos.
        /// </summary>
        public const string Free = "ICMS_FREE";
    }
}