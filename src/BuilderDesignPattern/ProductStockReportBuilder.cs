namespace BuilderDesignPattern;

public class ProductStockReportBuilder(IEnumerable<Product> products) : IProductStockReportBuilder
{
    private ProductStockReport _productStockReport = new();
    private readonly IEnumerable<Product> _products = products;

    public void BuildHeader()
    {
        _productStockReport.HeaderPart = "<header>Product Stock Report</header>";
    }

    public void BuildBody()
    {
        var productLines = _products.Select(p => $"Product: {p.MyProperty}, Price: {p.Price}");
        _productStockReport.BodyPart = string.Join(Environment.NewLine, productLines);
    }

    public void BuildFooter()
    {
        _productStockReport.FooterPart = "<footer>Report created at " + DateTime.Now + "</footer>";
    }

    public ProductStockReport GetReport()
    {
        var productStockReport = _productStockReport;

        // Reset builder
        _productStockReport = new ProductStockReport();

        return productStockReport;
    }
}