using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Mosquecoordinate
{
    public int Id { get; set; }

    public string MosqId { get; set; } = null!;

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public ulong? ActiveFlag { get; set; }
}
