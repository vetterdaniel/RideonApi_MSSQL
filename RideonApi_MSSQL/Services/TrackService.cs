namespace RideonApi_MSSQL.Services;
using RideonApi_MSSQL.Entities.Tracks;
using RideonApi_MSSQL.Helpers;

public interface ITrackService
{
    IEnumerable<Mtbtrack> GetAll();
    Trackhead GetById(int id);
    Trackhead CreateTrackhead(Trackhead trackhead);
}

//public class TrackService : ITrackService
//{
//    private DataContext _context;

//    public TrackService(DataContext dataContext)
//    {
//        _context = dataContext;
//    }

//    public IEnumerable<Mtbtrack> GetAll()
//    {
//        return _context.
//    }
//}