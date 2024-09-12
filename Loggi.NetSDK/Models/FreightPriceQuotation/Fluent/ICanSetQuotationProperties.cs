namespace Loggi.NetSDK.Models.FreightPriceQuotation.Fluent
{
    /// <summary>
    /// Interface para que possa ser utilizada a FluentAPI para o <see cref="QuotationBuilder"/>
    /// </summary>
    public interface ICanSetQuotationProperties
    {
        /// <summary>
        /// Opção de setar o valor de ShipFrom para a Quotation
        /// </summary>
        /// <param name="shipFrom">Um objeto <see cref="IQuotationAddress"/> Contendo informações de um endereço podendo ser correios, internacional ou widget.</param>
        /// <returns><see cref="ICanSetQuotationProperties"/></returns>
        public ICanSetQuotationProperties SetShipFrom(IQuotationAddress shipFrom);

        /// <summary>
        /// Opção de setar o valor de ShipTo para a Quotation.
        /// </summary>
        /// <param name="shipTo">Um objeto <see cref="IQuotationAddress"/> Contendo informações de um endereço podendo ser correios, internacional ou widget.</param>
        /// <returns><see cref="ICanSetQuotationProperties"/></returns>
        public ICanSetQuotationProperties SetShipTo(IQuotationAddress shipTo);

        /// <summary>
        /// Adiciona um pacote para a Quotation.
        /// </summary>
        /// <param name="package">um objeto <see cref="QuotationPackage"/> Contendo informaçoes do pacote a ser adicionado.</param>
        /// <returns><see cref="ICanSetQuotationProperties"/></returns>
        public ICanSetQuotationProperties AddPackage(QuotationPackage package);

        /// <summary>
        /// Constroi o objeto Quotation se tudo estiver correto.
        /// </summary>
        /// <returns><see cref="Quotation"/></returns>
        public Quotation Build();
    }
}