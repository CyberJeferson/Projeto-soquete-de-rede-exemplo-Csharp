using System; //Biblioteca padrão do C# onde contém  demais métodos usados nessa classe
using System.Collections.Generic; //Biblioteca usada para criar lista generica no C#
using System.Net; //Biblioteca usada para definir o ip do servidor socket
using System.Net.Sockets; //Biblioteca de Socket do C#
using System.Text; //Biblioteca usada para codificar textos no C#
//TODAS AS BIBLIOTECAS SÃO PADRÃO DA PROPRIA LÍNGUAGEM DE PROGRAMAÇÃO.


namespace ServerJogo_velha
{
    class MServidor //Classe MServidor
    {
        private static Socket ServidorSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream ,ProtocolType.Tcp); //intancia uma nova  variavel de socket da biblioteca de soquete .NET e diz que sua camada é do tipo tcp
        private static byte[] buffer = new byte[1024]; //criar uma array do tipo byte de no máximo 1024 bytes
        private List<Socket> ClientesSocket = new List<Socket>(); //Cria uma lista genérica do tipo socket
       
      

        public void StartServidor() //Método que inicia o servidor e coloca em modo de escuta  ele também define o ip do servidor e sua porta. que é 11000
        {
            ServidorSocket.Bind(new IPEndPoint(IPAddress.Parse("192.168.0.9"), 11000));//Método bind vcoê deve usar para especificar qual ip e porta o seu  servidor deve escutar.
            //O ip definido foi o ip, 192.168.0.9 e a porta 11000
            ServidorSocket.Listen(1); //COLOCA A SOCKET EM MODO DE ESCUTA
            ServidorSocket.BeginAccept(new AsyncCallback(Interceptar), null); //BeginAccept método para processar de forma assíncrona as tentativas de conexão de entrada. A aceitação de conexões de forma assíncrona oferece a capacidade de enviar e receber dados em um thread de execução separado. Essa sobrecarga permite que você especifique o soquete aceito no acceptSocket parâmetro. Se esse parâmetro for null , o soquete aceito será criado pelo BeginAccept método "Interceptar"
        }
        Socket soquete; //Cria uma variavel do tipo Socket

