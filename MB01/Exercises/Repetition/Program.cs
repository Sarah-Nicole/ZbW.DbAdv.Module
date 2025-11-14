

using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetRep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Filter-Criteria: ");
            var filter = Console.ReadLine();

            ReadWithFilter(filter);
        }

        private static void ReadWithFilter(string filter)
        {

            // Connectionstring: https://www.connectionstrings.com/sqlconnection/
            /* Connection string */
            string connectionString = @"Data Source=.;Initial Catalog=Northwind;Integrated Security=True;Encrypt=False";

            string sqlStatement = $"select c.companyName, c.contactname, sum(cast(od.UnitPrice * od.Quantity * (1 - od.Discount)/ 100 as decimal(10, 2))) AS Umsatz " +
                $"from customers c join orders o on c.CustomerID = o.CustomerID join [Order Details] od on o.OrderID = od.OrderID " +
                $"where c.ContactName like @filter or CompanyName like @filter group by c.companyName,  c.contactname order by c.CompanyName";

            // Verbindung deklarieren
            IDbConnection connection = null!;

            try
            {
                //Verbindung erzeugen
                connection = new SqlConnection(connectionString);
                // Verbingung öffnen:
                connection.Open();
                // Command initialisieren:
                IDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = sqlStatement;
                cmd.Parameters.Add(new SqlParameter("@filter", SqlDbType.NVarChar, 400) { Value = "%" + (filter) + "%" }); // gegen SQL-Injection

                // Command ausführen:
                IDataReader reader = cmd.ExecuteReader();


                object[] dataRow = new object[reader.FieldCount];
                // jede Zeile lesen und verarbeiten
                while (reader.Read())
                { // solange noch Daten vorhanden sind
                    int cols = reader.GetValues(dataRow); // die Spalten vom Select die es hat. companyName, contactname, umsatz
                    var val = reader["companyName"]; // so kann man die Werte der einzelnen Spalten auslesen -> z.b. companyName
                    for (int i = 0; i < cols; i++)
                    {
                        Console.Write(dataRow[i]); // i = jedes Resultat, dataRow = jeder Datensatz (in dem Fall company, name, umsatz)
                        if (i < cols - 1)
                        {
                            Console.Write(" | "); // Trenner, außer nach der letzten Spalte
                        }
                    }
                    Console.WriteLine();
                }
                // Reader schließen
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                try
                {
                    if (connection != null)
                        // Verbindung schließen
                        connection.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

    }
}
