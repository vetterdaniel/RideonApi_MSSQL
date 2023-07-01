namespace RideonApi_MSSQL.Entities.Tracks;

public class Parking
{
    public int Id { get; set; }

    public int TrackheadId { get; set; }

    public string? Address { get; set; }

    public int? Zipcode { get; set; }

    public string? City { get; set; }

    public double Lat { get; set; }

    public double Lon { get; set; }

    public string? Description { get; set; }

    public virtual Trackhead Trackhead { get; set; } = null!;

}
