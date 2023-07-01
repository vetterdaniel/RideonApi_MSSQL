namespace RideonApi_MSSQL.Entities.Tracks;

public partial class Media
{
    public int Id { get; set; }

    public int MtbtrackId { get; set; }

    public short? Type { get; set; }

    public string? Link { get; set; }

    public virtual Mtbtrack Mtbtrack { get; set; } = null!;
}