        /*
         * MÉTODO Interceptar(IAsyncResult AR)
         * O que esse método faz? Ele vai ficar sempre em loop infinito de forma assícrona em um thread separado. Seu objetivo é ficar
         * sempre esperando uma conexão remota, quando há uma conexão ele vai receber seus dados e chamar o método Interceptar(IAsyncResult AR)
         * também de forma assícrona para armazenar os dados em uma String por final enviar dados ao cliente.
         * Um IAsyncResult que faz referência à leitura assíncrona.*
         */
        private void Interceptar(IAsyncResult AR)
        {
            try
            {
                soquete = ServidorSocket.EndAccept(AR); //Aceita de forma assíncrona uma tentativa de conexão de entrada e cria um novo objeto Socket para manipular as comunicações de host remoto.
            }
            catch (Exception)
            {

               
            }
              
            
           
            ClientesSocket.Add(soquete); //A conexão é adicionada na lista generica
            try
            {
                soquete.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBacks), soquete); //Começa a receber de maneira assíncrona dados de um Socket conectado, e chama o método ReceiveCallBacks para cloncuir a operação de forma assícrona.
            }
            catch (Exception)
            {

                
            }
          
            ServidorSocket.BeginAccept(new AsyncCallback(Interceptar), null); //Retorna de modo assícrono para esse método de receber conexões e fica em loop infinito sempre esperando um cliente se conectar 
        }
        private static String Entrada; //Variavel do tipo string el vai receber os dados do cliente
        private static String Saida= "Bem vindo"; //Variavel do tipo String, ela vai conter os dados que serão enviados ao cliente
        static int Recebidos; //Variavel do tipo inteiro int32, vai receber o tamanho dos dados da socket
        private static Socket soquete2; //Cria um novo objeto do tipo Socket que vai conter os dados da operação assícrona
        static   byte[] EnviarDados; //Cria um novo objeto array do tipo byte que vai ser enviado ao cliente
        static byte[] dadosBuf; ///Cria um novo objeto array do tipo byte que vai conter os dados da soquete


        /*
         * Método ReceiveCallBacks(IAsyncResult AR).
         * Esse método é responsável por gravar os dados recebidos do cliente e também enviar de modo assíncrono
         * ao cliente ele támbém ignora dados já recebidos para evitar um flood
         */
        private static void ReceiveCallBacks(IAsyncResult AR)
        {
             soquete2 = (Socket)AR.AsyncState; //O soquete recebe o resultado assícrono de AR.
            try
            {
                Recebidos = soquete2.EndReceive(AR); //Recebidos recebe o resultado da soquete que é do tipo int32 e finaliza a solicitação assicrona
                dadosBuf = new byte[Recebidos]; //a array de bytes dadosbuf recebe os dados de Recebidos int32, e transforma em byte
                Array.Copy(buffer, dadosBuf, Recebidos); //Copia os dados da array buffer para a array dadosBuf Usando a var recebidos como o tamanho da array total


                Entrada = Encoding.UTF8.GetString(dadosBuf); //Entrada converte os dados a array dadosbuf em String UTF-8

                ultimo = Entrada;// a variavel ultimo recebe a menssagem do socket que está em Entrada.
                LerComandos.verificarMensagem();
               ultimo = "";



            }
            catch (Exception)//Se tiver algum erro o servidor vai continuar executando os próximos passos abaixo
            {

            }
           

            try
            {
                EnviarDados = Encoding.UTF8.GetBytes(Saida); //A array  EnviarDados recebe a string Saida codificada em utf-8
                Saida = "";
            }
            catch (Exception)//caso haja erros não fazer nada
            {

               
            }
            
                try
                {
               

                soquete2.BeginSend(EnviarDados, 0, EnviarDados.Length, SocketFlags.None, new AsyncCallback(EnviarMenssagem), soquete2);//Envia dados de forma assíncrona para um Socket conectado, e chama o método EnviarMenssagem Para encerrar a operação assíncrona de enviar os dados.
                //SocketFlags é uma combinação bit a bit dos valores SocketFlags.
                //SocketFlags.None, não usa sinalizadores para essa chamada.
            }
            catch (Exception)
                {
               // System.Windows.Forms.MessageBox.Show("Erro provavel variavel");

                }
            
       

                
            
                
            
        }

        //Método usado para Escrever uma menssagem ao cliente conectado.
        public void EscreverMenssagem(String Menssagem)
        {
            Saida = Menssagem; //Saida recebe os dados em string, do parametro Menssagem
        }
      static Socket soquete3;  //Cria um novo objeto estatico do tipo Socket
      static  String ultimo; //Cria um novo objeto statico do tipo String


      
        private static void EnviarMenssagem(IAsyncResult AR)   //Esse método  concluí a operação assícrona enviando os dados ao cliente .
        {
          
            soquete3 = (Socket)AR.AsyncState; //o socket Recebe os dados da operação assíncrona de AR
            try
            {

                soquete3.EndSend(AR); //EndSend conclui a operação de envio assíncrono iniciada em BeginSend, no método ReceiveCallBacks.


            }
            catch (Exception)//Caso haja erros não fazer nada
            {

               
            }
          


        }
      
        public String getEntrada()  //Esse método retorna os dados recebidos do cliente quando chamado
        {
            return ultimo; //Retorna a variavel ultimo para o método de retorno em string
        }
        
        public void LimparEntrada() //Esse método limpa os dados da variavel que recebe os dados do cliente, quando chamado
        {
            ultimo = ""; //A variavel ultimo recebe um valor vazio
        }
 

    }
}
