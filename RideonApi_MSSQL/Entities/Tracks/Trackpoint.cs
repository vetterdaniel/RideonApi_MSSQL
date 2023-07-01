namespace RideonApi_MSSQL.Entities.Tracks;

public class Trackpoint
{
    public int MtbtrackId { get; set; }

    public int PointId { get; set; }

    public double Lat { get; set; }

    public double Lon { get; set; }

    public float? Altitude { get; set; }

    public virtual Mtbtrack Mtbtrack { get; set; } = null!;
}
