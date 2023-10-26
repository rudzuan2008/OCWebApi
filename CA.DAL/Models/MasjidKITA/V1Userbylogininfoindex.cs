﻿using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Userbylogininfoindex
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? LoginProvider { get; set; }

    public string? ProviderKey { get; set; }

    public virtual V1Document? Document { get; set; }
}
