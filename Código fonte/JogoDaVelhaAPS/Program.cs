/*
 * Classe program a classe principal do projeto.
 * Nela é carregada várias telas e também possui o método main.
 * 
 */

using System;//Biblioteca padrão do C#, usada no projeto para
using System.Windows.Forms;//Biblioteca padrão do C#, usada no projeto para liberar formulários e seus componentes

namespace JogoDaVelhaAPS//O projeto está na solução, JogoDaVelhaAPS
{
    static class Program//Classe program
    {
        private static Login logar;//Cria um novo objeto do tipo Login classe login
        private static Form1 Jogo;//Cria um novo objeto do tipo Form1 a tela do jogo da velha
        private static Home Inicio;//Cria um novo objeto do tipo Home, a a tela do chat principal 
        private static CriarConta conta;//Cria um novo objeto do tipo CriarConta a tela de criar conta
        public static void abrirJogo()//Método usado para abrir a classe do jogo da velha.
        {
            Jogo = new Form1();//Instancia o Form1
            Jogo.Show();//Exibe a tela do jogo da velha
        }
        public static void AbriHome()//Método usado para abrir a tela Home 
        {
            Inicio = new Home();//Instancia a tela Home            
            Inicio.Show();//Exibe a tela home.
        }
        public static void MensagemStatusHome(String texto)//Método usado para escrever em uma label abaixo dos vitorias e derrotas na tela home.
        {
            Inicio.setMensagemStatus(texto);//Escreve o texto na label
        }
        public static void abrirConta()//Método usado para abrir a tela de criar uma conta
        {
            conta = new CriarConta();//Istancia a classe CriarConta
            conta.Show();//Exibe a tela CriarConta
        }


        [STAThread]//Indica que um modelo de Threading para um aplicativo é STA
        static void Main()//Método principal.

        {
            Application.EnableVisualStyles();//Permite estilos visuais para o aplicativo
            Application.SetCompatibleTextRenderingDefault(false);//Define o padrão do aplicativo para a propriedade UseCompatibleTextRendering definida em certos controles.
            logar = new Login();//Instancia a Classe Login
            Application.Run(logar);//Inicia a aplicação na tela de login.

          

        }
        public static void FecharJogo()//Método usado para fechar a tela de login
        {

            logar.Dispose();

        }
        //-------------------LOGAR ATRIBUIÇÕES
        public static void LogarVisible()//Métódo usado para exibir a tela de login
        {
            logar.Visible = true;
        }


        //----------------------------------SISTEMA DE USUARIOS ONLINE E CHAT----------------------------
      private static  fconvite Convite;//Cira um novo objeto do tipo fconvite a tela de convites
        public static void CarregarConvite()//Método usado para abrir a tela de convites
        {
            Convite = new fconvite();//Instancia a tela de convites
            Convite.Show();//Exibe a tela de convites
        }
        public static void FecharHome()//Método usado para fechar a tela Home do chat principal.
        {
            Inicio.Close();//Fecha a tela
        }



        public static void FecharTudo(Boolean fechar)//Método usado para indicar home se quer fechar todos processos da aplicação
        {
            Inicio.Fechartudo(fechar);//Fecha todos processos da aplicação se receber um valor boleano true
        }



    }
}
