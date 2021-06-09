using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET;
using System.Device.Location;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace JogoDaVelhaAPS
{
    class cMapa//Classe cMapa
    {
        private static GeoCoordinateWatcher GPS = new GeoCoordinateWatcher(GeoPositionAccuracy.High);//Cria um novo objeto do tipo GeoCoordinateWatcher que fornece dados de localização do usuário.
        private  static GMapControl Mapa = new GMapControl();//Cria um novo objeto do tipo GMapControl, um mapa com localização baseada em latitude e longitude
        private static double dlatitude, dlongitude;//Cria um novo objeto do tipo double.

        //A classe Marcar será responsável por criar novos icones e colocar eles no mapa de acordo com a sua localização.
        private class Marcar//Cria uma nova classe dentro da classe cMapa chamada Marcar.
        {
            private PointLatLng Cordenadas = new PointLatLng(-14.427464715734638, -51.66893281468073);//Cria um novo objeto do tipo PointLatLng que são cordeenadas baseadas em latitude e longitude
            private Bitmap Fogo;//Cria um novo objeto do tipo Bitmap para trabalhar com imagens.
            private GMapMarker Marca;//Novo objeto do tipo GMapMarker da biblioteca Gmap
            private String ImagemAtual;//Novo objeto do tipo string

            private GMapOverlay Marcas = new GMapOverlay("Fogo");//Novo objeto do tipo GMapOverlay, da biblioteca GMap

            /*O próximo método NovoNomeMarca é usado para criar uma nova marcação e dar um nome 
             *como identificação.
             */
            public void NovoNomeMarca(String id)
            {
                Marcas = new GMapOverlay(id);
            }
            public String obterNomeMarca()//Método usado para obter o nome da marcação
            {
                return Marcas.Id.ToString();//Retorna o nome da marcação
            }
            public void mudarCoords(double x, double y)//Método usado para alterar as cordenadas das marcações
            {
                Cordenadas = new PointLatLng(x, y);//Cordenadas recebe novas cordenadas dos parametros x e y
            }
            public void ImagemMarca(String f)//Método usadao para alterar a imagem (icone) de uma marcação no mapa
            {   Fogo = (Bitmap)Image.FromFile(f);//Fogo recebe uma nova imagem Bitmap.
                Marca = new GMarkerGoogle(Cordenadas, Fogo);//Marca recebe cordenadas e a nova imagem.
                Marcas.Markers.Clear();//Apaga todas marcações.
                Marcas.Markers.Add(Marca);//Adiciona a marcação com a nova imagem
                ImagemAtual = f;//Recebe o caminho da imagem atual
            }
            public String Imagematual()//Método usado para obter o nome e o caminho da imagem atual
            {
                return ImagemAtual;//Retorna a imagem atual usada na marcação
            }
            public GMapOverlay OMarcas()//Método usado para retornar a marcação e usa-la
            {
                return Marcas;//Retorna a marcação.
            }
        }
        static Marcar[] Marc;//Nova array do tipo Marcar.
        public static void fecharMapa()//Metodo usado para cancelar o armazenamento dos blocos em cache
        {
            Mapa.Manager.CancelTileCaching();//Cancela o armazenamento dos blocos do mapa em cache
        }
        public static void CarregarMapa(Panel p)//Método usado para configurar o mapa e colocar ele dentro de um panel usando o parametro p
        {
            GPS.Start();         
            Marc = new Marcar[50000];//Nova array do tipo marcar com de tamanho maximo de 50000


            Mapa.Width = p.Width;//Define o tamanho do mapa igual ao tamanho de largura do panel
            Mapa.Height = p.Height;//Define o tamanho de altura do mapa igual a altura do painel
            Mapa.Location = new Point(0, 0);//O mapa vai ficar na posição x 0 e y 0 dentro do painel
            p.Controls.Add(Mapa);//O painel já adiciona o mapa em seus controles
            
            Mapa.DragButton = MouseButtons.Left;//Informa qual botão deve mover o mapa
            Mapa.CanDragMap = true;//O mapa pode ser movido.
            Mapa.MapProvider = GMapProviders.GoogleTerrainMap;//Usa o mapa do google terrain de início
            Mapa.Position = new PointLatLng(-14.427464715734638, -51.66893281468073);//Seta uma nova cordeenada no mapa.
            Mapa.MinZoom = 3;//Informa que o minimo de zoom permitido no mapa é 3
            Mapa.MaxZoom = 20;//E o maximo de zoom é 20
            Mapa.Zoom = 3;//Inicia o mapa já no zoom 3
            Mapa.AutoScroll = false; //Indica se o usuario pode rolar em controles dentro do container fora dos limites visíveis. 
            Mapa.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);//Auto redimensiona o Mapa de acordo com o formulário.
            Mapa.MarkersEnabled = true;//Marcações no mapa que eu marcar serão exibidas.
           
        }
        public static void DirecionarMapa(double Latitude,double longitude)//Método usado para o mapa exibir a latitude e longitude das ocorrencias com zoom para ver o local
        {
            Mapa.Position = new PointLatLng(Latitude, longitude);//centraliza a cruz do mapa em uma nova cordeenada recebida
            Mapa.Zoom = 18;//Colocs o mapa em zoom 18
        }

   
        public static void obterCordeenadas()//Método usado para obter as cordeenadas do GPS quando o gps muda de posição.
        {
            if (GPS.TryStart(false, TimeSpan.FromSeconds(1.0)))// SE TIVER MUDANÇAS NA LOCALIZAÇÃO EM 1MS
            {
                LocationMessage();//Obtém esses dados
            }
     
        }
        private static double veloz;//Novo objeto do tipo double
        public static double obtervelocidade()//Método usado para obter o valor da velocidade em double 
        {
            return veloz;//Retorna a velocidade
        }

        private static string cord;//Novo objeto do tipo string
        
        private static void LocationMessage()//Método usado para obter a latitude e longitude e a velocidade de acordo com o GPS
        {
     
            var auxGPS = GPS.Position.Location;//Nova variavel tipo implícido auxGPS que vai receber as localizações do gps
            
            var Latitude = auxGPS.Latitude.ToString("0.000000");  //Var tipo implícido que vai receber a latitude do GPS
            var Longitude = auxGPS.Longitude.ToString("0.000000");  //Var tipo implícido que vai receber a longitude da geolocalização         
         
            var velocidade = auxGPS.Speed.ToString();//Var tipo implicido que vai receber a velocidade em metros por segundo.
            
            if (velocidade.ToString() != "NaN")//Se a velocidade for diferende de double.NaN Not a number então:
            {
                veloz = double.Parse(velocidade.ToString()); //Veloz recebe a velocidade convertida em double.

            }
            else//Se não
            {
                veloz = 0;//Veloz recebe zero
            }
            dlatitude = double.Parse(Latitude);//dlatitude recebe alatitude convertida em double



         
    
           


    
            try
            {
                dlongitude = double.Parse(Longitude.ToString());//Recebe a longitude convertida em double
            }
            catch (Exception)
            {

               //Em caso de erro nada a fazer
            }


            cord = ">" + Latitude + ">" + Longitude + ">";//Cord recebe a latitude e a longitude separados pela string >
            novaMarcacao("Player", "./pa1.png", dlatitude, dlongitude);//Cria uma nova marcação do usuário no mapa.
            
          

         

        }
     private static int nMarc = 0;//Novo objeto do tipo inteiro
     private static   bool existe;//Novo objeto do tipo booleano
        public static void novaMarcacao(String nome, String icone, double la, double lo)//Método usado para adicionar as marcações no mapa
        {
            existe = false;//Existe inicia com o valor falso
            if (nMarc == 0)//Se nMarc a variavel contatadora for igual a 0
            {

                Marc[nMarc] = new Marcar();//Instancia uma nova classe Marcar na array na posição nMarc
                Marc[nMarc].NovoNomeMarca(nome);//Dar um nome a marcação
                Marc[nMarc].ImagemMarca(icone);//Informa qual é a imagem da marcação.
                Marc[nMarc].mudarCoords(la, lo);//Informa a coordenada da marcação.                
                Mapa.Overlays.Add(Marc[nMarc].OMarcas());//Adiciona a marcação ao mapa.
                nMarc++;//nMap se auto incrementa
            }
            else//Se não for igual a 0 então 
            {
                for (int i = 0; i < nMarc; i++)//de 0 até nMarc
                {
                    if (Marc[i].obterNomeMarca() == nome)//Se o nome da marcação for igual o nome do parametro nome
                    {
                    
                      
                        Marc[i].mudarCoords(la, lo);//informa a nova cordenada da marcação                       
                        Mapa.Overlays.Remove((Marc[i].OMarcas()));//Remove do mapa a antiga marcação
                        Mapa.Overlays.Add(Marc[i].OMarcas());//Coloca a nova marcação
                      
                        existe = true;//Existe essa marcação é verdadeiro
                    }
   
                }

                if (existe == false)//Se a marcação não existe
                {
                    Marc[nMarc] = new Marcar();//Cria uma nova marcação
                    Marc[nMarc].NovoNomeMarca(nome);//Define o seu nome
                    Marc[nMarc].ImagemMarca(icone);//Define seu icone
                    Marc[nMarc].mudarCoords(la, lo);//Define a cordenada                    
                    Mapa.Overlays.Add(Marc[nMarc].OMarcas());//Adiciona a nova marcação ao mapa
                    nMarc++;//nMapa auto incrementa.
                }
                
            }

        }
        public static void MapaSatelite()//Muda a visualização do mapa para imagens de satelite
        {
            Mapa.MapProvider = GMapProviders.GoogleHybridMap;//Usa o GoogleHybridMap imagens de satelites
        }
        public static void MapaTerreno()//Usa o mapa com visualização de terreno
        {
            Mapa.MapProvider = GMapProviders.GoogleTerrainMap;// /Muda a visualização do mapa para imagens de terreno
        }
        public static String getMapaPositionLat()//Método usado para receber a latitude da posição do mapa
        {
           return Mapa.Position.Lat.ToString();//Retorna a latitude do mapa
        }
        public static String getMapaPositionLong()//Método usado para receber a longitude da posição do mapa
        {
            return Mapa.Position.Lng.ToString();//Retorna a longitude do mapa
        }
        public static void LimparMapa()//Método usado para limpar as marcações no mapa
        {

            for (int i = 0; i < nMarc; i++)//De 0 até nMarc
            {
                Marc[nMarc] = null;//Esvazia a array
               
            }
            nMarc = 0;//nmarc recebe o valor 0
            Mapa.Overlays.Clear();
        }

        public static void mudarImagem()//Método usado para alterar a imagem dos icones nas marcações do mapa
        {
            for (int i = 0; i < nMarc; i++)//De 0 até nMarc
            {
                if (Marc[i].Imagematual() == "./pa1.png")//Se a imagem for igual esse caminho então:
                {
                  
                    Marc[i].ImagemMarca("./pa2.png");//Recebe uma nova imagem
                    Mapa.Overlays.Remove(Marc[i].OMarcas());//Remove a marcação com a imagem antiga
                    Mapa.Overlays.Add(Marc[i].OMarcas());//adiciona a marcação com a nova imagem

                }
                else
                {
                    if (Marc[i].Imagematual() == "./pa2.png")//Se a imagem for igual esse caminho então:
                    {
                        Marc[i].ImagemMarca("./pa3.png");//Recebe uma nova imagem
                        Mapa.Overlays.Remove(Marc[i].OMarcas());//Remove a marcação com a imagem antiga
                        Mapa.Overlays.Add(Marc[i].OMarcas());//adiciona a marcação com a nova imagem
                    }
                    else
                    {
                        if (Marc[i].Imagematual() == "./pa3.png")//Se a imagem for igual esse caminho então:
                        {
                            Marc[i].ImagemMarca("./pa1.png");//Recebe uma nova imagem
                            Mapa.Overlays.Remove(Marc[i].OMarcas());//Remove a marcação com a imagem antiga
                            Mapa.Overlays.Add(Marc[i].OMarcas());//adiciona a marcação com a nova imagem
                        }
                        else
                        {
                            if (Marc[i].Imagematual() == "./ocorrencia.png")//Se a imagem for igual esse caminho então:
                            {
                                Marc[i].ImagemMarca("./ocorrencia2.png");//Recebe uma nova imagem
                                Mapa.Overlays.Remove(Marc[i].OMarcas());//Remove a marcação com a imagem antiga
                                Mapa.Overlays.Add(Marc[i].OMarcas());//adiciona a marcação com a nova imagem
                            }
                            else
                            {
                                if (Marc[i].Imagematual() == "./ocorrencia2.png")//Se a imagem for igual esse caminho então:
                                {
                                    Marc[i].ImagemMarca("./ocorrencia.png");//Recebe uma nova imagem
                                    Mapa.Overlays.Remove(Marc[i].OMarcas());//Remove a marcação com a imagem antiga
                                    Mapa.Overlays.Add(Marc[i].OMarcas());//adiciona a marcação com a nova imagem
                                }
                            }
                        }
                    }
                }
            }

        }

        public static String ObterCordenadasGPS()//Método usado para obter a latitude e a longitude do gps em cord
        {
            return cord;//Retorna cord
        }



    }
}
