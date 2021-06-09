/*
 * Tela Form1, essa classe éonde ocorre a batalha do jogo da velha.
 */
using System;//Biblioteca padrão do C# usada no projeto para criar Strings e exceções
using System.Drawing;//Biblioteca do C# usada no projeto para definir a posição das labels.
using System.Linq;//Biblioteca do C# usada para capturar um caractere em certa posição dentro de uma string
using System.Windows.Forms;//Biblioteca de formulários do C#

namespace JogoDaVelhaAPS//Informa a solução one está a classe
{
  
    public partial class Form1 : Form//Diz que a classe é um formulário.
    {

        String Jogador;  //Cria um novo objeto do tipo String      
        String Comando;//Novo objeto do tipo String
        private bool Bloquear;//Novo objeto do tipo boleano
        private String VerificarMensagem;//Novo objeto do tipo string
      
        public Form1()//Construtor da classe.
        {
            InitializeComponent();
        }

        /*
         * Essa classe possui 9 botões usados para o jogo da velha.
         * Os botões vão responder ao clique do jogador com X ou O
         * 
         */
        private void LimparBotoes()//Método usado para limpar os botões do jogo da velha.
        {
            button1.Text = "";//Limpar o botão
            button2.Text = "";//Limpar o botão
            button3.Text = "";//Limpar o botão
            button6.Text = "";//Limpar o botão
            button5.Text = "";//Limpar o botão
            button4.Text = "";//Limpar o botão
            button9.Text = "";//Limpar o botão
            button8.Text = "";//Limpar o botão
            button7.Text = "";//Limpar o botão
        }
        private Cliente cliente = new Cliente();//Instancia a classe Cliente
      
        //Eventos dos botões usados no jogo.========================================================
        private void button1_Click(object sender, EventArgs e)//Evento clique do botão do jogo da velha
        {
            if (Bloquear == false)//Se a boleana bloquer for falso
            {
                if (button1.Text == "")//Se o botão estiver vazio
                {
                    Bloquear = true;//Bloquear rebe o valor verdadeiro.
                    button1.Text = Jogador; //O botão recebe a letra do jogador X ou O
                    VerificarMensagem = "mvr" + Combate.getMeuId() + ",p1";// Verificar mensagem recebe mvr mais o nome do jogador e a string p3 separado por virgula
                    cliente.setEnviarMensagem(VerificarMensagem);//A informação é gravada na variavel que entrega ao servidor
                    Cliente.buffar();//a informação é enviada ao servidor atravéz de uma thread.

                    Combate.VerificarmensagemEnviada(VerificarMensagem);//Verifica se foi enviada a informação.

                    button1.ForeColor = Color.Green;//O botão recebe a cor de texto verde
                    Status.Text = "AGUARDE " + Combate.getIdAdversario() + " JOGAR!";//a label status exibirá aguarde, o nome do adversio e a string jogar.
                   
                    VerificarLetra = Combate.getMinhaLetra();//VerificarLetra  recebe a letra do jogador
                    VerificarPartida();//Verifica se o jogador venceu a partida, perdeu ou empatou
                    VerificarLetra = Combate.getAdversarioLetra();//Verificarletra Recebe a letra do adversario
                    VerificarPartida();//Verifica se o adversario venceu perdeu ou empatou.
                   //Obs: eu sei que existe uma lógica se o jogador está jogando então devo verificar se ele venceu e não o adversario e vice versa, mas fiz assim para evitar bugs.
                }

            }



          

        }
        

        private void button2_Click(object sender, EventArgs e)//Evento clique do botão do jogo da velha 
        {
            if (Bloquear == false)//Se a boleana bloquer for falso
            {
                if (button2.Text == "")//Se o botão estiver vazio
                {
                    Bloquear = true;//Bloquear rebe o valor verdadeiro.
                    button2.Text = Jogador;  //O botão recebe a letra do jogador X ou O
                    VerificarMensagem = "mvr" + Combate.getMeuId() + ",p2";// Verificar mensagem recebe mvr mais o nome do jogador e a string p3 separado por virgula
                    cliente.setEnviarMensagem(VerificarMensagem);//A informação é gravada na variavel que entrega ao servidor
                    Cliente.buffar();//a informação é enviada ao servidor atravéz de uma thread.

                    Combate.VerificarmensagemEnviada(VerificarMensagem);//Verifica se foi enviada a informação.

                    button2.ForeColor = Color.Green;//O botão recebe a cor de texto verde
                    Status.Text = "AGUARDE " + Combate.getIdAdversario() + " JOGAR!";//a label status exibirá aguarde, o nome do adversio e a string jogar.
                   
                    VerificarLetra = Combate.getMinhaLetra();//VerificarLetra  recebe a letra do jogador
                    VerificarPartida();//Verifica se o jogador venceu a partida, perdeu ou empatou
                    VerificarLetra = Combate.getAdversarioLetra();//Verificarletra Recebe a letra do adversario
                    VerificarPartida();//Verifica se o adversario venceu perdeu ou empatou.
                }
            }
  


        }

