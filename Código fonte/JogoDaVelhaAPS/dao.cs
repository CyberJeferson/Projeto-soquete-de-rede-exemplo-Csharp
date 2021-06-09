/*
 * Classe dao.
 * Essa classe é responsável por gravar e ler algumas informações no banco de dados.
 */
using System;//Biblioteca padrão do C# usada no projeto para Criar variaveis em String e tratamento de erro em catch
using MySql.Data.MySqlClient;//Biblioteca do Mysql do oracle, para linguagens .NET

namespace JogoDaVelhaAPS//O projeto está dentro da solução JogoDaVelhaAPS
{
    class dao
    {
      
        private static MySqlConnection Conexao;//Cria um novo objeto do tipo MySqlConnection 
        private static MySqlCommand mComando;//Cria um novo objeto do tipo MySqlCommand




        //O proximo passo é o método Conectar() onde vai retornar a conexão do banco de dados
        public static MySqlConnection Conectar()//Método Conectar
        {
            try
            {
                Conexao = new MySqlConnection("server=192.168.0.9;uid=root;database=jogo_da_velha;pwd=123");//Conexão recebe uma nova conexão com o ip do servidor usuario e senha informados.
                Conexao.Open();//Abre a conexão
               
            }
            catch (Exception e)//Se tiver erro
            {
                System.Windows.Forms.MessageBox.Show("Houve um erro no servidor. " + e.Message);//Exibe o erro na tela
                Program.FecharJogo();//Fecha o jogo
            }
            return Conexao;//Retorna a conexão.
          
        }
        static MySqlDataReader dtreader;//Cria um novo objeto do tipo MySqlDataReader
        static bool criuouconta;//Cria um novo objeto do tipo boleano
     

        public static void PesquisarPlayer(String nome, String Senha)//Método PesquisarPlayer usado para Pesquisar um player no banco de dados, que quer logar no jogo
        {
            
            try
            {
                Combate.setMeuId("");//Deixa o nome do jogador vazio na Classe combate
                Conectar();//Conecta ao banco de dados
                mComando = new MySqlCommand();//Diz que mComando é um novo objeto MySqlCommand
                mComando.Connection = Conexao;//mComando recebe a conexão com o banco de dados
                mComando.CommandText = "SELECT * FROM player  WHERE nm_player LIKE '" + nome + "' AND " + "senha_player = '" + Senha + "'";//Comando SQL para pesquisar o jogador no banco de dados.

                dtreader = mComando.ExecuteReader();//Ler os dados binarios da pesquisa

                while (dtreader.Read())//Enquanto estiver lendo os dados
                {
                    Combate.setMeuId(dtreader["nm_player"].ToString());//Grava o nome do jogador
                    Combate.setPlayerFoto(dtreader["foto_player"].ToString());//Grava o caminho da foto
                    Combate.setPlayerVitorias(int.Parse(dtreader["n_vitorias"].ToString()));//Grava o número de vitórias
                    Combate.setPlayerDerrotas(int.Parse(dtreader["n_derrotas"].ToString()));//Grava o número de derrotas.
       
                   
                }
                
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);//Se tiver erro exibe-o na tela
            }
            
            Conexao.Close();//Fecha a conexão com o banco de dados.
           

        }

        public static bool CriarPlayer(Combate c)//Método usado para criar uma nova conta no banco de dados quando chamado
        {
            criuouconta = false;//criuouconta recebe o valor falso
            try
            {
              
                Conectar();//Conecta ao banco de dados
                mComando = new MySqlCommand();//Instancia mComando
                mComando.Connection = Conexao;//mComando recebe a conexão
                mComando.CommandText = "INSERT INTO player(nm_player,senha_player,foto_player,n_vitorias,n_derrotas) VALUES(@nome,@senha,@foto,@vitorias,@derrotas)";//Recebe o comando do SQL para inserir o novo jogador no banco de dados
              
                mComando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = c.getcNome();//O parametro @nome recebe o nome do jogador
                mComando.Parameters.Add("@senha", MySqlDbType.VarChar).Value = c.getcSenha();//O parametro @senha recebe a senha do jogador
                mComando.Parameters.Add("@foto", MySqlDbType.VarChar).Value = c.getcFoto();//O parametro @Foto recebe a foto do jogador
                mComando.Parameters.Add("@vitorias", MySqlDbType.VarChar).Value = Combate.getPlayerVitorias();//O parametro @vitorias recebe o numero de vitorias do jogador o padrão é 0 vitorias
                mComando.Parameters.Add("@derrotas", MySqlDbType.VarChar).Value = Combate.getPlayerDerrotas();//O parametro @derrotas recebe o numero de derrotas do jogador o padrão é 0 derrotas

                mComando.ExecuteNonQuery();//Executa o comando do SQL

                criuouconta = true;// criuouconta Recebe o valor verdadeiro.

            }
            catch (MySqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);//Em caso de erro exibira na tela a mensagem do erro

            }
          
            Combate.setMeuId("");//Limpa o nome do jogador
            Combate.setSenha("");//Limpa a senha
            Combate.setPlayerFoto("");//Limpa a foto

