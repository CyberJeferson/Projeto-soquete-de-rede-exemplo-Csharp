/*
 * Tela Home
 * Essa classe é responsável por exibir um player online, possui um chat global
 * que permite interações entre os jogadores, que poderão desafiar uns aos outros
 * no jogo da velha. 
 */

//Bibliotecas padrões do C#
using System;//Biblioteca padrão do C# para Strings e tratamento de erros. 
using System.Drawing;//Nesse projeto essa biblioteca está sendo usada para usar o recurso image
using System.IO;//Essa biblioteca está  sendo usada nesse projeto para usar o recurso memorystream
using System.Linq;//Biblioteca padrão usada para obter um caractere especifico de uma string nesse projeto
using System.Net;//Biblioteca padrão usada para baixar a imagem do player com o WebClient nesse projeto
using System.Windows.Forms;//Biblioteca padrão de formularios
using MySql.Data.MySqlClient;//Biblioteca do  mysql para linguagens .net

namespace JogoDaVelhaAPS
{
    public partial class Home : Form //Informa que essa classe é um formulário.
    {

        int LinhaSelecionada; //Cria um novo objeto do tipo inteiro
        String Comando;//Cria um novo objeto do tipo string
        String ConteudoAVeirificar;//Cria um novo objeto do tipo string
        public Home()//Método construtor da classe
        {
            InitializeComponent();
        }

        private static MySqlCommand mComando;//Cria um novo objeto do tipo mysqlCommand
        MySqlDataReader dtreader; //Cria um novo objeto do tipo MySqlDataReader
        String nmm;//Cria um novo objeto do tipo string
        String vt;//Cria um novo objeto do tipo string
        String dr;//Cria um novo objeto do tipo string
        String rcfoto;//Cria um novo objeto do tipo string
        Image rfoto;//Cria um novo objeto do tipo image
        object[] bplayer;//Cria uma nova array do tipo object
        WebClient rbaixar = new WebClient(); //Novo objeto do tipo WebClient
        byte[] brfoto;//Cria uma nova array do tipo byte
        MemoryStream rstream;//Cria um novo objeto do tipo MemoryStream


        /*
         * Ao carregar o formulário ele exibirá um top 5 de jogadores que fizeram mais pontos
         * no jogo da velha e para fazer usarames o método TopDez() esse método vai buscar esses dados
         * em um banco de dados e depois colocar em um datagridview.
         */
        private void TopDez()//Método top dez
        {

            //Primeiro passo é buscar os dados no banco de dados
            try
            {

          
                mComando = new MySqlCommand(); //mComando é um novo objeto MySqlCommand.
                mComando.Connection = dao.Conectar();//Sua conexão é definida como dao.Conectar() onde está as instruções de conexão com o banco de dados. 
                mComando.CommandText = "SELECT * FROM player  ORDER BY n_vitorias DESC LIMIT 5";//CommandText de mComando vai receber instruções em string do SQL informando para carregar todas as colunas da tabela player e organizar em ordem decrescente atraves da coluna n_vitorias com o LIMIT de 5 resultados

                dtreader = mComando.ExecuteReader(); //Usa o dtreader para ler os dados binarios, e executa a leitura do resultado.

                while (dtreader.Read()) //Enquanto estiver lendo os dados recebidos
                {
                    vt = dtreader["n_vitorias"].ToString(); //Recebe o número de vitorias em string
                    dr = dtreader["n_derrotas"].ToString();//Recebe o número de derrotas em string
                    nmm = dtreader["nm_player"].ToString();//Recebe o nome do player
                    rcfoto = dtreader["foto_player"].ToString();//Recebe o caminho da foto do player
                    brfoto = rbaixar.DownloadData(rcfoto); //A array brfoto recebe de rbaixar o download dos dados da foto do cliente de byte a byte
                    rstream = new MemoryStream(brfoto);//Grava os dados da array na memoria
                    rfoto = Image.FromStream(rstream);//Cria uma imagem apartir dos dados recebidos em rstream.
                    bplayer = new Object[] {rfoto, nmm, vt, dr}; //Array de objetos, bplayer vai receber a foto, o nome do player, o numero de vitorias e derrotas
                    Topd.Rows.Add(bplayer);//Depois a array será adionada nas linhas do tadagridview.
                }

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message); //Caso haja erros será avisado com uma popup
            }

