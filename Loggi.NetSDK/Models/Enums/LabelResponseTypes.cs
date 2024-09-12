namespace Loggi.NetSDK.Models.Enums
{
    /// <summary>
    /// Tipo de retorno do label gerado.
    /// </summary>
    public static class LabelResponseTypes
    {
        /// <summary>
        /// Retorno em forma de Base64.
        /// </summary>
        public const string Base64 = "LABEL_RESPONSE_TYPE_BASE_64";
        
        /// <summary>
        /// Retorno em forma de Url.
        /// </summary>
        public const string Url = "LABEL_RESPONSE_TYPE_URL";
    }
}