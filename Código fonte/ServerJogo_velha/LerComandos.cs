using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*Desenvolvido por Jeferson Oliveira.
 * Projeto de comunicação de rede.
 */
namespace ServerJogo_velha
{
    class LerComandos
    {

        private static MServidor Sev = new MServidor();// instancia a classe mServidor.
        private static bool VerificarOnline; //Variável booleana que de tempo em tempo fica true e para retornar quem tá online e limpar a lista de clientes online. 
        private static String PlayersOnline;//cria um novo objeto do tipo string com o nome PlayersOnline, essa variavel vai armazenar o nome dos players online
        private static String HoraMinuto, VerPlayer, VerificarPlayerOn, NovaEntrada; //Cria vários objetos do tipo string
        private static String auxpl;//Novo objeto do tipo string
        private static ListBox listBox1 = new ListBox();//Novo objeto do tpo ListBox
        public LerComandos()
        {

            
        }
        public static string Lertudo()
        {
            try
            {
                return listBox1.Items[listBox1.Items.Count -1].ToString();
            }
            catch (Exception)
            {

                return "";
            }
            
        }
        public static String QuemEstaOnline()
        {
            return PlayersOnline;
        }
        public static void verificarMensagem()
        {

            HoraMinuto = DateTime.Now.ToString("HH:mm:ss"); //a variavel HoraMinuto rebe a hora e a data do momento atual.

            try
            {
                if (Sev.getEntrada() != "") //Se a variavel de dados recebidos do servidor for diferente de vazia então
                {
                    VerPlayer = Sev.getEntrada(); //A variavél VerPlayer recebe os dados que foram entregues ao servidor

                    if ((VerPlayer.ElementAt(0).ToString() != "o" && VerPlayer.ElementAt(1).ToString() != "n"))// se os dados recebidos do cliente tiver as primeiras letras escritas diferente de "on" então:
                    {
                       
                        listBox1.Items.Add(HoraMinuto + " " + Sev.getEntrada());    //Adiciona os dados  do cliente em uma list box                     
                       






                    }
                    else //Se não
                    {


                     


                            if (VerPlayer.ElementAt(0).ToString() == "o" && VerPlayer.ElementAt(1).ToString() == "n") // Se os dados  recebidos do cliente  tiver as primeiras letras escrita on então:
                            {



                                VerPlayer = Sev.getEntrada();
                                auxpl = "";
                                VerificarPlayerOn = "";
                                NovaEntrada = "";
                                auxpl = VerPlayer;


                                for (int i = 3; i < auxpl.Length; i++) //Cria um laço de repetição de acordo com o tamanho de caracteres da variavel VerPlayer começando do caractere na terceira posição
                                {
                                    NovaEntrada += auxpl.ElementAt(i).ToString(); //Adiciona caractere por caractere na variavel NovaEntrada
                                }

                                if (PlayersOnline != "") //Se avariavel PlayersOnline for diferente de Vazia então:
                                {


                                    for (int i = 3; i < PlayersOnline.Length; i++)  //Cria um laço de repetição que começa do 3 até o tamanhp de caracteres da variavel PlayersOline
                                    {




                                        if (PlayersOnline.ElementAt(i).ToString() != ",") //Dentro do laço de repetição se a variavel PlayersOnline tiver o caractere igual uma virgula ele adiciona o caractere na varivel VerificarPlayer online
                                        {
                                            VerificarPlayerOn += PlayersOnline.ElementAt(i).ToString();//Adiciona o caractere de player online na variavel VerificarPlayerOn
                                        }
                                        else
                                        { //Se tiver virgula:
                                            if (VerificarPlayerOn == NovaEntrada) //Verifica se VerificarPlayerOn é igual NovaEntrada se for igual ele para o for
                                            {
                                                VerificarPlayerOn = "NULL";
                                                break;
                                            }

                                            VerificarPlayerOn = ""; //VerificarPlayerOn receb um valor vazio





                                        }









                                    }//Fim do laço de repetição


                                    //No final do laço de repetição ele vai verificar se
                                    if (VerificarPlayerOn == "" && NovaEntrada != "") //VerificarPlayerOn for vazia
                                    {
                                        PlayersOnline += NovaEntrada + ","; //adiciona o nome na var PlayersOnline junto com uma virgula
                                        VerificarPlayerOn = "NULL";
                                        NovaEntrada = ""; //NovaEntrada recebe um valor vazio
                                    }




                                }

                                else
                                {   //Se a variavel PlayersOnline for vazia:
                                    PlayersOnline = "Xn:" + NovaEntrada + ","; //A variavel playeronline recebe os a string 0n e os  dados de NovaEntrada com uma virgula



                                }



                            } //Fim da condição se os primeiros caracteres for on da variavel VerPlayer



                        












                    }

      
                    if (listBox1.Items.Count == 0) //Se alistbox estiver vazia
                    {
                        Sev.EscreverMenssagem(listBox1.Items[listBox1.Items.Count].ToString()); //Envia ao  cliente o valor atual da listbox adicionado
                    }
                    else
                    {
                        if (listBox1.Items[listBox1.Items.Count - 1].ToString().ElementAt(0).ToString() == "X" && listBox1.Items[listBox1.Items.Count - 1].ToString().ElementAt(0).ToString() == "n")
                        {
        
                            Sev.EscreverMenssagem(listBox1.Items[listBox1.Items.Count - 2].ToString());//se não Envia ao cliente um item adicionado antes do ultimo item adicionado ao listbox
                        }
                        else
                        {
                            if (listBox1.Items[listBox1.Items.Count - 2].ToString().ElementAt(0).ToString() == "X" && listBox1.Items[listBox1.Items.Count - 2].ToString().ElementAt(0).ToString() == "n")
                            {
                                Sev.EscreverMenssagem(listBox1.Items[listBox1.Items.Count - 3].ToString());//se não Envia ao cliente um item adicionado antes do ultimo item adicionado ao listbox
                            }
                            else
                            {
                                Sev.EscreverMenssagem(listBox1.Items[listBox1.Items.Count - 1].ToString());//se não Envia ao cliente um item adicionado antes do ultimo item adicionado ao listbox
                            }
                           
                        }
                        
                     
                        
                       
                    }


                } //Fim da condição de entradas vazias do servidor



            }
            catch (Exception e)//Caso haja erro limpa os players online
            {
                PlayersOnline = "";//PlayersOnline recebe um valor vazio
                VerificarPlayerOn = "NULL";
                VerificarOnline = false;
                auxpl = "";               
                NovaEntrada = "";
            }
            if (VerificarOnline) // se a boleana VerificarOnline for verdadeira
            {
                //Sev.EscreverMenssagem(PlayersOnline); //Envia ao cliente a variavel PlayersOnline
               // Sev.LimparEntrada(); //Limpa a ultima menssagem que o cliente enviou ao servidor
                listBox1.Items.Add(PlayersOnline);
                PlayersOnline = ""; //PlayerOnline recebe um valor vazio
                VerificarPlayerOn = "NULL";
                VerificarOnline = false;// A boleana VerificarOnline recebe o valor falso
                auxpl = "";
                NovaEntrada = "";
            }





            if (listBox1.Items.Count >= 1000) //se a listbox tiver itens igual ou acima de 1000 ela será limpa
            {
                listBox1.Items.Clear();//Limpa a listbox
            }
          

        }
        public static void verificarPlayOn(bool verificar)
        {
            VerificarOnline = verificar;
        }
        public static ListBox Lista()
        {
            listBox1.Visible = true;
            listBox1.Show();
            return listBox1;
        }
    }
}
