$(document).ready(function(){

    /* Generation
    *
    ---------------------------------------- */

    var code, codec, name, unidade;


    $('.options #unidade').change(function(code){
        
        unidade    = $('#unidade').val();

        if (unidade == 1){
                endereco = '<font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Rua A, Fazenda Boa Vista do Gurjão e Dendê, Anexo 2 <br /> Enseada do Paraguaçu Maragojipe – BA | CEP: 44420-000 <br /> www.enseada.com';
            /*}else if(unidade == 2){
                endereco = '<font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Rua Santa Cruz - Quadra 19 - Lote 01 <br /> Distrito São Roque do Paraguaçu | Maragojipe – BA | CEP: 44428-000 <br /> www.enseada.com';
            }else if(unidade == 3){
                endereco = '<font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Rua General Gurjão <br /> Caju | Rio de Janeiro - RJ | CEP: 20931-900 <br /> www.enseada.com';*/
            }else if(unidade == 4){
                endereco = '<font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Av. Luís Viana Filho nº 2.841, Edf. Odebrecht, 1º Andar <br /> Paralela | Salvador – Bahia | CEP: 41730-900 <br /> www.enseada.com';
            }else if(unidade == 5){
                endereco = '<font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Av. Cidade de Lima, n° 86, 7° andar <br /> Santo Cristo | Rio de Janeiro – RJ | CEP : 20220-710 <br /> www.enseada.com';
            };

            //Modifica o Texto
            $('p.vcard-info').html(endereco);
            
    });

    $('.options').keyup(function(code){

        name = $('#txtNome').val();

        //var cname   = name.toLowerCase().replace(/ /g, ''),
            imagem  = $('#1_imagem').val(),
            area = $('#txtArea').val(),
            email = $('#txtEmail').val(),
            telefone = $('#txtTelefone').val(),
            celular = $('#txtCelular').val(),
            voip = $('#txtVoip').val(),
            desc    = $('#1_desc').val(),
            unidade    = $('#unidade').val();
            skin    = $('#skin').val();

            if (unidade == 1){
                endereco = '<p class="vcard-info"><font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Rua A, Fazenda Boa Vista do Gurjão e Dendê, Anexo 2 <br /> Enseada do Paraguaçu Maragojipe – BA | CEP: 44420-000 <br /> www.enseada.com </p>';
            /*}else if(unidade == 2){
                endereco = '<p class="vcard-info"><font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Rua Santa Cruz - Quadra 19 - Lote 01 <br /> Distrito São Roque do Paraguaçu | Maragojipe – BA | CEP: 44428-000 <br /> www.enseada.com </p>';
            }else if(unidade == 3){
                endereco = '<p class="vcard-info"><font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Rua General Gurjão <br /> Caju | Rio de Janeiro - RJ | CEP: 20931-900 <br /> www.enseada.com </p>';*/
            }else if(unidade == 4){
                endereco = '<p class="vcard-info"><font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Av. Luís Viana Filho nº 2.841, Edf. Odebrecht, 1º Andar <br /> Paralela | Salvador – Bahia | CEP: 41730-900 <br /> www.enseada.com </p>';
            }else if(unidade == 5){
                endereco = '<p class="vcard-info"><font color="fc0000"><b>Enseada Indústria Naval S.A.</b></font> <br /> Av. Cidade de Lima, n° 86, 7° andar <br /> Santo Cristo | Rio de Janeiro – RJ | CEP : 20220-710 <br /> www.enseada.com </p>';
            };


            if (code.length > 0) { code = code + '<div class="vcard ' + skin + '" ><div class="vcard-hold"></div><div class="vcard-container" id="assinatura"><div class="vcard-head">'; } else { code = '<div class="vcard ' + skin + '" ><div class="vcard-hold"></div><div class="vcard-container"><div class="vcard-head">'; };
        code = code+'</div><div class="vcard-content" id="assinatura" >' +
                        '<img src="arquivos/barratopo.png"/>'+
                        '<div class="vcard-info"><h4>'+name+'</h4>'+
                        '<p class="vcard-profession">'+area+'</p>'+
                        '<p class="vcard-email">'+email+'</p>'+
                        //'<div style="clear:both"></div>'+
                        //'<div style="clear:both"></div><br />' +
                        '<br />' +
                        //'<img src="'+imagem+'" alt="" class="vcard-avatar">'+
                        '<img src="arquivos/enseada.png" alt="" class="vcard-avatar">'+
                        '<ul class="vcard-list">'+
                            '<li><span class="vcard-ind"><img src="arquivos/icone-tel.png"></span>'+telefone+'</li>'+
                            '<li><span class="vcard-ind"><img src="arquivos/icone-cel.png"></span>'+celular+'</li>'+
                            '<li><span class="vcard-ind"><img src="arquivos/icone-voip.png"></span>'+voip+'</li>';        
        code = code+'</ul>';
        code = code+endereco;
        code = code+'<img src="arquivos/barrafim.png"/> </div></div></div></div>';

        $('#code').html(code);

        codec = code.replace(/</g, '&lt;').replace(/>/g, '&gt;');

        // Outras coisas

        $('.tip').hide();
        $('.tip-parent').hover(function(){
            var tip = $(this).children('.tip'),
                width = tip.width(),
                height = tip.outerHeight(),
                pwidth = $(this).width();
            tip.css({
                top: -height-5,
                left: pwidth/2-width/2
            });
            tip.fadeToggle(200);
        });
    });




})