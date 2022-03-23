<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
<!DOCTYPE HTML>
<html><head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta charset="UTF-8">
	<title>Gerador de Assinaturas</title>
   <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	
	<!-- Inclui jQuery do google.com -->
	<script type="text/javascript" src="arquivos/jquery.min.js"></script>

	<!-- Inlcui o Javascript -->
	<script type="text/javascript" src="arquivos/gerador.js"></script>
	<script type="text/javascript" src="arquivos/introjs/intro.min.js"></script>
    <script type="text/javascript" src="arquivos/canvas2image.js"></script>
    <script type="text/javascript" src="arquivos/base64.js"></script>

	
	<!-- Inclui o CSS -->
	<link rel="stylesheet" type="text/css" href="arquivos/style.css">
	<link rel="stylesheet" type="text/css" href="arquivos/introjs/introjs.min.css">

	<!-- PARA GERAR A IMAGEM -->
	<script src="arquivos/htmlcanvas.js"></script>
	<script type="text/javascript">

	    function loader() {


	        name = $('#txtNome').val();

	        //var cname   = name.toLowerCase().replace(/ /g, ''),
	        imagem = $('#1_imagem').val(),
            area = $('#txtArea').val(),
            email = $('#txtEmail').val(),
            telefone = $('#txtTelefone').val(),
            celular = $('#txtCelular').val(),
            voip = $('#txtVoip').val(),
            desc = $('#1_desc').val(),
            unidade = $('#unidade').val();
	        skin = $('#skin').val();

	        if (unidade == 1) {
	            endereco = '<p class="vcard-info"><font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Rua A, Fazenda Boa Vista do Gurjão e Dendê, Anexo 2 <br /> Enseada do Paraguaçu Maragojipe – BA | CEP: 44420-000 <br /> www.enseada.com </p>';
	        /*} else if (unidade == 2) {
	            endereco = '<p class="vcard-info"><font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Rua Santa Cruz - Quadra 19 - Lote 01 <br /> Distrito São Roque do Paraguaçu | Maragojipe – BA | CEP: 44428-000 <br /> www.enseada.com </p>';
	        } else if (unidade == 3) {
	            endereco = '<p class="vcard-info"><font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Rua General Gurjão <br /> Caju | Rio de Janeiro - RJ | CEP: 20931-900 <br /> www.enseada.com </p>';*/
	        } else if (unidade == 4) {
	            endereco = '<p class="vcard-info"><font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Av. Luís Viana Filho nº 2.841, Edf. Odebrecht, 1º Andar <br /> Paralela | Salvador – Bahia | CEP: 41730-900 <br /> www.enseada.com </p>';
	        } else if (unidade == 5) {
	            endereco = '<p class="vcard-info"><font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Av. Cidade de Lima, n° 86, 7° andar <br /> Santo Cristo | Rio de Janeiro – RJ | CEP : 20220-710 <br /> www.enseada.com </p>';
	        };


	        if (code.length > 0) { code = code + '<div class="vcard ' + skin + '" ><div class="vcard-hold"></div><div class="vcard-container" id="assinatura"><div class="vcard-head">'; } else { code = '<div class="vcard ' + skin + '" ><div class="vcard-hold"></div><div class="vcard-container"><div class="vcard-head">'; };
	        code = code + '</div><div class="vcard-content" id="assinatura" >' +
                            '<img src="arquivos/barratopo.png"/>' +
                            '<div class="vcard-info"><h4>' + name + '</h4>' +
                            '<p class="vcard-profession">' + area + '</p>' +
                            '<p class="vcard-email">' + email + '</p>' +
                            //'<div style="clear:both"></div>' +
                            //'<div style="clear:both"></div><br />' +
                            '<br />' +
                            //'<img src="'+imagem+'" alt="" class="vcard-avatar">'+
                            '<img src="arquivos/enseada.png" alt="" class="vcard-avatar">' +
                            '<ul class="vcard-list">' +
                                '<li><span class="vcard-ind"><img src="arquivos/icone-tel.png"></span>' + telefone + '</li>' +
                                '<li><span class="vcard-ind"><img src="arquivos/icone-cel.png"></span>' + celular + '</li>' +
                                '<li><span class="vcard-ind"><img src="arquivos/icone-voip.png"></span>' + voip + '</li>';
	        code = code + '</ul>';
	        code = code + endereco;
	        code = code + '<img src="arquivos/barrafim.png"/> </div></div></div></div>';

	        $('#code').html(code);

	        codec = code.replace(/</g, '&lt;').replace(/>/g, '&gt;');

	        // Outras coisas

	        $('.tip').hide();
	        $('.tip-parent').hover(function () {
	            var tip = $(this).children('.tip'),
                    width = tip.width(),
                    height = tip.outerHeight(),
                    pwidth = $(this).width();
	            tip.css({
	                top: -height - 5,
	                left: pwidth / 2 - width / 2
	            });
	            tip.fadeToggle(200);
	        });
	    }

	    function geraImagem() {

	        html2canvas([document.getElementById('assinatura')], {
	            allowTaint: true,
	            logging: true,
	            taintTest: false,
	            onrendered: function (canvas) {
	                document.getElementById('canvas').appendChild(canvas);
	                var base64 = canvas.toDataURL("image/png",10.0);

	                var dados = {};
	                dados.base64 = base64.substr(base64.indexOf(',') + 1, base64.length);
	                $.ajax({
	                    type: 'POST',
	                    //Chamar o webmethod SalvarImagem em webservice.asmx
	                    url: "webservice.asmx/SalvarImagem",
	                    contentType: 'application/json; charset=utf-8',
	                    dataType: 'json',
	                    //enviar o base64 como parâmetro
	                    data: JSON.stringify(dados),
	                    success: function (data) {
	                      
	                    }
                        , error: function (xmlHttpRequest, status, err) {
                          
                        }
	                });	               

	            }
	        });
	    }
	    
	    //Máscara
	    function formataCampo(campo, Mascara, evento) {
	        var boleanoMascara;

	        var Digitato = evento.keyCode;
	        exp = /\-|\.|\/|\(|\)|\+| /g
	        campoSoNumeros = campo.value.toString().replace(exp, "");

	        var posicaoCampo = 0;
	        var NovoValorCampo = "";
	        var TamanhoMascara = campoSoNumeros.length;;

	        if (Digitato != 8) { // backspace 
	            for (i = 0; i <= TamanhoMascara; i++) {
	                boleanoMascara = ((Mascara.charAt(i) == "-") || (Mascara.charAt(i) == ".")
                        || (Mascara.charAt(i) == "/"))
	                boleanoMascara = boleanoMascara || ((Mascara.charAt(i) == "(") || (Mascara.charAt(i) == "+")
                        || (Mascara.charAt(i) == ")") || (Mascara.charAt(i) == " "))
	                if (boleanoMascara) {
	                    NovoValorCampo += Mascara.charAt(i);
	                    TamanhoMascara++;
	                } else {
	                    NovoValorCampo += campoSoNumeros.charAt(posicaoCampo);
	                    posicaoCampo++;
	                }
	            }
	            campo.value = NovoValorCampo;
	            return true;
	        } else {
	            return true;
	        }
	    }

	    //valida numero inteiro com mascara
	    function mascaraInteiro() {
	        if (event.keyCode < 48 || event.keyCode > 57) {
	            event.returnValue = false;
	            return false;
	        }
	        return true;
	    }

	    //adiciona mascara ao telefone
	    function MascaraTelefone(tel) {
	        if (mascaraInteiro(tel) == false) {
	            event.returnValue = false;
	        }
	        if (tel.value.length == 15)
	            return formataCampo(tel, '+00 00 0000-00000', event);
	        else
	            return formataCampo(tel, '+00 00 00000-00000', event);
	    }

	    function MascaraVoip(tel) {
	        if (mascaraInteiro(tel) == false) {
	            event.returnValue = false;
	        }
	        return formataCampo(tel, '0000 00000', event);
	    }

	</script>

	    <script type="text/javascript">
	        function startIntro() {
	            var intro = introJs();
	            intro.setOptions({
	                steps: [
                      {
                          element: '#painel',
                          intro: "Para gerar sua assinatura preencha os campos ao lado.",
                          position: 'right'
                      },
                      {
                          element: '#Download',
                          intro: "Após digitar os dados, clique neste botão para gerar sua assinatura.",
                          position: 'bottom'
                      }
	                ]
	            });

	            intro.start();

	        }
    </script>