            Conexao.Close();//Fecha a conexão com o banco de dados
            return criuouconta;//Retorna a boleana criuouconta 
        }
        //O próximo método PesqOnline, é usado para pesquisar o jogador online no banco de dados de acordo com a informação em seu parametro.
        public static void PesqOnline(String nome)//Método PesqOnline
        {




            try
            {
            
                Conectar();//Conecta ao banco de dados
                mComando = new MySqlCommand();//mComando é instanciado como um novo MySqlCommand
                mComando.Connection = Conexao;//Recebe a conexão
                mComando.CommandText = "SELECT * FROM player  WHERE nm_player = '" + nome + "'";//Recebe as instruções SQL para pesquisar um jogador atraves do nome.

                dtreader = mComando.ExecuteReader();//Ler os dados binarios recebidos do banco de dados

                while (dtreader.Read())//Enquanto estiver lendoos dados recebidos
                {
                    Combate.setOnid(dtreader["nm_player"].ToString());//Grava o nome do jogador online na Classe Combate
                    Combate.setOnstringFoto(dtreader["foto_player"].ToString());//Grava a foto do jogador online na classe Combate
                }

            }
            catch (MySqlException)
            {
                
            }

            Conexao.Close();//Fecha a conexão com o banco de dados.
        }

        public static void Pontuar(String Nome, int Pontoganho,int Derrotas)//Método pontuar usado para alterar a pontuação do jogador no banco de dados
        {
            //-----------------------------------------------------
            try
            {

                Conectar();//Conecta no banco de dados.
                mComando = new MySqlCommand();//Intancia um novo MySqlCommand
                mComando.Connection = Conexao;//Recebe a conexão
                mComando.CommandText = "UPDATE player SET n_vitorias = @vitorias, n_derrotas = @derrotas WHERE nm_player = @nome";//Recebe as instruções SQL para informar o que deve ser alterado(vitorias e derrotas).
                mComando.Parameters.AddWithValue("@vitorias", Convert.ToInt16(Pontoganho));//O parametro @vitorias recebe o número de vitórias 
                mComando.Parameters.AddWithValue("@derrotas", Convert.ToInt16(Derrotas));//O parametro @derrotas recebe o número de derrotas.
                mComando.Parameters.AddWithValue("@nome", Nome);//O parametro @nome recebe o nome.
                mComando.ExecuteNonQuery();

              
                Conexao.Close();//Fecha a conexão com o banco de dados.
            }
            catch (MySqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);//Em caso de erro exibirá a mensagem do erro
            }
            //----------------------------------------------------------
          
        }

        //Opróximo metodo é usado para pesquisar o adversário e gravar a foto dele na classe combate
        public static void PesquisarAdversario(String nome)//Método PesquisarAdversario
        {

            try
            {

                Conectar();//Conecta ao banco de dados
                mComando = new MySqlCommand();//mComando é um novo objeto do tipo MySqlCommand
                mComando.Connection = Conexao;//Recebe a conexão com o bando de dados
                mComando.CommandText = "SELECT * FROM player  WHERE nm_player LIKE '" + nome + "'";//Recebe o comando em SQL para pesquisar o adversrio pelo nome.

                dtreader = mComando.ExecuteReader();//Recebe os dados em binario

                while (dtreader.Read())//Enquanto estiver lendo os dados recebidos
                {
                    Combate.setAdversarioCaminhoFoto(dtreader["foto_player"].ToString());//Grava a foto do adversario na classe Combate
                }

            }
            catch (MySqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);//Em caso de erro exibirá na tela o erro
            }

            Conexao.Close();//Fecha a conexão do banco de dados.






        }


        public static void InserirOcorrencia(String tipo, String Ocorrencia, String Latitude, String Longitude)
        {
            try
            {
                Conectar();//Conecta ao banco de dados
                mComando = new MySqlCommand();//Instancia mComando
                mComando.Connection = Conexao;//mComando recebe a conexão
                mComando.CommandText = "INSERT INTO ocorrencia(tipo_ocorrencia,ds_ocorrencia,latitude,longetude) VALUES(@tp,@ocorrencia,@latitude,@longetude)";//Recebe o comando do SQL para inserir o novo jogador no banco de dados
                
                mComando.Parameters.Add("@tp", MySqlDbType.VarChar).Value = tipo;
                mComando.Parameters.Add("@ocorrencia", MySqlDbType.VarChar).Value = Ocorrencia;
                mComando.Parameters.Add("@latitude", MySqlDbType.VarChar).Value = Latitude;
                mComando.Parameters.Add("@longetude", MySqlDbType.VarChar).Value = Longitude;


                mComando.ExecuteNonQuery();//Executa o comando do SQL


                Conexao.Close();//Fecha a conexão com o banco de dados.
                System.Windows.Forms.MessageBox.Show("Nova Ocorrencia gerada!!!");
            }
            catch (Exception)
            {

            }
        }
       private static String Lt, Ld;
        public static void ObterCordenadasOcorrencias(String codigo)
        {
            try
            {

                Conectar();//Conecta ao banco de dados
                mComando = new MySqlCommand();//mComando é um novo objeto do tipo MySqlCommand
                mComando.Connection = Conexao;//Recebe a conexão com o bando de dados
                mComando.CommandText = "SELECT * FROM player  WHERE cd_ocorrencia = '" + codigo + "'";

                dtreader = mComando.ExecuteReader();//Recebe os dados em binario

                while (dtreader.Read())//Enquanto estiver lendo os dados recebidos
                {

                    Lt = dtreader["latitude"].ToString();

                    Ld = dtreader["longitude"].ToString();

                }
            }
            catch (Exception)
            {

            }
        }

    }//FIM DA CLASSE DAO
}//FIM DO NAME SPACE
