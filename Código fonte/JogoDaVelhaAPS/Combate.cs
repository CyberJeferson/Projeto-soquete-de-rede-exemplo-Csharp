/* Classe Combate
 * Essa classe vai ser usada para definir quem está online, quem o player, quem é o adversario.
 * vai  ler e enviar convites e comandos ao servidor socket.
 * Essa classe também vai insistir em enviar um comando caso o servidor não o receba.
 */
using System;//Biblioteca padrão C#, usada em Strings e etc...
using System.Drawing;//Biblioteca padrão do c# usada nesse projeto para desenhar icone a partir de uma imagem
using System.Linq;//Biblioteca padrão do C#, para obter um caractere em certa posição definida de uma string
using System.Timers; //Biblioteca padrão do C#, usada para criar um novo timer que dispara em um determinado tempo em thread separado


namespace JogoDaVelhaAPS
{
    class Combate
    {
        //PLAYER STATUS----------------------------------------------------
        private static String id; //Objeto do tipo string usada para receber o nome do jogador 
        private static String MinhaLetra; //Objeto do tipo string usado para receber a Letra do jogador no jogo da velha
        private static int PlayerVitorias; //Objeto do tipo string usado para reber do banco de dados o número de vitórias do jogador
        private static int PlayerDerrotas; //Objeto do tipo string usado para receber o número de derrotas do jogador no banco de dados
        private static String PlayerFoto;//Objeto tipo string usado para receber O caminho onde a foto do jogador está hospedada
        private static String Senha;//Objeto do tipo string usado para receber a senha do jogador
        //-----------------------------------------------------------------

        //ADVERSARIO STATUS
        private static String AdversarioLetra;//Objeto do tipo string que recebe a Letra do adversario no jogo da velha.
        private static String idAdversario;//Objeto do tipo string que recebe o nome do adversario
        private static String AdversarioPose;//Objeto do tipo string que recebe o ultimo local onde adversario jogou.
        private static String AdversarioCaminhoFoto;//Objeto do tipo string que recebe o caminho da foto do adversario.

       
        //COMANDOS DO JOGO
        private static String ultimoComando; //Variavel que recebe o ultimo dado rebedio do servidor      
        private static String QuemComeca; //Variavel que recebe o nome do player que vai começar jogando o jogo da velha
        private static String AceitouConvite;//Variavel que recebe a resposta do servidor informando se o adversário aceitou o convite
        //PLAYERS ONLINE
        private static String onid;//Variavel que rebe o nome de um player online
        private static String onstringFoto;//Recebe o  caminho da foto do player online
  


        //-------VARIÁVEIS AUXILIARES
        private static int ContarComando;//Variável do tipo int32
        private static Timer relogio; //Variável do tipo Timer da biblioteca System.Timers.Timer do C#.
        private static String sIDAdversario;//Objeto do tipo string auxiliar
        private static string verpose;
        private static string auxverpose;
        private static String auxgps,auxgpsultimo,gpsnome,gpslongitude,gpslatitude;
        private static int auxgpscontar;
        private static bool recarregarTabela;
        //O Timer componente é um temporizador baseado em servidor que gera um Elapsed evento em seu aplicativo após o número de milissegundos na Interval.
        
        /*
         * O método acoes(), esse método quando chamado é responsável por ler convites para uma nova batalha no jogo da velha, verifica onde
         * o adversario jogou, qual é a letra do adversario no convite, quem começa a jogar e também verifica se o player teve um covite recusado por um adversario. 
         */