            mComando.Connection.Close();//Fecha a  conexão com o banco de dados.




        }


        //Ao carregar a tela precisamos exibir coisas importantes também como nome do player numero de vitorias derrotas e o top 5
        //Para isso usaremos o método Home_Load que é um envento ao ser carregado o formulário ele vai exibir também todas essas coisas.
        private void Home_Load(object sender, EventArgs e)
        {
          
            label6.Text = Combate.getMeuId(); //Carrega o nome do jogador.
            label5.Text = "Vitórias: " + Combate.getPlayerVitorias() + " || Derrotas: " + Combate.getPlayerDerrotas(); //recebe o número de vitorias e derrotas do jogadorr
            pictureBox2.LoadAsync(Combate.getPlayerFoto()); //Recebe a foto do jogador
            TopDez();//Exibe o top 5 em um datagridview
          


        }

        
        public void setMensagemStatus(String texto)//Método usado para exibir um texto no label abaixo do número de vitorias e derrotas do jogador
        {
            StatusJogo.Text = texto; 
        }






        private bool FecharTudo;//Cria um novo objeto do tipo boleano
        public void Fechartudo(Boolean fechar)//Método usado para indicar se quer fechar todos os processos do programa
        {
            FecharTudo = fechar;
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)//Evento que ocorre quando fecha o formulario se a boleana fechar tudo ele vai fechar todos os processos em execução.
        {
            if (FecharTudo) //Se a boleana fecharTudo for verdadeiro 
            {
                Combate.LiberarIcone();//Libera o controle da notifyicon
                cMapa.fecharMapa();//Cancela o armazenamento de cache do mapa.
                Application.Exit();//Fecha todos os processos.
            }


        }
        Cliente cliente = new Cliente();//Instancia a classe Cliente
   
        private String Menssagem;//Cria um novo objeto do tipo string
        private int contar; //Cria um novo objeto do tipo inteiro
        private void Escutar_Tick(object sender, EventArgs e)//Timar envento tick a cada 100 ms ele vai disparar e chamar o método  receberMservidor()
        {
            receberMservidor();
        }


