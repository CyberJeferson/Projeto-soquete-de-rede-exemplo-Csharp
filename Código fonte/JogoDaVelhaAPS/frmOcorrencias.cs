using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;//Biblioteca padrão do C# usada no projeto para Criar variaveis em String e tratamento de erro em catch
using MySql.Data.MySqlClient;//Biblioteca do Mysql do oracle, para linguagens .NET

namespace JogoDaVelhaAPS
{
    public partial class frmOcorrencias : Form      //classe frmOcorrencias 
    {
        public frmOcorrencias()//Método construtor da classe
        {
            InitializeComponent();
        }
        Cliente cliente = new Cliente();//Novo objeto do tipo cliente
        private String Verificar;//Novo objeto do tipo string
        private void frmOcorrencias_Load(object sender, EventArgs e)//Esse método é um evento que ocorre ao carregar o formulario
        {
            cMapa.LimparMapa();//Limpa o mapa
            cMapa.CarregarMapa(pMapa);//Adiciona o mapa no painel
          
            txtTipo.SelectedIndex = 0;//Inicia o combobox txtTipo no indice 0
          
            CarregarOcorrenciasNaTabela();//Adiciona as ocorrencias do banco de dados no datagrid, e coloca no mapa
            timer1.Enabled = true;// Ativa o timer 1
           
        
           

        }

        private void frmOcorrencias_FormClosing(object sender, FormClosingEventArgs e)//Método usado quando o formulário é fechado
        {
            Program.FecharTudo(true);//Se o fofmulario bome for fechado encerra toda aplicacão
            Program.AbriHome();////Abre o formulario Home      
            pMapa.Controls.Clear();//Remove o mapa dos controles do painel pMapa

        }

        private void pMapa_Paint(object sender, PaintEventArgs e)
        {

        }
        double v;
        private void timer1_Tick(object sender, EventArgs e)//Metodo usado para obter a velocidade de movimento no gps e atualizar a posição no gps ele é um evento de timer e será disparado a cada 500 ms
        {
            cMapa.obterCordeenadas();//Atualiza a posição no gps
            v = cMapa.obtervelocidade() * 3.6;//Obtém a velocidade do movimento na geolocalização
         
          
            if (v == 0)//Se a velocidade for 0  então:
            {
                Velocidade.Text = "0 km/h";//Vai exibir na tela a velocidade 0 seguida de km/h
            }
            else //Se for diferente de 0
            {
                Velocidade.Text = v.ToString() + " km/h";//Vai exibir na tela a velocidade seguido de km/h
            }
         
         



        }

        private void label8_Click(object sender, EventArgs e)//Evento click do label 8, ao clicar no label ele vai exibir o mapa em modo terreno ou satélite
        {

            
            if (label8.Text != "Mapa Terreno")//Se o label estiver exibindo o texto Mapa terreno então:
            {
                cMapa.MapaSatelite();//Exibe o mapa como satelite.
                pMapa.Invalidate();//Invalida o mapa para ser redesenhado na tela
                label8.Text = "Mapa Terreno";//Muda o texto Para mapa terreno.
                
            }
            else//Se não estiver exibindo o texto Mapa Terreno
            {
                cMapa.MapaTerreno();//Exibe o mapa como terreno
                pMapa.Invalidate();//Invalida para ser redesenhado na tela
                label8.Text = "Mapa Satélite";//Exibe o texto Mapa Satélite na label
            }
        }



        private void latlong_Tick(object sender, EventArgs e)//Esse método também é um evento de timer que será disparado a cada 500 ms, ele vai verificar comandos do servidor soquete de acordo com o comando vai carregar informações do banco de dados de novas ocorrencias no mapa e na tabela do datagrid, ele também vai colocar as posições do mapa de latitude e longitude em dois textbox, ele também anima as imagens dos incones do mapa
        {
            Combate.acoes(Cliente.getMenssagemServidor());//Verifica os comando recebidos do servidor soquete
            if (Combate.podeRecarregarTabela())//Se a boleana podeRecarregarTabela() for verdade então:
            {
                gOcorrencia.Rows.Clear();//Limpa a tabela do datagrid
                CarregarOcorrenciasNaTabela();//Carrega as novas informações do banco de dados no datagrid e no mapa
              
              
                Combate.RecarregaTabela(false);//Muda a boleana recebida de combate para false
            }
            txtlat.Text = cMapa.getMapaPositionLat();//Coloca a latitude no textbox txtlat
            txtlong.Text = cMapa.getMapaPositionLong();//Coloca a longitude no textbox txtlong
            cMapa.mudarImagem();//Anima as imagens de cMapa, fazendo elas mudarem 
           
        }

