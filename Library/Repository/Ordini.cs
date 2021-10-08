using System;
using System.Collections.Generic;
using Library.Model;
using System.Data.SqlClient;

namespace Library.Repository
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
                string sql = "select * from ordine where attivo = 1";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
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
                string sql = "select * from ordine where idordine = @idordine";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idordine", idOrdine);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
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
                string sql = "select * from ordine where idCliente = @idCliente";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
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
                string sql = "select * from ordine where idProdotto = @idProdotto";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
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
                string sql = @"insert into ordine (attivo,IdCliente,dataordine,IdProdotto,IndirizzoSpedizione)  
                    values (@attivo,@IdCliente,@dataordine,@IdProdotto,@IndirizzoSpedizione); SELECT CAST(scope_identity()) AS int";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
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
        }

        public Ordine UpdateOrdine(Ordine Ordine)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = @"update ordine set attivo=@attivo, dataordine=@dataordine, IndirizzoSpedizione=@IndirizzoSpedizione,
                            IdProdotto=@IdProdotto, IdCliente=@IdCliente  where idordine=@idordine";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        command.Parameters.AddWithValue("@attivo", Ordine.Attivo);
                        command.Parameters.AddWithValue("@IdCliente", Ordine.IdCliente);
                        command.Parameters.AddWithValue("@dataordine", Ordine.DataOrdine);
                        command.Parameters.AddWithValue("@IdProdotto", Ordine.IdProdotto);
                        command.Parameters.AddWithValue("@IndirizzoSpedizione", Ordine.IndirizzoSpedizione);

                        var result = command.ExecuteNonQuery();

                        return GetOrdine(Ordine.IdOrdine);
                    }
                }
            }
        }
    }
}
