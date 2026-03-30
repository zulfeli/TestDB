using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

namespace TestDB
{
    public partial class Form1 : Form
    {
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        private DataView dataView;
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=PetrolStation;User Id=sa;Password=Qwerty1;TrustServerCertificate=True";

        private Panel filterPanel;
        private DateTimePicker filterDatePicker;
        private DateTimePicker filterTimePicker;
        private CheckBox chkUseTime;
        private Button btnReset;
        private Button btnExport;

        // 1. Добавляем переменную для текста с датой
        private Label lblLastDate;

        public Form1()
        {
            InitializeComponent();
            SetupLayout();
            this.FormClosing += MainForm_FormClosing;
        }

        private void SetupLayout()
        {
            this.Text = "Petrol Station Monitoring";
            this.Size = new Size(1100, 600);

            filterPanel = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.FromArgb(240, 240, 240), BorderStyle = BorderStyle.FixedSingle };

            Label lblDate = new Label { Text = "Date:", Left = 15, Top = 22, AutoSize = true };
            filterDatePicker = new DateTimePicker { Left = 55, Top = 18, Width = 110, Format = DateTimePickerFormat.Short };
            filterDatePicker.ValueChanged += ApplyFilter;

            Label lblTime = new Label { Text = "Time:", Left = 190, Top = 22, AutoSize = true };
            filterTimePicker = new DateTimePicker { Left = 235, Top = 18, Width = 80, Format = DateTimePickerFormat.Custom, CustomFormat = "HH:mm", ShowUpDown = true };
            filterTimePicker.ValueChanged += ApplyFilter;

            chkUseTime = new CheckBox { Text = "Apply Time", Left = 330, Top = 21, AutoSize = true };
            chkUseTime.CheckedChanged += ApplyFilter;

            btnReset = new Button { Text = "Reset", Left = 440, Top = 16, Width = 80, Height = 30 };
            btnReset.Click += (s, e) => { chkUseTime.Checked = false; dataView.RowFilter = ""; };

            btnExport = new Button
            {
                Text = "Export to Excel",
                Left = 540,
                Top = 16,
                Width = 120,
                Height = 30,
                BackColor = Color.LightSkyBlue,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnExport.Click += (s, e) => ExportToExcelFast();

            // 2. Создаем и настраиваем Label программно
            lblLastDate = new Label
            {
                Text = "Last Date: --",
                Left = 680,
                Top = 22,
                AutoSize = true,
                ForeColor = Color.DarkBlue,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // Добавляем все контролы на панель (включая новый Label)
            filterPanel.Controls.AddRange(new Control[] { lblDate, filterDatePicker, lblTime, filterTimePicker, chkUseTime, btnReset, btnExport, lblLastDate });

            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            this.Controls.Add(dataGridView1);
            this.Controls.Add(filterPanel);
        }

        private void ExportToExcelFast()
        {
            if (dataGridView1.Rows.Count == 0) return;

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmm}.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("Petrol Report");
                            int colCount = dataGridView1.Columns.Count;
                            int rowCount = dataGridView1.Rows.Count;

                            for (int i = 0; i < colCount; i++)
                            {
                                var cell = ws.Cell(1, i + 1);
                                cell.Value = dataGridView1.Columns[i].HeaderText;
                                cell.Style.Font.Bold = true;
                                cell.Style.Font.FontColor = XLColor.White;
                                cell.Style.Fill.BackgroundColor = XLColor.CornflowerBlue;
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            }

                            for (int i = 0; i < rowCount; i++)
                            {
                                var rowColor = (i % 2 == 0) ? XLColor.AliceBlue : XLColor.White;
                                for (int j = 0; j < colCount; j++)
                                {
                                    var cell = ws.Cell(i + 2, j + 1);
                                    var val = dataGridView1.Rows[i].Cells[j].Value;

                                    if (val != null && decimal.TryParse(val.ToString(), out decimal num))
                                        cell.Value = num;
                                    else
                                        cell.Value = val?.ToString() ?? string.Empty;

                                    cell.Style.Fill.BackgroundColor = rowColor;
                                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                    cell.Style.Border.OutsideBorderColor = XLColor.LightGray;
                                }
                            }

                            int amountIdx = -1;
                            for (int k = 0; k < colCount; k++)
                                if (dataGridView1.Columns[k].Name == "Amount") amountIdx = k + 1;

                            if (amountIdx != -1)
                            {
                                int lastRow = rowCount + 1;
                                var labelCell = ws.Cell(lastRow + 1, amountIdx - 1);
                                labelCell.Value = "TOTAL:";
                                labelCell.Style.Font.Bold = true;
                                labelCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                                var sumCell = ws.Cell(lastRow + 1, amountIdx);
                                sumCell.FormulaA1 = $"=SUM({ws.Cell(2, amountIdx).Address}:{ws.Cell(lastRow, amountIdx).Address})";
                                sumCell.Style.Font.Bold = true;
                                sumCell.Style.Fill.BackgroundColor = XLColor.LightYellow;
                                sumCell.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                            }

                            ws.Range(1, 1, rowCount + 1, colCount).SetAutoFilter();
                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            }
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    adapter = new SqlDataAdapter("SELECT * FROM [PetrolStation].[dbo].[NozzleTotal]", connection);
                    new SqlCommandBuilder(adapter);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataView = new DataView(dataTable);
                    dataGridView1.DataSource = dataView;

