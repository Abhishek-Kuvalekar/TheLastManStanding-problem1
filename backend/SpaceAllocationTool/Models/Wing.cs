namespace SpaceAllocationTool.Models {
    public class Wing {
        public int WingId { get; set; }

        public string? WingName { get; set; }

        public int TotalSeats { get; set; }

        public int TotalRooms { get; set; }

        public virtual Floor? Floor { get; set; }
    }
}