        /* MÓDULO CHAT GLOBAL.
         * Método receberMservidor, é responsável por verificar se os dados recebidos do servidor é uma conversa de chat global
         * se for ele vai adicionar em uma listbox os dados recbidos para serem exibidos ao jogador. 
         * 
         */
        private void receberMservidor()//Método receberMservidor()
        {
            //Ao receber uma mensagem de chat ele dever adicionar ao listbox o listbox será responsavel a exibir as mensagens de chat.


            Menssagem = Cliente.getMenssagemServidor();//A variavel Menssagem receberá os dados do servidor
         
            contar = listBox1.Items.Count;//contar vai receber o número de itens existentes no listbox
           




            try
            {
                if (Menssagem.ElementAt(9).ToString() == "m" && Menssagem.ElementAt(10).ToString() == "s" && Menssagem.ElementAt(11).ToString() == "g")//A partir do caractere na posição 9 de uma string recebida do servidor estiver os caracteres msg, então:
                {
           

                        if (contar <= 1) //Se o numero de itens do listbox for menor ou igual a 1
                        {
                            listBox1.Items.Add(Cliente.getMenssagemServidor());//Adicioa a nova mensagem


                        }
                        else
                        {   //Se a listbox for maior que 1
                            if (Menssagem == listBox1.Items[contar - 1].ToString())  //Se a mensagem recebida do servidor for igual a ultima mensagem do listbox:
                            {
                                //Não faz nada.
                            }
                            else
                            {   //Se não for igual 
                                listBox1.Items.Add(Cliente.getMenssagemServidor());    //Adiona a nova mensagem ao listbox                         
                                listBox1.SelectedIndex = listBox1.Items.Count - 1; //Seleciona a  mensagem recebida
                            }

                        }





                    
                }
                else
                {   //Se os dados recebidos não for uma conversa de chat então será um comando e para ler esse comando usaremos o método acoes na classe Combate para verificar se é um convite de batalha, uma recusa de convite ou uma posição onde o adversario jogou.
                    Combate.acoes(Cliente.getMenssagemServidor()); //Chama o método acoes na classe combate para ler o comando
                }
            }
            catch (Exception)
            {
                //Caso haja erros não fazer nada.

            }



         //Fim do módulo do chat global



        }
        //Método EnviarCht será responsavel em enviar mensagens de chat ao servidor quando chamado.
        private void EnviarCht()
        {
            if (textBox1.Text == "") //Se o campo de digitar a mensagem for vazio
            {
                label8.Text = "Digite uma Menssagem!";//A label vai avisar que deve digitar uma mensagem.
            }
            else
            {   //Se o campo de digitar não for vazio.

                Comando = "msg: " + Combate.getMeuId() + ": " + textBox1.Text; //A variavel comando recebe a string msg, o nome do jogador e sua mensagem
                cliente.setEnviarMensagem(Comando);//adiciona os dados de Comando na variavel responsavel por enviar string ao servidor
                Cliente.buffar();//Depois executa o envio em uma thread
                Combate.VerificarmensagemEnviada(Comando);//Veirifica se a mensagem foi realmente enviada
                textBox1.Text = "";//Limpa o campo de enviar mensagem no chat
                textBox1.Focus();//Foca no campo d enviar mensagem no chat



            }

        }
        //Ao pressionar enter no campo de enviar mensagem no chat ele deve imediatamente chamar o método EnviarCht para concluir o envio, e para isso estou usando o evento key down, quando enter é pressionado
        private void textBox1_KeyDown(object sender, KeyEventArgs e)//textBox1_KeyDown Quando uma tecla for pressionada no campo de enviar texto para o chat
        {
            if (e.KeyCode == Keys.Enter)//Verifica se foi enter a tecla pressionada
            {
               //Se a tecla foi enter
                EnviarCht();//Chama o método EnviarCht Para concluir o envio de uma nova mensagem ao chat global

            }
        }
        //Agora que carregamos os player online verificamos mensagens enviadas no chat e enviamos mensagem podemos ir ao próximo passo
        //Verificar quem está onine, para podermos desafiar em uma batalha no jogo da velha.

