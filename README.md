<img src="/img/logo.jpg" alt="Youtube" width="100%" height="400" />
<p><strong>Autor: Jeferson Oliveira</strong></p>
<p><strong><a href="https://www.linkedin.com/in/jeferson-oliveira-8335051b6/"><img style="border-style: none;" src="https://www.transparentpng.com/thumb/linkedin/linkedin-icon-png-4.png" alt="Linkedin" width="50" height="50" /></a></strong></p>
<p><strong>Linkedin</strong></p>
<p><strong><a href="https://www.youtube.com/channel/UCz-iNlr68eMM1N5vcsBSJrw"><img src="https://portal.ifba.edu.br/irece/institucional/documentos-institucionais/ascom_ifba_irece/imagens/youtube-icon-14.png" alt="Youtube" width="50" height="50" /></a></strong></p>
<p><strong>YouTube</strong></p>
<p><strong>E-mail: <a href="mailto:contact.jeferson.oliveira@gmail.com">contact.jeferson.oliveira@gmail.com</a></strong></p>
<p>&nbsp;</p>
<h1>Meu projeto de comunica&ccedil;&atilde;o de rede em C#</h1>
<p>Esse projeto foi usado como trabalho acad&ecirc;mico na UNIP, &eacute; um exemplo de comunica&ccedil;&atilde;o de rede via soquete.</p>
<p>&nbsp;</p>
<h2>Instru&ccedil;&otilde;es de uso do software</h2>
<p><strong>O software do cliente</strong> abrir o software do cliente o usu&aacute;rio vai ver <strong>a tela de Login.</strong></p>
<p>Figura 1 Tela de login</p>
<p><strong>A tela de login</strong> possui dois campos de texto um bot&atilde;o e uma label</p>
<p>Para antes de logar o usu&aacute;rio deve criar uma conta clicando em criar conta. Ap&oacute;s criar a conta ele pode colocar o nome que ele criou e a senha para logar no sistema.</p>
<p><strong>A tela de criar contas.</strong></p>
<p>Ao clicar em criar conta na tela de login o usu&aacute;rio vai abrir essa tela onde ele pode escolher uma imagem para usar em seu perfil, ele tamb&eacute;m pode escolher um nome que n&atilde;o tenha espa&ccedil;os ou virgulas, e uma senha <strong>&ldquo;&Eacute; importante repetir a mesma senha em repetir senha&rdquo;</strong>, ap&oacute;s isso clicando em confirmar a sua conta ser&aacute; criada e salva no banco de dados, ele ser&aacute; redirecionado a tela de login onde deve logar. Para entrar na tela home. Clicando em Voltar o usu&aacute;rio vai retornar para login.</p>
<p><strong>A tela home.</strong></p>
<p>A tela home vai exibir a imagem que o jogador escolheu, tamb&eacute;m tem um campo de players online ao clicar em um jogar online surgir&aacute; um menu sugerindo se o usu&aacute;rio quer desafiar aquele jogador em uma batalha no jogo da velha o jogador que foi desafiado receber&aacute; um convite onde ele pode aceitar ou recusa a batalha se ele estiver uma batalha o convite n&atilde;o aparecer&aacute; para ele, se ele aceitar ser&atilde;o redirecionados para <strong>a tela do jogo da velha</strong>.&nbsp; O rank top 5 vai exibir 5 jogadores que mais pontuou no jogo. O chat pode ser usado para quem estiver online poder trocar mensagens.</p>
<p><strong>A tela do jogo da velha.</strong></p>
<p>Quando um convite de batalha &eacute; aceito o usu&aacute;rio ser&aacute; redirecionado para essa tela onde ele poder&aacute; jogar o jogo da velha com o advers&aacute;rio. Ele ter&aacute; acesso ao chat da batalha e ao chat, o usu&aacute;rio deve esperar sua vez de jogar para poder clickar em um bot&atilde;o do tabuleiro. Sua cor por padr&atilde;o ser&aacute; verde e a cor do advers&aacute;rio vermelho. Quando o jogo termina em derrota, empate, ou vit&oacute;ria aparecer&aacute; o bot&atilde;o de voltar ao in&iacute;cio e desafiar novamente.</p>
<p><strong>A tela de ocorr&ecirc;ncia.</strong></p>
<p>Na tela de ocorr&ecirc;ncia o usu&aacute;rio poder&aacute; criar uma ocorr&ecirc;ncia no mapa de ocorr&ecirc;ncias, o mapa tamb&eacute;m exibe a localiza&ccedil;&atilde;o de todos os usu&aacute;rios que est&atilde;o online com o &iacute;cone de viatura da pol&iacute;cia ambiental.</p>
<p>Para criar uma ocorr&ecirc;ncia o usu&aacute;rio deve colocar o tipo de ocorr&ecirc;ncia que &eacute; o tipo de crime e tamb&eacute;m a descri&ccedil;&atilde;o l&aacute; no mapa o usu&aacute;rio deve apontar com a mira de cruz onde &eacute; essa ocorr&ecirc;ncia para obter a localiza&ccedil;&atilde;o, basta apontar ao local e a localiza&ccedil;&atilde;o ser&aacute; obtida de forma autom&aacute;tica.</p>
<p>Com todas as informa&ccedil;&otilde;es inseridas o usu&aacute;rio j&aacute; pode criar uma ocorr&ecirc;ncia clicando em gerar ocorr&ecirc;ncia, a ocorr&ecirc;ncia ser&aacute; salva no banco de dados com informa&ccedil;&otilde;es de latitude, longitude, descri&ccedil;&atilde;o e tipo de ocorr&ecirc;ncia, ap&oacute;s isso o software vai enviar via soquete essas informa&ccedil;&otilde;es para o servidor soquete que vai enviar a todos usu&aacute;rios online e ser&aacute; exibida como uma notifica&ccedil;&atilde;o do Windows.</p>
<p>As posi&ccedil;&otilde;es dos usu&aacute;rios online ser&atilde;o atualizadas a cada 3 segundos via soquete, o software do cliente vai ficar enviando essas informa&ccedil;&otilde;es ao servidor soquete no tipo texto usando a camada tcp, os usu&aacute;rios v&atilde;o receber essas informa&ccedil;&otilde;es e de acordo com a latitude e longitude recebido ser&aacute; desenhado no mapa um &iacute;cone de viatura da pol&iacute;cia indicando o local.</p>
<p>A tabela de ocorr&ecirc;ncias em andamento, essa tabela tem todas as informa&ccedil;&otilde;es da ocorr&ecirc;ncia e clicando em uma ocorr&ecirc;ncia na tabela o mapa vai automaticamente exibir o local da ocorr&ecirc;ncia com o zoom ampliado dessa forma:</p>
