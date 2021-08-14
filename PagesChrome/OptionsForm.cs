using PagesChrome.DAL;
using System;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PagesChrome.Classe;
using System.Data;
using System.Threading;
using System.Runtime.InteropServices;
using System.Linq;

namespace PagesChrome
{
    public partial class OptionsForm : Form
    {
        #region variaveis Globais (acesso ao DataBase e Classe)
        //Acesso aos Metodos que retorna dados do DataBase
        Configuration DB = new Configuration();
        //instanciando objeto
        Usuario objUsuario = new Usuario();
        #endregion

        #region inicializando Componentes
        public OptionsForm()
        {
            InitializeComponent();

        }
        #endregion

        #region Metodo para Bloqueio do Teclado e Mouse
        [DllImport("user32.dll")]
        public static extern void BlockInput(bool fBlockIt);
        #endregion

        #region variavel Temporizador

        System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();

        #endregion

        #region instanciando Formulario Blocked e Unlocked
        Blocked AlertON = new Blocked();

        Unlocked AlertOFF = new Unlocked();
        #endregion

        #region Acessando Facebook
        private void btnFacebook_Click(object sender, EventArgs e)
        {
            //ocultar Formulario Atual
            this.Hide();

            DataSet ds = new DataSet();

            IWebElement txtUser;
            IWebElement txtSenha;
            IWebElement txtBotao;

            /*
            Codigo 1 -> facebook
            Codigo 2 -> hotmail
            Codigo 3 -> gmail
            */

            //capturando dados do banco
            ds = DB.getDados(1);

            //populando classe Usuario
            objUsuario.Url = ds.Tables[0].Rows[0]["PagesUrl"].ToString();
            objUsuario.Login = ds.Tables[0].Rows[0]["LoginUser"].ToString();
            objUsuario.Senha = ds.Tables[0].Rows[0]["LoginSenha"].ToString();

            /*
             Necessário baixar Chromedrive no site 'https://chromedriver.chromium.org/downloads'
             OBS: Verifique a versão do seu navegador para baixar uma versão do chromedriver compativel
            */
            try {

                //caminho do chromedrive
                String path = Properties.Settings.Default.ChromeDrive.ToString();
                
                //configurando chromedrive (ocultar console do chrome drive)
                ChromeDriverService driverService = ChromeDriverService.CreateDefaultService(path);
                driverService.HideCommandPromptWindow = true;

                //instanciando chromedrive
                IWebDriver chrome;
                chrome = new ChromeDriver(driverService);

                //configurando para navegador abrir maximizado
                chrome.Manage().Window.Maximize();

                //setando url do site que deve abrir o navegador
                chrome.Navigate().GoToUrl(objUsuario.Url);

                //aguando site abrir
                Thread.Sleep(5000);

                //bloquando teclado e mouse
                BlockInput(true);

                //abrindo formulario de alerta 
                OpenFormAlertBlockON();

                /* -------------------- Email -------------------------*/
                //capturando elemento pelo id
                txtUser = chrome.FindElement(By.Id("email"));

                //digitando no campo valor armazenado no objeto
                txtUser.SendKeys(objUsuario.Login);

                //aguandando
                Thread.Sleep(100);

                /* -------------------- Senha -------------------------*/
                //capturando elemento pelo id
                txtSenha = chrome.FindElement(By.Id("pass"));

                //digitando no campo valor armazenado no objeto
                txtSenha.SendKeys(objUsuario.Senha);

                //aguandando
                Thread.Sleep(100);

                /* -------------------- Botão de Confirmar -------------------------*/
                //capturando elemento pelo name
                txtBotao = chrome.FindElement(By.Name("login"));

                //clicando no botão de 'entrar'
                txtBotao.Click();

                //aguardando
                Thread.Sleep(2000);

                //abrindo Formulado de alerta
                OpenFormAlertBlockOFF();

                //desbloquando teclado e mouse
                BlockInput(false);

            } catch(Exception ex)
            {
                MessageBox.Show("Erro No Processo:\n\n " + ex);

                //desbloquando teclado e mouse
                BlockInput(false);

            }

            //abrir novamente o Formulario
            var formToShow = Application.OpenForms.Cast<Form>()
            .FirstOrDefault(c => c is OptionsForm);
            if (formToShow != null)
            {
                formToShow.Show();
            }
        }

