using System;
using System.Windows.Forms;

namespace Practica2
{
    public partial class Form1 : Form
    {
        private float[,] A;
        private float[] B;
        private float[] x;
        public Form1()
        {
            InitializeComponent();
            A = new float[3, 3];
            B = new float[3];
            x = new float[3];
            x[0] = 0;
            x[1] = 0;
            x[2] = 0;
        }
        private float[,] LeerA()
        {
            A[0, 0] = float.Parse(txtbA11.Text);
            A[0, 1] = float.Parse(txtbA12.Text);
            A[0, 2] = float.Parse(txtbA13.Text);
            A[1, 0] = float.Parse(txtbA21.Text);
            A[1, 1] = float.Parse(txtbA22.Text);
            A[1, 2] = float.Parse(txtbA23.Text);
            A[2, 0] = float.Parse(txtbA31.Text);
            A[2, 1] = float.Parse(txtbA32.Text);
            A[2, 2] = float.Parse(txtbA33.Text);
            return A;
        }
        private float[] LeerB()
        {
            B[0] = float.Parse(txtbB1.Text);
            B[1] = float.Parse(txtbB2.Text);
            B[2] = float.Parse(txtbB3.Text);
            return B;
        }

        private void btnResolver_Click(object sender, EventArgs e)
        {
            try
            {
                LeerA();
                LeerB();
                // Un if para confirmar la convergencia
                if (Math.Abs(A[0, 0]) > Math.Abs(A[0, 1] + A[0, 2]) && Math.Abs(A[1, 1]) > Math.Abs(A[1, 0] + A[1, 2]) && Math.Abs(A[2, 2]) > Math.Abs(A[2, 0] + A[2, 1]))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        x[0] = (1 / A[0, 0]) * (B[0] - A[0, 1] * x[1] - A[0, 2] * x[2]);
                        x[1] = (1 / A[1, 1]) * (B[1] - A[1, 0] * x[0] - A[1, 2] * x[2]);
                        x[2] = (1 / A[2, 2]) * (B[2] - A[2, 0] * x[0] - A[2, 1] * x[1]);
                    }
                    lbxRespuesta.Text = "x = " + x[0].ToString();
                    lbyRespuesta.Text = "y = " + x[1].ToString();
                    lbzRespuesta.Text = "z = " + x[2].ToString();
                }
                else
                {
                    MessageBox.Show("El metodo no converge");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("No debe haber campos vacios");
            }
            
        }
    }
}
