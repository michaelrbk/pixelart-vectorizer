using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PixelArtUpScaler
{
    public partial class Parameter : Form
    {
        private int max = 100;
        private int min = 0;
        private int valor;

        public int getValor()
        {
            return valor;
        }

        public Parameter(int min, int max)
        {
            InitializeComponent();
            trackBar1.SetRange(min, max);
            label.Text = trackBar1.Value.ToString();
        }

        public Parameter()
        {
            this.min = 0;
            this.max = 100;
            InitializeComponent();
            trackBar1.SetRange(min, max);
            label.Text = trackBar1.Value.ToString();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label.Text = trackBar1.Value.ToString();
            valor = trackBar1.Value;
        }
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
