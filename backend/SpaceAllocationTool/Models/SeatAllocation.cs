namespace SpaceAllocationTool.Models {
    public class SeatAllocation {
        public int SeatAllocationId { get; set; }

        public DateTime Date { get; set; }
        
        public bool IsBooking { get; set; }

        public virtual Seat? Seat { get; set; }

        public virtual Employee? Allocatee { get; set; }

        public virtual Employee? Allocator { get; set; }
    }
}