        #endregion

        #region Acessando Hotmail
        private void btnHotmail_Click(object sender, EventArgs e)
        {
            //ocultar Formulario Atual
            this.Hide();

            DataSet ds = new DataSet();

            IWebElement txtUser;
            IWebElement txtSenha;
            IWebElement txtBotaoNext;

            /*
            Codigo 1 -> facebook
            Codigo 2 -> hotmail
            Codigo 3 -> gmail
            */

            //capturando dados do banco
            ds = DB.getDados(2);

            //populando classe Usuario
            objUsuario.Url = ds.Tables[0].Rows[0]["PagesUrl"].ToString();
            objUsuario.Login = ds.Tables[0].Rows[0]["LoginUser"].ToString();
            objUsuario.Senha = ds.Tables[0].Rows[0]["LoginSenha"].ToString();

            /*
             Necessário baixar Chromedrive no site 'https://chromedriver.chromium.org/downloads'
             OBS: Verifique a versão do seu navegador para baixar uma versão do chromedriver compativel
            */
            try
            {
                //caminho do chromedrive
                String path = Properties.Settings.Default.ChromeDrive.ToString();

                //configurando chromedrive (ocultar console do chrome drive)
                ChromeDriverService driverService = ChromeDriverService.CreateDefaultService(path);
                driverService.HideCommandPromptWindow = true;

                //instanciando chromedrive
                IWebDriver chrome;
                chrome = new ChromeDriver(driverService);

                //configurando para navegador abrir maximizado
                chrome.Manage().Window.Maximize();

                //setando url do site que deve abrir o navegador
                chrome.Navigate().GoToUrl(objUsuario.Url);



                //aguando site abrir
                Thread.Sleep(5000);

                //bloquando teclado e mouse
                BlockInput(true);

                //abrindo formulario de alerta 
                OpenFormAlertBlockON();

                /* -------------------- Email -------------------------*/
                //capturando elemento pelo name
                txtUser = chrome.FindElement(By.Name("loginfmt"));

                //digitando no campo valor armazenado no objeto
                txtUser.SendKeys(objUsuario.Login);


                //capturando elemento do botão pelo id
                txtBotaoNext = chrome.FindElement(By.Id("idSIButton9"));

                //clicando no botão
                txtBotaoNext.Click();

                //aguandando
                Thread.Sleep(4000);

                /* -------------------- Senha -------------------------*/
                //capturando elemento pelo id
                txtSenha = chrome.FindElement(By.Name("passwd"));

                //digitando no campo valor armazenado no objeto
                txtSenha.SendKeys(objUsuario.Senha);

                //capturando elemento do botão pelo id
                txtBotaoNext = chrome.FindElement(By.Id("idSIButton9"));

                //clicando no botão
                txtBotaoNext.Click();

                //aguardando
                Thread.Sleep(2000);

                //abrindo Formulado de alerta
                OpenFormAlertBlockOFF();

                //desbloquando teclado e mouse
                BlockInput(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro No Processo:\n\n " + ex);

                //desbloquando teclado e mouse
                BlockInput(false);

            }

            //abrir novamente o Formulario
            var formToShow = Application.OpenForms.Cast<Form>()
            .FirstOrDefault(c => c is OptionsForm);
            if (formToShow != null)
            {
                formToShow.Show();
            }
        }

        #endregion

        #region Acessando Gmail
        private void btnGmail_Click(object sender, EventArgs e)
        {
            //ocultar Formulario Atual
            this.Hide();

            DataSet ds = new DataSet();

            IWebElement txtUser;
            IWebElement txtSenha;
            IWebElement txtBotao;

            /*
            Codigo 1 -> facebook
            Codigo 2 -> hotmail
            Codigo 3 -> gmail
            */

            //capturando dados do banco
            ds = DB.getDados(3);

            //populando classe Usuario
            objUsuario.Url = ds.Tables[0].Rows[0]["PagesUrl"].ToString();
            objUsuario.Login = ds.Tables[0].Rows[0]["LoginUser"].ToString();
            objUsuario.Senha = ds.Tables[0].Rows[0]["LoginSenha"].ToString();

            /*
             Necessário baixar Chromedrive no site 'https://chromedriver.chromium.org/downloads'
             OBS: Verifique a versão do seu navegador para baixar uma versão do chromedriver compativel
            */
            try
            {
                //caminho do chromedrive
                String path = Properties.Settings.Default.ChromeDrive.ToString();

                //configurando chromedrive (ocultar console do chrome drive)
                ChromeDriverService driverService = ChromeDriverService.CreateDefaultService(path);
                driverService.HideCommandPromptWindow = true;

                //instanciando chromedrive
                IWebDriver chrome;
                chrome = new ChromeDriver(driverService);

                //configurando para navegador abrir maximizado
                chrome.Manage().Window.Maximize();

                //setando url do site que deve abrir o navegador
                chrome.Navigate().GoToUrl(objUsuario.Url);



                //aguando site abrir
                Thread.Sleep(5000);

                //bloquando teclado e mouse
                BlockInput(true);

                //abrindo formulario de alerta 
                OpenFormAlertBlockON();

                //verifica se elemento existe (Entrar com Outro Usuario)
                if (chrome.FindElements(By.ClassName("BHzsHc")).Count > 0)
                {
                    //captura elemento pela classe
                    txtBotao = chrome.FindElement(By.ClassName("BHzsHc"));

                    //clicando na div
                    txtBotao.Click();

                    //aguardando...
                    Thread.Sleep(3000);
                }


                /* -------------------- Email -------------------------*/

                //capturando elemento pelo name
                txtUser = chrome.FindElement(By.Name("identifier"));

                //digitando no campo valor armazenado no objeto
                txtUser.SendKeys(objUsuario.Login);

                //capturando elemento pela classe
                txtBotao = chrome.FindElement(By.ClassName("VfPpkd-RLmnJb"));

                //clicando no botão
                txtBotao.Click();

                //aguardando
                Thread.Sleep(4000);

                /* -------------------- Senha -------------------------*/

                //capturando elemento pelo name
                txtSenha = chrome.FindElement(By.Name("password"));

                //digitando no campo valor armazenado no objeto
                txtSenha.SendKeys(objUsuario.Senha);

                //capturando elemento pela classe
                txtBotao = chrome.FindElement(By.ClassName("VfPpkd-RLmnJb"));

                //clicando no botão
                txtBotao.Click();

                //aguardando
                Thread.Sleep(2000);

                //abrindo Formulado de alerta
                OpenFormAlertBlockOFF();

                //desbloquando teclado e mouse
                BlockInput(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro No Processo:\n\n " + ex);

                //desbloquando teclado e mouse
                BlockInput(false);

            }
            
            //abrir novamente o Formulario
            var formToShow = Application.OpenForms.Cast<Form>()
            .FirstOrDefault(c => c is OptionsForm);
            if (formToShow != null)
            {
                formToShow.Show();
            }
        }
        #endregion

        #region Abrir e Fechar o Formulario de Alerta de Bloqueio
        public void OpenFormAlertBlockON()
        {
            //chamada do metodo
            OpenMessageBoxON();

        }
        #endregion

        #region Abrir e Fechar o Formulario de Alerta de Desbloqueio
        public void OpenFormAlertBlockOFF()
        {
            //chamada do metodo
            OpenMessageBoxOFF();
        }
        #endregion

        #region Formulario de Bloqueio/Desbloqueio de Teclado e Mouse
        public void OpenMessageBoxON()
        {

            //criando time
            time.Interval = 4000;

            time.Tick += new EventHandler(CloseMessageBox);

            //startando time
            time.Start();

            //abrindo formulario
            AlertON.ShowDialog();


        }
        #endregion

        #region MessageBox de Desbloqueio de Teclado e Mouse
        public void OpenMessageBoxOFF()
        {
            //criando time
            time.Interval = 7000;

            time.Tick += new EventHandler(CloseMessageBox);

            //startando time
            time.Start();

            //abrindo formulario
            AlertOFF.ShowDialog();

        }
        #endregion

        #region Fechando MessageBox
        public void CloseMessageBox(object sender, EventArgs e)

        {
            //verifica Qual Formulario Foi Aberto
            if (AlertON.Visible)
            {
                AlertON.Close();
            }
            else
            {
                AlertOFF.Close();
            }
            
            time.Stop();
        }
        #endregion
    }
}
