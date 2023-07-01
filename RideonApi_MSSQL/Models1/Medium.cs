using System;
using System.Collections.Generic;

namespace RideonApi_MSSQL.Models1;

public partial class Medium
{
    public int Id { get; set; }

    public int MtbTrackId { get; set; }

    public short? Type { get; set; }

    public string? Link { get; set; }

    public virtual MtbTrack MtbTrack { get; set; } = null!;
}
