
using Microsoft.VisualBasic;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class PurchaseService : IPurchaseService {
    private readonly IPurchaseRepository _purchaseRepository;
    public PurchaseService(IPurchaseRepository purchaseRepository) {
        _purchaseRepository = purchaseRepository;
    }

    public bool Create(Purchase purchase)
    {
        return _purchaseRepository.Create(purchase);
    }

    public bool Exists(int id)
    {
        return _purchaseRepository.Exists(id);
    }

    public void GeneratePdfInvoice(int purchaseId)
    {
        Purchase purchase = _purchaseRepository.GetById(purchaseId);
        QuestPDF.Settings.License = LicenseType.Community;
        Document.Create(container => {
            container.Page(page => {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.DefaultTextStyle(x => x.FontSize(20));

                page.Header()
                .Text("Invoice for purchase #" + purchaseId)
                .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Spacing(20);
                        x.Item().Text("Total: $" + purchase.Total);
                        x.Item().Text("Customer ID: " + purchase.CustomerId);
                        x.Item().Text("Order created at: " + purchase.CreatedAt);
                        x.Item().Text("Current order status: " + purchase.PurchaseStatus);

                    });
                
                page.Footer()
                    .AlignCenter()
                    .Text("Invoice printed on: " + DateTime.Now);
            });
        }).GeneratePdf("invoice.pdf");
    }

    public ICollection<Purchase> GetAll()
    {
        return _purchaseRepository.GetAll();
    }

    public ICollection<Purchase> GetAllByCustomerId(int customerId)
    {
        return _purchaseRepository.GetAllByCustomerId(customerId);
    }

    public Purchase GetById(int id)
    {
        return _purchaseRepository.GetById(id);
    }

    public bool Save()
    {
        return _purchaseRepository.Save();
    }

    public void Cancel(int purchaseId)
    {
        try
        {
            Purchase purchase = _purchaseRepository.GetById(purchaseId);
            if (purchase.PurchaseStatus == PurchaseStatus.PROCESSING || purchase.PurchaseStatus == PurchaseStatus.CONFIRMED)
            {
                purchase.PurchaseStatus = PurchaseStatus.CANCELED;
            }

            _purchaseRepository.Update(purchase);
        }
        catch (Exception ex)
        {
            throw new Exception("Error while trying to cancel purchase", ex);
        }
    }
}