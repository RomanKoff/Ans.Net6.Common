namespace Ans.Net6.Common
{

    public interface ITreeItem
    {
        int Id { get; set; }
        int? MasterPtr { get; set; }
        bool AllowMasters { get; }
        bool AllowSlaves { get; }
        int CountMasters { get; }
        int CountSlaves { get; }
    }

}
