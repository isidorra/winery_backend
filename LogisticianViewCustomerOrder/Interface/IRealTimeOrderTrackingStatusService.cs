namespace winery_backend.LogisticianViewCustomerOrder.Interface
{
    public interface IRealTimeOrderTrackingStatusService
    {
        string FindStatusNameById(int id);
        int FindIdByStatusName(string newStatusName);
    }
}