        private void button3_Click(object sender, EventArgs e)//Evento clique do botão do jogo da velha 
        {
            if (Bloquear == false)//Se a boleana bloquer for falso
            {
                if (button3.Text == "")//Se o botão estiver vazio
                {
                    Bloquear = true;//Bloquear rebe o valor verdadeiro.
                    button3.Text = Jogador; //O botão recebe a letra do jogador X ou O
                    VerificarMensagem = "mvr" + Combate.getMeuId() + ",p3";//Verificar mensagem recebe mvr mais o nome do jogador e a string p3 separado por virgula
                    cliente.setEnviarMensagem(VerificarMensagem);//A informação é gravada na variavel que entrega ao servidor
                    Cliente.buffar();//a informação é enviada ao servidor atravéz de uma thread.
              
                    Combate.VerificarmensagemEnviada(VerificarMensagem);//Verifica se foi enviada a informação.

                    button3.ForeColor = Color.Green;//O botão recebe a cor de texto verde
                    Status.Text = "AGUARDE " + Combate.getIdAdversario() + " JOGAR!";//a label status exibirá aguarde, o nome do adversio e a string jogar.
                    
                    VerificarLetra = Combate.getMinhaLetra();//VerificarLetra  recebe a letra do jogador
                    VerificarPartida();//Verifica se o jogador venceu a partida, perdeu ou empatou
                    VerificarLetra = Combate.getAdversarioLetra();//Verificarletra Recebe a letra do adversario
                    VerificarPartida();//Verifica se o adversario venceu perdeu ou empatou.
                    //Essas instruções se repetem nos 9 botões
                }

            }





        }
        
        private void button6_Click(object sender, EventArgs e)//Evento clique do botão do jogo da velha 
        {
            if (Bloquear == false)//Se a boleana bloquer for falso
            {
                if (button6.Text == "")//Se o botão estiver vazio
                {
                    Bloquear = true;//Bloquear rebe o valor verdadeiro.
                    button6.Text = Jogador; //O botão recebe a letra do jogador X ou O
                    VerificarMensagem = "mvr" + Combate.getMeuId() + ",p6";//Verificar mensagem recebe mvr mais o nome do jogador e a string p3 separado por virgula
                    cliente.setEnviarMensagem(VerificarMensagem);//A informação é gravada na variavel que entrega ao servidor
                    Cliente.buffar();//a informação é enviada ao servidor atravéz de uma thread.

                    Combate.VerificarmensagemEnviada(VerificarMensagem);//Verifica se foi enviada a informação.

                    button6.ForeColor = Color.Green;//O botão recebe a cor de texto verde
                    Status.Text = "AGUARDE " + Combate.getIdAdversario() + " JOGAR!";//a label status exibirá aguarde, o nome do adversio e a string jogar.
                    
                    VerificarLetra = Combate.getMinhaLetra();//VerificarLetra  recebe a letra do jogador
                    VerificarPartida();//Verifica se o jogador venceu a partida, perdeu ou empatou
                    VerificarLetra = Combate.getAdversarioLetra();//Verificarletra Recebe a letra do adversario
                    VerificarPartida();//Verifica se o adversario venceu perdeu ou empatou.

                }
            }


            


        }

        private void button5_Click(object sender, EventArgs e)//Evento clique do botão do jogo da velha 
        {
            if (Bloquear == false)//Se a boleana bloquer for falso
            {
                if (button5.Text == "")//Se o texto do botão estiver vazio
                {
                    Bloquear = true;//Bloquear rebe o valor verdadeiro.
                    button5.Text = Jogador; //O botão recebe a letra do jogador X ou O
                    VerificarMensagem = "mvr" + Combate.getMeuId() + ",p5";//Verificar mensagem recebe mvr mais o nome do jogador e a string p3 separado por virgula
                    cliente.setEnviarMensagem(VerificarMensagem);//A informação é gravada na variavel que entrega ao servidor
                    Cliente.buffar(); //a informação é enviada ao servidor atravéz de uma thread.

                    Combate.VerificarmensagemEnviada(VerificarMensagem);//Verifica se foi enviada a informação.
                    button5.ForeColor = Color.Green;//O botão recebe a cor de texto verde
                    Status.Text = "AGUARDE " + Combate.getIdAdversario() + " JOGAR!";//a label status exibirá aguarde, o nome do adversio e a string jogar.
                    
                    VerificarLetra = Combate.getMinhaLetra();//VerificarLetra  recebe a letra do jogador
                    VerificarPartida();//Verifica se o jogador venceu a partida, perdeu ou empatou
                    VerificarLetra = Combate.getAdversarioLetra();//Verificarletra Recebe a letra do adversario
                    VerificarPartida();//Verifica se o adversario venceu perdeu ou empatou.
                }
            }
   
  
           
        }

