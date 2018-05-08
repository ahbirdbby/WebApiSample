using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ChargeRepository
    {
        public void SaveCharge(ChargeResultParams result)
        {
            string queryString = "insert into db.jiao_fei(lsh, xmmc, xmsjje) values (@lsh, @xmmc, @je)";

            using (SqlConnection connection = DbUtils.GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                var lsh = result.Lsh;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Transaction = transaction;

                command.Parameters.AddWithValue("@lsh", lsh);
                try
                {
                    foreach (var sfqj in result.SfqjList)
                    {
                        foreach (var item in sfqj.MxData)
                        {
                            var xmmc = item.Xmmc;
                            var je = item.Xmsjje;
                            // Create the Command and Parameter objects.

                            command.Parameters.AddWithValue("@xmmc", xmmc);
                            command.Parameters.AddWithValue("@je", je);

                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally {
                    connection.Close();
                }
            }
        }
    }
}