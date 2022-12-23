using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MySqlConnector;

namespace Atividade2.Models
{
    public class PacotesRepository
    {

        private const string DadosConexao = "Database=agencia; Data source=localhost; User Id=root;";

        public void Excluir(PacotesTuristicos pt)
        {
             MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            Conexao.Open();

            string Query = "delete from pacotesTuristicos where idPacote = @idPacote";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@idPacote", pt.Id);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
        public void Inserir(PacotesTuristicos pt)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            Conexao.Open();

            string Query = "insert into pacotesTuristicos (nomePacote, origemPacote, destinoPacote, atrativosPacote, saidaPacote, chegadaPacote) values (@nome, @origem, @destino, @atrativos, @saida, @chegada);";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@nome", pt.Nome);
            Comando.Parameters.AddWithValue("@origem", pt.Origem);
            Comando.Parameters.AddWithValue("@destino", pt.Destino);
            Comando.Parameters.AddWithValue("@atrativos", pt.Atrativos);
            Comando.Parameters.AddWithValue("@saida", pt.Saida);
            Comando.Parameters.AddWithValue("@chegada", pt.Retorno);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
        public void Editar(PacotesTuristicos pt)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            Conexao.Open();

            string Query = "update pacotesTuristicos set nomePacote=@nome, origemPacote=@origem, destinoPacote=@destino, atrativosPacote=@atrativos, saidaPacote=@saida, chegadaPacote=@chegada where idPacote = @idPacote;";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@idPacote", pt.Id);
            Comando.Parameters.AddWithValue("@nome", pt.Nome);
            Comando.Parameters.AddWithValue("@origem", pt.Origem);
            Comando.Parameters.AddWithValue("@destino", pt.Destino);
            Comando.Parameters.AddWithValue("@atrativos", pt.Atrativos);
            Comando.Parameters.AddWithValue("@saida", pt.Saida);
            Comando.Parameters.AddWithValue("@chegada", pt.Retorno);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
        public List<PacotesTuristicos> Listar()
        {
           MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            Conexao.Open();

            string Query = "select * from pacotesTuristicos;";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<PacotesTuristicos> Lista = new List<PacotesTuristicos>();

            while(Reader.Read())
            {
                PacotesTuristicos PacotesEncontrados = new PacotesTuristicos();
                PacotesEncontrados.Id = Reader.GetInt32("idPacote");
                if(!Reader.IsDBNull(Reader.GetOrdinal("nomePacote")))
                    PacotesEncontrados.Nome = Reader.GetString("nomePacote");
                if(!Reader.IsDBNull(Reader.GetOrdinal("origemPacote")))
                    PacotesEncontrados.Origem = Reader.GetString("origemPacote");
                if(!Reader.IsDBNull(Reader.GetOrdinal("destinoPacote")))
                    PacotesEncontrados.Destino = Reader.GetString("destinoPacote");
                if(!Reader.IsDBNull(Reader.GetOrdinal("atrativosPacote")))
                    PacotesEncontrados.Atrativos = Reader.GetString("atrativosPacote");

                    PacotesEncontrados.Saida = Reader.GetDateTime("saidaPacote");
                    PacotesEncontrados.Retorno = Reader.GetDateTime("chegadaPacote");

                Lista.Add(PacotesEncontrados);

            }

            Conexao.Close();

            return Lista;
        }

        public PacotesTuristicos BuscarPorId(int idPacote)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            Conexao.Open();

            string Query = "select * from pacotesTuristicos where idPacote=@idPacote;";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@idPacote", idPacote);

            MySqlDataReader Reader = Comando.ExecuteReader();

            PacotesTuristicos PacotesEncontrados = new PacotesTuristicos();

            if(Reader.Read())
            {
                PacotesEncontrados.Id = Reader.GetInt32("idPacote");
                if(!Reader.IsDBNull(Reader.GetOrdinal("nomePacote")))
                    PacotesEncontrados.Nome = Reader.GetString("nomePacote");
                if(!Reader.IsDBNull(Reader.GetOrdinal("origemPacote")))
                    PacotesEncontrados.Origem = Reader.GetString("origemPacote");
                if(!Reader.IsDBNull(Reader.GetOrdinal("destinoPacote")))
                    PacotesEncontrados.Destino = Reader.GetString("destinoPacote");
                if(!Reader.IsDBNull(Reader.GetOrdinal("atrativosPacote")))
                    PacotesEncontrados.Atrativos = Reader.GetString("atrativosPacote");

                    PacotesEncontrados.Saida = Reader.GetDateTime("saidaPacote");
                    PacotesEncontrados.Retorno = Reader.GetDateTime("chegadaPacote");

            }

            Conexao.Close();

            return PacotesEncontrados;
        }

    }
}