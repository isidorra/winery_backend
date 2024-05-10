namespace winery_backend.LogisticianViewCustomerOrder.Interface
{
    public interface IRealTimeOrderTrackingStatusRepository
    {
        string FindStatusNameById(int id);
    }
}
