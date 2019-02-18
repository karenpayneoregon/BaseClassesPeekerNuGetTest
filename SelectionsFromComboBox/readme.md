### What is this project?

This is a purely educational code sample.

- Using BaseConnectionLibrary for database connection to a SQL-Server database.
- Populating a ComboBox of choices (in this case product names)
- Data Binding to labels so you can see the selection from the ComboBox
- How to properly get fields for the current selected ComboBox item with assertion as a mock DataRow was inserted to prompt the user to make a selection

For the method GetProductsByIdentifier, in a production application a instance of a class would be a better choice than a DataTable for the return type, using a DataTable is simple to follow than the proper way to use a concrete class.

To change from DataTable to concrete class in this case would be to use the following class in tangent with using a DataReader to populate an instance of the Product class.

```csharp
public class Products
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int? SupplierID { get; set; }
    public int? CategoryID { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public short? UnitsOnOrder { get; set; }
    public short? ReorderLevel { get; set; }
    public bool Discontinued { get; set; }
    public DateTime? DiscontinuedDate { get; set; }

}
```