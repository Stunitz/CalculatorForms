using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Calculadora
{
    public partial class frmCalculadora : Form
    {
        #region Construtor

        public frmCalculadora()
        {
            InitializeComponent();
        }

        #endregion

        #region Inicialiazadores, Atalhos de Teclado e Mensagem Inicial

        private string primeiroValor, historicoConta, valor;
        private double segundoValor;
        private bool adicao, subtracao, multiplicacao, divisao, resultado, virgula;
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        private void frmCalculadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0)
            {
                btnNumero0.PerformClick();
            }
            if (e.KeyCode == Keys.D1)
            {
                btnNumero1.PerformClick();
            }
            if (e.KeyCode == Keys.D2)
            {
                btnNumero2.PerformClick();
            }
            if (e.KeyCode == Keys.D3)
            {
                btnNumero3.PerformClick();
            }
            if (e.KeyCode == Keys.D4)
            {
                btnNumero4.PerformClick();
            }
            if (e.KeyCode == Keys.D5)
            {
                btnNumero5.PerformClick();
            }
            if (e.KeyCode == Keys.D6)
            {
                btnNumero6.PerformClick();
            }
            if (e.KeyCode == Keys.D7)
            {
                btnNumero7.PerformClick();
            }
            if (e.KeyCode == Keys.D8)
            {
                btnNumero8.PerformClick();
            }
            if (e.KeyCode == Keys.D9)
            {
                btnNumero9.PerformClick();
            }
            if (e.Shift && e.KeyCode == Keys.Oemplus)
            {
                btnAdicao.PerformClick();
            }
            if (e.KeyCode == Keys.OemMinus)
            {
                btnSubtracao.PerformClick();
            }
            if (e.Shift && e.KeyCode == Keys.D8)
            {
                btnMultiplicacao.PerformClick();
            }
            if (e.KeyCode == Keys.Q)
            {
                btnDivisao.PerformClick();
            }
            if (e.KeyCode == Keys.I)
            {
                btnInversor.PerformClick();
            }
            if (e.KeyCode == Keys.Oemcomma)
            {
                btnVirgula.PerformClick();
            }
            //if (e.KeyCode == Keys.Oemplus)
            //{
            //    btnResultado.PerformClick();
            //}
            if (e.KeyCode == Keys.Back)
            {
                btnApagar.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.Back)
            {
                btnLimpar.PerformClick();
            }
            if (e.KeyCode == Keys.Back && e.Shift && e.Control)
            {
                btnLimparTudo.PerformClick();
            }
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            synthesizer.Rate = 2;
            synthesizer.SpeakAsync("Bem vindo a Calculadora!");
            this.txtValor.Text = "0";
        }

        #endregion

        #region Métodos dos Números

        private void btnNumero1_Click(object sender, EventArgs e)
        {
            addNumero("1");
        }

        private void btnNumero2_Click(object sender, EventArgs e)
        {
            addNumero("2");
        }

        private void btnNumero3_Click(object sender, EventArgs e)
        {
            addNumero("3");
        }

        private void btnNumero4_Click(object sender, EventArgs e)
        {
            addNumero("4");
        }

        private void btnNumero5_Click(object sender, EventArgs e)
        {
            addNumero("5");
        }

        private void btnNumero6_Click(object sender, EventArgs e)
        {
            addNumero("6");
        }

        private void btnNumero7_Click(object sender, EventArgs e)
        {
            addNumero("7");
        }

        private void btnNumero8_Click(object sender, EventArgs e)
        {
            addNumero("8");
        }

        private void btnNumero9_Click(object sender, EventArgs e)
        {
            addNumero("9");
        }

        private void btnNumero0_Click(object sender, EventArgs e)
        {
            addNumero("0");
        }

        #endregion

        #region Método para agrupar os números digitados em uma string

        private void addNumero(string valorRecebido)
        {
            // Limpa o historico e zera a variavel primeiroValor
            if (resultado == true)
            {
                historicoConta = "";
                txtValor.Text = "";
                primeiroValor = null;
                resultado = false;
            }

            // Controla o número máximo a ser digitado

            if (txtValor.TextLength <= 17)
            {
                primeiroValor += valorRecebido;
                txtValor.Text = primeiroValor;
                if (primeiroValor.Length >= 11)
                {
                    txtValor.Font = new Font("Microsoft Sans Serif", 24F);
                }
                else
                {
                    txtValor.Font = new Font("Microsoft Sans Serif", 36F);
                }
            }
        }

        #endregion

        #region Métodos dos operadores
        private void btnAdicao_Click(object sender, EventArgs e)
        {
            if (primeiroValor != null && !primeiroValor.Equals(""))
            {
                historicoConta += primeiroValor + " + ";
                segundoValor += Convert.ToDouble(primeiroValor);
            }
            
            primeiroValor = null;
            txtConta.Text = historicoConta;
            txtValor.Text = Convert.ToString(segundoValor);
            adicao = true;
            virgula = false;
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            if (primeiroValor != null && !primeiroValor.Equals("") && subtracao == true)
            {
                historicoConta += primeiroValor + " - ";
                segundoValor -= Convert.ToDouble(primeiroValor);
                subtracao = true;
            }
            if(primeiroValor != null && subtracao == false)
            {
                historicoConta += primeiroValor + " - ";
                segundoValor = Convert.ToDouble(primeiroValor);
                subtracao = true;
            }
            primeiroValor = null;
            txtConta.Text = historicoConta;
            txtValor.Text = Convert.ToString(segundoValor);
            virgula = false;
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            if (primeiroValor != null && !primeiroValor.Equals("") && multiplicacao == true)
            {
                historicoConta += primeiroValor + " × ";
                segundoValor *= Convert.ToDouble(primeiroValor);
                multiplicacao = true;
            }
            if (primeiroValor != null && multiplicacao == false)
            {
                historicoConta += primeiroValor + " × ";
                segundoValor = Convert.ToDouble(primeiroValor);
                multiplicacao = true;
            }
            primeiroValor = null;
            txtConta.Text = historicoConta;
            txtValor.Text = Convert.ToString(segundoValor);
            virgula = false;
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            if (primeiroValor != null && !primeiroValor.Equals("") && divisao == true)
            {
                historicoConta += primeiroValor + " ÷ ";
                segundoValor /= Convert.ToDouble(primeiroValor);
                divisao = true;
            }
            if (primeiroValor != null && divisao == false)
            {
                historicoConta += primeiroValor + " ÷ ";
                segundoValor = Convert.ToDouble(primeiroValor);
                divisao = true;
            }
            primeiroValor = null;
            txtConta.Text = historicoConta;
            txtValor.Text = Convert.ToString(segundoValor);
            virgula = false;
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            resultado = true;
            virgula = false;

            if (adicao == true)
            {
                segundoValor += Convert.ToDouble(primeiroValor);
                txtValor.Text = Convert.ToString(segundoValor);
                primeiroValor = Convert.ToString(segundoValor);
                adicao = false;
                txtConta.Text = null;
                segundoValor = 0;
                historicoConta = null;
            }

            if (subtracao == true)
            {
                segundoValor -= Convert.ToDouble(primeiroValor);
                txtValor.Text = Convert.ToString(segundoValor);
                primeiroValor = Convert.ToString(segundoValor);

                segundoValor = 0;
                txtConta.Text = null;
                historicoConta = null;
                subtracao = false;
            }

            if (multiplicacao == true)
            {
                segundoValor *= Convert.ToDouble(primeiroValor);
                txtValor.Text = Convert.ToString(segundoValor);
                primeiroValor = Convert.ToString(segundoValor);

                segundoValor = 0;
                txtConta.Text = null;
                historicoConta = null;
                multiplicacao = false;
            }

            if (divisao == true && primeiroValor != null)
            {
                segundoValor /= Convert.ToDouble(primeiroValor);
                txtValor.Text = Convert.ToString(segundoValor);
                primeiroValor = Convert.ToString(segundoValor);

                segundoValor = 0;
                txtConta.Text = null;
                historicoConta = null;
                divisao = false;
            }

            if (primeiroValor != null && primeiroValor.Length >= 11)
            {
                txtValor.Font = new Font("Microsoft Sans Serif", 24F);
            }
            else
            {
                txtValor.Font = new Font("Microsoft Sans Serif", 36F);
            }
        }

        #endregion

        #region Métodos para Limpar Calculadora

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (primeiroValor != null && primeiroValor.Length > 0)
            {
                primeiroValor = primeiroValor.Remove(primeiroValor.Length - 1);
                txtValor.Text = primeiroValor;
                if (primeiroValor.Equals(""))
                {
                    txtValor.Text = "0";
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            primeiroValor = null;
            txtValor.Text = "0";
        }


        /// <summary>
        /// Limpa todas as caixas de textos e contas efetuadas 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimparTudo_Click(object sender, EventArgs e)
        {
            // Limpa todos os valores que recebem uma string para vazio
            this.primeiroValor = this.historicoConta = this.txtConta.Text = string.Empty;

            // Zera o segundo valor para poder iniciar uma nova operação depois
            this.segundoValor = 0;

            // Zera a caixa de texto do resultado
            this.txtValor.Text = "0";
        }

        #endregion

        #region Métodos extras

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (virgula == false)
            {
                if(primeiroValor == null)
                    addNumero("0,");
                else
                    addNumero(",");
                virgula = true;
            }
        }

        private void btnInversor_Click(object sender, EventArgs e)
        {
            double inversor;
            if (primeiroValor != null && !primeiroValor.Equals(""))
            {
                inversor = Convert.ToDouble(primeiroValor) - Convert.ToDouble(primeiroValor) * 2;
                primeiroValor = Convert.ToString(inversor);
                txtValor.Text = primeiroValor;
            }
        }
       
        private void txtConta_TextChanged(object sender, EventArgs e)
        {

            int MaxChars = 42;
            if (txtConta.Text.Count() > MaxChars)
            {
                txtConta.ScrollBars = ScrollBars.Horizontal;
                txtConta.SelectionStart = txtConta.Text.Length;
                txtConta.ScrollToCaret();
            }
            else
                txtConta.ScrollBars = ScrollBars.None;
        }

        #endregion
    }
}