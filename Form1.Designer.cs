namespace TestDB
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nozzleTotalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.petrolStationDataSet = new TestDB.PetrolStationDataSet();
            this.nozzleTotalTableAdapter = new TestDB.PetrolStationDataSetTableAdapters.NozzleTotalTableAdapter();
            this.ypqIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pumpIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pistolIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nozzleTotalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.petrolStationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ypqIDDataGridViewTextBoxColumn,
            this.pumpIDDataGridViewTextBoxColumn,
            this.pistolIDDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.createDateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.nozzleTotalBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(544, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // nozzleTotalBindingSource
            // 
            this.nozzleTotalBindingSource.DataMember = "NozzleTotal";
            this.nozzleTotalBindingSource.DataSource = this.petrolStationDataSet;
            // 
            // petrolStationDataSet
            // 
            this.petrolStationDataSet.DataSetName = "PetrolStationDataSet";
            this.petrolStationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nozzleTotalTableAdapter
            // 
            this.nozzleTotalTableAdapter.ClearBeforeFill = true;
            // 
            // ypqIDDataGridViewTextBoxColumn
            // 
            this.ypqIDDataGridViewTextBoxColumn.DataPropertyName = "YpqID";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.ypqIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.ypqIDDataGridViewTextBoxColumn.FillWeight = 20F;
            this.ypqIDDataGridViewTextBoxColumn.HeaderText = "YPQ";
            this.ypqIDDataGridViewTextBoxColumn.Name = "ypqIDDataGridViewTextBoxColumn";
            this.ypqIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pumpIDDataGridViewTextBoxColumn
            // 
            this.pumpIDDataGridViewTextBoxColumn.DataPropertyName = "PumpID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.pumpIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.pumpIDDataGridViewTextBoxColumn.FillWeight = 20F;
            this.pumpIDDataGridViewTextBoxColumn.HeaderText = "PUMP";
            this.pumpIDDataGridViewTextBoxColumn.Name = "pumpIDDataGridViewTextBoxColumn";
            this.pumpIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pistolIDDataGridViewTextBoxColumn
            // 
            this.pistolIDDataGridViewTextBoxColumn.DataPropertyName = "PistolID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.pistolIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.pistolIDDataGridViewTextBoxColumn.FillWeight = 20F;
            this.pistolIDDataGridViewTextBoxColumn.HeaderText = "PISTOLL";
            this.pistolIDDataGridViewTextBoxColumn.Name = "pistolIDDataGridViewTextBoxColumn";
            this.pistolIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.amountDataGridViewTextBoxColumn.HeaderText = "COUNTERS";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.createDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.createDateDataGridViewTextBoxColumn.HeaderText = "DATE";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            this.createDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nozzleTotalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.petrolStationDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private PetrolStationDataSet petrolStationDataSet;
        private System.Windows.Forms.BindingSource nozzleTotalBindingSource;
        private PetrolStationDataSetTableAdapters.NozzleTotalTableAdapter nozzleTotalTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ypqIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pumpIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pistolIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
    }
}

