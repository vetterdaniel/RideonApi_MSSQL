using System;
using System.Collections.Generic;

namespace RideonApi_MSSQL.Models1;

public partial class TrackHead
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int? Zipcode { get; set; }

    public string? City { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Lon { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<MtbTrack> MtbTracks { get; set; } = new List<MtbTrack>();

    public virtual ICollection<Parking> Parkings { get; set; } = new List<Parking>();
}
