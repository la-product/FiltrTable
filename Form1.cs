using System.Globalization;
using System.Xml.Linq;

namespace TescoSW_task {
    public partial class Prodeje : Form {
        private static readonly NumberFormatInfo CisloFormat = new() {
            NumberGroupSeparator = " ",
            NumberDecimalDigits = 2,
        };

        private List<Sales> prodeje = new();

        public Prodeje() {
            InitializeComponent();
            cboProdeje.SelectedIndex = 0;
            cboDph.SelectedIndex = 0;
        }

        private void btnVybratSoubor_Click(object? sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            try {
                prodeje = NactiProdeje(openFileDialog1.FileName);
                lblSoubor.Text = Path.GetFileName(openFileDialog1.FileName);
                ZobrazVysledky();
            } catch (Exception ex) {
                MessageBox.Show($"Soubor se nepodařilo načíst: {ex.Message}", "Chyba",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProdeje_SelectedIndexChanged(object? sender, EventArgs e) {
            ZobrazVysledky();
        }

        private void cboDph_SelectedIndexChanged(object? sender, EventArgs e) {
            ZobrazVysledky();
        }

        private static List<Sales> NactiProdeje(string cesta) {
            var doc = XDocument.Load(cesta);
            return doc.Root!.Elements("auto").Select(e => new Sales(
                e.Element("nazev_modelu")!.Value,
                DateTime.ParseExact(e.Element("datum_prodeje")!.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                decimal.Parse(e.Element("cena")!.Value, CultureInfo.InvariantCulture),
                decimal.Parse(e.Element("dph")!.Value, CultureInfo.InvariantCulture)
            )).ToList();
        }

        private void ZobrazVysledky() {
            lvVysledky.Items.Clear();

            IEnumerable<Sales> filtrovane = cboProdeje.SelectedItem switch {
                "Víkend" => prodeje.Where(p => p.Datum.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday),
                _ => prodeje,
            };

            filtrovane = cboDph.SelectedItem switch {
                "19%" => filtrovane.Where(p => p.Dph == 19),
                "20%" => filtrovane.Where(p => p.Dph == 20),
                _ => filtrovane,
            };

            var soucty = filtrovane
                .GroupBy(p => p.NazevModelu)
                .Select(g => new {
                    Model = g.Key,
                    BezDph = g.Sum(p => p.Cena),
                    SDph = g.Sum(p => p.Cena + p.Cena * (p.Dph / 100m)),
                })
                .OrderBy(s => s.Model);       

            foreach (var s in soucty) {
                var item = new ListViewItem(s.Model);
                item.SubItems.Add($"{s.BezDph.ToString("N2", CisloFormat)} CZK");
                item.SubItems.Add($"{s.SDph.ToString("N2", CisloFormat)} CZK");
                lvVysledky.Items.Add(item);
            }
        }
    }

    internal record Sales(string NazevModelu, DateTime Datum, decimal Cena, decimal Dph);
}
