using System;
using System.Windows.Forms;

namespace Practica2
{
    public partial class Form1 : Form
    {
        #region Atributos
        private float[,] matrizCoef; //Matriz de coeficientes
        private float[] matrizCte; //Matriz de constantes
        private float[] matrizInicio; //Matriz 0 con el que se inicia a iterar
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            matrizCoef = new float[3, 3];
            matrizCte = new float[3];
            matrizInicio = new float[3];
            matrizInicio[0] = 0;
            matrizInicio[1] = 0;
            matrizInicio[2] = 0;
        }
        #endregion

        #region Metodos
        private float[,] LeerMatrizCoef()
        {
            matrizCoef[0, 0] = float.Parse(txtbA11.Text);
            matrizCoef[0, 1] = float.Parse(txtbA12.Text);
            matrizCoef[0, 2] = float.Parse(txtbA13.Text);
            matrizCoef[1, 0] = float.Parse(txtbA21.Text);
            matrizCoef[1, 1] = float.Parse(txtbA22.Text);
            matrizCoef[1, 2] = float.Parse(txtbA23.Text);
            matrizCoef[2, 0] = float.Parse(txtbA31.Text);
            matrizCoef[2, 1] = float.Parse(txtbA32.Text);
            matrizCoef[2, 2] = float.Parse(txtbA33.Text);
            return matrizCoef;
        }
        private float[] LeerMatrizCte()
        {
            matrizCte[0] = float.Parse(txtbB1.Text);
            matrizCte[1] = float.Parse(txtbB2.Text);
            matrizCte[2] = float.Parse(txtbB3.Text);
            return matrizCte;
        }
        #endregion

        #region Eventos
        private void btnResolver_Click(object sender, EventArgs e)
        {
            try
            {
                LeerMatrizCoef();
                LeerMatrizCte();
                // Un if para confirmar la convergencia
                if (Math.Abs(matrizCoef[0, 0]) > Math.Abs(matrizCoef[0, 1] + matrizCoef[0, 2]) && Math.Abs(matrizCoef[1, 1]) > Math.Abs(matrizCoef[1, 0] + matrizCoef[1, 2]) && Math.Abs(matrizCoef[2, 2]) > Math.Abs(matrizCoef[2, 0] + matrizCoef[2, 1]))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        matrizInicio[0] = (1 / matrizCoef[0, 0]) * (matrizCte[0] - matrizCoef[0, 1] * matrizInicio[1] - matrizCoef[0, 2] * matrizInicio[2]);
                        matrizInicio[1] = (1 / matrizCoef[1, 1]) * (matrizCte[1] - matrizCoef[1, 0] * matrizInicio[0] - matrizCoef[1, 2] * matrizInicio[2]);
                        matrizInicio[2] = (1 / matrizCoef[2, 2]) * (matrizCte[2] - matrizCoef[2, 0] * matrizInicio[0] - matrizCoef[2, 1] * matrizInicio[1]);
                    }
                    lbxRespuesta.Text = "x = " + matrizInicio[0].ToString();
                    lbyRespuesta.Text = "y = " + matrizInicio[1].ToString();
                    lbzRespuesta.Text = "z = " + matrizInicio[2].ToString();
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
        #endregion
    }
}
