namespace RideonApi_MSSQL.Entities.Tracks;

public class Trackhead
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int? Zipcode { get; set; }

    public string? City { get; set; }

    public double Lat { get; set; }

    public double Lon { get; set; }

    public string? Description { get; set; }

    public ICollection<Mtbtrack>? Mtbtracks { get; set; }

    public ICollection<Parking>? Parkings { get; set; }

}









