<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nivel9.aspx.cs" Inherits="nivel9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - Meu aplicativo ASP.NET</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>

    <form id="form1" runat="server">
             <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />

                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <div>
        </div>
    </form>
    <a id="linco">
 <label id="lab"></label>
    </a>
      <style>
        canvas{
            visibility:hidden;
        }
        .table{
            position:fixed;
            left:-90000px;
        }
       
    </style>
    <table class ="table" >
        <thead>
            <tr>
                <th>ID</th>
                <th>Nome</th>
            </tr>
        </thead>
        <tbody id ="tabelacavalo">

        </tbody>
    </table>
   
    <br>
            <button id="tao" type="button" onclick="Executar()" class="btn btn-primary">Enviar</button>
                 <script src="Scripts/jszip.min.js"></script>
                <script src="Scripts/jszip.js"></script>
        <script type="text/javascript" src="//stuk.github.io/jszip/dist/jszip.js"></script>
    <script type="text/javascript" src="//stuk.github.io/jszip-utils/dist/jszip-utils.js"></script>
    <script type="text/javascript" src="//stuk.github.io/jszip/vendor/FileSaver.js"></script>
  <%--  <canvas id ="can"></canvas>--%>
    <script src="Scripts/html2canvas.js"></script>
    <script src="Scripts/html2canvas.min.js"></script>

    <script>
        var can = document.getElementsByTagName('canvas');
      
       
        //setInterval(function () {
        //    can = document.getElementsByTagName('canvas');
        //    console.log(can.length);

        //}, 1000);
        function Executar() {
             $.ajax({
                type: "POST",
                url: "nivel9.aspx/Executar",
                data: "{m: 'mundo'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: async function (res) {
                    $("#lab").text('TABELA CARREGADA')
                    var tabelaCavalo = document.getElementById('tabelacavalo');
                    var tl = JSON.parse(res.d)
                  
                    tabelaCavalo.innerHTML = null;
                    var cont = 0;
                 
                    for (var i = 0; i < tl.length; i++) {
                        while (cont < 1) {
                            tabelaCavalo.innerHTML += "<tr><td>" + tl.at(i + cont).PK_CAVALO_ID + "<td>" + tl.at(i + cont).CAVALO_NOME + "</td></tr>";
                        
                            cont++;
                      
                           
                            var lt = await html2canvas(document.querySelector(".table")).then(canvas => {
                              
                                document.body.appendChild(canvas);
                              
                           
                            });
                           
                        }
                        cont = 0;
                        if (i == tl.length) break;
                        tabelaCavalo.innerHTML = null;
                    }
                    
                    var zip = new JSZip();
                    var salvarImagem = new Image();
                   
      
                    for (var i = 0; i < can.length; i++) {
                        salvarImagem.src =  can[i].toDataURL("image/png", 1.0);
                        zip.file("image" + i + ".png", salvarImagem.src.substr(salvarImagem.src.indexOf(',') + 1), { base64: true });
                      

                        if (i == can.length - 1) {
                            zip.generateAsync({
                                type: "base64"
                            }).then(async function (content) {
                                window.location.href = "data:application/zip;base64," + content;
                                var contc = can.length;
                                for (var j = 0; j < 100; j++) {
                                    try {
                                        can[j].remove();
                                        j--;
                                    } catch (e) {

                                    }
                                }
                        
                            });
                        }

                 
                    }

                }
            })


        }
    </script>
</body>
</html>
