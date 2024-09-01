namespace BuilderDesignPattern;

public class ProductStockReportDirector(IProductStockReportBuilder builder)
{
    public void BuildStockReport()
    {
        builder.BuildHeader();
        builder.BuildBody();
        builder.BuildFooter();
    }
}