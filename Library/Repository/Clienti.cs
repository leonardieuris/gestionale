using System;
using System.Collections.Generic;
using Library.Model;
using System.Data.SqlClient;

namespace Library.Repository
{
    public class Clienti : IClienti
    {
        private readonly string Strcon;

        public Clienti(string strcon)
        {
            Strcon = strcon;
        }


        public bool DeleteCliente(int idCliente)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "update clienti set attivo=0 where idcliente=@idcliente";
                using (var command = new SqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@idcliente", idCliente);
                    return command.ExecuteNonQuery() == 1;
                }
            }

        }

        public IEnumerable<Cliente> GetAllCliente()
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "select * from clienti where attivo = 1";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            yield return new Cliente
                            {
                                Attivo = Convert.ToBoolean(dr["attivo"]),
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Indirizzo = dr["Indirizzo"].ToString(),
                                Piva = dr["Piva"].ToString(),
                                RagSoc = dr["RagSoc"].ToString()
                            };
                        }
                    }
                }
            }
        }

        public Cliente GetCliente(int idCliente)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "select * from clienti where idcliente = @idcliente";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            return new Cliente
                            {
                                Attivo = Convert.ToBoolean(dr["attivo"]),
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Indirizzo = dr["Indirizzo"].ToString(),
                                Piva = dr["Piva"].ToString(),
                                RagSoc = dr["RagSoc"].ToString()
                            };
                        }
                        else throw new ArgumentOutOfRangeException(nameof(idCliente));
                    }
                }
            }
        }

        public IEnumerable<Cliente> GetCliente(string search)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "select * from clienti where ragsoc like @search ";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        command.Parameters.AddWithValue("@search", $"%{search}%");
                        if (dr.HasRows)
                        {
                            yield return new Cliente
                            {
                                Attivo = Convert.ToBoolean(dr["attivo"]),
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Indirizzo = dr["Indirizzo"].ToString(),
                                Piva = dr["Piva"].ToString(),
                                RagSoc = dr["RagSoc"].ToString()
                            };
                        }
                    }
                }
            }
        }

        public Cliente NewCliente(Cliente cliente)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "insert into clienti (ragsoc,piva,indirizzo,attivo) values (@ragsoc,@piva,@indirizzo,@attivo); SELECT CAST(scope_identity()) AS int";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        command.Parameters.AddWithValue("@ragsoc", cliente.RagSoc);
                        command.Parameters.AddWithValue("@piva", cliente.Piva);
                        command.Parameters.AddWithValue("@indirizzo", cliente.Indirizzo);
                        command.Parameters.AddWithValue("@attivo", cliente.Attivo);

                        var result =Convert.ToInt32(command.ExecuteScalar());

                        return GetCliente(result);
                    }
                }
            }
        }

        public Cliente UpdateCliente(Cliente cliente)
        {
            using (var connection = new SqlConnection(Strcon))
            {
                connection.Open();
                string sql = "update clienti set ragsoc=@ragsoc, piva=@piva, indirizzo=@indirizzo, attivo=@attivo where idcliente=@idcliente";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        command.Parameters.AddWithValue("@ragsoc", cliente.RagSoc);
                        command.Parameters.AddWithValue("@piva", cliente.Piva);
                        command.Parameters.AddWithValue("@indirizzo", cliente.Indirizzo);
                        command.Parameters.AddWithValue("@attivo", cliente.Attivo);
                        command.Parameters.AddWithValue("@idcliente", cliente.IdCliente);

                        var result = command.ExecuteNonQuery();

                        return GetCliente(cliente.IdCliente);
                    }
                }
            }
        }
    }
}
