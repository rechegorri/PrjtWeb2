using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PrjtWeb2_cadastro_ocorrencia.Models
{
    public class AlunoRepository : AbstractRepository<Aluno, int>
    {
        public override void Delete(Aluno entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Aluno Where Id=@Id";
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
                string sql = "DELETE Aluno Where Id=@Id";
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

        public override List<Aluno> GetAll()
        {
            string sql = "Select Id, Nome, Endereco, Cidade, Telefone, RA FROM Aluno ORDER BY Nome";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Aluno> list = new List<Aluno>();
                Aluno p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Aluno();
                            p.id = (int)reader["Id"];
                            p.nome = reader["Nome"].ToString();
                            p.endereco = reader["Endereco"].ToString();
                            p.cidade = reader["Cidade"].ToString();
                            p.telefone = reader["Telefone"].ToString();
                            p.RA = (int)reader["RA"];
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

        public override Aluno GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Id, Nome, Endereco, Cidade, Telefone, RA FROM Aluno WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                Aluno p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Aluno();
                                p.id = (int)reader["Id"];
                                p.nome = reader["Nome"].ToString();
                                p.endereco = reader["Endereco"].ToString();
                                p.cidade = reader["Cidade"].ToString();
                                p.telefone = reader["Telefone"].ToString();
                                p.RA = (int)reader["RA"];
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

        public override void Save(Aluno entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO Aluno (Nome, Endereco, Cidade, Telefone, RA) VALUES (@Nome, @Endereco, @Cidade, @Telefone, @RA)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.nome);
                cmd.Parameters.AddWithValue("@Email", entity.endereco);
                cmd.Parameters.AddWithValue("@Cidade", entity.cidade);
                cmd.Parameters.AddWithValue("@Endereco", entity.telefone);
                cmd.Parameters.AddWithValue("@RA", entity.RA);
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

        public override void Update(Aluno entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE Aluno SET Nome=@Nome, Endereco=@Endereco, Cidade=@Cidade, Telefone=@Telefone, RA=@RA where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.nome);
                cmd.Parameters.AddWithValue("@Email", entity.endereco);
                cmd.Parameters.AddWithValue("@Cidade", entity.cidade);
                cmd.Parameters.AddWithValue("@Endereco", entity.telefone);
                cmd.Parameters.AddWithValue("@RA", entity.RA);
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
