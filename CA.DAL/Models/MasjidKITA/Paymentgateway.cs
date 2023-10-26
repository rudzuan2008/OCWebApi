using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Paymentgateway
{
    public int Id { get; set; }

    public int? MosqId { get; set; }

    public string? Handle { get; set; }

    public string? CollectionId { get; set; }

    public string? ApiKey { get; set; }

    public string? PayGatewayUrl { get; set; }

    public string? CallbackUrl { get; set; }

    public string? RedirectUrl { get; set; }

    public sbyte? ActiveFlag { get; set; }
}