        private void button2_Click(object sender, EventArgs e)//Método event click do botão de criar ocorrência
        {
            dao.InserirOcorrencia(txtTipo.Text,txtdesc.Text,txtlat.Text,txtlong.Text);//Insere no banco de dados as informações
            Verificar =  "alerta " + txtTipo.Text + " " + txtdesc.Text;//Verificar recebe essas informações
            cliente.setEnviarMensagem(Verificar);//A variavel de enviar dados ao servidor soquete recebe verificar
            Cliente.buffar(); //Envia a informação ao servidor soquete          
            Cliente.desbufar();//Para a thread
            Combate.VerificarmensagemEnviada(Verificar);//Verifica se a mensagem foi enviada
            txtTipo.SelectedIndex = 0;//Mua o indice do combobox para 0
            txtdesc.Text = "";//Limpa o textbox descrição
           

        }

        private void button3_Click(object sender, EventArgs e)//Botão voltar ele fecha o formulário
        {
 
            this.Close();//Fecha o formulário
        }
        private static MySqlConnection Conexao;//Cria um novo objeto do tipo MySqlConnection 
        private static MySqlCommand mComando;//Cria um novo objeto do tipo MySqlCommand
        static MySqlDataReader dtreader;//Cria um novo objeto do tipo MySqlDataReader
        String[] linhaOcorrencias;//Nova array do tipo string
        String Latitude, Longitude, Descricao,Tipo,Nomeo, auxLatitude, auxLongitude;//Novos objetos do tipo string
        int Linhas;//Novo objeto do tipo inteiro
        String EnviarCordeenadas;//Novo objeto do tipo String
        private void EnviarCords_Tick(object sender, EventArgs e)
        {
           
            EnviarCordeenadas = ">" + Combate.getMeuId() + cMapa.ObterCordenadasGPS();
            cliente.setEnviarMensagem(EnviarCordeenadas);
            Cliente.buffar();

            
        }


        private void gOcorrencia_CellClick(object sender, DataGridViewCellEventArgs e)//Esse método é um evento CellClick do datagrid onde exibe a ocorrência clicada no mapa
        {
            Linhas = gOcorrencia.CurrentCell.RowIndex;//Recebe a linha selecionada do datagridview.
            auxLatitude = gOcorrencia.Rows[Linhas].Cells[2].Value.ToString();//Recebe a latititude da tabela
            auxLongitude = gOcorrencia.Rows[Linhas].Cells[3].Value.ToString();//Recebe a longitude da tabela
            cMapa.DirecionarMapa(Double.Parse(auxLatitude),Double.Parse(auxLongitude));//Exibe a latitude e alongitude onde se encontra a ocorrencia no mapa e dar um zoom para ver de perto

        }

        private void CarregarOcorrenciasNaTabela()//Método para carregar as ocorrencias do banco de dados. coloca no mapa e no data grid
        {
            try
            {

                Conexao = dao.Conectar();//Conecta ao banco de dados

                mComando = new MySqlCommand();//mComando é um novo objeto do tipo MySqlCommand
                mComando.Connection = Conexao;//Recebe a conexão com o bando de dados
                mComando.CommandText = "SELECT * FROM ocorrencia";

                dtreader = mComando.ExecuteReader();//Recebe os dados em binario
                Nomeo = "";
                while (dtreader.Read())//Enquanto estiver lendo os dados recebidos
                {
                    Tipo = dtreader["tipo_ocorrencia"].ToString();//Recebe o tipo de ocorrencia
                    Nomeo = dtreader["cd_ocorrencia"].ToString();//Recebe o código da ocorrencia
                    Descricao = dtreader["ds_ocorrencia"].ToString();//Recebe a descrição 
                    Latitude = dtreader["latitude"].ToString();//Recebe a latitude
                    Longitude = dtreader["longetude"].ToString();//Recebe a longitude
                    linhaOcorrencias = new String[] { Tipo, Descricao, Latitude, Longitude };//A array recebe as informações da ocorrencia
                    gOcorrencia.Rows.Add(linhaOcorrencias);//E as informações são adicionadas no datagrid
      
                    if (Nomeo != "")//Se o id da ocorrencia for diferente de vazio
                    {
                        cMapa.novaMarcacao(Nomeo, "./ocorrencia.png", Double.Parse(Latitude), Double.Parse(Longitude));//Coloca a ocorrencia no mapa
                    }
                  



                }
                Conexao.Close();//Fecha a conexão com o banco de dados
            }
            catch (Exception)
            {
               //Em caso de erro não fazer nada
            }

        }
     
  
    }
}
