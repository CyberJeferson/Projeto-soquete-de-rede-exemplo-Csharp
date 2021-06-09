//Classe Cliente================================================================================================
using System;//Biblioteca padrão do C# usada para criar variaveis em String e Tratamentos de Erros
using System.Net;//Bilioteca padrão do C# usada para definir o IP do socket
using System.Net.Sockets;//Biblioteca padrão do C# usada para usar o socket
using System.Text;//Biblioteca padrão do C# usada para codificar texto em utf-8, asc, etc
using System.Threading;//Biblioteca padrão do C# usada para criar uma thread


namespace JogoDaVelhaAPS
{
    class Cliente
    {
        //==============================
        private static int bytesSend; //Cria um novo objeto do tipo integer    
        private static int bytesRec; //Cria um novo objeto do tipo integer
        private static IPAddress IP; //Cria um novo objeto do tipo IPAddress da biblioteca System.Net do C#
        private static Socket sender;//Cria um novo objeto do tipo Socket da biblioteca System.Net.Socket
        public static Thread Buf;//Cria um novo objeto do tipo Thread
        private static String Menssagem = ""; //Cria um novo objeto do tipo String
        private static  byte[] bytes = new byte[1024]; //Cria uma nova bytearray
        private static  IPEndPoint remoteEP; //cria um novo objeto do tipo IPEndPoint
        private static byte[] msg; //Cria uma nova array do tipo byte
        //==============================


        /*
         * Método StartClient(), esse método é responsável por enviar e receber dados ao servidor socket.
         */
        public static void StartClient()
        {          
           

            //CONECTANDO AO SERVIDOR SOQUETE
           
            try
            {
                //IP DO SERVIDOR
                 IP = IPAddress.Parse("192.168.0.9");//Define o ip do servidor socket para 177.140.30.147

                 remoteEP = new IPEndPoint(IP, 11000); //Diz qual é o IP e a porta do servidor socket

              
                 sender = new Socket(IP.AddressFamily,
                 SocketType.Stream, ProtocolType.Tcp);//Informa que o socket vai usar a camada tcp

                //CONECTANDO AO SERVIDOR
                try
                {
                    sender.Connect(remoteEP);  //Conecta ao servidor socket         

                    msg = Encoding.UTF8.GetBytes(Menssagem); //A array msg vai receber a variavel menssagem byte a byte

                    
                  
                        bytesSend = sender.Send(msg); //Depois essa array vai ser enviada para o servidor nessa linha
                   
                         bytesRec = sender.Receive(bytes);//Após enviar os dados ao servidor essa linha terá a variavel BytesRec  que vai receber os dados de resposta do servidor socket

                    receber(Encoding.UTF8.GetString(bytes, 0, bytesRec)); //Após todo esse processo o método receber vai converter os bytes recebidos do servidor em UTF-8 e colocar eles dentro da string texto

          
                  
                   
                  

                }
                catch (ArgumentNullException)
                {
                   
                }
                catch (SocketException)
                {
                   
                }
                catch (Exception)
                {
                   
                }

            }
            catch (Exception)
            {
                
            }
           
            sender.Close(); //Fecha a conexão Socket e libera todos os recursos associados.
            desbufar();              //Em caso de erro não fazer nada     
    



        }

        /* Toda mensagem conexão do socket client será enviado via thread emum processo separado para poder-mos manipular
         * outros processos durante o envio e recebimento de dados
         */


        public static void desbufar()//Esse método para a thread que está rodando imediatamente.
        {
            Buf.Abort();
        }
      
        public static void buffar() //Esse método define qual método deve rodar em processo separado na thread e também define a prioridade e o nome, logo depois ele inicia o método como uma thread
        {

            try
            {
                Buf = new Thread(new ThreadStart(StartClient)); //Diz que buf é uma nova thread que deve rodar o método StartClient()
                Buf.IsBackground = true; //Aqui informa que a thread deve rodar em segundo plano
                Buf.Priority = ThreadPriority.Highest; //Diz que sua prioridade no processo é Highest
                Buf.Name = "Buf";//Dar um nome a thread
                //Depois de configurar a thread
                Buf.Start();//Inicia a thread 
               
            }
            catch
            {

            }
           
          


        }
        private static String Recebido; //Cria um novo objeto do tipo String

        public static void receber(String Texto) //Esse é usado para receber os dados do servidor socket
        {
            Recebido = Texto; //Recebido recebe  Texto
        }
  
        public static String getMenssagemServidor() //Esse método é usado para obter os dados recebidos do servidor quando chamado
        {
            return Recebido; //Retorna a variavel Recebido ao método
        }
        public void setEnviarMensagem(String m) //Esse método é chamado para alterar a mensagem que eu quero enviar ao servidor soquete
        {
            Menssagem = m; //Menssagem recebe m
        }

        ////////////////
     
        //////////
    }
}
