namespace RideonApi_MSSQL.Entities.Tracks;

public class Mtbtrack
{
    public int Id { get; set; }

    public int TrackheadId { get; set; }

    public string? Name { get; set; }

    public int? Color { get; set; }

    public float? Lenght { get; set; }

    public float? Ascend { get; set; }

    public float? Descend { get; set; }

    public string? Description { get; set; }

    public virtual Trackhead Trackhead { get; set; } = null!;

    public virtual ICollection<Trackpoint> Trackpoints { get; } = new List<Trackpoint>();

    public virtual ICollection<Media> Media { get; } = new List<Media>();
}
