using System;
using System.Collections.Generic;

namespace RideonApi_MSSQL.Models1;

public partial class Trackpoint
{
    public int MtbTrackId { get; set; }

    public int PointId { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Lon { get; set; }

    public float? Altitude { get; set; }

    public virtual MtbTrack MtbTrack { get; set; } = null!;
}