        private void button4_Click(object sender, EventArgs e)//Evento clique do botão do jogo da velha 
        {
            if (Bloquear == false)//Se a boleana bloquer for falso
            {
                if (button4.Text == "")//Se o texto do botão estiver vazio
                {
                    Bloquear = true;//Bloquear rebe o valor verdadeiro.
                    button4.Text = Jogador;//O botão recebe a letra do jogador X ou O
                    VerificarMensagem = "mvr" + Combate.getMeuId() + ",p4";//Verificar mensagem recebe mvr mais o nome do jogador e a string p3 separado por virgula
                    cliente.setEnviarMensagem(VerificarMensagem);//A informação é gravada na variavel que entrega ao servidor
                    Cliente.buffar(); //a informação é enviada ao servidor atravéz de uma thread.

                    Combate.VerificarmensagemEnviada(VerificarMensagem);//Verifica se foi enviada a informação.

                    button4.ForeColor = Color.Green;//O botão recebe a cor de texto verde
                    Status.Text = "AGUARDE " + Combate.getIdAdversario() + " JOGAR!";//a label status exibirá aguarde, o nome do adversio e a string jogar.
                  
                    VerificarLetra = Combate.getMinhaLetra();//VerificarLetra  recebe a letra do jogador
                    VerificarPartida();//Verifica se o jogador venceu a partida, perdeu ou empatou
                    VerificarLetra = Combate.getAdversarioLetra();//Verificarletra Recebe a letra do adversario
                    VerificarPartida();//Verifica se o adversario venceu perdeu ou empatou.
                }
            }


            
        }

        private void button9_Click(object sender, EventArgs e)//Evento clique do botão do jogo da velha 
        {

            if (Bloquear == false)//Se a boleana bloquer for falso
            {
                if (button9.Text == "")//Se o texto do botão estiver vazio
                {
                    Bloquear = true;//Bloquear rebe o valor verdadeiro.
                    button9.Text = Jogador;//O botão recebe a letra do jogador X ou O
                    VerificarMensagem = "mvr" + Combate.getMeuId() + ",p9";//Verificar mensagem recebe mvr mais o nome do jogador e a string p3 separado por virgula
                    cliente.setEnviarMensagem(VerificarMensagem);//A informação é gravada na variavel que entrega ao servidor
                    Cliente.buffar(); //a informação é enviada ao servidor atravéz de uma thread.

                    Combate.VerificarmensagemEnviada(VerificarMensagem);//Verifica se foi enviada a informação.

                    button9.ForeColor = Color.Green;//O botão recebe a cor de texto verde
                    Status.Text = "AGUARDE " + Combate.getIdAdversario() + " JOGAR!";//a label status exibirá aguarde, o nome do adversio e a string jogar.
                    
                    VerificarLetra = Combate.getMinhaLetra();//VerificarLetra  recebe a letra do jogador
                    VerificarPartida();//Verifica se o jogador venceu a partida, perdeu ou empatou
                    VerificarLetra = Combate.getAdversarioLetra();//Verificarletra Recebe a letra do adversario
                    VerificarPartida();//Verifica se o adversario venceu perdeu ou empatou.
                }

            }


           

        }

        private void button8_Click(object sender, EventArgs e)//Evento clique do botão do jogo da velha 
        {
            if (Bloquear == false)//Se a boleana bloquer for falso
            {
                if (button8.Text == "")//Se o texto do botão estiver vazio
                {
                    Bloquear = true;//Bloquear rebe o valor verdadeiro.
                    button8.Text = Jogador;//O botão recebe a letra do jogador X ou O
                    VerificarMensagem = "mvr" + Combate.getMeuId() + ",p8";//Verificar mensagem recebe mvr mais o nome do jogador e a string p3 separado por virgula
                    cliente.setEnviarMensagem(VerificarMensagem);//A informação é gravada na variavel que entrega ao servidor
                    Cliente.buffar(); //a informação é enviada ao servidor atravéz de uma thread.

                    Combate.VerificarmensagemEnviada(VerificarMensagem);//Verifica se foi enviada a informação.

                    button8.ForeColor = Color.Green;//O botão recebe a cor de texto verde
                    Status.Text = "AGUARDE " + Combate.getIdAdversario() + " JOGAR!";//a label status exibirá aguarde, o nome do adversio e a string jogar.
                  
                    VerificarLetra = Combate.getMinhaLetra();//VerificarLetra  recebe a letra do jogador
                    VerificarPartida();//Verifica se o jogador venceu a partida, perdeu ou empatou
                    VerificarLetra = Combate.getAdversarioLetra();//Verificarletra Recebe a letra do adversario
                    VerificarPartida();//Verifica se o adversario venceu perdeu ou empatou.
                }
            }


            

        }

