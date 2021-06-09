/*
 * Tela CriarConta.
 * Essa classe é responsável por criar uma nova conta de jogador 
 * e salvar as informações no banco de dados.
 * 
 */

using System;//Biblioteca padrão do C#, usada Em String e tratamentos de erros etc.
using System.Drawing;//Biblioteca usada no projeto para usar cores
using System.Linq;//Biblioteca usada no projeto para obter um determinado caractere dentro de uma string
using System.Windows.Forms;//Biblioteca padrão do C# que carrega todos os controles do system.windows.form.

namespace JogoDaVelhaAPS
{
    public partial class CriarConta : Form//Diz que essa classe é um formulário
    {
        public CriarConta()//Construtor da classe
        {
            InitializeComponent();
        }


        Combate comb = new Combate(); //Instancia a classe Combate.

        //Quando o formulário é fechado ele vai exibir o Formulario Login no evento CriarConta_FormClosing
        private void CriarConta_FormClosing(object sender, FormClosingEventArgs e)//Evento CriarConta_FormClosing
        {
            Program.LogarVisible();//Diz que Login será exibido.
        }


        //Ao carregar o formulário será baixada e exibidas as imagens opcionais que o player pode escolher em cada picturebox no evento CriarConta_Load.
        private void CriarConta_Load(object sender, EventArgs e)
        {
            //Exibe as imagens nas picturesBox abaixo.
            pictureBox11.LoadAsync(@"http://192.168.0.9/PERFIL/BORUTO.jpg");
            pictureBox1.LoadAsync(@"http://192.168.0.9/PERFIL/BORUTO.jpg");
            pictureBox2.LoadAsync(@"http://192.168.0.9/PERFIL/GAARA.jpg");
            pictureBox3.LoadAsync(@"http://192.168.0.9/PERFIL/SASUKE.jpg");
            pictureBox4.LoadAsync(@"http://192.168.0.9/PERFIL/hinata.jpg");
            pictureBox5.LoadAsync(@"http://192.168.0.9/PERFIL/kakashi.jpg");
            pictureBox6.LoadAsync(@"http://192.168.0.9/PERFIL/madara.jpg");
            pictureBox7.LoadAsync(@"http://192.168.0.9/PERFIL/naruto.jpg");
            pictureBox8.LoadAsync(@"http://192.168.0.9/PERFIL/narutoKurama.jpg");
            pictureBox9.LoadAsync(@"http://192.168.0.9/PERFIL/sakura.jpg");
            pictureBox10.LoadAsync(@"http://192.168.0.9/PERFIL/shikamaru.jpg");
        
        }
        //Os próximos métodos a seguir são evento click das picturesbox ao ser clicadas elas irão exibir suas imagens no picturebox1 que pe principal.
        private void pictureBox1_Click(object sender, EventArgs e)//Exibe sua imagem no picturebox1
        {
            pictureBox11.LoadAsync(pictureBox1.ImageLocation);
        }

        private void pictureBox2_Click(object sender, EventArgs e)//Exibe sua imagem no picturebox1
        {
            pictureBox11.LoadAsync(pictureBox2.ImageLocation);
        }

        private void pictureBox3_Click(object sender, EventArgs e)//Exibe sua imagem no picturebox1
        {
            pictureBox11.LoadAsync(pictureBox3.ImageLocation);
        }

        private void pictureBox4_Click(object sender, EventArgs e)//Exibe sua imagem no picturebox1
        {
            pictureBox11.LoadAsync(pictureBox4.ImageLocation);
        }

        private void pictureBox5_Click(object sender, EventArgs e)//Exibe sua imagem no picturebox1
        {
            pictureBox11.LoadAsync(pictureBox5.ImageLocation);
        }

        private void pictureBox6_Click(object sender, EventArgs e)//Exibe sua imagem no picturebox1
        {
            pictureBox11.LoadAsync(pictureBox6.ImageLocation);
        }

        private void pictureBox7_Click(object sender, EventArgs e)//Exibe sua imagem no picturebox1
        {
            pictureBox11.LoadAsync(pictureBox7.ImageLocation);
        }

        private void pictureBox8_Click(object sender, EventArgs e)//Exibe sua imagem no picturebox1
        {
            pictureBox11.LoadAsync(pictureBox8.ImageLocation);
        }

        private void pictureBox9_Click(object sender, EventArgs e)//Exibe sua imagem no picturebox1
        {
            pictureBox11.LoadAsync(pictureBox9.ImageLocation);
        }

