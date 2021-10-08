using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GestionaleLibrary.Model;

namespace GestionaleLibrary.Repository
{
    public class Ordini : IOrdini
    {
        private readonly string Strcon;

        public Ordini(string strcon)
        {
            Strcon = strcon;
        }

        public bool DeleteOrdine(int idOrdine)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "update Ordini set attivo=0 where idOrdine=@idOrdine";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idOrdine", idOrdine);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public IEnumerable<Ordine> GetAllOrdine()
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "select  IdOrdine,DataOrdine,IdProdotto,IdCliente,IndirizzoSpedizione,Attivo from ordini where attivo = 1";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            yield return new Ordine
                            {
                                Attivo = Convert.ToBoolean(dr["attivo"]),
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                DataOrdine = Convert.ToDateTime(dr["dataordine"]),
                                IdOrdine = Convert.ToInt32(dr["IdOrdine"]),
                                IdProdotto = Convert.ToInt32(dr["IdProdotto"]),
                                IndirizzoSpedizione = dr["IndirizzoSpedizione"].ToString()
                            };
                        }
                    }
                }
            }
        }

        public Ordine GetOrdine(int idOrdine)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "select  IdOrdine,DataOrdine,IdProdotto,IdCliente,IndirizzoSpedizione,Attivo from ordini where idordine = @idordine";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idordine", idOrdine);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows && dr.Read())
                        {
                            return new Ordine
                            {
                                Attivo = Convert.ToBoolean(dr["attivo"]),
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                DataOrdine = Convert.ToDateTime(dr["dataordine"]),
                                IdOrdine = Convert.ToInt32(dr["IdOrdine"]),
                                IdProdotto = Convert.ToInt32(dr["IdProdotto"]),
                                IndirizzoSpedizione = dr["IndirizzoSpedizione"].ToString()
                            };
                        }
                        else throw new ArgumentOutOfRangeException(nameof(idOrdine));
                    }
                }
            }
        }

        public IEnumerable<Ordine> GetOrdineByIdCliente(int idCliente)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "select  IdOrdine,DataOrdine,IdProdotto,IdCliente,IndirizzoSpedizione,Attivo from ordini where idCliente = @idCliente";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idcliente", idCliente);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            yield return new Ordine
                            {
                                Attivo = Convert.ToBoolean(dr["attivo"]),
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                DataOrdine = Convert.ToDateTime(dr["dataordine"]),
                                IdOrdine = Convert.ToInt32(dr["IdOrdine"]),
                                IdProdotto = Convert.ToInt32(dr["IdProdotto"]),
                                IndirizzoSpedizione = dr["IndirizzoSpedizione"].ToString()
                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<Ordine> GetOrdineByIdProdotto(int idProdotto)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "select  IdOrdine,DataOrdine,IdProdotto,IdCliente,IndirizzoSpedizione,Attivo from ordini where idProdotto = @idProdotto";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idProdotto", idProdotto);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            yield return new Ordine
                            {
                                Attivo = Convert.ToBoolean(dr["attivo"]),
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                DataOrdine = Convert.ToDateTime(dr["dataordine"]),
                                IdOrdine = Convert.ToInt32(dr["IdOrdine"]),
                                IdProdotto = Convert.ToInt32(dr["IdProdotto"]),
                                IndirizzoSpedizione = dr["IndirizzoSpedizione"].ToString()
                            };
                        }
                    }
                }
            }
        }

        public Ordine NewOrdine(Ordine Ordine)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = @"insert into ordini (attivo,IdCliente,dataordine,IdProdotto,IndirizzoSpedizione)  
                    values (@attivo,@IdCliente,@dataordine,@IdProdotto,@IndirizzoSpedizione); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@attivo", Ordine.Attivo);
                    command.Parameters.AddWithValue("@IdCliente", Ordine.IdCliente);
                    command.Parameters.AddWithValue("@dataordine", Ordine.DataOrdine);
                    command.Parameters.AddWithValue("@IdProdotto", Ordine.IdProdotto);
                    command.Parameters.AddWithValue("@IndirizzoSpedizione", Ordine.IndirizzoSpedizione);
                    var result = Convert.ToInt32(command.ExecuteScalar());
                    return GetOrdine(result);
                }
            }
        }

        public Ordine UpdateOrdine(Ordine Ordine)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = @"update ordini set attivo=@attivo, dataordine=@dataordine, IndirizzoSpedizione=@IndirizzoSpedizione,
                            IdProdotto=@IdProdotto, IdCliente=@IdCliente  where idordine=@idordine";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@attivo", Ordine.Attivo);
                    command.Parameters.AddWithValue("@IdCliente", Ordine.IdCliente);
                    command.Parameters.AddWithValue("@dataordine", Ordine.DataOrdine);
                    command.Parameters.AddWithValue("@IdProdotto", Ordine.IdProdotto);
                    command.Parameters.AddWithValue("@IndirizzoSpedizione", Ordine.IndirizzoSpedizione);
                    command.Parameters.AddWithValue("@idordine", Ordine.IdOrdine);

                    command.ExecuteNonQuery();

                    return GetOrdine(Ordine.IdOrdine);
                }
            }
        }
    }
}
