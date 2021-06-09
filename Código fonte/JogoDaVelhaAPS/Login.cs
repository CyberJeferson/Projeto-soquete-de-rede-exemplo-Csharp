/*
 * Tela Login.
 * Essa tela é responsável por autenticar um jogador. Depois do jogador ser autenticado
 * ele vai para a tela home.
 */
using System;//Biblioteca padrão do C#, usada no projeto em strings e exceções.
using System.Windows.Forms;//Biblioteca padrão do C# de controles de formulários e eventos.

namespace JogoDaVelhaAPS//O projeto está na solução JogoDaVelhaAPS
{
    public partial class Login : Form//indica que essa classe é um formulário, dessa forma quando chamar o "this" estára se referindo a um formulário.
    {
        public Login()//Método construtor da classe.
        {
            InitializeComponent();
        }

        Cliente c = new Cliente();//Instancia  a classe cliente.

        private void button1_Click(object sender, EventArgs e)//Evento clique do botão Entrar
        {
          

            if (txtNome.Text != "")//Se o campo de nome for diferente de vazio.
            {
                
                dao.PesquisarPlayer(txtNome.Text,textBox2.Text);//Pesquisa o nome do jogador e a senha no banco de dados
                if (Combate.getMeuId() != "")//Se o nome do player na classe Combate for diferente de vazio, significa que o nome e a senha está correto. Então:
                {

                    this.Visible = false;//Oculta a tela de login
                    c.setEnviarMensagem("msg: " + Combate.getMeuId() + "....acabou de entrar");//Envia uma mensagem ao servidor informando que o player tá on no chat
                    Cliente.buffar();
                    Combate.VerificarmensagemEnviada("msg: " + Combate.getMeuId() + "....acabou de entrar");
                    Combate.IniciarPrograma();
                    Combate.Responder();//Ativa o timer que fica atualizando resposta do servidor.
                    Program.AbriHome();//Abre atela home.
                    Program.FecharTudo(true);//Se home for fechado deve fechar toda aplicação.


                }
                else
                {
                    MessageBox.Show("Usuário ou senha não encontrado");//Se o nome ou senha estiver errados exibirá essa mensagem na tela.
                }
            }
           
            
        }

        private void label4_Click(object sender, EventArgs e)//Evento click da label criar conta
        {
            this.Visible = false;//Oculta o formulário.
            Program.abrirConta();//Abre o formulário de criar conta.


        }

        private void Login_Load(object sender, EventArgs e)//Evento  load do formulário ocorre ao carregar o formulário.
        {
            Combate.startRelogioVerificar();//Inicia o Timer que verifica as mensagens enviadas
            Combate.VerificarmensagemEnviada("");//Limpa a variavel que verifica as mensagens.
         
        }
    }
}
