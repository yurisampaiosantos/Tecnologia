namespace OutlookGeradorAssinatura
{
    partial class RibbonAssinatura : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonAssinatura()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl2 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl3 = this.Factory.CreateRibbonDropDownItem();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.geradorBotao = this.Factory.CreateRibbonGroup();
            this.btGerarAssinatura = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.editNome = this.Factory.CreateRibbonEditBox();
            this.editArea = this.Factory.CreateRibbonEditBox();
            this.editAreaIngles = this.Factory.CreateRibbonEditBox();
            this.cbEscritorio = this.Factory.CreateRibbonComboBox();
            this.geradorAssinatura = this.Factory.CreateRibbonGroup();
            this.editTelefone = this.Factory.CreateRibbonEditBox();
            this.editCelular = this.Factory.CreateRibbonEditBox();
            this.editVOIP = this.Factory.CreateRibbonEditBox();
            this.tab1.SuspendLayout();
            this.geradorBotao.SuspendLayout();
            this.group1.SuspendLayout();
            this.geradorAssinatura.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.geradorBotao);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.geradorAssinatura);
            this.tab1.Label = "Assinatura";
            this.tab1.Name = "tab1";
            // 
            // geradorBotao
            // 
            this.geradorBotao.Items.Add(this.btGerarAssinatura);
            this.geradorBotao.Name = "geradorBotao";
            // 
            // btGerarAssinatura
            // 
            this.btGerarAssinatura.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btGerarAssinatura.Image = global::OutlookGeradorAssinatura.Properties.Resources.icon_procuracoes;
            this.btGerarAssinatura.Label = "Gerar Assinatura";
            this.btGerarAssinatura.Name = "btGerarAssinatura";
            this.btGerarAssinatura.ShowImage = true;
            this.btGerarAssinatura.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btGerarAssinatura_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.editNome);
            this.group1.Items.Add(this.editArea);
            this.group1.Items.Add(this.editAreaIngles);
            this.group1.Items.Add(this.cbEscritorio);
            this.group1.Label = "Dados";
            this.group1.Name = "group1";
            // 
            // editNome
            // 
            this.editNome.Label = "Nome";
            this.editNome.Name = "editNome";
            this.editNome.SizeString = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.editNome.Text = null;
            // 
            // editArea
            // 
            this.editArea.Label = "Área";
            this.editArea.Name = "editArea";
            this.editArea.SizeString = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.editArea.Text = null;
            // 
            // editAreaIngles
            // 
            this.editAreaIngles.Label = "Área Ingles";
            this.editAreaIngles.Name = "editAreaIngles";
            this.editAreaIngles.SizeString = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.editAreaIngles.Text = null;
            // 
            // cbEscritorio
            // 
            ribbonDropDownItemImpl1.Label = "Escritório Bahia";
            ribbonDropDownItemImpl2.Label = "Escritório Rio de Janeiro";
            ribbonDropDownItemImpl3.Label = "Estaleiro Paraguaçu";
            this.cbEscritorio.Items.Add(ribbonDropDownItemImpl1);
            this.cbEscritorio.Items.Add(ribbonDropDownItemImpl2);
            this.cbEscritorio.Items.Add(ribbonDropDownItemImpl3);
            this.cbEscritorio.Label = "Escritório";
            this.cbEscritorio.Name = "cbEscritorio";
            this.cbEscritorio.SizeString = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.cbEscritorio.Text = "Escritório Bahia";
            // 
            // geradorAssinatura
            // 
            this.geradorAssinatura.Items.Add(this.editTelefone);
            this.geradorAssinatura.Items.Add(this.editCelular);
            this.geradorAssinatura.Items.Add(this.editVOIP);
            this.geradorAssinatura.Label = "Contato";
            this.geradorAssinatura.Name = "geradorAssinatura";
            // 
            // editTelefone
            // 
            this.editTelefone.Label = "Telefone";
            this.editTelefone.Name = "editTelefone";
            this.editTelefone.SizeString = "+xx xxxxx xxxx-xxxxxxx";
            this.editTelefone.Text = null;
            this.editTelefone.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.editTelefone_TextChanged);
            // 
            // editCelular
            // 
            this.editCelular.Label = "Celular";
            this.editCelular.Name = "editCelular";
            this.editCelular.SizeString = "+xx xxxxx xxxx-xxxxxxx";
            this.editCelular.Text = null;
            this.editCelular.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.editCelular_TextChanged);
            // 
            // editVOIP
            // 
            this.editVOIP.Label = "VOIP";
            this.editVOIP.Name = "editVOIP";
            this.editVOIP.SizeString = "xxxxxxxxxxxx";
            this.editVOIP.Text = null;
            this.editVOIP.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.editVOIP_TextChanged);
            // 
            // RibbonAssinatura
            // 
            this.Name = "RibbonAssinatura";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.geradorBotao.ResumeLayout(false);
            this.geradorBotao.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.geradorAssinatura.ResumeLayout(false);
            this.geradorAssinatura.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup geradorAssinatura;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editTelefone;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editCelular;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editVOIP;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btGerarAssinatura;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup geradorBotao;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editNome;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editArea;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox cbEscritorio;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editAreaIngles;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonAssinatura Ribbon1
        {
            get { return this.GetRibbon<RibbonAssinatura>(); }
        }
    }
}
