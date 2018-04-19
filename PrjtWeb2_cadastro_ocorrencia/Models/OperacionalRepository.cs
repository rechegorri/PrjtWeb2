using PrjtWeb2_cadastro_ocorrencia.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PrjtWeb2_cadastro_ocorrencia.Models
{
    public class OperacionalRepository : AbstractRepository<Operacional, int>
    {
        public override void Delete(Operacional entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Operacional Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", entity.id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Operacional Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override List<Operacional> GetAll()
        {
            string sql = "Select Id, Nome, Endereco, Cidade, Telefone, funcao FROM Operacional ORDER BY Nome";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Operacional> list = new List<Operacional>();
                Operacional p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Operacional();
                            p.id = (int)reader["Id"];
                            p.nome = reader["Nome"].ToString();
                            p.endereco = reader["Endereco"].ToString();
                            p.cidade = reader["Cidade"].ToString();
                            p.telefone = reader["Telefone"].ToString();
                            p.funcao = (string)reader["funcao"];
                            list.Add(p);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return list;
            }
        }

        public override Operacional GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Id, Nome, Endereco, Cidade, Telefone, funcao FROM Operacional WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                Operacional p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Operacional();
                                p.id = (int)reader["Id"];
                                p.nome = reader["Nome"].ToString();
                                p.endereco = reader["Endereco"].ToString();
                                p.cidade = reader["Cidade"].ToString();
                                p.telefone = reader["Telefone"].ToString();
                                p.funcao = (string)reader["Funcao"];
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }

        public override void Save(Operacional entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO Operacional (Nome, Endereco, Cidade, Telefone, funcao) VALUES (@Nome, @Endereco, @Cidade, @Telefone, @funcao)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.nome);
                cmd.Parameters.AddWithValue("@Email", entity.endereco);
                cmd.Parameters.AddWithValue("@Cidade", entity.cidade);
                cmd.Parameters.AddWithValue("@Endereco", entity.telefone);
                cmd.Parameters.AddWithValue("@funcao", entity.funcao);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override void Update(Operacional entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE Operacional SET Nome=@Nome, Endereco=@Endereco, Cidade=@Cidade, Telefone=@Telefone, funcao=@funcao where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.nome);
                cmd.Parameters.AddWithValue("@Email", entity.endereco);
                cmd.Parameters.AddWithValue("@Cidade", entity.cidade);
                cmd.Parameters.AddWithValue("@Endereco", entity.telefone);
                cmd.Parameters.AddWithValue("@funcao", entity.funcao);
                cmd.Parameters.AddWithValue("@Id", entity.id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}