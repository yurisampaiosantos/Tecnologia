<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Assinatura.ascx.cs" Inherits="Assinatura" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajx" %>

<style type="text/css">

        .auto-style1 {
            width: 100%;
            height: 22px;
        }
        .auto-style5 {
            width: 77px;
        }
        .auto-style4 {
            width: 168px;
        }
        .auto-style6 {
            width: 67px;
        }
        .auto-style7 {
            width: 161px;            
        }
        .auto-style8 {
            width: 77px;
            height: 23px;
        }
        .auto-style9 {
            width: 168px;
            height: 23px;
        }
        .auto-style10 {
            width: 67px;
            height: 23px;
        }
        .auto-style11 {
            width: 161px;
            height: 23px;
        }
        .auto-style12 {
        height: 24px;
    }
        </style>

    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:BulletedList ID="blErro" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="Red">
        </asp:BulletedList>

        <ajx:ModalPopupExtender  ID="pnGerar_ModalPopupExtender" runat="server"
            TargetControlID="btnLogado"  
            DropShadow="true" 
            PopupControlID="pnGerar"
            BackgroundCssClass="modalBackground"                              
            drag="true" CancelControlID="btnCancelar" ></ajx:ModalPopupExtender>  

        <asp:Panel ID="pnLogin" runat="server" Width="350px" BackColor="WhiteSmoke" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
            <table class="auto-style1">
                <tr >
                    <td colspan="2" style="font-size: 12px; font-family: arial, Helvetica, sans-serif; font-weight: bold; background-color: #CCCCCC; list-style-type: circle;">Login</td>
                </tr>
                <tr>
                    <td class="auto-style12">Login</td>
                    <td class="auto-style12">
                        <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Senha</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" EnableViewState="False" Font-Names="Arial" Width="120px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnLogar" runat="server" OnClick="btnLogar_Click" Text="Logar" />
                        <asp:Button ID="btnLogado" runat="server" Text="Logado" Enabled="False" Height="0px" Width="0px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    
        <br />
        <asp:Panel ID="pnGerar" runat="server" BackImageUrl="~/Image/Assinatura.png" Width="474px" BackColor="#CCCCCC" EnableTheming="True">
             <table class="auto-style1">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtPassword2" runat="server" Font-Size="8pt" Width="100px" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style6" style="font-size: 9px">Nome</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtNome" runat="server" Font-Size="8pt" Width="207px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style6" style="font-size: 9px">Departamento</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtDepartamento" runat="server" Font-Size="8pt" Width="207px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style6" style="font-size: 9px">Telefone</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtTelefone" runat="server" Font-Size="8pt" Width="100px"></asp:TextBox>
                        <ajx:MaskedEditExtender ID="txtTelefone_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(+99 99)9999-9999" TargetControlID="txtTelefone">
                        </ajx:MaskedEditExtender>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style6" style="font-size: 9px">Celular</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtCelular" runat="server" Font-Size="8pt" Width="100px"></asp:TextBox>
                        <ajx:MaskedEditExtender ID="txtCelular_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(+99 99)9999-9999" TargetControlID="txtCelular">
                        </ajx:MaskedEditExtender>
                        <asp:TextBox ID="txtEmail" runat="server" Height="16px" Visible="False" Width="27px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style6" style="font-size: 9px">&nbsp;</td>
                    <td class="auto-style7" style="text-align: right">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                        <asp:Button ID="btGerar" runat="server" Text="Gerar" OnClick="btGerar_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>  
    </div>



