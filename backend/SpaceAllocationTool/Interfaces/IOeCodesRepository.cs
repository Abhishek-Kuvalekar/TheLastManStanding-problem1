using SpaceAllocationTool.Models;

namespace SpaceAllocationTool.Interfaces {
    public interface IOeCodesRepository {
        public IEnumerable<OeCode> GetOeCodes();

        public void InitializeOeCodes();
    }
}