</head>
<body onload="loader()">

	<div class="container">

		<div class="header">
			<!--<img src="arquivos/icon-support.png" alt="Email">-->
			<a href="#">
				<span style="color: white; font-size: 15px;">Gerador de Assinaturas - Enseada</span>
			</a>
			<!--<a href="#" onclick="startIntro();">
				<span style="color: white; font-size: 15px;"> | Como usar?</span>
			</a>-->
            
            <a href="http://wdciis03/VisualizarAnexo/Manual_Sistema/Assinatura_Eletronica.pdf" TARGET = "_blank">
				<span style="color: white; font-size: 15px;">
                    <img alt="" src="arquivos/Help.png" style="height: 20px; width: 20px; margin-left: 5px;" /></span>
			</a>
		</div>

		<div class="content clearfix">

			<span id="code"></span>

			<div class="options" id="painel">           
				<form id="form1" runat="server" name="form1">
				<label>Unidade</label>
				<select id="unidade">
					<option value="1">Paraguaçu</option>
					<!--<option value="2">São Roque</option>
					<option value="3">Inhaúma</option>-->
					<option value="4">Escritório SSA</option>
					<option value="5">Escritório RJ</option>
				</select>
				<!-- <input type="text" placeholder="Imagem" id="1_imagem" class="inp"> -->     

				<label>Nome</label>
                    <asp:TextBox  runat="server" placeholder="Nome" ID="txtNome" class="inp"></asp:TextBox>               
                <table >
                    <tr>
                        <td>
                            <label>Área</label>
                        </td>
                        <td style="padding-left: 20px; font-size: 12px;">
                            <asp:LinkButton ID="lbIdioma" runat="server" OnClick="idioma_Onclick" Visible="False">English</asp:LinkButton>
                        </td>                            
                    </tr>
                </table>

                    <asp:TextBox  runat="server" placeholder="Área" class="inp" ID="txtArea" Enabled="False"></asp:TextBox>							
				<label>Email</label>
                    <asp:TextBox  runat="server" placeholder="Email" class="inp" ID="txtEmail" Enabled="False"></asp:TextBox>
				
				<label>Telefone</label>
                   <!-- <asp:TextBox  runat="server" placeholder="Telefone" class="inp" ID="txtTelefone" ></asp:TextBox>-->
                    <input type="text"  id="txtTelefone" name="tel" class="inp" onKeyPress="MascaraTelefone(form1.tel);">				
				<label>Celular</label>
                    <!--<asp:TextBox  runat="server" placeholder="Celular" class="inp" ID="txtCelular" name="cel"  onKeyPress="MascaraTelefone(form1.cel);"></asp:TextBox>-->
				<input type="text"  id="txtCelular" name="cel" class="inp" onKeyPress="MascaraTelefone(form1.cel);">
				<label>Voip</label>
                    <!--<asp:TextBox  runat="server" placeholder="VoiP" class="inp" ID="txtVoip"></asp:TextBox>-->
				    <input type="text"  id="txtVoip" class="inp" name="voip" onKeyPress="MascaraVoip(form1.voip);">
                    <asp:Button ID="Download" runat="server"  onclientclick="geraImagem();"  CssClass="button" Text="Gerar&nbsp;Assinatura" OnClick="Download_Click" Font-Size="15px" ></asp:Button>
           
				</form>
			</div>
		</div>
	</div>

	<div id="canvas" style="display:none">
		<p>Salvar imagem</p>
	</div></>
</body>
</html>