        String tempOnline; //Cria um novo objeto do tipo String
        Image onimgFoto; //Novo objeto do tipo image
        object[] LinhaPlayers; //Nova array do tipo object que recebe qualquer variavel.
        WebClient Baixar = new WebClient();//Novo objeto do tipo WebClient para baixar arquivos na internet
        byte[] bFoto;//nova array do tipo byte
        MemoryStream mStream;//Novo objeto do tipo MemoryStream
        private bool taon = false;
        private String auxPl;
        //O próximo métdo (POnline_Tick), é um evento de Timer que dispara a cada 100 ms, Ele vai verificar os jogadores que estão online e adicionar em um datagrid para o jogador poder clicar emseu nome ou foto para desafiar em uma nova batalha.
        private void POnline_Tick(object sender, EventArgs e)///Método POnline_Tick
        {

          
                //O primeiro passo para verificar se existe jogadores online é verificar na mensagem do servidor quem está online. em determinado tempo ele vai enviar essa mensagem. então devemos reconhece-la.
                try
                {
                    if (Cliente.getMenssagemServidor().ElementAt(0).ToString() == "X" && Cliente.getMenssagemServidor().ElementAt(1).ToString() == "n")//Se nos dados recebidos do servidor estiverem no inicio os caracteres 0n, então:
                    {



                        gPlayerOn.Rows.Clear();//Limpa as linhas do datagrid que vai exibir os players online.
                        tempOnline = "";//A auxiliar tempOnline também ficará vazia.
                        if (Cliente.getMenssagemServidor().ElementAt(0).ToString() == ">")
                        {

                        }

                        for (int i = 3; i < Cliente.getMenssagemServidor().Length; i++) //Do caractere na posição 3 até o ultimo caracere da mensagem recebida do servidor faça:
                        {


                            if (Cliente.getMenssagemServidor().ElementAt(i).ToString() != ",")//Se o caractere for diferente de virgula:
                            {
                                tempOnline = tempOnline + Cliente.getMenssagemServidor().ElementAt(i).ToString();//Aauxiliar recebe ela mesma e o caractere da mensagem recebida do servidor.

                            }
                            else
                            {



                                //Se o caractere for uma virgula.
                                dao.PesqOnline(tempOnline);//Pesquisa o nome do player que está na auxiliar tempOnline e Coloca seus valores nas variaveis de players online na classe Combate.




                                bFoto = Baixar.DownloadData(Combate.getOnFotoString());//Baixa a foto do player e coloca em bfoto byte a byte.
                                mStream = new MemoryStream(bFoto);//mStream recebe os dados, e salva na memoria
                                onimgFoto = Image.FromStream(mStream);//Cria uma nova imagem a partir dos dados de mStream.
                                LinhaPlayers = new Object[] { onimgFoto, Combate.getOnid() }; //A array LinhaPlayers recebe a foto e o nome do jogador.

                            if (Combate.getOnid() != "")
                            {
                                gPlayerOn.Rows.Add(LinhaPlayers);//Depois a array é adicionada como uma nova linha no datagridview onde exibirá o player online.
                            }
                               
                                tempOnline = "";//Limpa a auxiliar.
                                Combate.setOnid("");










                            }


                        }


                    }

                }
                catch (Exception)
                {
                    //Em caso de erros não fazer nada.

                }
            
               
            
       


            
           

        }
        
        private void label7_Click(object sender, EventArgs e)//Label que quando clicada ela deve fechar todos os processos do programa.
        {

            FecharTudo = true;//Diz que vai fechar todos processos ao fechar o formulario.
            this.Close();//Fecha o formulario.
        }


        String PlayerTemp;//Cria um novo objeto do tipo String

        //O próximo passo agora é clicar em cima do datagrid e aparecer um menu indicando se quer batalhar com o player online, e para isso usaremos o evento do datagrid gPlayerOn_CellClick
        //E támbem usaremos um contextmenustrip que deve aparecer quando alguma linha do datagridview for clicada
        private void gPlayerOn_CellClick(object sender, DataGridViewCellEventArgs e)//evento gPlayerOn_CellClick
        {
            //Quando alguma linha do datagrid for clicada.
            LinhaSelecionada = gPlayerOn.CurrentCell.RowIndex;//Recebe a linha selecionada do datagridview.
            PlayerTemp = gPlayerOn.Rows[LinhaSelecionada].Cells[1].Value.ToString();//PlayerTemp recebe o valor da cédula na segunda coluna da linha selecionada. "O nome do jogador".

            if (Combate.getMeuId() != PlayerTemp)//Se o o nome do jogador for diferente do nome do jogador selecionado no datagrid então:
            {
              
                MenuBatalha.Show(MousePosition.X, MousePosition.Y);//Exibe o contextmenustrip na posição x e y do mouse.

            }
        }

        //Exibindo o menustrip ele terá uma opção que é a opção "Desafiar no jogo da velha", caso o player clique nessa opção um convite será enviado para o jogador selecionado no datagridview e ele deve aguardar a resposta do jogador.
       
        Random Qual = new Random();//Cria um novo objeto do tipo random
        int QuemComeça;//Novo objeto do tipo inteiro
        int escLetra;//Novo objeto do tipo inteiro
        AguardarResposta resp; //Novo objeto do tipo AguardarResposta. O formulario AguardarResposta.

