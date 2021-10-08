using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Library.Model;

namespace Library.Repository
{
    public class Prodotti : IProdotti
    {
        private readonly string Strcon;

        public Prodotti(string strcon)
        {
            Strcon = strcon;
        }

  
        public bool DeleteProdotto(int idProdotto)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "update prodotto set attivo=0 where idprodotto=@idprodotto";
                using (var command = new SqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@idcliente", idProdotto);
                    return command.ExecuteNonQuery() == 1;
                }
            }

        }

        public IEnumerable<Prodotto> GetAllProdotto()
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "select * from prodotto where attivo = 1";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            yield return new Prodotto
                            {
                                Attivo = Convert.ToBoolean(dr["attivo"]),
                                IdProdotto = Convert.ToInt32(dr["IdProdotto"]),
                                Categoria = dr["categoria"].ToString(),
                                Codice8 = dr["codice8"].ToString(),
                                NomeProdotto = dr["nomeprodotto"].ToString(),
                                Qta = Convert.ToInt32(dr["Qta"])
                            };
                        }
                    }
                }
            }
        }

        public Prodotto GetProdotto(int idProdotto)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "select * from prodotto where idprodotto = @idprodotto";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            return new Prodotto
                            {
                                Attivo = Convert.ToBoolean(dr["attivo"]),
                                IdProdotto = Convert.ToInt32(dr["IdProdotto"]),
                                Categoria = dr["categoria"].ToString(),
                                Codice8 = dr["codice8"].ToString(),
                                NomeProdotto = dr["nomeprodotto"].ToString(),
                                Qta = Convert.ToInt32(dr["Qta"])
                            };
                        }
                        else throw new ArgumentOutOfRangeException(nameof(idProdotto));
                    }
                }
            }
        }

        public IEnumerable<Prodotto> GetProdotto(string search)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "select * from prodotto where nomeprodotto like @search or codice8 like @search ";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        command.Parameters.AddWithValue("@search", $"%{search}%");
                        if (dr.HasRows)
                        {
                            yield return new Prodotto
                            {
                                Attivo = Convert.ToBoolean(dr["attivo"]),
                                IdProdotto = Convert.ToInt32(dr["IdProdotto"]),
                                Categoria = dr["categoria"].ToString(),
                                Codice8 = dr["codice8"].ToString(),
                                NomeProdotto = dr["nomeprodotto"].ToString(),
                                Qta = Convert.ToInt32(dr["Qta"])
                            };
                        }
                    }
                }
            }
        }

        public Prodotto NewProdotto(Prodotto prodotto)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "insert into prodotto (attivo,categoria,codice8,nomeprodotto,Qta) values (@attivo,@categoria,@codice8,@nomeprodotto,@qta); SELECT CAST(scope_identity()) AS int";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        command.Parameters.AddWithValue("@attivo", prodotto.Attivo);
                        command.Parameters.AddWithValue("@categoria", prodotto.Categoria);
                        command.Parameters.AddWithValue("@codice8", prodotto.Codice8);
                        command.Parameters.AddWithValue("@nomeprodotto", prodotto.NomeProdotto);
                        command.Parameters.AddWithValue("@Qta", prodotto.Qta);

                        var result =Convert.ToInt32(command.ExecuteScalar());

                        return GetProdotto(result);
                    }
                }
            }
        }

        public Prodotto UpdateProdotto(Prodotto prodotto)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = @"update prodotto set attivo=@attivo,categoria=@categoria,codice8=@codice8,
                             nomeprodotto=@nomeprodotto,qta=@qta where idprodotto=@idprodotto";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        command.Parameters.AddWithValue("@attivo", prodotto.Attivo);
                        command.Parameters.AddWithValue("@IdProdotto", prodotto.IdProdotto);
                        command.Parameters.AddWithValue("@categoria", prodotto.Categoria);
                        command.Parameters.AddWithValue("@codice8", prodotto.Codice8);
                        command.Parameters.AddWithValue("@nomeprodotto", prodotto.NomeProdotto);
                        command.Parameters.AddWithValue("@Qta", prodotto.Qta);

                        var result = command.ExecuteNonQuery();

                        return GetProdotto(prodotto.IdProdotto);
                    }
                }
            }
        }
    }
}