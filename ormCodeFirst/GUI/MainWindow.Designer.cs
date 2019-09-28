namespace dblab2
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnFullTextSearch = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.fullTextSearchBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.attrSearch = new System.Windows.Forms.Button();
            this.citiesSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.TableDataGrid = new System.Windows.Forms.DataGridView();
            this.genderSearch = new System.Windows.Forms.TextBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RandFillBtn = new System.Windows.Forms.Button();
            this.executingTablesView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(979, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 45);
            this.button1.TabIndex = 38;
            this.button1.Text = "Search not included";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFullTextSearch
            // 
            this.btnFullTextSearch.Location = new System.Drawing.Point(979, 141);
            this.btnFullTextSearch.Name = "btnFullTextSearch";
            this.btnFullTextSearch.Size = new System.Drawing.Size(99, 79);
            this.btnFullTextSearch.TabIndex = 37;
            this.btnFullTextSearch.Text = "Search all";
            this.btnFullTextSearch.UseVisualStyleBackColor = true;
            this.btnFullTextSearch.Click += new System.EventHandler(this.btnFullTextSearch_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(397, 111);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(681, 24);
            this.textBox4.TabIndex = 36;
            this.textBox4.Text = "Full text search";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fullTextSearchBox
            // 
            this.fullTextSearchBox.Location = new System.Drawing.Point(397, 141);
            this.fullTextSearchBox.Multiline = true;
            this.fullTextSearchBox.Name = "fullTextSearchBox";
            this.fullTextSearchBox.Size = new System.Drawing.Size(576, 80);
            this.fullTextSearchBox.TabIndex = 35;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(397, 21);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(681, 24);
            this.textBox2.TabIndex = 34;
            this.textBox2.Text = "Search by attributes";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // attrSearch
            // 
            this.attrSearch.Location = new System.Drawing.Point(979, 51);
            this.attrSearch.Name = "attrSearch";
            this.attrSearch.Size = new System.Drawing.Size(99, 54);
            this.attrSearch.TabIndex = 33;
            this.attrSearch.Text = "Search";
            this.attrSearch.UseVisualStyleBackColor = true;
            this.attrSearch.Click += new System.EventHandler(this.attrSearch_Click);
            // 
            // citiesSearch
            // 
            this.citiesSearch.Location = new System.Drawing.Point(397, 81);
            this.citiesSearch.Multiline = true;
            this.citiesSearch.Name = "citiesSearch";
            this.citiesSearch.Size = new System.Drawing.Size(576, 24);
            this.citiesSearch.TabIndex = 32;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(6, 528);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(1072, 24);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "Add row";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // TableDataGrid
            // 
            this.TableDataGrid.AllowUserToAddRows = false;
            this.TableDataGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.TableDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableDataGrid.Location = new System.Drawing.Point(6, 227);
            this.TableDataGrid.Name = "TableDataGrid";
            this.TableDataGrid.Size = new System.Drawing.Size(1072, 295);
            this.TableDataGrid.TabIndex = 30;
            this.TableDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableDataView_Click);
            // 
            // genderSearch
            // 
            this.genderSearch.Location = new System.Drawing.Point(397, 51);
            this.genderSearch.Multiline = true;
            this.genderSearch.Name = "genderSearch";
            this.genderSearch.Size = new System.Drawing.Size(576, 24);
            this.genderSearch.TabIndex = 29;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(273, 21);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(108, 24);
            this.clearBtn.TabIndex = 28;
            this.clearBtn.Text = "Clear table";
            this.clearBtn.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(6, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(139, 24);
            this.textBox1.TabIndex = 27;
            this.textBox1.Text = "Executing tables";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RandFillBtn
            // 
            this.RandFillBtn.Location = new System.Drawing.Point(161, 21);
            this.RandFillBtn.Name = "RandFillBtn";
            this.RandFillBtn.Size = new System.Drawing.Size(106, 24);
            this.RandFillBtn.TabIndex = 25;
            this.RandFillBtn.Text = "Random filling";
            this.RandFillBtn.UseVisualStyleBackColor = true;
            this.RandFillBtn.Click += new System.EventHandler(this.RandFillBtn_Click);
            // 
            // executingTablesView
            // 
            this.executingTablesView.Location = new System.Drawing.Point(6, 51);
            this.executingTablesView.Name = "executingTablesView";
            this.executingTablesView.Size = new System.Drawing.Size(375, 169);
            this.executingTablesView.TabIndex = 24;
            this.executingTablesView.UseCompatibleStateImageBehavior = false;
            this.executingTablesView.View = System.Windows.Forms.View.List;
            this.executingTablesView.SelectedIndexChanged += new System.EventHandler(this.executingTablesView_SelectedIndexChanged);
            this.executingTablesView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.executingTablesView_MouseDoubleClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 572);
            this.Controls.Add(this.btnFullTextSearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.fullTextSearchBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.attrSearch);
            this.Controls.Add(this.citiesSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.TableDataGrid);
            this.Controls.Add(this.genderSearch);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RandFillBtn);
            this.Controls.Add(this.executingTablesView);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFullTextSearch;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox fullTextSearchBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button attrSearch;
        private System.Windows.Forms.TextBox citiesSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView TableDataGrid;
        private System.Windows.Forms.TextBox genderSearch;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button RandFillBtn;
        private System.Windows.Forms.ListView executingTablesView;
    }
}