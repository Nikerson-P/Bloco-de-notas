﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bloco_de_notas
{
    public partial class Form1 : Form
    {
        //Fonte
        private float tamanhoFonte;
        private Font fonte;
        private FontDialog fDialog = new FontDialog();
        private ColorDialog corFonte = new ColorDialog();

        //Arquivos
        private string nomeDoArquivo;
        private SaveFileDialog salvarArquivo = new SaveFileDialog();
        private OpenFileDialog abrirArquivo = new OpenFileDialog();

        public Form1(string name = "Sem titulo")
        {

            InitializeComponent();
            this.Text = name;

            inicializaFonte();
           
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm("Sem titulo",null);
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(salvarArquivo.ShowDialog() == DialogResult.OK)
            {
                StreamWriter arquivo = new StreamWriter(salvarArquivo.FileName);
                arquivo.Write(richTextBox1.Text);
                arquivo.Close();
                this.Text = salvarArquivo.FileName;
            }

            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (abrirArquivo.ShowDialog() == DialogResult.OK)
            {
                nomeDoArquivo = abrirArquivo.SafeFileName;
                StreamReader leitor = new StreamReader(abrirArquivo.FileName);
                string texto = leitor.ReadToEnd();
                abrirForm(nomeDoArquivo,texto);
                leitor.Close();
               
            }
        }

        private void abrirForm(string nome,string texto)
        {

            Form1 newFile = new Form1(nomeDoArquivo);
            newFile.Show();
            if (texto != null || texto != "")
            {
                newFile.richTextBox1.Text = texto;
               
            }
           
        }

        private void mudarFonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fDialog.Font;
                fonte = fDialog.Font;
            }
        }

        private void corDaFonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(corFonte.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = corFonte.Color;
            }
        }

        private void aumentarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tamanhoFonte += 1;
            Font f = new Font(fonte.Name, tamanhoFonte, fonte.Style,GraphicsUnit.Point);
            richTextBox1.Font = f;
        }


        private void inicializaFonte()
        {
            //Pega a fonte usada como padrao na inicializacao
            fonte = this.Font;
            tamanhoFonte = fonte.Size;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void diminuirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tamanhoFonte -= 1;
            Font f = new Font(fonte.Name, tamanhoFonte, fonte.Style, GraphicsUnit.Point);
            richTextBox1.Font = f;
        }
    }
}
