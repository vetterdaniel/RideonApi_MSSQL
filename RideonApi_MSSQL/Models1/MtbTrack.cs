using System;
using System.Collections.Generic;

namespace RideonApi_MSSQL.Models1;

public partial class MtbTrack
{
    public int Id { get; set; }

    public int TrackHeadId { get; set; }

    public string? Name { get; set; }

    public int? Color { get; set; }

    public float? Lenght { get; set; }

    public float? Ascend { get; set; }

    public float? Descend { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Medium> Media { get; set; } = new List<Medium>();

    public virtual TrackHead TrackHead { get; set; } = null!;
}