        private void button7_Click(object sender, EventArgs e)//Evento clique do botão do jogo da velha 
        {
            if (Bloquear == false)//Se a boleana bloquer for falso
            {
                Bloquear = true;//Bloquear rebe o valor verdadeiro.
                if (button7.Text == "" )//Se o texto do botão estiver vazio
                {
                    button7.Text = Jogador;//O botão recebe a letra do jogador X ou O
                    VerificarMensagem = "mvr" + Combate.getMeuId() + ",p7";//Verificar mensagem recebe mvr mais o nome do jogador e a string p3 separado por virgula
                    cliente.setEnviarMensagem(VerificarMensagem);//A informação é gravada na variavel que entrega ao servidor
                    Cliente.buffar(); //a informação é enviada ao servidor atravéz de uma thread.

                    Combate.VerificarmensagemEnviada(VerificarMensagem);//Verifica se foi enviada a informação.
                    button7.ForeColor = Color.Green;//O botão recebe a cor de texto verde
                    Status.Text = "AGUARDE " + Combate.getIdAdversario() + " JOGAR!";//a label status exibirá aguarde, o nome do adversio e a string jogar.
                 
                    VerificarLetra = Combate.getMinhaLetra();//VerificarLetra  recebe a letra do jogador
                    VerificarPartida();//Verifica se o jogador venceu a partida, perdeu ou empatou
                    VerificarLetra = Combate.getAdversarioLetra();//Verificarletra Recebe a letra do adversario
                    VerificarPartida();//Verifica se o adversario venceu perdeu ou empatou.
                }
            }
 

           

        }


        int pose;//Novo objeto do tipo inteiro
        int divisor;//Novo objeto do tipo inteiro

        //O próximo método vai exibir algumas inofrmações ao carregar o formulario. Ele é o evento Form1_Load
        private void Form1_Load(object sender, EventArgs e)// Evento Form1_Load
        {
            LimparBotoes();//Limpa os botões


            //Player|||||||||||||||||||||||||||||||||||||||||||||||||||||||||
            lPlayer.Text = Combate.getMinhaLetra(); //Exibe a letra do jogador no jogo.
            imgPlayer.LoadAsync(Combate.getPlayerFoto());//Exibe a foto do jogador.
            nmPlayer.Text = Combate.getMeuId();//Exibe o nome do jogador
            Jogador = Combate.getMinhaLetra();//Jogador recebe a letra do jogador na partida.
            //ADVERSARIO ||||||||||||||||||||||||||||||||||||||||||||||||||||
            dao.PesquisarAdversario(Combate.getIdAdversario());//Pesquisa no banco de dados o nome do adversario, para obter a sua foto.
            lAdversario.Text = Combate.getAdversarioLetra();//Exibe a letra do adversário
            imgAdversario.LoadAsync(Combate.getAdversarioCaminhoFoto());//Exibe a foto do adversario
            nmAdversario.Text = Combate.getIdAdversario();//Exibe o nome do adversario
          
            //CENTRALIZA O NOME DO ADVERSARIO DE ACORDO COM SUA FOTO|||||||||||||||||||||||||||||||||||||||||
            divisor = nmAdversario.Width / 2;
            pose = (nmAdversario.Location.X - divisor);
            nmAdversario.Location = new Point(pose, nmAdversario.Location.Y);
            //CENTRALIZA TAMBÉM O NOME DO JOGADOR DE ACORDO COM SUA FOTO||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
            divisor = nmPlayer.Width / 2;
            pose = (nmPlayer.Location.X - divisor);
            nmPlayer.Location = new Point(pose, nmPlayer.Location.Y);
            //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

            //O próximo passo agora é verificar quem vai começar jogando primeiro

            if (Combate.getQuemComeca() == Combate.getMeuId())//Se for o player que começa primeiro
            {
               
                Status.Text = "SUA VEZ DE JOGAR!";//Exibe o texto na tela
                Bloquear = false;//Desbloqueia todos botões
            }
            else
            {   //Mas se for o adversario que começa primeiro
              
                Status.Text = "AGUARDE " + Combate.getIdAdversario() + " JOGAR!";//Exibe o texto na tela
                Bloquear = true;//Bloqueia todos botões
            }
          

        }
      
        private int contar;//Novo objeto do tipo inteiro
        private String Menssagem;//Novo objeto do tipo String 

        
        private String VerificarLetra;//Novo objeto do tipo string
        
