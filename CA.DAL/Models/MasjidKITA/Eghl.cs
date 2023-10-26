using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Eghl
{
    public int Id { get; set; }

    public string? TransactionType { get; set; }

    public string? PymtMethod { get; set; }

    public string? ServiceId { get; set; }

    public string? MerchantName { get; set; }

    public string? MerchantReturnUrl { get; set; }

    public string? CurrencyCode { get; set; }

    public int? TxnStatus { get; set; }

    public string? LanguageCode { get; set; }

    public int? PageTimeout { get; set; }

    public int? ActiveFlag { get; set; }

    public string? MerchantCallBackUrl { get; set; }
}
