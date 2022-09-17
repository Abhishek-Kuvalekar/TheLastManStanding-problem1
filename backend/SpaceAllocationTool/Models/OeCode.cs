namespace SpaceAllocationTool.Models {
    public class OeCode {
        public int OeCodeId { get; set; }

        public string? OeCodeValue { get; set; }

        public virtual OeCode? Parent { get; set; }

        public virtual Department? Department { get; set; }
    }
}