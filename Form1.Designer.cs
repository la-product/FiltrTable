namespace TescoSW_task {
    partial class Prodeje {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button btnVybratSoubor;
        private Label lblSoubor;
        private Label lblProdeje;
        private ComboBox cboProdeje;
        private Label lblDph;
        private ComboBox cboDph;
        private ListView lvVysledky;
        private ColumnHeader colModel;
        private ColumnHeader colBezDph;
        private ColumnHeader colSDph;
        private OpenFileDialog openFileDialog1;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            btnVybratSoubor = new Button();
            lblSoubor = new Label();
            lblProdeje = new Label();
            cboProdeje = new ComboBox();
            lblDph = new Label();
            cboDph = new ComboBox();
            lvVysledky = new ListView();
            colModel = new ColumnHeader();
            colBezDph = new ColumnHeader();
            colSDph = new ColumnHeader();
            openFileDialog1 = new OpenFileDialog();

            // btnVybratSoubor
            btnVybratSoubor.Location = new Point(12, 12);
            btnVybratSoubor.Size = new Size(130, 30);
            btnVybratSoubor.Text = "Vybrat soubor...";
            btnVybratSoubor.UseVisualStyleBackColor = true;
            btnVybratSoubor.Click += btnVybratSoubor_Click;

            // lblSoubor
            lblSoubor.AutoSize = true;
            lblSoubor.Location = new Point(155, 20);
            lblSoubor.Text = "Žádný soubor není načten";

            // lblProdeje
            lblProdeje.AutoSize = true;
            lblProdeje.Location = new Point(12, 58);
            lblProdeje.Text = "Prodeje:";

            // cboProdeje
            cboProdeje.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProdeje.Location = new Point(80, 54);
            cboProdeje.Size = new Size(150, 23);
            cboProdeje.Items.AddRange(new object[] { "Vše", "Víkend" });
            cboProdeje.SelectedIndexChanged += cboProdeje_SelectedIndexChanged;

            // lblDph
            lblDph.AutoSize = true;
            lblDph.Location = new Point(250, 58);
            lblDph.Text = "DPH:";

            // cboDph
            cboDph.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDph.Location = new Point(300, 54);
            cboDph.Size = new Size(100, 23);
            cboDph.Items.AddRange(new object[] { "Vše", "19%", "20%" });
            cboDph.SelectedIndexChanged += cboDph_SelectedIndexChanged;

            // colModel
            colModel.Text = "Model";
            colModel.Width = 220;

            // colBezDph
            colBezDph.Text = "Celkem bez DPH";
            colBezDph.Width = 180;

            // colSDph
            colSDph.Text = "Celkem s DPH";
            colSDph.Width = 180;

            // lvVysledky
            lvVysledky.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvVysledky.FullRowSelect = true;
            lvVysledky.Location = new Point(12, 92);
            lvVysledky.Size = new Size(560, 300);
            lvVysledky.View = View.Details;
            lvVysledky.Columns.AddRange(new ColumnHeader[] { colModel, colBezDph, colSDph });

            // openFileDialog1
            openFileDialog1.Filter = "XML soubory (*.xml)|*.xml|Všechny soubory (*.*)|*.*";

            // Form1
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 420);
            Controls.Add(btnVybratSoubor);
            Controls.Add(lblSoubor);
            Controls.Add(lblProdeje);
            Controls.Add(cboProdeje);
            Controls.Add(lblDph);
            Controls.Add(cboDph);
            Controls.Add(lvVysledky);
            Text = "Filtr Prodejů";
        }

        #endregion
    }
}
