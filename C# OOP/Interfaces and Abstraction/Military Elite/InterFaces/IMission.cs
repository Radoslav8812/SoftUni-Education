
namespace MilitaryElite.InterFaces
{
    public interface IMission
    {
        public string CodeName { get; }
        public Status Status { get; set; }
    }
}
