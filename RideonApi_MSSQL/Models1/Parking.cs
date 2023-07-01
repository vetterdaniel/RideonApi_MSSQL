using System;
using System.Collections.Generic;

namespace RideonApi_MSSQL.Models1;

public partial class Parking
{
    public int Id { get; set; }

    public int TrackHeadId { get; set; }

    public string? Address { get; set; }

    public int? Zipcode { get; set; }

    public string? City { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Lon { get; set; }

    public string? Description { get; set; }

    public virtual TrackHead TrackHead { get; set; } = null!;
}
