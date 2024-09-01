namespace BuilderDesignPattern;

public class ProductStockReportBuilder(IEnumerable<Product> products) : IProductStockReportBuilder
{
    private ProductStockReport _productStockReport = new();
    public IProductStockReportBuilder BuildHeader()
    {
        _productStockReport.HeaderPart = "<header>Product Stock Report</header>";

        return this;
    }

    public IProductStockReportBuilder BuildBody()
    {
        var productLines = products.Select(p => $"Product: {p.MyProperty}, Price: {p.Price}");
        _productStockReport.BodyPart = string.Join(Environment.NewLine, productLines);

        return this;
    }

    public IProductStockReportBuilder BuildFooter()
    {
        _productStockReport.FooterPart = "<footer>Report created at " + DateTime.Now + "</footer>";

        return this;
    }

    public ProductStockReport GetReport()
    {
        var productStockReport = _productStockReport;

        // Reset builder
        _productStockReport = new ProductStockReport();

        return productStockReport;
    }
}