        //Se o player desafiar outro jogador então algumas coisas serão enviadas ao servidor para o outro jogador receber essas informações. 
        //Quando o jogador clicar em desafiar no jogo da velha, será chamado o método DecidirRegras que definir de forma aleatoria quem deve jogar primeiro e qual será sua letra no jogo e a letra do jogador adversario.
        private void DecidirRegras()//Método decidir regras.
        {
            
            QuemComeça = Qual.Next(2);//Quem começa recebe um número inteiro de 0 até 1, de forma aleatória. 
          
            escLetra = Qual.Next(2);//escLetra recebe um número inteiro de 0 até 1, de forma aleatória.
            //O próximo passo é obter a letra dos jogadores no jogo.
            switch (escLetra)//Se o valor recebido em esLetra for:
            {
                case 0://Se for 0
                    Combate.setMinhaLetra("O");//A letra do jogador é O
                    Combate.setAdversarioLetra("X");//A letra do adversario é X
                    break;//Para a instrução
                case 1://Se for 1
                    Combate.setMinhaLetra("X");//A letra do jogador é X
                    Combate.setAdversarioLetra("O");//A letra do adversario é O
                    break;//Para a instrução

            }
            //Agora deve dizer quem começa primeiro.
            switch (QuemComeça)//Se o valor recebido em esLetra QuemComeça:
            {
                case 0://Se for 0
                    Combate.setQuemComeca(Combate.getMeuId()); //O player começa primeiro
                    break;//Para a instrução
                case 1://Se for 1
                    Combate.setQuemComeca(Combate.getIdAdversario());//O adversario começa primeiro
                    break;//Para a instrução
            }
            //Depois de obtido as letras dos jgadores e o nome de quem começa primeiro de forma aleatoria, ou randomica o próximo passo é enviar essas informações ao servidor socket para o adversario receber essas informações.
            
            ConteudoAVeirificar = "cvt" + Combate.getIdAdversario() + "," + Combate.getAdversarioLetra() +","+ Combate.getMeuId() + "," + Combate.getMinhaLetra() + "," + Combate.getQuemComeca() + ",";// ConteudoAVeirificar recebe a string cvt, o nome do adversario, a letra do adversario,o nome do player, a letra do player e o nome de quem começa primeiro separado por virgulas.
            cliente.setEnviarMensagem(ConteudoAVeirificar);//Coloca o conteudo na variavel que envia essas informações ao servidor
            Cliente.buffar();//Envia as informações ao servidor em uma thread
            Cliente.desbufar();
            Combate.VerificarmensagemEnviada(ConteudoAVeirificar);//Verifica se o servidor recebeu essas informações.
      
            Combate.setAceitouConvite("");//Limpa a variavel onde diz se o adversario aceitou o convite para aguardar sua resposta.
            resp = new AguardarResposta(); //Intancia o formulário que aguarda a resposta do convite de batalha
            resp.Show();//Faz o formulario aparecer.

        }

        //O ultumi método é o método que mDesafiar_Click() é um evento de click do menustripbox na opção  mDesafiar "Desafiar no jogo da velha".
        private void mDesafiar_Click(object sender, EventArgs e)//Evento mDesafiar_Click()
        {
            //Ao clicar no menu na opção desafiar no jogo da velha.
           
            Combate.setIdAdversario(PlayerTemp);//Define o nome do adversario que está em PlayerTemp
            DecidirRegras();// Chama o método DecidirRegras para dizer qual será a letra de cada um e quem começa primeiro.




        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.FecharTudo(false);            
            frmOcorrencias oco = new frmOcorrencias();
            oco.Show();
            this.Close();
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            EnviarCht();
        }

        private void Limpar_Tick(object sender, EventArgs e)
        {

        }

        private void Veirificar_Tick(object sender, EventArgs e)
        {

        }
    }
}
