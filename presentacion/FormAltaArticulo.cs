using dominio;
using negocio;
using System;
using System.Windows.Forms;

namespace presentacion
{
    public partial class FormAltaArticulo : Form
    {
        private Articulo articulo = null;
        //private OpenFileDialog archivo = null;
        public FormAltaArticulo()
        {
            InitializeComponent();
        }
        public FormAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (!(validarAgregar()))
                {
                    if (articulo == null)
                    {
                        articulo = new Articulo();
                    }
                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Precio = decimal.Parse(txtPrecio.Text);
                    articulo.Categoria = (Categoria)cmbCategoria.SelectedItem;
                    articulo.Marca = (Marca)cmbMarca.SelectedItem;
                    articulo.UrlImagen = txtImagenUrl.Text;

                    if (articulo.Id != 0)
                    {
                        negocio.modificar(articulo);
                        MessageBox.Show("Modificado con éxito", "Modificar");
                    }
                    else
                    {
                        negocio.agregar(articulo);
                        MessageBox.Show("Agregado éxitosamente");
                    }

                    Close();
                    // guardo imagen si la levanto
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormAltaArticulo_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio1 = new CategoriaNegocio();
            MarcaNegocio negocio2 = new MarcaNegocio();

            try
            {
                cmbCategoria.DataSource = negocio1.listar();
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DisplayMember = "Descripcion";
                cmbMarca.DataSource = negocio2.listar();
                cmbMarca.ValueMember = "Id";
                cmbMarca.DisplayMember = "Descripcion";
                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtImagenUrl.Text = articulo.UrlImagen;
                    cargarImagen(articulo.UrlImagen);
                    cmbCategoria.SelectedValue = articulo.Categoria.Id;
                    cmbMarca.SelectedValue = articulo.Marca.Id;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagenUrl.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagenAlta.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxImagenAlta.Load("https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png");
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool validarAgregar()
        {
            
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Porfavor ponga un Nombre al articulo...");
                return true;
            }
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Porfavor ponga un codigo al articulo...");
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