        bool venceu;//Novo objeto do tipo boleano.
        private void quemGanhou()//Método que verifica se a partida continua, quem venceu ou foi derrotado para exibir a informação em um label e adicionar na pontuação do jogador.
        {
            if (VerificarLetra == Combate.getMinhaLetra()) //Se a variavel que verifica quem venceu for o nome do jogador.
            {
                Status.Text = "VOCÊ GANHOU ESSA PARTIDA";//Exibe a informação na tela
                Status.ForeColor = Color.Green;//Pinta o texto da informação de verde
                venceu = true;//venceu é verdadeiro.


            }
            else
            {
                //Caso seja o adversário.               
                Status.Text = "VOCÊ PERDEU";//Exibe a inforação na tela em um label.
                Status.ForeColor = Color.Red;//Pinta o texto de vermelho.
                venceu = false;//Venceu recebe o valor falso

            }
            Fim();//chama o método que vai colocar os pontos no banco de dados.
        }
        private bool PontosComputado;//Novo objeto do tipo boleano
        private int vitoria,derrota;//Novos objetos do tipo inteiro
        private bool Empate;//Novo objeto do tipo boleano.
        private void Fim()//Método fim, ele é o fim da partida e deve verificar quem venceu ganhou ou perdeu e enviar os pontos ao banco de dados e bloquear os botões.
        {
            if (PontosComputado == false)
            {
                if (venceu)//Se venceu for verdadeiro
                {

                    vitoria = Combate.getPlayerVitorias() + 3;//Adiciona 3 pontos de vitorias para o player
                    derrota = Combate.getPlayerDerrotas();//Derrota continua no mesmo valor.
                    dao.Pontuar(Combate.getMeuId(), vitoria, derrota);//Envia a informação ao banco de dados.
                    Combate.setPlayerVitorias(vitoria);//Atualiza a informação de vitoria na Classe Combate
                    Combate.setPlayerDerrotas(derrota);//Atualiza a informação de derrota na Classe Combate
                    Bloquear = true;//Bloqueia os botões
                    PontosComputado = true;//Diz que os pontos foram enviados
                    VerificarMensagem = "msg Fofocas quentes: " + Combate.getMeuId() + " Venceu " + Combate.getIdAdversario() + " Em uma partida do jogo da velha!";//Comando para o chat avisando que venceu
                    cliente.setEnviarMensagem(VerificarMensagem);//Bota o comando na variavel de dados que serão enviados ao servidor.
                    Cliente.buffar();//Envia os dados.
                   // Combate.VerificarmensagemEnviada(VerificarMensagem);//Verifica se foi enviado.

                }
                else
                {
                    //Se o jogador perdeu.
                    vitoria = Combate.getPlayerVitorias();//Adiciona 0 pontos de vitorias para o player
                    derrota = Combate.getPlayerDerrotas()  + 1; //Adiciona 1 ponto de derrotas
                    dao.Pontuar(Combate.getMeuId(), vitoria, derrota);//Envia a informação ao banco de dados.
                    Combate.setPlayerVitorias(vitoria);//Atualiza a informação de vitoria na Classe Combate
                    Combate.setPlayerDerrotas(derrota);//Atualiza a informação de derrota na Classe Combate
                    Bloquear = true;//Bloqueia os botões
                    PontosComputado = true;//Diz que os pontos foram enviados


                }
                //Se não perdeu nem venceu então empatou.
                if (Empate)//Se Empate for verdade
                {
                    vitoria = Combate.getPlayerVitorias() + 1;//Adiciona 1 ponto de vitoria para o player
                    derrota = Combate.getPlayerDerrotas();//Derrota continua no mesmo valor.
                    dao.Pontuar(Combate.getMeuId(), vitoria, derrota);//Envia a informação ao banco de dados.
                    Combate.setPlayerVitorias(vitoria);//Atualiza a informação de vitoria na Classe Combate
                    Combate.setPlayerDerrotas(derrota);//Atualiza a informação de derrota na Classe Combate
                    Bloquear = true;//Bloqueia os botões
                    PontosComputado = true;//Diz que os pontos foram enviados
                }
         
                Voltar.Visible = true;//Exibe o botão de voltar ao inicio.

            }
 


        }
        //O próximo método "VerificarPartida", é chamado a cada jogada, para verificar se teve um empate vitoria ou derrota lendo os texto X ou O dos botões
        private void VerificarPartida()//Método verificar partida.
        {
            Combate.acoes(Menssagem);//Chama o método de ler comandos em combate
            if (button1.Text != "" && button2.Text != "" && button3.Text != "" && button6.Text != "" && button5.Text != "" && button4.Text != "" && button9.Text != "" && button8.Text != "" && button7.Text != "")//Se todos os botões estiverem preenchidos significa que é um empate então:
            {
                Status.Text = "EMPATE NA PARTIDA";//Exibe a informação na tela
                Status.ForeColor = Color.Green;//Pinta o texto de verde
                //COMANDO PARA UM EMPATE
                Bloquear = true;//Bloqueia todas as teclas
                Empate = true;//Empate recebe o valor verdade
                Fim(); //Chama o método que vai adicionar a informação no banco de dados.

            }
            else
            {   //Se não for um empate pode ser uma vitoria ou derrota então.

                if (button1.Text == VerificarLetra && button2.Text == VerificarLetra && button3.Text == VerificarLetra)//Se a letra "X" ou "O"  aparecer nesses botões então
                {
                    quemGanhou();//Verifica se quem ganhou foi O ou X
                    Bloquear = true;//Bloqueia todos botões.
                   
                }
                else
                {
                    if (button6.Text == VerificarLetra && button5.Text == VerificarLetra && button4.Text == VerificarLetra)//Se a letra "X" ou "O"  aparecer nesses botões então
                    {
                        quemGanhou();//Verifica se quem ganhou foi O ou X
                        Bloquear = true;//Bloqueia todos botões.
                        //
                    }
                    else
                    {
                        if (button6.Text == VerificarLetra && button5.Text == VerificarLetra && button4.Text == VerificarLetra)//Se a letra "X" ou "O"  aparecer nesses botões então
                        {
                            quemGanhou();//Verifica se quem ganhou foi O ou X
                            Bloquear = true;//Bloqueia todos botões.
                            //
                        }
                        else
                        {
                            if (button9.Text == VerificarLetra && button8.Text == VerificarLetra && button7.Text == VerificarLetra)//Se a letra "X" ou "O"  aparecer nesses botões então
                            {
                                quemGanhou();//Verifica se quem ganhou foi O ou X
                                Bloquear = true;//Bloqueia todos botões.
                                //
                            }
                            else
                            {
                                if (button1.Text == VerificarLetra && button5.Text == VerificarLetra && button7.Text == VerificarLetra)//Se a letra "X" ou "O"  aparecer nesses botões então
                                {
                                    quemGanhou();//Verifica se quem ganhou foi O ou X
                                    Bloquear = true;//Bloqueia todos botões.
                                    //
                                }
                                else
                                {
                                    if (button3.Text == VerificarLetra && button5.Text == VerificarLetra && button9.Text == VerificarLetra)//Se a letra "X" ou "O"  aparecer nesses botões então
                                    {
                                        quemGanhou();//Verifica se quem ganhou foi O ou X
                                        Bloquear = true;//Bloqueia todos botões.
                                        //
                                    }
                                    else
                                    {
                                        if (button1.Text == VerificarLetra && button6.Text == VerificarLetra && button9.Text == VerificarLetra)//Se a letra "X" ou "O"  aparecer nesses botões então
                                        {
                                            quemGanhou();//Verifica se quem ganhou foi O ou X
                                            Bloquear = true;//Bloqueia todos botões.
                                            //
                                        }
                                        else
                                        {
                                            if (button2.Text == VerificarLetra && button5.Text == VerificarLetra && button8.Text == VerificarLetra)//Se a letra "X" ou "O"  aparecer nesses botões então
                                            {
                                                quemGanhou();//Verifica se quem ganhou foi O ou X
                                                Bloquear = true;//Bloqueia todos botões.
                                                //
                                            }
                                            else
                                            {
                                                if (button3.Text == VerificarLetra && button4.Text == VerificarLetra && button7.Text == VerificarLetra)//Se a letra "X" ou "O"  aparecer nesses botões então
                                                {
                                                    quemGanhou();//Verifica se quem ganhou foi O ou X
                                                    Bloquear = true;//Bloqueia todos botões.
                                                    //
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

        }





        /* Módulo Chat
         * O próximo módulo é o evento Escutar_Tick, do Timer Escutar. O timer vai chamar esse evento a cada 100 ms.
         * E esse evento deve ficar verificando os dados recebidos do servidor para saber se é uma mensagem de chat ou um comando.
         */
        String UltimaPose;
        private void Escutar_Tick(object sender, EventArgs e)//Evento Escutar_Tick
        {


                    
               
                    Menssagem = Cliente.getMenssagemServidor();//Menssagem recebe os dados do servidor.           
                    contar = listBox1.Items.Count;//Recebe o numero total de itens dentro da listbox do chat.

                    Combate.acoes(Menssagem);



            try
            {
                if (Menssagem.ElementAt(9).ToString() == "m" && Menssagem.ElementAt(10).ToString() == "s" && Menssagem.ElementAt(11).ToString() == "g")//Se os caracteres a partir da posição 9 dos dados recebidos do servidor forem msg: Então é uma mensagem de chat.
                {
                 

                        if (contar <= 1)//Se o número de itens da listbox for menor ou igual a 1
                        {
                            listBox1.Items.Add(Cliente.getMenssagemServidor());//Adiciona os dados recebidos do servidor na listbox .
                            
                           
                        }
                        else
                        {   //Se for maior que 1
                            if (Menssagem == listBox1.Items[contar - 1].ToString())//Se os dados for igual ao ultimo recebido do servidor.
                            {
                            //nao fazer nada
                            }
                            else
                            {   //Se não for igual ao ultimo
                                listBox1.Items.Add(Cliente.getMenssagemServidor());//Adiciona os novos dados na listbox
                               
                               listBox1.SelectedIndex = listBox1.Items.Count - 1;//Depois seleciona ele
                            }

                        }





                    
                }

            }
            catch (Exception)
            {
                //Em caso de um erro não fazer nada.
                
            }
         

            if (Combate.getAdversarioPose() == "p1" && Bloquear == true)//Se os dados recebidos for a ultima jogada do adversario na posição p1.
            {
                button1.Text = lAdversario.Text;   //Exibe no texto do botão que adversario o marcou.                    
                button1.ForeColor = Color.Red;//Pinta o texto de vermelho.
                Bloquear = false;//Desbloqueai os botões para o player jogador.
                Status.Text = "SUA VEZ DE JOGAR!";//Exibe na label que é a vez do jogador jogar.
                Status.ForeColor = Color.Green;//Pinta a label de verde
                VerificarLetra = Combate.getMinhaLetra();//Recebe a letra do jogador.
                VerificarPartida();//Verifica se venceu
                VerificarLetra = Combate.getAdversarioLetra();//Recebe a letra do adversario.
                VerificarPartida();//Verifica se venceu.


            }
            else
            {
                if (Combate.getAdversarioPose() == "p2" && Bloquear == true)//Se os dados recebidos for a ultima jogada do adversario na posição p2.
                {
                    button2.Text = lAdversario.Text;//Exibe no texto do botão que adversario o marcou.                                   
                    button2.ForeColor = Color.Red;//Pinta o texto de vermelho.
                    Bloquear = false;//Desbloqueai os botões para o player jogador.
                    Status.Text = "SUA VEZ DE JOGAR!";//Exibe na label que é a vez do jogador jogar.
                    Status.ForeColor = Color.Green;//Pinta a label de verde
                    VerificarLetra = Combate.getMinhaLetra();//Recebe a letra do jogador.
                    VerificarPartida();//Verifica se venceu
                    VerificarLetra = Combate.getAdversarioLetra();//Recebe a letra do adversario.
                    VerificarPartida();//Verifica se venceu
                }
                else
                {


                    if (Combate.getAdversarioPose() == "p3" && Bloquear == true)//Se os dados recebidos for a ultima jogada do adversario na posição p3.
                    {
                        button3.Text = lAdversario.Text;//Exibe no texto do botão que adversario o marcou.       
                        button3.ForeColor = Color.Red;//Pinta o texto de vermelho.
                        Bloquear = false;//Desbloqueai os botões para o player jogador.
                        Status.Text = "SUA VEZ DE JOGAR!";//Exibe na label que é a vez do jogador jogar.
                        Status.ForeColor = Color.Green;//Pinta a label de verde
                        VerificarLetra = Combate.getMinhaLetra();//Recebe a letra do jogador.
                        VerificarPartida();//Verifica se venceu
                        VerificarLetra = Combate.getAdversarioLetra();//Recebe a letra do adversario.
                        VerificarPartida();//Verifica se venceu
                    }
                    else
                    {
                        if (Combate.getAdversarioPose() == "p6" && Bloquear == true)//Se os dados recebidos for a ultima jogada do adversario na posição p6.
                        {
                            button6.Text = lAdversario.Text; //Exibe no texto do botão que adversario o marcou.                                         
                            button6.ForeColor = Color.Red;//Pinta o texto de vermelho.
                            Bloquear = false;//Desbloqueai os botões para o player jogador.
                            Status.Text = "SUA VEZ DE JOGAR!";//Exibe na label que é a vez do jogador jogar.
                            Status.ForeColor = Color.Green;//Pinta a label de verde
                            VerificarLetra = Combate.getMinhaLetra();//Recebe a letra do jogador.
                            VerificarPartida();//Verifica se venceu
                            VerificarLetra = Combate.getAdversarioLetra();//Recebe a letra do adversario.
                            VerificarPartida();//Verifica se venceu
                        }
                        else
                        {
                            if (Combate.getAdversarioPose() == "p5" && Bloquear == true)//Se os dados recebidos for a ultima jogada do adversario na posição p5.
                            {
                                button5.Text = lAdversario.Text;//Exibe no texto do botão que adversario o marcou.                                              
                                button5.ForeColor = Color.Red;//Pinta o texto de vermelho.
                                Bloquear = false;//Desbloqueai os botões para o player jogador.
                                Status.Text = "SUA VEZ DE JOGAR!";//Exibe na label que é a vez do jogador jogar.
                                Status.ForeColor = Color.Green;//Pinta a label de verde
                                VerificarLetra = Combate.getMinhaLetra();//Recebe a letra do jogador.
                                VerificarPartida();//Verifica se venceu
                                VerificarLetra = Combate.getAdversarioLetra();//Recebe a letra do adversario.
                                VerificarPartida();//Verifica se venceu
                            }
                            else
                            {
                                if (Combate.getAdversarioPose() == "p4" && Bloquear == true)//Se os dados recebidos for a ultima jogada do adversario na posição p4.
                                {
                                    button4.Text = lAdversario.Text;  //Exibe no texto do botão que adversario o marcou.                                                
                                    button4.ForeColor = Color.Red;//Pinta o texto de vermelho.
                                    Bloquear = false;//Desbloqueai os botões para o player jogador.
                                    Status.Text = "SUA VEZ DE JOGAR!";//Exibe na label que é a vez do jogador jogar.
                                    Status.ForeColor = Color.Green;//Pinta a label de verde
                                    VerificarLetra = Combate.getMinhaLetra();//Recebe a letra do jogador.
                                    VerificarPartida();//Verifica se venceu
                                    VerificarLetra = Combate.getAdversarioLetra();//Recebe a letra do adversario.
                                    VerificarPartida();//Verifica se venceu
                                }
                                else
                                {
                                    if (Combate.getAdversarioPose() == "p9" && Bloquear == true)//Se os dados recebidos for a ultima jogada do adversario na posição p9.
                                    {
                                        button9.Text = lAdversario.Text;  //Exibe no texto do botão que adversario o marcou.                                                     
                                        button9.ForeColor = Color.Red;//Pinta o texto de vermelho.
                                        Bloquear = false;//Desbloqueai os botões para o player jogador.
                                        Status.Text = "SUA VEZ DE JOGAR!";//Exibe na label que é a vez do jogador jogar.
                                        Status.ForeColor = Color.Green;//Pinta a label de verde
                                        VerificarLetra = Combate.getMinhaLetra();//Recebe a letra do jogador.
                                        VerificarPartida();//Verifica se venceu
                                        VerificarLetra = Combate.getAdversarioLetra();//Recebe a letra do adversario.
                                        VerificarPartida();//Verifica se venceu
                                    }
                                    else
                                    {
                                        if (Combate.getAdversarioPose() == "p7" && Bloquear == true)//Se os dados recebidos for a ultima jogada do adversario na posição p7.
                                        {
                                            Bloquear = false;//Desbloqueai os botões para o player jogador.
                                            button7.Text = lAdversario.Text;//Exibe no texto do botão que adversario o marcou.                                                          
                                            button7.ForeColor = Color.Red;//Pinta o texto de vermelho.

                                            Status.Text = "SUA VEZ DE JOGAR!";//Exibe na label que é a vez do jogador jogar.
                                            Status.ForeColor = Color.Green;//Pinta a label de verde
                                            VerificarLetra = Combate.getMinhaLetra();//Recebe a letra do jogador.
                                            VerificarPartida();//Verifica se venceu
                                            VerificarLetra = Combate.getAdversarioLetra();//Recebe a letra do adversario.
                                            VerificarPartida();//Verifica se venceu
                                        }
                                        else
                                        {
                                            if (Combate.getAdversarioPose() == "p8" && Bloquear == true)//Se os dados recebidos for a ultima jogada do adversario na posição p8.
                                            {
                                                button8.Text = lAdversario.Text;//Exibe no texto do botão que adversario o marcou.                                                              
                                                button8.ForeColor = Color.Red;//Pinta o texto de vermelho.
                                                Bloquear = false;//Desbloqueai os botões para o player jogador.
                                                Status.Text = "SUA VEZ DE JOGAR!";//Exibe na label que é a vez do jogador jogar.
                                                Status.ForeColor = Color.Green;//Pinta a label de verde
                                                VerificarLetra = Combate.getMinhaLetra();//Recebe a letra do jogador.
                                                VerificarPartida();//Verifica se venceu
                                                VerificarLetra = Combate.getAdversarioLetra();//Recebe a letra do adversario.
                                                VerificarPartida();//Verifica se venceu
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }


            }

            Combate.limparPoseAdversario();

        }

        private void button10_Click(object sender, EventArgs e)//Evento clique  do botão que envia mensagem ao chat para o servidor.
        {
            EnviarCht();//Método EnviarCht ele envia uma mensagem do chat ao servidor.
        }

        String Mensagem;
      
        private void EnviarCht()//Método EnviarCht ele envia uma mensagem do chat ao servidor.
        {
            if (textBox1.Text == "")//Se o campo de escrever a mensagem for vazio.
            {
                label5.Text = "Digite uma Menssagem!";//Exibirá esse texto na tela.
            }
            else
            {   //Se não for vazio
                
                Mensagem = "msg: " + Combate.getMeuId() + ": " + textBox1.Text;//Adiciona em mensagem o a string msg mais o nome do jogador mais a string : e o texto que ele digitou.
                cliente.setEnviarMensagem(Mensagem);//Coloca a todas informações na string que será enviada ao servidor.
                Cliente.buffar();//Envia elas em uma thread
                
                Combate.VerificarmensagemEnviada(Mensagem);  //Verifica se as infos foram enviadas        

                textBox1.Text = "";//Limpa o campo de escrever
                textBox1.Focus();//Foca no campo de escrever.



            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//Evento que ocorre ao fechar o formulário de jogo
        {

            Combate.setIdAdversario("");//Limpa o adversario.
            Combate.LimparUltimaPose();//Limpa a ultima pose do adversario
            Program.AbriHome();//Abre o fomulário home.
            Program.FecharTudo(true);//Se home for fechado deve fechar toda aplicação.

        }

 

        int ponto1,ponto2;//Novos objetos do tipo inteiro

        private void Voltar_Click(object sender, EventArgs e)//Evento clique do botão voltar o botão fica oculto quando há empate ou vencedor e perdedor, ele aparece.
        {
            Combate.setIdAdversario("");//Limpa o adversario.
            Combate.LimparUltimaPose();//Limpa a ultima pose do adversario
            this.Close();//Fecha o formulário.
        
        }

        private void CentStatus_Tick(object sender, EventArgs e)//Evento do timer CentStatus_Tick que será disparado a cada 100 ms
        {
            //Esse evento sempre vai centralizar a mensagem de status de acordo com a label3 acima do tabuleiro do jogo da velha
            ponto1 = Status.Width / 2;//Ponto 1 recebe o tamanho da largura de Status e divide por 2

            ponto2 = (label3.Location.X + 56) - ponto1;//Ponto2 recebe as cordenadas x de label3 e soma com 56, depois subtrai com ponto1
            Status.Location = new Point(ponto2, Status.Location.Y);//Agora os status estão centralizados.
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)//Evendo de pressionamento de botão no campo de escrever mensagem no chat.
        {   
            if (e.KeyCode == Keys.Enter)//Se a tecla pressionada for Enter
            {
                EnviarCht();//Chama o método de enviar a mensagem.
            }
        }
    }
}
