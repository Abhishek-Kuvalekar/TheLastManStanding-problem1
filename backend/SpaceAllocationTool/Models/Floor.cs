namespace SpaceAllocationTool.Models {
    public class Floor {
        public int FloorId { get; set; }

        public string? FloorName { get; set; }

        public int TotalWings { get; set; }

        public virtual Building? Building { get; set; }
    }
}