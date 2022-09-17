namespace SpaceAllocationTool.Models {
    public class Seat { 
        public int SeatId { get; set; }

        public int RowNumber { get; set; }

        public int ColumnNumber { get; set; }

        public virtual Wing? Wing { get; set; }
    }
}