        public static void acoes(String comando) //Método acoes()
        {
            
          
          
            //----------------COMANDO DE BATALHA
            if (ultimoComando != comando)//Se os dados recebidos do servidor for diferente do ultimo dado recebido então:
            {
                try
                {
                    if (comando.ElementAt(9).ToString() == "m" && comando.ElementAt(10).ToString() == "v" && comando.ElementAt(11).ToString() == "r")// Se nos dados recebidos do servidor estiver as primeiras letras como mvr então:
                    {
                        ContarComando = 12; //a variavel int32 ContarComando recebe o valor 12 
                        while (comando.ElementAt(ContarComando).ToString() != ",") //Verifica cada caractere recebido do servidor apartir do valor em ContarComando, Enquanto esse caractere for diferente de virgula ele fazer:
                        {
                            sIDAdversario = sIDAdversario + comando.ElementAt(ContarComando).ToString(); //Adicionar o caractere na variavel auxiliar sIDAdversario
                            ContarComando++; //ContarComando se auto incrementa
                        }

                        //Depois de chegar em uma virgular ele o próximo passo é checar se os dados da variavel auxiliar sIDAdversario é igual a variavel idAdversario 
                        //Se for igual significa que esse comando foi enviado para o player indicando que o adversario jogou em certo local no jogo da velha
                        if (idAdversario == sIDAdversario) //Se idAdversario for igual sIDAdversario então:
                        {
                            ContarComando++;//Auto incrementa ContarComando
                            auxverpose = "";
                            for (int i = ContarComando; i < comando.Length; i++) //Enquanto ContarComando for menor que o número de caracteres de comando faça:
                            {
                                auxverpose = auxverpose + comando.ElementAt(i).ToString(); //A variavel pose recebe Cada caractere que indica onde o adverario jogou
                            }

                            if (verpose != auxverpose)//Se verpose for diferente de auxverpose então
                            {

                                AdversarioPose = auxverpose;//AdversarioPose recebe auxverpose
                                verpose = auxverpose;//verpose recebe auxverpose
                            }
                            else
                            {
                                AdversarioPose = "";//Limpa a pose do adversário.
                            }



                        }
                        sIDAdversario = ""; //Depois de terminar todos os passos acima a variavel auxiliar sIDAdversario vai receber um valor vazio.
                    }  //---------------------------------------------------------------------------------
                    else
                    {   //Se os dados recebidos não estiver nas primeiras letras a palavra mvr então o próximo passo é verificar se foi um convite recebido para uma batalha

                        /*
                         * Se os dados recebidos do seridor estiver os primeios caracteres como cvt
                         * então significa que é um convite de batalha e devemos ler esse convite para
                         * verificar se esse convite foi enviado para o player atual.
                         */
                        if (comando.ElementAt(9).ToString() == "c" && comando.ElementAt(10).ToString() == "v" && comando.ElementAt(11).ToString() == "t") //  Se os dados recebidos do seridor estiver os primeios caracteres como cvt então:
                        {
                            ContarComando = 12; //ContarComando como de costume recebe o valor 12

                            while (comando.ElementAt(ContarComando).ToString() != ",") //Enquanto os dados estiver caracteres diferente de uma virgula "," o proximo passo será
                            {
                                sIDAdversario = sIDAdversario + comando.ElementAt(ContarComando).ToString(); //Adicionar o caractere na auxiliar
                                ContarComando++; //Auto incrementar ContarComando
                            }
                            /*
                             * Se a variavel auxiliar sIDAdversario estiver
                             * os primeiros  caracteres antes da virgula, igual ao nome
                             * do  player que está jogando significa que esses dados
                             * foram realmente enviados para o player atual ou seja alguém está desafiando o palyer atual para
                             * uma batalha de jogo da velha, então teremos que no próximo passo colher todas informações sobre isso
                             * quem é o player que o desafiou, qual foi a letra que foi definida aleatoriamente para cada um
                             * e quem deve começar primeiro a jogar, caso o player aceite o convite.
                             */
                            if (sIDAdversario == id && idAdversario == "" || idAdversario == null) //Se a variavel auxiliar for igual ao nome do player e idAdversario for diferente de nulo ou vazio então:
                            {
                                ContarComando++; //ContarComando se autoincrementa para sair da virgula.
                                sIDAdversario = ""; //A variavel auxiliar recebe um valor vazio.

                                //o próximo passo é pegar a letra que foi definida para o player de forma aleatoria em seu convite
                                while (comando.ElementAt(ContarComando).ToString() != ",")//enquanto os caracteres dentro dos dados recebidos for diferente de virgula o proximo passo é:
                                {
                                    sIDAdversario = sIDAdversario + comando.ElementAt(ContarComando).ToString(); //Cada caractere da letra é colocada dentro da variavel auxiliar
                                    ContarComando++; //Auto incrementar ContarComando
                                }
                                //Depois de capturar a letra ela deve ficar em um lugar que não seja de uma variavel auxiliar.
                                MinhaLetra = sIDAdversario; //MinhaLetra vai receber a letra definida aleatoriamente no convite.
                                sIDAdversario = "";//A variavel auiliar vai receber um valor vazio.
                                ContarComando++; //ContarComando vai se auto incrementar para sair da virgula.

                                /* Já tenho a letra que foi definida na batalha para mim então o proximo passo é saber.
                                 * Quem é o adversárioque desafiou o player,  qual será sua letra e quem começa primeiro.
                                 */
                                while (comando.ElementAt(ContarComando).ToString() != ",") //Enquanto os caracteres contidos nos dados recebidos forem diferente de virgula:
                                {
                                    sIDAdversario = sIDAdversario + comando.ElementAt(ContarComando).ToString(); //Coloca caractere por caractere na variavel auxiliar sIDAdversario.
                                    ContarComando++;//Auto incrementa ContarComando até chegar na virgula
                                }
                                //Depois que chegar na virgual já temos o nome do adversario
                                idAdversario = sIDAdversario; //coloca os dados do nome do advervasario na variavel idAdversario
                                dao.PesquisarAdversario(Combate.getIdAdversario()); //Pesquisa o nome do adversario e obtem o caminho da foto e será colocada na variavel AdversarioCaminhoFoto
                                sIDAdversario = ""; //Limpar a auxiliar
                                ContarComando++; //Auto incrementa ContarComando Para sair da virgula.

                                //Agora só resta saber qual é a letra do adversario no jogo e quem começa primeiro e para isso continua o próximo passo obtera letra do adversario.

                                while (comando.ElementAt(ContarComando).ToString() != ",")//Enquanto os caracteres contidos nos dados recebidos forem diferente de virgula:
                                {
                                    sIDAdversario = sIDAdversario + comando.ElementAt(ContarComando).ToString(); //Coloca caractere por caractere na variavel auxiliar sIDAdversario.
                                    ContarComando++; //Auto incrementa ContarComando
                                }

                                AdversarioLetra = sIDAdversario; //AdversarioLetra recebe aletra do adversario capturada pela auxiliar sIDAdversario
                                sIDAdversario = "";//Limpa a variavel auxiliar.
                                ContarComando++;//ContarComando se auto incrementa para sair da virgula.

                                //Agora só falta obter a informação de quem deve começar a jogar primeiro. 
                                while (comando.ElementAt(ContarComando).ToString() != ",")//Enquanto os caracteres contidos nos dados recebidos forem diferente de virgula:
                                {
                                    sIDAdversario = sIDAdversario + comando.ElementAt(ContarComando).ToString();//Coloca caractere por caractere na variavel auxiliar sIDAdversario.
                                    ContarComando++; //Auto incrementa até chegar na virgula
                                }
                                QuemComeca = sIDAdversario;//QuemComeca recebe da variavel auxiliar sIDAdversario o nome de quem deve começar primeiro a jogar quando abrir a tela do jogo.
                                sIDAdversario = ""; //Limpa a auxiliar
                                ContarComando = 12; //Para evitar bugs ContarComando começa int 12
                                Program.CarregarConvite(); //Aqui carrega a tela do convite para o player contendo todas informações capturadas acima.
                            }




                        }
                        else
                        {

                            //Quando o player envia um convite para jogar esse convite pode ser negado ou aceito, então o servidor retorna esses dados ao cliente
                            //Então o próximo passo é reconhecer se os dados obtidos do servidor tem no inicio os caracteres cvr
                            if (comando.ElementAt(9).ToString() == "c" && comando.ElementAt(10).ToString() == "v" && comando.ElementAt(11).ToString() == "r")//Se os dados obtidos do servidor tiver os caracteres  cvr apartir da posição 9  então:
                            {
                                ContarComando = 12;//ContarComando recebe o valor 12

                                //o proximo passo agora é ver se essa recusa veio para o player que está logado 
                                //Então toda a mensagem recebida do servidor deve ser lida para saber tal informação.
                                while (comando.ElementAt(ContarComando).ToString() != ",")//Enquanto os caracteres contidos nos dados recebidos forem diferente de virgula:
                                {
                                    sIDAdversario = sIDAdversario + comando.ElementAt(ContarComando).ToString();//Coloca caractere por caractere na variavel auxiliar sIDAdversario.
                                    ContarComando++;//Auto incrementa ContarComando até chegar na virgula
                                }

                                ContarComando++; //ContarComando se auto incrementa para sair da virgula.
                                                 //---------------------------------------------------------------------------------
                                                 //Depois de obtido o nome do player a quem foi direcionado a mensagem
                                                 //O próximo passo é verificar se foi direcionada ao player logado
                                if (sIDAdversario == id) //Se o os dados do nome em sIDAdversario for o nome do player online então:
                                {

                                    sIDAdversario = "";//Limpa a variavel aux sIDAdversario.

                                    //Depois de confirmar que é para o player logado.
                                    //O proximo passo é verificar se o convite foi aceito ou recusado.
                                    while (comando.ElementAt(ContarComando).ToString() != ",")//Enquanto os caracteres contidos nos dados recebidos forem diferente de virgula:
                                    {
                                        sIDAdversario = sIDAdversario + comando.ElementAt(ContarComando).ToString(); //sIDAdversario recebe cada caractere dos dados recebidos do servidor soquete
                                        ContarComando++; //Auto incrementa ContarComando até chegar na virgula
                                    }
                                    //Agora com a menssagem da resposta nas mão o proximo passo é verificar se o adversario aceitou ou não.

                                    if (sIDAdversario == "n") //Se o convite for negado então:
                                    {
                                        AceitouConvite = "n";//Grava a informação na variável AceitouConvite
                                    }
                                    else //Se for  aceito
                                    {
                                        AceitouConvite = "s"; //Grava a informação também na variável AceitouConvite
                                    }
                                    //E aqui acaba todas as configurações de leitura de convite de batalhas.
                                }



                            }
                            else// Se não
                            {
                                //O proximo código abaixo serve para avisar sobre ocorrencias
                                if (comando.ElementAt(9).ToString() == "a" && comando.ElementAt(10).ToString() == "l" && comando.ElementAt(11).ToString() == "e")//Se os primeiros caracteres de comando a partir do nono for ale então:
                                {
                                    ContarComando = 16;//Começa a pegar o caractere no numero 16 na fila
                                    auxgps = "";//auxgps recebe um valor vazio
                                    for (int i = ContarComando; i < comando.Length; i++)//De contar comando até o ultimo caractere de comando
                                    {
                                        auxgps += comando.ElementAt(i).ToString();//auxgps recebe caractere por caractere de comando
                                    }


                                    if (auxgpsultimo == auxgps)//Se auxgpsultimo for igual auxgps
                                    {
                                        //Não faz nada
                                    }
                                    else//Se não,se for diferente
                                    {
                                        alertarJogador("Nova ocorrência", auxgps, 5000);//Alerta o cliente sobre uma nova ocorrencia
                                        auxgpsultimo = auxgps;//auxgpsultimo recebe auxgps
                                        recarregarTabela = true;//recarregarTabela recebe um valor verdadeiro
                                    }

                                }
                                else// se não
                                {
                                    //Agora o próximo código pega a localização dos clientes no gps
                                    if (comando.ElementAt(9).ToString() == ">")//Se o caractere 9 de comando for > então é um comando de gps
                                    {

                                        auxgpscontar = 10;//auxgpscontar recebe 10
                                        auxgps = "";//Lipa auxgps
                                        try
                                        {
                                            while (comando.ElementAt(auxgpscontar).ToString() != ">")//Enquanto os caracteres de comando for diferente de >
                                            {
                                                auxgps += comando.ElementAt(auxgpscontar).ToString();//Auxgps recebe caractere por caractere
                                                auxgpscontar++;//auxgpscontar se auto incrementa
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            //Em caso de erro não fazer nada.
                                        }


                                        if (auxgps == id)//Se auxgps for igual ao nome do jogador
                                        {
                                            //Não fazer nada
                                        }
                                        else//Se não
                                        {
                                            gpsnome = auxgps;//gpsnome é igual auxgps
                                            auxgpscontar++;//auxgpscontar se auto incrementa
                                            auxgps = "";//auxgps recebe um valor vazio
                                            try
                                            {
                                                while (comando.ElementAt(auxgpscontar).ToString() != ">")//Enquanto os caracteres de comando for diferente de >
                                                {
                                                    auxgps += comando.ElementAt(auxgpscontar).ToString();//Auxgps recebe caractere por caractere
                                                    auxgpscontar++;//auxgpscontar se auto incrementa
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                //Em caso de erro não fazer nada

                                            }

                                            gpslatitude = auxgps;//gpslatitude recebe auxgps
                                            auxgpscontar++;//auxgpscontar se auto incrementa
                                            auxgps = "";//auxgps recebe um valor vazio
                                            try
                                            {
                                                while (comando.ElementAt(auxgpscontar).ToString() != ">")//Enquanto os caracteres de comando for diferente de >
                                                {


                                                    auxgps += comando.ElementAt(auxgpscontar).ToString();//Auxgps recebe caractere por caractere
                                                    auxgpscontar++;//auxgpscontar se auto incrementa
                                                }
                                            }
                                            catch (Exception)
                                            {

                                                //Em caso de erro não fazer nada.
                                            }

                                            gpslongitude = auxgps;//gpslongitude recebe auxgps




                                            try
                                            {
                                                cMapa.novaMarcacao(gpsnome, "./pa1.png", Double.Parse(gpslatitude), Double.Parse(gpslongitude));//Insere o player no mapa com as cordenadas convertidas em double.
                                            }
                                            catch (Exception)
                                            {

                                                //Em caso de erro não fazer nada
                                            }

                                        }

                                    }
                                }
                            }




                        }









                    }

                }
                catch (Exception)
                {

                   
                }
          




            }
 





            sIDAdversario = ""; //A variável sIDAdversario recebe um valor vazio
            ultimoComando = comando; //Ultimo comando recebeos dados do servidor
          
        }

        
        public static String getAceitouConvite()//Método getAceitouConvite, quando chamado ele retorna a resposta de um convite de batalha.
        {
            return AceitouConvite; //Retorna a variavel AceitouConvite
        }

        
        public static void setAceitouConvite(String r)//Método usado para alterar A variavel setAceitouConvite
        {
            AceitouConvite = r; //AceitouConvite Recebe r
        }

        public static String getMinhaLetra()//Método que retorna a letra do jogador no jogo da velha.
        {
            return MinhaLetra; //Retorna MinhaLetra
        }


        public static void setMinhaLetra(String Letra)//Método usado para definir a letra do jogador
        {
            MinhaLetra = Letra; //MinhaLetra recebe Letra
        }
        public static String getMeuId()//Método usado para obter o nome do jogador
        {
            return id;
        }
        public static void setMeuId(String ID)//Método usado para definir o nome do jogador
        {
            id = ID;
        }

        public static void setIdAdversario(String id)//Método usado para definir o nome do adversário.
        {
            idAdversario = id;
        }
        public static String getIdAdversario()//Método usado para obter o nome do adversario.
        {
            return idAdversario;
        }

        public static String getAdversarioPose()//Método usado para obter o ultimo lugar onde o adversario jogou
        {
            return AdversarioPose;
        }


        public static void limparPoseAdversario()//Método usado para limpar o lugar onde o adversario jogou
        {
            AdversarioPose = "";
        }




        public static int getPlayerVitorias()//Método usado para obter o número de vitórias do jogador.
        {
            return PlayerVitorias;
        }
        public static int getPlayerDerrotas()//Método usado para obter o npumero de derrotas do jogador.
        {
            return PlayerDerrotas;
        }
        public static String getPlayerFoto()//Método usado para obter a foto do jogador
        {
            return PlayerFoto;
        }
        public static void setPlayerVitorias(int vitorias)//Método usado para  definir o numero de vitorias do jogador.
        {
            PlayerVitorias = vitorias;
        }
        public static void setPlayerDerrotas(int derr)//Método usado para definir o numero de derrotas do jogador.
        {
            PlayerDerrotas = derr;
        }
        public static void setPlayerFoto(String foto)//Método usado para definir a foto do jogador.
        {
            PlayerFoto = foto;
        }
        public static void setSenha(String senha) //Método usado para definir a senha do jogador.
        {
            Senha = senha;
        }
   


        public  bool CadastrarPlayer(String cNome,String cSenha, String cFoto)//Método usado para cadastrar um novo jogador
        {
            id = cNome;  //Define o nome do jogador      
            Senha = cSenha; //A senha
            PlayerFoto = cFoto;//A foto
            PlayerVitorias = 0;//Número de vitórias
            PlayerDerrotas = 0;//Número de derrotas
           return  dao.CriarPlayer(this);//Chama a classe dao.CriarPlayer() que vai armazenar todas essas informações no banco de dados.
        }

        public String getcNome() //Método usado para obter o nome do novo player cadastrado
        {
            return id;
        }
        public String getcSenha()//Método usado para obter a senha do novo player cadastrado
        {
            return Senha;
        }
        public String getcFoto()//Método usado para obter o caminho da foto foto do player cadastrado
        {
            return PlayerFoto;
        }
        //GET E SETS DE PLAYER ONLINE
        //Quando um player está online precisamos pegar algumas informações dele como essas:
        public static void setOnid(String id)//Define o nome do player online obtido pelo banco de dados
        {
            onid = id;
        }
        public static void setOnstringFoto(String ft)//Define o caminho da foto do player online obtido pelo banco de dados.
        {
            onstringFoto = ft;
        }

        public static String getOnid()//Obtém o nome do player online
        {
            return onid;
        }
        public static String getOnFotoString()//Obtem a foto do player online
        {
            return onstringFoto;
        }


        //Algumas coisas importantes sobre o advérsario.

        public static String getAdversarioLetra()//Obtém a letra do adversario no jogo da velha
        {
            return AdversarioLetra;
        }
        public static void setAdversarioLetra(String l)//Determina a letra do player online no jogo da velha
        {
            AdversarioLetra = l;
        }
        public static void setQuemComeca(String nome)//Determina quem deve começar primeiro na batalha do jogo da velha
        {
            QuemComeca = nome;
        }
        public static String getQuemComeca()//Obtem quem deve começar primeiro no jogo da velha.
        {
            return QuemComeca;
        }

        
        public static void setAdversarioCaminhoFoto(String cfoto)//Determina onde estará hospeada a foto do adversario
        {
            AdversarioCaminhoFoto = cfoto;
        }
        public static String getAdversarioCaminhoFoto()//Obtem a foto a foto do adversario
        {
            return AdversarioCaminhoFoto;
        }

        private static String MensaggemAVerificar; //Cria um novo objeto estático do tipo string
        private static String auxv; //Cria um novo objeto estático do tipo string

        private static Cliente c = new Cliente(); //Cria um novo objeto estático do tipo Cliente 

        /*O método a seguir VerificarmensagemEnviada() é um método que
         * vai receber uma mensagem que o player enviou ao servidor e logo
         * depois vai ficar verificando se foi enviada em um timer, caso o servidor
         * não retorne a mensagem significa que não recebeu então ele vai enviar novamente
         * até ter esse conclusão.
         */
        public static void VerificarmensagemEnviada(String Mensagem) //Recebe a mensagem a ser verificada
        {

            MensaggemAVerificar = Mensagem;
        }

        //O próximo método é o timer que vai disparar o evento RelogioEvento a cada 1100 ms para verificar
        //se a menssagem foi entregue ao servidor.
        public static void startRelogioVerificar() //Esse me´todo cria o timer
        {
            relogio = new Timer() {
                Interval = 500//Coloca  o timer em um intervalo de 1100

            };
            relogio.Elapsed += new ElapsedEventHandler(RelogioEvento);//Define o método RelogioEvento como o evento ElapsedEventHandler do timer
            relogio.Enabled = true; //Ativa o rélogio agora ele vai ficar a a cada 1100 disparando o evento RelogioEvento


        }

        //Evento RelogioEvento ele que vai verificar se a mensagem recebida foi enviada ao servidor se não for ele insiste em enviar até ser entregue.
        public static void RelogioEvento(object myObject, EventArgs myEventArgs)
        {
         

            if (MensaggemAVerificar != "") //Caso MensaggemAVerificar seja diferente de vazio
            {
               
                try
                {
                    for (int i = 9; i < Cliente.getMenssagemServidor().Length; i++) //Da posição 9 do caracteres dos dados recebidos do servidor até o ultimo caractere ele vai fazer:
                    {
                        auxv = auxv + Cliente.getMenssagemServidor().ElementAt(i).ToString();//Adicionar caractere por caractere na variavel auxv.

                    }
                   //Depois de ter capturado todos caracteres precisamos agora verificar se é parecido com o que foi enviado ao servidor socket
                    if (auxv != MensaggemAVerificar)//Se for diferente então.
                    {
                       
                        c.setEnviarMensagem(MensaggemAVerificar); //Diz que vai enviar essa mensagem de novo ao servidor
                        Cliente.buffar();//Chama a thread para enviar.
                       

                    }
                    else
                    {
                        //Se for igual
                        MensaggemAVerificar = ""; //Limpa a mensagem por que já foi enviada ao servidor                        
                        
                       
                    }

                }
                catch (Exception)//Em caso de erro não fazer nada.
                {

                  
                }
                auxv = "";//Limpa a variavel auxiliar


            }
            auxv = "";//Limpa a variavel auxiliar

        }
         
       
       private static Timer Resp; //Cria um novo objeto do tipo timer 
        /*
         * O próximo método é um timer que vai ficar sempre disparando o método evtResponder
         * usando o timer Resp no intervalo de 1100 ms, indicando ao servidor que o player está online e
         * vai receber sempre novos dados do servidor.
         */
        public static void Responder()//Método usado para criar um novo timer,configurar seu intervalo e depois ativa-lo
        {
            Resp = new Timer() { //Instanca Resp como um novo Timer no intervalo de 1100
                Interval = 100 //Diz qual é o intervalo do novo Timer Resp

            };
            Resp.Elapsed += new ElapsedEventHandler(evtResponder); //Diz que o evento ElapsedEventHandler Que vai disparar a cada 1100 ms é o método evtResponder.
            Resp.Enabled = true; //Ativa o Timer e o deixa em execução


        }
        private static void evtResponder(object ob, EventArgs eag)//Método que vai ser chamado a cada 1100 ms pelo timer Resp
        {

           
                c.setEnviarMensagem("on," + id); //A variavl que envia dados ao servidor recebe a string on mais o nome do player separados por virgula.
                Cliente.buffar(); //Envia os dados ao servidor.
           







        }
       private static System.Windows.Forms.NotifyIcon Alerta = new System.Windows.Forms.NotifyIcon();//Instancia um novo objeto do tipo NotifyIcon que são icones de notificações do windows


        public static void IniciarPrograma()//Método usado para gerar uma notificação de boas vindas ao iniciar o login no programa
        {
            Alerta.Icon = new Icon("./ocorrencia.ico"); //O icone recebe uma nova imagem          
            Alerta.Visible = true;//O icone é visivel



            Alerta.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;//O icone seta seus balões de aviso como info
            Alerta.BalloonTipTitle = "Bem vindo ao jogo da velha";//Recebe esse titulo no balão de aviso, boas vindas
            Alerta.BalloonTipText = "Sessão iniciada";//Seta o texto que será exibido no balão de aviso 
            

            Alerta.ShowBalloonTip(5000);//O balão será exibido na tela no tempo máximo de 5000 ms

        }

        public static void alertarJogador(String Titulo,String Texto, int tempo){//Método usado para alertar o cliente sobre uma nova ocorencia gerada no mapa usando o notifyicon

            Alerta.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;//Muda a imagem do balão de notificações para warning, "aviso".
            Alerta.BalloonTipTitle = Titulo;//O titulo recebe o parametro Titulo
            Alerta.BalloonTipText = Texto;//O texto recebe o parametro Texto
            Alerta.ShowBalloonTip(tempo);//E o balão será exibido por um tempo máximo determinado pelo parametro tempo
        }
        public static void LiberarIcone()//Método usado paa liberar o controle notifyicon
        {
            Alerta.Dispose();//Libera o controle
        }
        public static void LimparUltimaPose()//Método usado para limpar a ultima jogada do jogador
        {
            verpose = "";//Recebe um valor vazio
        }
        public static void RecarregaTabela(bool resposta)//Método usado para informar se pode ou não recarregara tabela.
        {
            recarregarTabela = resposta;//A boleeana recarregarTabela recebe o parametro resposta
        }
        public static bool podeRecarregarTabela()//Método usado para saber se pode recarregar a tabela
        {
            return recarregarTabela;//Retorna a boleana recarregarTabela
        }
    }

}//Fim das instruções contidas na classe  Combate. 
