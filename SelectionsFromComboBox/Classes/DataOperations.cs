using System;
using System.Data;
using System.Data.SqlClient;

// from BaseConnectionLibrary NuGet package
using BaseConnectionLibrary.ConnectionClasses;

namespace SelectionsFromComboBox.Classes
{
    public class DataOperations : SqlServerConnection
    {
        /// <summary>
        /// Setup connection and if command text should be shown
        /// </summary>
        /// <param name="pRevealCommand"></param>
        public DataOperations(bool pRevealCommand = false)
        {
            DatabaseServer = "KARENS-PC";
            DefaultCatalog = "NorthWindAzure3";
        }

        /// <summary>
        /// Get all products, field list; ProductID and ProductName
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllProducts()
        {

            var dt = new DataTable();

            mHasException = false;

            var selectStatement = "SELECT ProductID,ProductName FROM dbo.Products" ;


            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                
                using (var cmd = new SqlCommand { Connection = cn })
                {

                    cmd.CommandText = selectStatement;


                    try
                    {
                        cn.Open();

                        dt.Load(cmd.ExecuteReader());
                        var row = dt.NewRow();
                        row[0] = 0;
                        row[1] = "Please select";
                        dt.Rows.InsertAt(row, 0);


                    }
                    catch (Exception ex)
                    {

                        mHasException = true;
                        mLastException = ex;

                    }

                }
            }

            return dt;
        }
        /// <summary>
        /// Get a few fields when a product key matches the
        /// key sent to us
        /// </summary>
        /// <param name="pIdentifier">Existing primary key</param>
        /// <returns></returns>
        public DataTable GetProductsByIdentifier(int pIdentifier)
        {

            var dt = new DataTable();

            mHasException = false;

            var selectStatement =
                "SELECT CategoryID, UnitPrice, UnitsInStock FROM dbo.Products WHERE ProductID = @ProductID";


            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {

                using (var cmd = new SqlCommand { Connection = cn })
                {

                    cmd.CommandText = selectStatement;
                    cmd.Parameters.AddWithValue("@ProductID", pIdentifier);

                    try
                    {
                        cn.Open();

                        dt.Load(cmd.ExecuteReader());


                    }
                    catch (Exception ex)
                    {

                        mHasException = true;
                        mLastException = ex;

                    }

                }
            }

            return dt;
        }
    }
}