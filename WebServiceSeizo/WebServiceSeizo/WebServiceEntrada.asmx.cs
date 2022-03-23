using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System.IO;

namespace WebServiceSeizo
{
    /// <summary>
    /// Summary description for WebServiceEntrada
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceEntrada : System.Web.Services.WebService
    {

        [WebMethod]
        public string ImportarOP(decimal anexoId) 
        {
            string diretorioPlanilha = ExtrairAnexo(anexoId);
            if (diretorioPlanilha != "")
            {
                ExcelPackage ep = new ExcelPackage(new FileInfo(diretorioPlanilha));
                ExcelWorksheet wsOrdemProducao = ep.Workbook.Worksheets["Dados básicos"];
                ExcelWorksheet wsAtributo = ep.Workbook.Worksheets["Atributos"];
                ExcelWorksheet wsItem = ep.Workbook.Worksheets["Itens"];

                if (wsOrdemProducao.Dimension.End.Row != 0)
                {
                    InserirOrdemProducao(wsOrdemProducao, anexoId);
                }
                if (wsAtributo.Dimension.End.Row != 0)
                {
                    InserirAtributo(wsAtributo, anexoId);
                }
                if (wsItem.Dimension.End.Row != 0)
                {
                    InserirItem(wsItem, anexoId);
                }
            }
            return "Importado";
        }
        private void InserirOrdemProducao(ExcelWorksheet oSheet, decimal anexoId)
        {

            for (int i = 2; i <= oSheet.Dimension.End.Row; i++)
            {
                OrdemProducao ordemProducao = new OrdemProducao();

                ordemProducao.Importacao_id = anexoId;
                if (oSheet.Cells[i, 1].Value != null)
                    ordemProducao.Numero_Op_Id = oSheet.Cells[i, 1].Value.ToString();               
                if (oSheet.Cells[i, 2].Value != null)
                    ordemProducao.Op_Tipos_Id = oSheet.Cells[i, 2].Value.ToString();
                if (oSheet.Cells[i, 3].Value != null)
                    ordemProducao.Revisao = oSheet.Cells[i, 3].Value.ToString();
                if (oSheet.Cells[i, 4].Value != null)
                    ordemProducao.Descricao_Op = oSheet.Cells[i, 4].Value.ToString();
                if (oSheet.Cells[i, 5].Value != null)
                    ordemProducao.Qtd_Prevista = oSheet.Cells[i, 6].Value.ToString();
                if (oSheet.Cells[i, 6].Value != null)
                    ordemProducao.Qtd_Real = oSheet.Cells[i, 6].Value.ToString();
                if (oSheet.Cells[i, 7].Value != null)
                    ordemProducao.Un_Medida = oSheet.Cells[i, 7].Value.ToString();
                if (oSheet.Cells[i, 8].Value != null)
                    ordemProducao.Status = oSheet.Cells[i, 8].Value.ToString();
                if (oSheet.Cells[i, 9].Value != null)
                    ordemProducao.Observacao = oSheet.Cells[i, 9].Value.ToString();
                if (oSheet.Cells[i, 10].Value != null)
                    ordemProducao.Nome_Semiacabado = oSheet.Cells[i, 10].Value.ToString();

                ordemProducao.InserirDados(ordemProducao);
            }
        }
        private void InserirAtributo(ExcelWorksheet oSheet, decimal anexoId)
        {

            for (int i = 2; i <= oSheet.Dimension.End.Row; i++)
            {
                Atributo atributo = new Atributo();

                atributo.Importacao_id = anexoId;
                if (oSheet.Cells[i, 1].Value != null)
                    atributo.Numero_Op_Id = oSheet.Cells[i, 1].Value.ToString();
                if (oSheet.Cells[i, 2].Value != null)
                    atributo.ValorAtributo = oSheet.Cells[i, 2].Value.ToString();
                if (oSheet.Cells[i, 3].Value != null)
                    atributo.Valor = oSheet.Cells[i, 3].Value.ToString();

                atributo.InserirDados(atributo);
            }
        }
        private void InserirItem(ExcelWorksheet oSheet, decimal anexoId)
        {

            for (int i = 2; i <= oSheet.Dimension.End.Row; i++)
            {
                Item item = new Item();

                item.Importacao_id = anexoId;
                if (oSheet.Cells[i, 1].Value != null)
                    item.Numero_Op_Id = oSheet.Cells[i, 1].Value.ToString();
                if (oSheet.Cells[i, 2].Value != null)
                    item.Sap_Material = oSheet.Cells[i, 2].Value.ToString();
                if (oSheet.Cells[i, 3].Value != null)
                    item.Qtd_Projeto = oSheet.Cells[i, 3].Value.ToString();
                if (oSheet.Cells[i, 4].Value != null)
                    item.Qtd_Corrida = oSheet.Cells[i, 4].Value.ToString();
                if (oSheet.Cells[i, 5].Value != null)
                    item.Qtd_Reservada = oSheet.Cells[i, 5].Value.ToString();
                if (oSheet.Cells[i, 6].Value != null)
                    item.Qtd_Aplicada = oSheet.Cells[i, 6].Value.ToString();

                item.InserirDados(item);
            }
        }
        private string ExtrairAnexo(decimal anexoId)
        {
            Conexao anexo = new Conexao();
            anexo.SelecionarAnexo(anexoId);
            string diretorio = "";
            if (anexo.Anexo != null)
            {
                try
                {
                    DirectoryInfo infoDir = new DirectoryInfo(Server.MapPath("") + "\\Anexos");
                    if (!infoDir.Exists)
                    {
                        infoDir.Create();
                    }                    
                    try
                    {
                        diretorio = infoDir + "\\" + anexoId + System.IO.Path.GetExtension(anexo.NomeArquivo);
                        using (FileStream fs = new FileStream
                        (diretorio, FileMode.CreateNew, FileAccess.Write))
                        {
                            fs.Write(anexo.Anexo, 0, anexo.Anexo.Length);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return diretorio;
        }
    }
}
