using AlejandroGarciaMalo;
using AlejandroGarciaMalo.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsImperio
{
    public partial class Form1 : Form
    {
        private readonly WebServiceImperio _webService;

        public Form1()
        {
            InitializeComponent();

            _webService = new WebServiceImperio();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(string.Empty) || txtPlaneta.Text.Equals(string.Empty))
            {
                return;
            }

            var rebelde = new Rebelde(txtNombre.Text, txtPlaneta.Text,dateRegistro.Value);
            
            var strRebelde = rebelde.ConvertToString();

            listRebeldesAñadidos.Items.Add(strRebelde);
        }

        private void btnAñadirSubir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(string.Empty) || txtPlaneta.Text.Equals(string.Empty))
            {
                return;
            }

            var rebelde = new Rebelde(txtNombre.Text, txtPlaneta.Text, dateRegistro.Value);

            var strRebelde = rebelde.ConvertToString();

            var listStrRebeldes = new List<string> {strRebelde};

            _webService.InsertarRebeldes(listStrRebeldes);
        }

        

        private void btnSubirLista_Click(object sender, EventArgs e)
        {
            var listStrRebeldes = new List<string>();

            foreach (var rebeldeItem in listRebeldesAñadidos.Items)
            {
                listStrRebeldes.Add(rebeldeItem.ToString());
            }

            _webService.InsertarRebeldes(listStrRebeldes);

            listRebeldesAñadidos.Items.Clear();
        }

        private void btnRebeldes_Click(object sender, EventArgs e)
        {
            listRebeldesAñadidos.Items.Clear();
            listRebeldes.DataSource = _webService.ObtenerRebeldes();
        }
    }
}
