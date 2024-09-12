using System.Collections.Generic;

namespace Loggi.NetSDK.Models.FreightPriceQuotation.Fluent
{
    /// <summary>
    /// Interface para que possa ser utilizada a FluentAPI para o <see cref="QuotationBuilder"/>
    /// </summary>
    public interface ICanSetUse
    {
        /// <summary>
        /// Escolhe Usar ExternalIds em vez de PickupTypes e prossegue ao proximo passo.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ICanSetQuotationProperties UseExternalIds(List<string> ids);

        /// <summary>
        /// Escolhe Usar PickupTypes em vez de ExternalIds e prossegue ao proximo passo.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ICanSetQuotationProperties UsePickupTypes(List<string> ids);
    }
}
