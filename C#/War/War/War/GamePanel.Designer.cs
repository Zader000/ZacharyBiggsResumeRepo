namespace War
{
    partial class GamePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlayer2Card = new System.Windows.Forms.Label();
            this.lblPlayer2Info = new System.Windows.Forms.Label();
            this.lblPlayer1Info = new System.Windows.Forms.Label();
            this.lblPlayer1Card = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1093, 796);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1087, 119);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "War";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblPlayer2Card, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPlayer2Info, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPlayer1Info, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPlayer1Card, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 123);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.4065F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.5935F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1086, 669);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblPlayer2Card
            // 
            this.lblPlayer2Card.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayer2Card.AutoSize = true;
            this.lblPlayer2Card.Location = new System.Drawing.Point(546, 69);
            this.lblPlayer2Card.Name = "lblPlayer2Card";
            this.lblPlayer2Card.Size = new System.Drawing.Size(537, 600);
            this.lblPlayer2Card.TabIndex = 3;
            this.lblPlayer2Card.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPlayer2Info
            // 
            this.lblPlayer2Info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayer2Info.AutoSize = true;
            this.lblPlayer2Info.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayer2Info.Location = new System.Drawing.Point(546, 0);
            this.lblPlayer2Info.Name = "lblPlayer2Info";
            this.lblPlayer2Info.Size = new System.Drawing.Size(537, 69);
            this.lblPlayer2Info.TabIndex = 1;
            this.lblPlayer2Info.Text = "   ";
            this.lblPlayer2Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer1Info
            // 
            this.lblPlayer1Info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayer1Info.AutoSize = true;
            this.lblPlayer1Info.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayer1Info.Location = new System.Drawing.Point(3, 0);
            this.lblPlayer1Info.Name = "lblPlayer1Info";
            this.lblPlayer1Info.Size = new System.Drawing.Size(537, 69);
            this.lblPlayer1Info.TabIndex = 0;
            this.lblPlayer1Info.Text = "   ";
            this.lblPlayer1Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer1Card
            // 
            this.lblPlayer1Card.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayer1Card.AutoSize = true;
            this.lblPlayer1Card.Location = new System.Drawing.Point(3, 69);
            this.lblPlayer1Card.Name = "lblPlayer1Card";
            this.lblPlayer1Card.Size = new System.Drawing.Size(537, 600);
            this.lblPlayer1Card.TabIndex = 2;
            this.lblPlayer1Card.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPlayer1Card.Click += new System.EventHandler(this.lblPlayer1Card_Click);
            // 
            // GamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GamePanel";
            this.Size = new System.Drawing.Size(1099, 804);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTitle;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblPlayer2Info;
        private Label lblPlayer1Info;
        private Label lblPlayer1Card;
        private Label lblPlayer2Card;

        public Label GetLblPlayer2Info()
        {
            return lblPlayer2Info;
        }

        public Label GetLblPlayer1Info()
        {
            return lblPlayer1Info;
        }

        public Label GetLblPlayer2Card()
        {
            return lblPlayer2Card;
        }

        public Label GetLblPlayer1Card()
        {
            return lblPlayer1Card;
        }

    }
}
