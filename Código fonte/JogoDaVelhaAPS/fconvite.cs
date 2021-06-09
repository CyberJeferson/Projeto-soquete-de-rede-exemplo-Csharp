/*
 * Tela fconvite
 * Essa classe deve exibirum convite na tela caso o jogador seja desafiado.
 * O convite tem a opção de aceitar ou recusar.
 */
using System;//Biblioteca padrão do C#, esse projeto está usando String e tratamentos de erros dessa biblioteca
using System.Drawing;//Biblioteca usadano projeto para poder alterar a posição das labels
using System.Windows.Forms;//Biblioteca de formulários padrão do C# com todos os controles e eventos.

namespace JogoDaVelhaAPS
{
    public  partial class fconvite : Form//Diz que a classe é um formulário.
    {
        private String VarVerificar;//Cria um novo objeto do tipo String
        private bool ComAdversario = false;//Cria um novo objeto do tipo boleano
        public  fconvite()//Construtor da classe
        {
            InitializeComponent();
        }
        Cliente c = new Cliente();//Instancia a classe Cliente
        int pose;//Novo objeto do tipo inteiro
        int divisor;//Novo objeto do tipo inteiro
    
        private void fconvite_Load(object sender, EventArgs e)//Evento fconvite_Load é disparado quando o formulário é carregado.
        {
            pFoto.LoadAsync(Combate.getAdversarioCaminhoFoto());//Exibe a foto do adversário.
            lNome.Text = Combate.getIdAdversario();//Exibe o nome do adversário
                    //O proximo passo abaixo vai centralizar a label com o nome do adversario  no convite.
                    divisor = lNome.Width / 2; //Recebe o tamanho da largura do nome do adversario e divide por 2
                    pose = (lNome.Location.X - divisor);//pose recebe a posição x do nome do adversario menor divisor
                    lNome.Location = new Point(pose, lNome.Location.Y);//O nome do jogador é posicionado nas cordenadas x pose e y a posição atual

        }



        private void btnRecusar_Click(object sender, EventArgs e)//Evento de click do botão recusar a batalha.
        {
            VarVerificar = "cvr" + Combate.getIdAdversario() + "," + "n,";//Recebe a string cvr mais o nome do adverario e a string n separados por virgulas
     
            c.setEnviarMensagem(VarVerificar);//Grava as informações na string responsavel por enviar mensagem ao servidor.
            Cliente.buffar();//Envia a mensagem em uma thread
            Combate.VerificarmensagemEnviada(VarVerificar);//Verifica se a mensagem foi enviada
        
            this.Close();//Fecha o formulário.



        }

        private void fconvite_FormClosing(object sender, FormClosingEventArgs e)//Evento de fechar o formulário
        {
            if (ComAdversario)//Se ComAdversario for verdadeiro
            {
                Program.abrirJogo();//Abre o formulario do jogo da velha
            }
            else
            {   //Se for falso
                Combate.setIdAdversario("");//Limpa o nome do adversario
            }
           
        }

        private void btnAceitar_Click(object sender, EventArgs e)//Evento de clique do botão aceitar batalha
        {
            Program.FecharTudo(false);//Diz a home que não vai fechar todos processos do programa
            Program.FecharHome();//Fecha o fomulário home
            ComAdversario = true;//recebe um valor verdadeiro
            VarVerificar = "cvr" + Combate.getIdAdversario() + "," + "s,"; //Recebe cvr mais o nome do adversario e s, separados por virgulas
            c.setEnviarMensagem(VarVerificar);//Grava na variavel de enviar a informação ao servidor
            Cliente.buffar();//Envia a mensagem ao servidor.
            Combate.VerificarmensagemEnviada(VarVerificar);//Verifica se a mensagem foi enviada

            this.Close();//Fecha o formulário.
       
        }


         

        
     }
}

