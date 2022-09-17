namespace SpaceAllocationTool.Models {
    public class Room {
        public int RoomId { get; set; }

        public int RowNumber { get; set; }

        public int ColumnNumber { get; set; }

        public virtual Wing? Wing { get; set; }
    }
}