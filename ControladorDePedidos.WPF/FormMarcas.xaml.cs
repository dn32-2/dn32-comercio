using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControladorDePedidos.WPF
{
    public partial class FormMarcas : Window
    {
        RepositorioMarca repositorio;

        public FormMarcas()
        {
            repositorio = new RepositorioMarca();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregueElemtosDoBancoDeDados();
        }

        private void CarregueElemtosDoBancoDeDados()
        {
            lstMarcas.DataContext = repositorio.Liste();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroMarca = new FormCadastroDeMarca();
            formCadastroMarca.ShowDialog();
            CarregueElemtosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if(lstMarcas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }
            else
            {
                var itemSelecionado = (Marca)lstMarcas.SelectedItem;
                var formCadastroMarca = new FormCadastroDeMarca(itemSelecionado);
                formCadastroMarca.ShowDialog();
                CarregueElemtosDoBancoDeDados();
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (lstMarcas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }
            else
            {
                var itemSelecionado = (Marca)lstMarcas.SelectedItem;
                repositorio.Excluir(itemSelecionado);
                CarregueElemtosDoBancoDeDados();
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElemtosDoBancoDeDados();
        }
    }
}
