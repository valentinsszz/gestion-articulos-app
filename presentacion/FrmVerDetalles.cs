using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace presentacion
{
    public partial class FrmVerDetalles : Form
    {
        private Articulo articulo;
        public FrmVerDetalles(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;

        }

        private void FrmVerDetalles_Load(object sender, EventArgs e)
        {
            //AccesoDatos datos = new AccesoDatos();
            //Articulo articulo = new Articulo();
            //CategoriaNegocio categoria = new CategoriaNegocio();
            //MarcaNegocio marca = new MarcaNegocio();

            try
            {

                if (articulo != null)
                {
                   lblNombre.Text = articulo.Nombre;
                   lblDescripcion.Text = articulo.Descripcion;
                   lblPrecio.Text = articulo.Precio.ToString();
                   lblMarca.Text = articulo.Marca.Descripcion;
                   lblCategoria.Text = articulo.Categoria.Descripcion;
                   cargarImagenes(articulo.UrlImagen);
                   
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void cargarImagenes(string imagen)
        {
            try
            {
                pbxDetalles.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxDetalles.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
            }

        }
    }
}