        private void pictureBox10_Click(object sender, EventArgs e)//Exibe sua imagem no picturebox1
        {
            pictureBox11.LoadAsync(pictureBox10.ImageLocation);
        }
        //Escolhendo a imagem o player deverá agora criar um nome, uma senha e guardar essas informações no banco de dados. Para isso usaremos o evento click do botão Criar Conta
        String captura;//Cria um novo objeto do tipo String.
        String Vernome;//Novo objeto do tipo String
        bool Temchrx;//Novo objeto do tipo boleano
        
        private void button1_Click(object sender, EventArgs e)//Evento click do botão Criar Conta
        {
            //Ao clicar no botão criar conta.
            Temchrx = false;//Temchrx recebe false
            if (textBox1.Text == "")//Se o campo de inserir nome for vazio
            {
                textBox1.BackColor = Color.Red;//Pinta o fundo dele de vermelho
            }
            else
            {   //Se não for vazio
                Vernome = textBox1.Text;//VerNome recebe o nome do jogador
                textBox1.BackColor = Color.White;//O fundo do campo de nome recebe a cor branco
                for (int i = 0; i < Vernome.Length; i++)//Do caractere na posição 0 até o ultimo caractere de Vernome faça:
                {
                    captura = Vernome.ElementAt(i).ToString();//Captura recebe o caractere de acordo com i
                    if (captura == " " || captura == ",")//Se o caractere for igual a " " ou , então:
                    {
                        Temchrx = true; //Temchrx recebe o valor verdadeiro.

                    }                  
                }
                if (Temchrx)//se Temchrx for verdadeiro.
                {
                    MessageBox.Show("Pelo bem da humanidade, seu nickname não pode haver espaços nem virgulas."); //Essa mensagem será exibida na tela
                    textBox1.BackColor = Color.Red;//O campo de nome ficará com o fundo vermelho
                }
                else
                {   //Se Temchrx for falso
                    textBox1.BackColor = Color.White;//O campo de nome vai ter um fundo branco
                    //O proximo passo agora é verificar a senha
                    if (textBox2.Text == "")//Se o campo de senha for vazio
                    {
                        MessageBox.Show("Digite a Senha");//Exibe uma mensagem falando que deve digitar a senha
                        textBox2.BackColor = Color.Red;//O campo de senha fica com o fundo vermelho.
                    }
                    else
                    {
                        //Se não for vazio então o próximo passo é confirmar a senha.
                        textBox2.BackColor = Color.White;//O campo de senha recebe o fundo branco
                        if (textBox3.Text == "")//Se o campo de repetir senha for vazio.
                        {
                            MessageBox.Show("Confirme sua senha!!!");//Exibira essa mensagem na tela 
                            textBox3.BackColor = Color.Red;//O campo de recepetir senha recebe a cor vermelha no fundo
                        }
                        else
                        {   //Se não for vaizo o campo de repetir senha
                            textBox3.BackColor = Color.White;//O campo de texto repetir senha recebe um fundo branco
                            if (textBox2.Text != textBox3.Text)//Se o campo de senha for diferente do campo de repetir senha
                            {
                                MessageBox.Show("As senhas inseridas não sao parecidas.");//Exibira essa mensagem na tela
                                textBox2.BackColor = Color.Red;//O campo de senha fica com o fundo vermelho
                                textBox3.BackColor = Color.Red;//O campo de repetir senha ficará com o fundo vermelho também
                            }
                            else
                            {   //Se for iguais o campo senha e repetir senha
                                textBox2.BackColor = Color.White;//O campo de senha recebe a cor branca no fundo
                                textBox3.BackColor = Color.White;//O fundo do campo repetir senha recebe a cor branca
                                //Depois disso os dados serão gravados no banco de dados com o próximo comando abaixo
                                if (comb.CadastrarPlayer(textBox1.Text, textBox2.Text, pictureBox11.ImageLocation))//Grava os dados de foto,nome,senha. Se foram gravados então:
                                {
                                    MessageBox.Show("CONTA CRIADA COM SUSSESSO! AGORA LOGUE-SE");//Exibe essa mensagem na tela
                                    this.Close();//Fecha o formulário
                                    Program.LogarVisible();//Exibe o formulário de logar
                                }
                  
                               
                            }
                        }
                    }
                }
            }
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
