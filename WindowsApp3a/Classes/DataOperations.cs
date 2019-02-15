using System;
using System.Data.SqlClient;
using System.IO;
using BaseConnectionLibrary.ConnectionClasses;

namespace WindowsApp3a.Classes
{
    /// <summary>
    /// https://code.msdn.microsoft.com/SQL-Server-export-to-Excel-c3c6f21f
    /// </summary>
    public class DataOperations : SqlServerConnection
    {
        public DataOperations()
        {
            DefaultCatalog = "ExcelExporting";
        }
        /// <summary>
        /// Copy template excel file to app folder
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public bool CopyToApplicationFolder(string pFileName)
        {

            try
            {
                File.Copy(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Files\\{Path.GetFileName(pFileName)}"), 
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pFileName), true);

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// Copy template file to app folder with a different name
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pTargetFile"></param>
        /// <returns></returns>
        public bool CopyToApplicationFolder(string pFileName, string pTargetFile)
        {

            try
            {
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Files\\{Path.GetFileName(pFileName)}"), 
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pTargetFile), true);

                return true;

            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }

            return IsSuccessFul;
        }
        /// <summary>
        /// Export data to Excel
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pRowsExported">Used to return export row count </param>
        /// <returns></returns>
        public bool WriteCustomerTableToXmlFile(string pFileName, ref int pRowsExported)
        {
            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {

                    cmd.CommandText = 
                        $"INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'Excel 12.0;Database={pFileName}'," + 
                        "'SELECT * from [Customers$]') " + 
                        "SELECT CustomerIdentifier,CompanyName,ContactName,ContactTitle," + 
                        "[Address],City,Region,PostalCode,Country,Phone " + 
                        "FROM Customers";

                    Console.WriteLine(cmd.CommandText);
                    cn.Open();

                    try
                    {

                        pRowsExported = cmd.ExecuteNonQuery();
                        return pRowsExported > 0;

                    }
                    catch (Exception e)
                    {
                        mHasException = true;
                        mLastException = e;
                    }
                }
            }

            return IsSuccessFul;
        }
    }
}
