<%@ Page Language="C#" AutoEventWireup="true" CodeFile="canvas.aspx.cs" Inherits="canvas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exemplo de canvas</title>
    <script src="http://code.jquery.com/jquery-1.8.1.js" type="text/javascript"></script>
    <script type="text/Javascript">
        function desenhar() {
            //Canvas
            var canvas = document.getElementById("myCanvas");
            //contexto
            var context = canvas.getContext("2d");
            //limpar o contexto
            context.clearRect(0, 0, canvas.width, canvas.height);
            //Definir fonte e tamanho
            context.font = "18px Arial";
            //Escrever na canvas o texto que foi digitado no input txtNome
            context.fillText(document.getElementById("txtNome").value, 10, 50);
        }
        function salvar() {
            var dados = {};

            //Utilizar o toDataURL para converter em Base64
            var base64 = document.getElementById("myCanvas").toDataURL("image/png");
            //Remover os caracteres que são adionados por padão antes do Base64 da imagem (data:image/png;base64,).
            //Pois só depois disso vem o Base64 que precisamos salvar.
            dados.base64 = base64.substr(base64.indexOf(',') + 1, base64.length);
            //Base64 original:data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAfQAAABQCAYAAADvLIfGAAAH9ElEQVR4nO...
            //Base64 correta:iVBORw0KGgoAAAANSUhEUgAAAfQAAABQCAYAAADvLIfGAAAH9ElEQVR4nO...
            $.ajax({
                type: 'POST',
                //Chamar o webmethod SalvarImagem em webservice.asmx
                url: "webservice.asmx/SalvarImagem",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                //enviar o base64 como parâmetro
                data: JSON.stringify(dados),
                success: function (data) {
                    alert(data.d);
                } 
                , error: function (xmlHttpRequest, status, err) {
                    alert("Ocorreu o seguinte erro:" + xmlHttpRequest.responseText)
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Canvas
        </div>
        <div>
            <canvas id="myCanvas" width="500" height="80" style="border: 1px solid #ddd;"></canvas>
        </div>
        <div><input placeholder="Digite o nome"  style="width:496px" onkeyup="desenhar()" type="text" id="txtNome" /></div>
        <div><input type="button" onclick="salvar()" value="Salvar" /></div>
    </form>
</body>
</html>
