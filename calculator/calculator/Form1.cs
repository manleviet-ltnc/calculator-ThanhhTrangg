using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        bool isTyingNumber = false;
        enum PhepToan { None,Cong, Tru, Nhan, Chia};
        PhepToan pheptoan;
        double nho = 0.0;
        private void NhapSo(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            NhapSo(btn.Text);
        }
        private void NhapSo(string so)
        {
            if (isTyingNumber)
                lblDisplay.Text = lblDisplay.Text + so;
            else
            {
                lblDisplay.Text = so;
                isTyingNumber = true;
            }
        }
        private void NhapPhepToan(object sender, EventArgs e)
        {
            if (nho != 0)
                TinhKetQua();

            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "+": pheptoan = PhepToan.Cong; break;
                case "-": pheptoan = PhepToan.Tru; break;
                case "*": pheptoan = PhepToan.Nhan; break;
                case "/": pheptoan = PhepToan.Chia; break;
            }

            nho = double.Parse(lblDisplay.Text);

            isTyingNumber = false;
        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            isTyingNumber = false;
            nho = 0;
            pheptoan = PhepToan.None;
        }
        private void TinhKetQua()
        {
            //Tinh toan dua tren: nho, pheptoan, lblDisplay.Text
            double tam = double.Parse(lblDisplay.Text);
            double ketqua = 0.0;
            switch (pheptoan)
            {
                case PhepToan.Cong: ketqua = nho + tam; break;
                case PhepToan.Tru: ketqua = nho - tam; break;
                case PhepToan.Nhan: ketqua = nho * tam; break;
                case PhepToan.Chia: ketqua = nho / tam; break;
            }
            //Gan ket qua tinh duoc len lblDisplay
            lblDisplay.Text = ketqua.ToString();
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    NhapSo("" + e.KeyChar);
                    break;
                    NhapSo("" + e.KeyChar);
                    break;
                case '+':
                    btnCong.PerformClick();
                    break;
                case '-':
                    btnTru.PerformClick();
                    break;
                case '*':
                    btnNhan.PerformClick();
                    break;
                case '/':
                    btnChia.PerformClick();
                    break;
                case '=':
                    btnBang.PerformClick();
                    break;
                default:
                    break;

            }
        }

        private void btnPhanTram_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = ((double.Parse(lblDisplay.Text) / 100)).ToString();
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (Math.Sqrt(double.Parse(lblDisplay.Text))).ToString();
        }

        private void btnDoiDau_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (-1 * (double.Parse(lblDisplay.Text))).ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "")
                lblDisplay.Text = (lblDisplay.Text).Substring(0, lblDisplay.Text.Length - 1);
        }
    }

}