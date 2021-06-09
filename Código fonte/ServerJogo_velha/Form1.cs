//--------------------------------------------------------------------
//AUTOR JEFERSON OLIVEIRA
//linkedin: https://www.linkedin.com/in/jeferson-oliveira-8335051b6/
//E-MAIL: contact.jeferson.oliveira@gmail.com
//--------------------------------------------------------------------
using System;//bliblioteca padrão do C# de Strings Exceções e demais ultilidades.
using System.Linq; //Biblioteca padrão do C# usada para obter uma string de variavel em uma determinada posição
using System.Windows.Forms; //Biblioteca padrão do C# de formulários
//Todas as bilbiotecas são padrões da linguagem.
namespace ServerJogo_velha
{
    public partial class Form1 : Form //Informa que essa classe é um formulário
    {

        MServidor Sev = new MServidor();// instancia a classe mServidor.
        private static bool VerificarOnline; //Variável booleana que de tempo em tempo fica true e para retornar quem tá online e limpar a lista de clientes online. 
        private static  String PlayersOnline;//cria um novo objeto do tipo string com o nome PlayersOnline, essa variavel vai armazenar o nome dos players online
        public Form1()//Método construtor da classe padrão da linguagem.
        {
            InitializeComponent();
          
        }

        /*
         * Form1_Load() Esse é um evento ao carregar o formulário
         * Ele vai chamar outros métodos que São:
         * Sev.StartServidor();
           Sev.LimparEntrada();
         */
        private void Form1_Load(object sender, EventArgs e) //Evento Load do c#, ocorre quando o formulário é carregado
        {

            Sev.StartServidor(); //Chama o método que bota o servidor em estado de escuta e inicia o loop inifinito que verifica se há clientes conectados.
            notific.Text = "Servidor online"; // O objeto NotifyIcon é um método do C# para adicionar icones na barra de notificações do windows, Task Notify o texto da barra ao passar o mouse será "Servidor online"
            notific.Visible = true;//Deixa o NotifyIcon visivel para o usuario do windows
            
           
        }

        string ultimaMensagem;
        private void rec_info_Tick(object sender, EventArgs e) //rec_info_Tick() evendo do timer
        {
            listBox1.Items.Clear();
            try
            {
                if (LerComandos.QuemEstaOnline().ToString() == "" || LerComandos.QuemEstaOnline().ToString() == null)
                {
                    listBox1.Items.Add("NINGUÉM ONLINE");
                }
                else
                {
                    listBox1.Items.Add("ONLINE: " + LerComandos.QuemEstaOnline().Substring(3).ToString());
                }
               
            }
            catch (Exception)
            {
                listBox1.Items.Add("NINGUÉM ONLINE");
            }
          
            listBox1.Items.Add("ULTIMA MENSAGEM RECEBIDA:");
            try
            {
                if (LerComandos.Lertudo().ElementAt(0).ToString() == "X" && LerComandos.Lertudo().ElementAt(1).ToString() == "n")
                {

                }
                else
                {
                    ultimaMensagem = LerComandos.Lertudo();
                    listBox1.Items.Add(ultimaMensagem);
                }
                listBox1.Items.Add(ultimaMensagem);
            }
            catch (Exception)
            {

              
            }
        
         

        }
      

   



 



        private void timer1_Tick(object sender, EventArgs e) // acada 5000 ms o evento timer1_Tick()é disparado
        {
            LerComandos.verificarPlayOn(true);

        }

        //Evento clique do botão Ocultar
        private void button1_Click(object sender, EventArgs e) // evento button1_Click()
        {
            this.Visible = false; //Quando o botão é pressionado ele oculta o formulario 
          
        }


        //Evento notific_MouseDoubleClick(), quando o NotifyIcon é pressionado duas vezes ele vai fazer o fomulario aparecer se tiver ocultado
        private void notific_MouseDoubleClick(object sender, MouseEventArgs e)// Evento notific_MouseDoubleClick()
        {
            this.Visible = true; //O formulario fica vizivel
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
