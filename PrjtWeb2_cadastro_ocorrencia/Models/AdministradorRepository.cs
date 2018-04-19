using PrjtWeb2_cadastro_ocorrencia.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PrjtWeb2_cadastro_ocorrencia.Models
{
    public class AdministradorRepository : AbstractRepository<Administrador, int>
    {
        public override void Delete(Administrador entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Administrador Where Id=@Id";
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
                string sql = "DELETE Administrador Where Id=@Id";
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

        public override List<Administrador> GetAll()
        {
            string sql = "Select Id, Nome, Endereco, Cidade, Telefone, REG FROM Administrador ORDER BY Nome";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Administrador> list = new List<Administrador>();
                Administrador p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Administrador();
                            p.id = (int)reader["Id"];
                            p.nome = reader["Nome"].ToString();
                            p.endereco = reader["Endereco"].ToString();
                            p.cidade = reader["Cidade"].ToString();
                            p.telefone = reader["Telefone"].ToString();
                            p.REG = (int)reader["REG"];
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

        public override Administrador GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Id, Nome, Endereco, Cidade, Telefone, REG FROM Administrador WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                Administrador p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Administrador();
                                p.id = (int)reader["Id"];
                                p.nome = reader["Nome"].ToString();
                                p.endereco = reader["Endereco"].ToString();
                                p.cidade = reader["Cidade"].ToString();
                                p.telefone = reader["Telefone"].ToString();
                                p.REG = (int)reader["RA"];
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

        public override void Save(Administrador entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO Administrador (Nome, Endereco, Cidade, Telefone, REG) VALUES (@Nome, @Endereco, @Cidade, @Telefone, @REG)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.nome);
                cmd.Parameters.AddWithValue("@Email", entity.endereco);
                cmd.Parameters.AddWithValue("@Cidade", entity.cidade);
                cmd.Parameters.AddWithValue("@Endereco", entity.telefone);
                cmd.Parameters.AddWithValue("@REG", entity.REG);
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

        public override void Update(Administrador entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE Administrador SET Nome=@Nome, Endereco=@Endereco, Cidade=@Cidade, Telefone=@Telefone, REG=@REG where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.nome);
                cmd.Parameters.AddWithValue("@Email", entity.endereco);
                cmd.Parameters.AddWithValue("@Cidade", entity.cidade);
                cmd.Parameters.AddWithValue("@Endereco", entity.telefone);
                cmd.Parameters.AddWithValue("@REG", entity.REG);
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
