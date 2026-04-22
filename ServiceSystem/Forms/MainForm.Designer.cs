namespace ServiceSystem.Forms
{
    partial class MainForm
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
            this.pnTop = new System.Windows.Forms.Panel();
            this.pblog = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.pnBody = new System.Windows.Forms.Panel();
            this.btnMontlyService = new System.Windows.Forms.Button();
            this.btnRecieveMoney = new System.Windows.Forms.Button();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.btnUnits = new System.Windows.Forms.Button();
            this.btnElectric = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblog)).BeginInit();
            this.pnBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.Maroon;
            this.pnTop.Controls.Add(this.pblog);
            this.pnTop.Controls.Add(this.label1);
            this.pnTop.Controls.Add(this.lblDate);
            this.pnTop.Controls.Add(this.lblRole);
            this.pnTop.Controls.Add(this.lblCurrentUser);
            this.pnTop.ForeColor = System.Drawing.Color.White;
            this.pnTop.Location = new System.Drawing.Point(13, 13);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(955, 73);
            this.pnTop.TabIndex = 0;
            // 
            // pblog
            // 
            this.pblog.Image = global::ServiceSystem.Properties.Resources.square;
            this.pblog.Location = new System.Drawing.Point(145, 14);
            this.pblog.Name = "pblog";
            this.pblog.Size = new System.Drawing.Size(51, 50);
            this.pblog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pblog.TabIndex = 4;
            this.pblog.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("RudawRegular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "چوارچرای نوێ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("RudawRegular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(661, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(31, 23);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "📅";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("RudawRegular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(505, 41);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(31, 23);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "👤";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(469, 18);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(32, 21);
            this.lblCurrentUser.TabIndex = 0;
            this.lblCurrentUser.Text = "👤";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("RudawRegular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(19, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Programmer: Awder Anwar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("RudawRegular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(249, 530);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 27);
            this.label6.TabIndex = 4;
            this.label6.Text = "+9647701542773";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("RudawRegular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Maroon;
            this.btnRefresh.Location = new System.Drawing.Point(451, 534);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(99, 31);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "🔃 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("RudawRegular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Maroon;
            this.btnLogout.Location = new System.Drawing.Point(699, 534);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(99, 31);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("RudawRegular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Maroon;
            this.btnClose.Location = new System.Drawing.Point(819, 534);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 31);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "❌ Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Font = new System.Drawing.Font("RudawRegular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.Maroon;
            this.btnBackup.Location = new System.Drawing.Point(574, 534);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(99, 31);
            this.btnBackup.TabIndex = 13;
            this.btnBackup.Text = "📇 Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            // 
            // pnBody
            // 
            this.pnBody.BackgroundImage = global::ServiceSystem.Properties.Resources.pngtree_abstract_particles_background_with_geometric_connection_concept_vector_illustration_picture_image_1233144;
            this.pnBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnBody.Controls.Add(this.btnMontlyService);
            this.pnBody.Controls.Add(this.btnRecieveMoney);
            this.pnBody.Controls.Add(this.btnMaintenance);
            this.pnBody.Controls.Add(this.btnUnits);
            this.pnBody.Controls.Add(this.btnElectric);
            this.pnBody.Controls.Add(this.btnDelete);
            this.pnBody.Controls.Add(this.btnReport);
            this.pnBody.Controls.Add(this.btnSettings);
            this.pnBody.Controls.Add(this.btnUserManagement);
            this.pnBody.Location = new System.Drawing.Point(13, 106);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(917, 394);
            this.pnBody.TabIndex = 8;
            // 
            // btnMontlyService
            // 
            this.btnMontlyService.BackColor = System.Drawing.Color.White;
            this.btnMontlyService.Font = new System.Drawing.Font("RudawRegular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMontlyService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMontlyService.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMontlyService.Location = new System.Drawing.Point(419, 63);
            this.btnMontlyService.Name = "btnMontlyService";
            this.btnMontlyService.Size = new System.Drawing.Size(117, 80);
            this.btnMontlyService.TabIndex = 12;
            this.btnMontlyService.Text = "Monthly Service";
            this.btnMontlyService.UseVisualStyleBackColor = false;
            this.btnMontlyService.Click += new System.EventHandler(this.btnMontlyService_Click);
            // 
            // btnRecieveMoney
            // 
            this.btnRecieveMoney.BackColor = System.Drawing.Color.White;
            this.btnRecieveMoney.Font = new System.Drawing.Font("RudawRegular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecieveMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRecieveMoney.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecieveMoney.Location = new System.Drawing.Point(32, 63);
            this.btnRecieveMoney.Name = "btnRecieveMoney";
            this.btnRecieveMoney.Size = new System.Drawing.Size(117, 80);
            this.btnRecieveMoney.TabIndex = 12;
            this.btnRecieveMoney.Text = "Recieve Money";
            this.btnRecieveMoney.UseVisualStyleBackColor = false;
            this.btnRecieveMoney.Click += new System.EventHandler(this.btnRecieveMoney_Click);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.BackColor = System.Drawing.Color.White;
            this.btnMaintenance.Font = new System.Drawing.Font("RudawRegular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintenance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMaintenance.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMaintenance.Location = new System.Drawing.Point(788, 63);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(126, 80);
            this.btnMaintenance.TabIndex = 11;
            this.btnMaintenance.Text = "Maintenance";
            this.btnMaintenance.UseVisualStyleBackColor = false;
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // btnUnits
            // 
            this.btnUnits.BackColor = System.Drawing.Color.White;
            this.btnUnits.Font = new System.Drawing.Font("RudawRegular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUnits.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUnits.Location = new System.Drawing.Point(226, 63);
            this.btnUnits.Name = "btnUnits";
            this.btnUnits.Size = new System.Drawing.Size(117, 80);
            this.btnUnits.TabIndex = 11;
            this.btnUnits.Text = "Units";
            this.btnUnits.UseVisualStyleBackColor = false;
            this.btnUnits.Click += new System.EventHandler(this.btnUnits_Click);
            // 
            // btnElectric
            // 
            this.btnElectric.BackColor = System.Drawing.Color.White;
            this.btnElectric.Font = new System.Drawing.Font("RudawRegular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElectric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnElectric.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnElectric.Location = new System.Drawing.Point(610, 63);
            this.btnElectric.Name = "btnElectric";
            this.btnElectric.Size = new System.Drawing.Size(117, 80);
            this.btnElectric.TabIndex = 10;
            this.btnElectric.Text = "Electric";
            this.btnElectric.UseVisualStyleBackColor = false;
            this.btnElectric.Click += new System.EventHandler(this.btnElectric_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("RudawRegular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.Location = new System.Drawing.Point(543, 218);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 80);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Deleted Records";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.White;
            this.btnReport.Font = new System.Drawing.Font("RudawRegular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReport.Location = new System.Drawing.Point(90, 218);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(117, 80);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.Font = new System.Drawing.Font("RudawRegular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSettings.Location = new System.Drawing.Point(738, 218);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(126, 80);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = System.Drawing.Color.White;
            this.btnUserManagement.Font = new System.Drawing.Font("RudawRegular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUserManagement.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUserManagement.Location = new System.Drawing.Point(319, 218);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(117, 80);
            this.btnUserManagement.TabIndex = 8;
            this.btnUserManagement.Text = "User Management";
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1001, 592);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.pnBody);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblog)).EndInit();
            this.pnBody.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnBody;
        private System.Windows.Forms.Button btnMontlyService;
        private System.Windows.Forms.Button btnRecieveMoney;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.Button btnUnits;
        private System.Windows.Forms.Button btnElectric;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.PictureBox pblog;
    }
}