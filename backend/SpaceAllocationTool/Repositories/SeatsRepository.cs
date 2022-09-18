using SpaceAllocationTool.DbContexts;
using SpaceAllocationTool.Interfaces;
using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Repositories {
    public class SeatsRepository : RepositoryBase, ISeatsRepository
    {
        public SeatsRepository(SpaceAllocationToolContext dbContext): base(dbContext) { }

        public IEnumerable<Seat> GetSeats(int wingId)
        {
            return _db.Seats
                .Where(seat => wingId <= 0 || (seat.Wing != null && seat.Wing.WingId == wingId))
                .AsEnumerable<Seat>();
        }

        public void InitializeSeats()
        {
            _db.Wings.AsEnumerable().ToList().ForEach(wing => {
                for (int i = 1; i <= 10; ++i) {
                    for (int j = 1; j <= (wing.TotalSeats / 10); ++j) {
                        AddSeat(j, i, wing);
                    }
                }
            });
            _db.SaveChanges();
        }

        private void AddSeat(int row, int column, Wing wing) {
            _db.Seats.Add(new Seat
            {
                RowNumber = row,
                ColumnNumber = column,
                Wing = wing
            });
        }
    }
}