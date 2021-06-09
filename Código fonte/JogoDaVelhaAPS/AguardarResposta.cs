/*
 * Tela AguardarResposta.
 * Essa classe é responsável por ficar um determinado tempo esperando a resposta de um convite enviado em batalha.
 */
using System;//Biblioteca padrão do C#, usada em Strings
using System.Windows.Forms;//Biblioteca padrão do C# para usar itens de formulários. Como labels textbox etc.

namespace JogoDaVelhaAPS // Inoforma que a classe está dentro da solução JogoDaVelha
{
    public partial class AguardarResposta : Form //Diz que essa classe é um formulário.
    {
        public AguardarResposta()//Construtor da classe.
        {
            InitializeComponent();
        }
        int fmagem;//Cria um novo objeto do tipo inteiro.
        private bool PodeApagar = true;//Cria um novo objeto do tipo boleano.

        //O player deve ficar em um determinado tempo aguardando a resposta caso atinja o tempo limite de 1 minuto. deve aparecer uma mensagem ao player dizendo que o tempo limite foi atingido, para isso usaremos o Timer Contagem para disparar o evento Contagem_Tick a cada 10 segundos até atingir o tempo limite e fechar o formulario de aguardar resposta.
        private void Contagem_Tick(object sender, EventArgs e)//Evento Contagem_Tick() esse evento será disparado a cada 10 segundos.
        {
               //Fiz uma animação de uma espada onde a cada 10 segundos será preenchida com a cor vermelha

            if (fmagem <= 10) //se a variavel auxiliar fmagem for menor ou igual a 10
            {
                lAnimacao.LoadAsync("http://177.140.30.147/img/e" + fmagem + ".png"); //Adiciona uma nova imagem no picturebox lAnimacao

            }
            else
            {   
                if (fmagem > 10)//Se fmagem for maior que 10 ou seja 1 minuto pois o timer está rodando a cada 10 segundos.
                {
                    Program.MensagemStatusHome("TEMPO LIMITE DO CONVITE EXPIRADO!!");//O label no formulario home vai exibir TEMPO LIMITE DO CONVITE EXPIRADO!! no label abaixo das vitorias e derrotas do player.
                    Combate.setAceitouConvite("");//A resposta do convite será apagada.
                    Combate.setIdAdversario(""); //O nome do adversario será apagado.           
                    this.Close();//Fecha o formulário AguardarResposta.
                }
 
            }

            fmagem++;//fmagem se auto incrementa.
        }
        //Ao carregar o formulário a primeira imagem da animação será adicionada no evento AguardarResposta_Load()

        private void AguardarResposta_Load(object sender, EventArgs e)//Evento AguardarResposta_Load
        {

            lAnimacao.LoadAsync("http://177.140.30.147/img/e0.png");//Adiciona a primeira imagem na animação.
            
        }
        int lfinito;// Cria um novo objeto do tipo inteiro.
        //O proximo passo é um timer que fica verificando se o convite de batalha foi aceito ou negado. E para isso usaremos o Timer Letra. Que a cada 100 ms fará a verificação no evento Letras_Tick

        private void Letras_Tick(object sender, EventArgs e)//Evento Letras_Tick
        {
            //Animação dos 3 pontinhos no final da frase "Aguardando o player Responder"
            if (lfinito < 4)//Se a variavel lfinitofor menor que 4 então
            {
                lstatus.Text = lstatus.Text + ".";//O label lstatus exibirá  lstatus mais "." 
            }
            else
            {   //Se for igual a 4 
                lstatus.Text = "AGUARDANDO O PLAYER RESPONDER"; //lstatus exibirá a string "AGUARDANDO O PLAYER RESPONDER"
                lfinito = 0; //lfinito recebe o valor 0
            }
           
            //O próximo passo é verificar se o convite foi aceito
            if (Combate.getAceitouConvite() == "s")//Se a resposta do convite for s
            {

                PodeApagar = false;//A boleana podeApagar recebe false
                Combate.setAceitouConvite("");//Limpa a rsposta do convite.
                Program.abrirJogo();//Abre a tela de jogar o jogo da velha.
                this.Close();//Fecha o formulário
                Program.FecharTudo(false);//Informa que não vai ficar todos processos em Home.
                Program.FecharHome();//Fecha o formulário Home.
            }
            else
            {
                //Se o convite não foi aceito.
                if (Combate.getAceitouConvite() == "n")//Se não foi aceito
                {
                   
                    Program.MensagemStatusHome("CONVITE NEGADO");//Home vai exibir no label que foi negado o convite
                    Combate.setAceitouConvite("");//Limpa a resposta do convite.
                    Combate.setIdAdversario("");//Limpa o adversario.
                    this.Close();//Fecha o formulário.
                }

            }
            lfinito++;//lfinito se auto incrementa.
        }

        //Evento que ocorre ao fechar o formulário. AguardarResposta_FormClosing() se a boleana PodeApagar for verdadeiro vai apagar o convite e o nome do adversario
        private void AguardarResposta_FormClosing(object sender, FormClosingEventArgs e) //Evento AguardarResposta_FormClosing() quando fechar o formulário.
        {
            if (PodeApagar)//Se PodeApagar for verdade
            {
                Combate.setAceitouConvite("");//Apaga a resposta do convite
                Combate.setIdAdversario("");//Eapaga o nome do adversário.
            }
        }
    }
}
