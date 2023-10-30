namespace FicaTestiranje
{
    partial class Form1
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
            this.tcLowHigh = new System.Windows.Forms.TabControl();
            this.tabMinHigh = new System.Windows.Forms.TabPage();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblHighPrice = new System.Windows.Forms.Label();
            this.lblLowPrice = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblLow = new System.Windows.Forms.Label();
            this.btnUpdateLow = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.tabStock = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.rtbOneStock = new System.Windows.Forms.RichTextBox();
            this.btnData = new System.Windows.Forms.Button();
            this.tbMonths = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tbStockName = new System.Windows.Forms.TextBox();
            this.tcLowHigh.SuspendLayout();
            this.tabMinHigh.SuspendLayout();
            this.tabStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcLowHigh
            // 
            this.tcLowHigh.Controls.Add(this.tabMinHigh);
            this.tcLowHigh.Controls.Add(this.tabStock);
            this.tcLowHigh.Location = new System.Drawing.Point(2, 1);
            this.tcLowHigh.Name = "tcLowHigh";
            this.tcLowHigh.SelectedIndex = 0;
            this.tcLowHigh.Size = new System.Drawing.Size(777, 360);
            this.tcLowHigh.TabIndex = 0;
            // 
            // tabMinHigh
            // 
            this.tabMinHigh.Controls.Add(this.progressBar);
            this.tabMinHigh.Controls.Add(this.lblHighPrice);
            this.tabMinHigh.Controls.Add(this.lblLowPrice);
            this.tabMinHigh.Controls.Add(this.lblHigh);
            this.tabMinHigh.Controls.Add(this.lblLow);
            this.tabMinHigh.Controls.Add(this.btnUpdateLow);
            this.tabMinHigh.Controls.Add(this.btnUpdate);
            this.tabMinHigh.Controls.Add(this.rtbResult);
            this.tabMinHigh.Location = new System.Drawing.Point(4, 25);
            this.tabMinHigh.Name = "tabMinHigh";
            this.tabMinHigh.Padding = new System.Windows.Forms.Padding(3);
            this.tabMinHigh.Size = new System.Drawing.Size(769, 331);
            this.tabMinHigh.TabIndex = 0;
            this.tabMinHigh.Text = "52 low and high prices";
            this.tabMinHigh.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 300);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(464, 23);
            this.progressBar.TabIndex = 7;
            // 
            // lblHighPrice
            // 
            this.lblHighPrice.AutoSize = true;
            this.lblHighPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighPrice.Location = new System.Drawing.Point(562, 76);
            this.lblHighPrice.Name = "lblHighPrice";
            this.lblHighPrice.Size = new System.Drawing.Size(18, 20);
            this.lblHighPrice.TabIndex = 6;
            this.lblHighPrice.Text = "0";
            // 
            // lblLowPrice
            // 
            this.lblLowPrice.AutoSize = true;
            this.lblLowPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowPrice.Location = new System.Drawing.Point(562, 28);
            this.lblLowPrice.Name = "lblLowPrice";
            this.lblLowPrice.Size = new System.Drawing.Size(18, 20);
            this.lblLowPrice.TabIndex = 5;
            this.lblLowPrice.Text = "0";
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Location = new System.Drawing.Point(478, 80);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(69, 16);
            this.lblHigh.TabIndex = 4;
            this.lblHigh.Text = "Total high:";
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.Location = new System.Drawing.Point(478, 32);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(64, 16);
            this.lblLow.TabIndex = 3;
            this.lblLow.Text = "Total low:";
            // 
            // btnUpdateLow
            // 
            this.btnUpdateLow.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateLow.Location = new System.Drawing.Point(477, 277);
            this.btnUpdateLow.Name = "btnUpdateLow";
            this.btnUpdateLow.Size = new System.Drawing.Size(281, 46);
            this.btnUpdateLow.TabIndex = 2;
            this.btnUpdateLow.Text = "Update low file";
            this.btnUpdateLow.UseVisualStyleBackColor = true;
            this.btnUpdateLow.Click += new System.EventHandler(this.btnUpdateLow_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(477, 225);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(282, 46);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update high file";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // rtbResult
            // 
            this.rtbResult.Location = new System.Drawing.Point(7, 7);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(464, 287);
            this.rtbResult.TabIndex = 0;
            this.rtbResult.Text = "";
            // 
            // tabStock
            // 
            this.tabStock.Controls.Add(this.btnClear);
            this.tabStock.Controls.Add(this.rtbOneStock);
            this.tabStock.Controls.Add(this.btnData);
            this.tabStock.Controls.Add(this.tbMonths);
            this.tabStock.Controls.Add(this.label2);
            this.tabStock.Controls.Add(this.lbName);
            this.tabStock.Controls.Add(this.tbStockName);
            this.tabStock.Location = new System.Drawing.Point(4, 25);
            this.tabStock.Name = "tabStock";
            this.tabStock.Padding = new System.Windows.Forms.Padding(3);
            this.tabStock.Size = new System.Drawing.Size(769, 331);
            this.tabStock.TabIndex = 1;
            this.tabStock.Text = "Search stock";
            this.tabStock.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(17, 217);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(321, 50);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear tab";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rtbOneStock
            // 
            this.rtbOneStock.Location = new System.Drawing.Point(358, 16);
            this.rtbOneStock.Name = "rtbOneStock";
            this.rtbOneStock.Size = new System.Drawing.Size(401, 307);
            this.rtbOneStock.TabIndex = 5;
            this.rtbOneStock.Text = "";
            // 
            // btnData
            // 
            this.btnData.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnData.Location = new System.Drawing.Point(17, 273);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(321, 50);
            this.btnData.TabIndex = 4;
            this.btnData.Text = "Get data";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // tbMonths
            // 
            this.tbMonths.Location = new System.Drawing.Point(17, 150);
            this.tbMonths.Name = "tbMonths";
            this.tbMonths.Size = new System.Drawing.Size(321, 22);
            this.tbMonths.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 48);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter the amount of months of histroric that you want to retrieve:";
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(14, 24);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(324, 45);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Enter a ticker for the stock that you want to retrive data:";
            // 
            // tbStockName
            // 
            this.tbStockName.Location = new System.Drawing.Point(17, 72);
            this.tbStockName.Name = "tbStockName";
            this.tbStockName.Size = new System.Drawing.Size(321, 22);
            this.tbStockName.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 361);
            this.Controls.Add(this.tcLowHigh);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcLowHigh.ResumeLayout(false);
            this.tabMinHigh.ResumeLayout(false);
            this.tabMinHigh.PerformLayout();
            this.tabStock.ResumeLayout(false);
            this.tabStock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcLowHigh;
        private System.Windows.Forms.TabPage tabMinHigh;
        private System.Windows.Forms.TabPage tabStock;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbMonths;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbStockName;
        private System.Windows.Forms.RichTextBox rtbOneStock;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdateLow;
        private System.Windows.Forms.Label lblHighPrice;
        private System.Windows.Forms.Label lblLowPrice;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

