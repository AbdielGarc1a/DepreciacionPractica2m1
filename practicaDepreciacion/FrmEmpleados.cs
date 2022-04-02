using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore.IServices;

namespace practicaDepreciacion
{
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        //IEmpleadoServices EmpleadoServices;
        private int idSeleccionado;







        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


                idSeleccionado = dataGridView1.CurrentRow.Index;
                txtNombre.Text = dataGridView1[1, idSeleccionado].Value.ToString();
                txtCedula.Text = dataGridView1[2, idSeleccionado].Value.ToString();
                txtDireccion.Text = dataGridView1[3, idSeleccionado].Value.ToString();
                txtApellido.Text = dataGridView1[4, idSeleccionado].Value.ToString();

                txtNombre.Focus();


        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede numeros");
            }
        }

        private void txtValor_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtValorR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtVidaU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtEnviar_Click(object sender, EventArgs e)
        {
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los formularios.");
            }
            else
            {
                Empleados empleado = new Empleados()
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = double.Parse(txtTelefono.Text),
                    Direccion = txtDireccion.Text,
                   Email = textEmail.Text,
                   Cedula = txtCedula.Text


                };


                empleadoServices.Add(empleado);
                dataGridView1.DataSource = null;
                limpiar();
                dataGridView1.DataSource = empleadoServices.Read();

               


       


                //activoServices.Add(activo);
                //dataGridView1.DataSource = null;
                //limpiar();
                //dataGridView1.DataSource = activoServices.Read();

            }

          

        }
        private bool verificar()
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtApellido.Text) || String.IsNullOrEmpty(textEmail.Text) || String.IsNullOrEmpty(txtCedula.Text) || String.IsNullOrEmpty(txtDireccion.Text) || String.IsNullOrEmpty(txtTelefono.Text))
            {

                return false;
            }
            return true;
        }



        private void limpiar()
        {
            this.txtNombre.Text = String.Empty;
            this.txtApellido.Text = String.Empty;
            this.txtDireccion.Text = String.Empty;
            this.textEmail.Text = String.Empty;
            this.txtCedula.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = empleadoServices.Read();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            idSeleccionado = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

        }




    }




}
