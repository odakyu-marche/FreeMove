﻿namespace FreeMove
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_From = new System.Windows.Forms.TextBox();
            this.button_BrowseFrom = new System.Windows.Forms.Button();
            this.button_BrowseTo = new System.Windows.Forms.Button();
            this.textBox_To = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button_Move = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_Close = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOnProgramStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PermissionCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safeModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportAnIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Move From:";
            // 
            // textBox_From
            // 
            this.textBox_From.AllowDrop = true;
            this.textBox_From.Location = new System.Drawing.Point(82, 31);
            this.textBox_From.Name = "textBox_From";
            this.textBox_From.Size = new System.Drawing.Size(383, 19);
            this.textBox_From.TabIndex = 1;
            this.textBox_From.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_From_DragDrop);
            this.textBox_From.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_From_DragEnter);
            // 
            // button_BrowseFrom
            // 
            this.button_BrowseFrom.Location = new System.Drawing.Point(475, 31);
            this.button_BrowseFrom.Name = "button_BrowseFrom";
            this.button_BrowseFrom.Size = new System.Drawing.Size(75, 21);
            this.button_BrowseFrom.TabIndex = 2;
            this.button_BrowseFrom.Text = "Browse...";
            this.button_BrowseFrom.UseVisualStyleBackColor = true;
            this.button_BrowseFrom.Click += new System.EventHandler(this.Button_BrowseFrom_Click);
            // 
            // button_BrowseTo
            // 
            this.button_BrowseTo.Location = new System.Drawing.Point(475, 54);
            this.button_BrowseTo.Name = "button_BrowseTo";
            this.button_BrowseTo.Size = new System.Drawing.Size(75, 21);
            this.button_BrowseTo.TabIndex = 4;
            this.button_BrowseTo.Text = "Browse...";
            this.button_BrowseTo.UseVisualStyleBackColor = true;
            this.button_BrowseTo.Click += new System.EventHandler(this.Button_BrowseTo_Click);
            // 
            // textBox_To
            // 
            this.textBox_To.AllowDrop = true;
            this.textBox_To.Location = new System.Drawing.Point(82, 55);
            this.textBox_To.Name = "textBox_To";
            this.textBox_To.Size = new System.Drawing.Size(383, 19);
            this.textBox_To.TabIndex = 3;
            this.textBox_To.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_To_DragDrop);
            this.textBox_To.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_From_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "To:";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // button_Move
            // 
            this.button_Move.Location = new System.Drawing.Point(475, 109);
            this.button_Move.Name = "button_Move";
            this.button_Move.Size = new System.Drawing.Size(75, 21);
            this.button_Move.TabIndex = 6;
            this.button_Move.Text = "Move";
            this.button_Move.UseVisualStyleBackColor = true;
            this.button_Move.Click += new System.EventHandler(this.Button_Move_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 88);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(166, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Set original folder to hidden";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(12, 109);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 21);
            this.button_Close.TabIndex = 7;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(565, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdateToolStripMenuItem,
            this.PermissionCheckToolStripMenuItem,
            this.safeModeToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkNowToolStripMenuItem,
            this.checkOnProgramStartToolStripMenuItem});
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for update";
            // 
            // checkNowToolStripMenuItem
            // 
            this.checkNowToolStripMenuItem.Name = "checkNowToolStripMenuItem";
            this.checkNowToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.checkNowToolStripMenuItem.Text = "Check now";
            this.checkNowToolStripMenuItem.Click += new System.EventHandler(this.CheckNowToolStripMenuItem_Click);
            // 
            // checkOnProgramStartToolStripMenuItem
            // 
            this.checkOnProgramStartToolStripMenuItem.Name = "checkOnProgramStartToolStripMenuItem";
            this.checkOnProgramStartToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.checkOnProgramStartToolStripMenuItem.Text = "Check on program start";
            this.checkOnProgramStartToolStripMenuItem.Click += new System.EventHandler(this.CheckOnProgramStartToolStripMenuItem_Click);
            // 
            // PermissionCheckToolStripMenuItem
            // 
            this.PermissionCheckToolStripMenuItem.Name = "PermissionCheckToolStripMenuItem";
            this.PermissionCheckToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.PermissionCheckToolStripMenuItem.Text = "Full permission check";
            this.PermissionCheckToolStripMenuItem.ToolTipText = "If enabled checks for write permission on each file BEFORE starting to move (it\'s" +
    " needed to move the files).\r\nElse eventual Unauthorized Access Exceptions will b" +
    "e detected when moving.";
            this.PermissionCheckToolStripMenuItem.Click += new System.EventHandler(this.FullPermissionCheckToolStripMenuItem_Click);
            // 
            // safeModeToolStripMenuItem
            // 
            this.safeModeToolStripMenuItem.Checked = true;
            this.safeModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.safeModeToolStripMenuItem.Name = "safeModeToolStripMenuItem";
            this.safeModeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.safeModeToolStripMenuItem.Text = "Safe mode";
            this.safeModeToolStripMenuItem.Click += new System.EventHandler(this.SafeModeToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportAnIssueToolStripMenuItem,
            this.gitHubToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // reportAnIssueToolStripMenuItem
            // 
            this.reportAnIssueToolStripMenuItem.Name = "reportAnIssueToolStripMenuItem";
            this.reportAnIssueToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.reportAnIssueToolStripMenuItem.Text = "Report an Issue";
            this.reportAnIssueToolStripMenuItem.Click += new System.EventHandler(this.ReportAnIssueToolStripMenuItem_Click);
            // 
            // gitHubToolStripMenuItem
            // 
            this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            this.gitHubToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.gitHubToolStripMenuItem.Text = "GitHub";
            this.gitHubToolStripMenuItem.Click += new System.EventHandler(this.GitHubToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 138);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button_Move);
            this.Controls.Add(this.button_BrowseTo);
            this.Controls.Add(this.textBox_To);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_BrowseFrom);
            this.Controls.Add(this.textBox_From);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Free Move";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_From;
        private System.Windows.Forms.Button button_BrowseFrom;
        private System.Windows.Forms.Button button_BrowseTo;
        private System.Windows.Forms.TextBox textBox_To;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button_Move;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportAnIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkOnProgramStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PermissionCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safeModeToolStripMenuItem;
    }
}