                    // 3. Логика поиска последней даты
                    if (dataTable.Rows.Count > 0 && dataTable.Columns.Contains("CreateDate"))
                    {
                        var lastDate = dataTable.AsEnumerable()
                                                .Where(r => r["CreateDate"] != DBNull.Value)
                                                .Max(row => row.Field<DateTime>("CreateDate"));

                        lblLastDate.Text = "Last Date: " + lastDate.ToString("dd.MM.yyyy HH:mm:ss");
                    }

                    if (dataGridView1.Columns.Contains("CreateDate"))
                        dataGridView1.Columns["CreateDate"].ReadOnly = true;
                }
            }
            catch (Exception ex) { MessageBox.Show("DB Error: " + ex.Message); }
        }

        private void ApplyFilter(object sender, EventArgs e)
        {
            if (dataView == null) return;
            string datePart = filterDatePicker.Value.ToString("yyyy-MM-dd");
            string timePart = filterTimePicker.Value.ToString("HH:mm");

            if (!chkUseTime.Checked)
                dataView.RowFilter = string.Format("CreateDate >= '{0} 00:00:00' AND CreateDate <= '{0} 23:59:59'", datePart);
            else
                dataView.RowFilter = string.Format("CreateDate >= '{0} {1}:00' AND CreateDate <= '{0} {1}:59'", datePart, timePart);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.EndEdit();
            if (dataTable?.GetChanges() != null)
            {
                if (MessageBox.Show("Save changes?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        adapter.SelectCommand.Connection = conn;
                        new SqlCommandBuilder(adapter);
                        adapter.Update(dataTable);
                    }
                }
            }
        }

        public static string ShowPasswordDialog(string text, string caption)
        {
            Form prompt = new Form() { Width = 350, Height = 160, Text = caption, StartPosition = FormStartPosition.CenterScreen, FormBorderStyle = FormBorderStyle.FixedDialog };
            Label lbl = new Label() { Left = 20, Top = 20, Text = text, Width = 300 };
            TextBox txt = new TextBox() { Left = 20, Top = 45, Width = 300, UseSystemPasswordChar = true };
            Button btn = new Button() { Text = "Login", Left = 220, Top = 80, Width = 100, DialogResult = DialogResult.OK };
            prompt.Controls.AddRange(new Control[] { lbl, txt, btn });
            prompt.AcceptButton = btn;
            return prompt.ShowDialog() == DialogResult.OK ? txt.Text : "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (ShowPasswordDialog("Enter security code:", "Login") == "777") LoadData();
            else Environment.Exit(0);
        }
    }
}