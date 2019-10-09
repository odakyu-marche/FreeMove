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
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace FreeMove
{
    public partial class Form1 : Form
    {
        bool safeMode = true;

        #region Initialization
        public Form1()
        {
            //Initialize UI elements
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            SetToolTips();

            //Check whether the program is set to update on its start
            if (Settings.AutoUpdate)
            {
                //Update the menu item accordingly
                checkOnProgramStartToolStripMenuItem.Checked = true;
                //Start a background update task
                Updater updater = await Task<bool>.Run(() => Updater.SilentCheck());
                //If there is an update show the update dialog
                if (updater != null) updater.ShowDialog();
            }
            if (Settings.PermCheck)
            {
                PermissionCheckToolStripMenuItem.Checked = true;
            }
        }

        #endregion

        #region SymLink
        //External dll functions
        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(
        string lpSymlinkFileName, string lpTargetFileName, SymbolicLink dwFlags);

        enum SymbolicLink
        {
            File = 0,
            Directory = 1
        }

        private bool MakeLink(string directory, string symlink)
        {
            return CreateSymbolicLink(symlink, directory, SymbolicLink.Directory);
        }
        #endregion

        #region Private Methods
        private bool CheckFolders(string source, string destination)
        {
            bool passing = true; //Set to false if there are one or more errors
            string errors = ""; //String to show if there is any error

            //Check for correct file path format
            try
            {
                Path.GetFullPath(source);
                Path.GetFullPath(destination);
            }
            catch (Exception)
            {
                errors += "ERROR, invalid path name\n\n";
                passing = false;
            }
            string pattern = @"^[A-Za-z]:\\{1,2}";
            if (!Regex.IsMatch(source, pattern) || !Regex.IsMatch(destination, pattern))
            {
                errors += "ERROR, invalid path format\n\n";
                passing = false;
            }

            //Check if the chosen directory is blacklisted
            string[] Blacklist = { @"C:\Windows", @"C:\Windows\System32", @"C:\Windows\Config", @"C:\ProgramData" };
            foreach (string item in Blacklist)
            {
                if (source == item)
                {
                    errors += $"Sorry, the \"{source}\" directory cannot be moved.\n\n";
                    passing = false;
                }
            }

            //Check if folder is critical
            if(safeMode)
            if( //Regex.IsMatch(source, "^" + Environment.GetFolderPath(Environment.SpecialFolder.Windows)) ||
                source == Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) ||
                source == Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86))
            {
                    errors += $"It's recommended not to move the {source} directory, you can disable safe mode in the Settings tab to override this check";
                    passing = false;
            }

            //Check for existence of directories
            if (!Directory.Exists(source))
            {
                errors += "ERROR, source folder doesn't exist\n\n";
                passing = false;
            }
            if (Directory.Exists(destination))
            {
                errors += "ERROR, destination folder already contains a folder with the same name\n\n";
                passing = false;
            }
            if (passing && !Directory.Exists(Directory.GetParent(destination).FullName))
            {
                errors += "destination folder doesn't exist\n\n";
                passing = false;
            }

            if (passing)
            {
                //Check admin privileges
                string TestFile = Path.Combine(Path.GetDirectoryName(source), "deleteme");
                while (File.Exists(TestFile)) TestFile += new Random().Next(0, 10).ToString();
                try
                {
                    //Try creating a file to check permissions
                    System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(source);
                    File.Create(TestFile).Close();
                }
                catch (UnauthorizedAccessException)
                {
                    errors += "You do not have the required privileges to move the directory.\nTry running as administrator\n\n";
                    passing = false;
                }
                finally
                {
                    if (File.Exists(TestFile))
                        File.Delete(TestFile);
                }

                //Try to create a symbolic link to check permissions
                if (!CreateSymbolicLink(TestFile, Path.GetDirectoryName(destination), SymbolicLink.Directory))
                {
                    errors += "Could not create a symbolic link.\nTry running as administrator\n\n";
                    passing = false;
                }
                if (Directory.Exists(TestFile))
                    Directory.Delete(TestFile);

                //If set to do full check try to open for write all files
                if (passing && Settings.PermCheck)
                {
                    try
                    {
                        Parallel.ForEach(Directory.GetFiles(source), file =>
                        {
                            CheckFile(file);
                        });
                        Parallel.ForEach(Directory.GetDirectories(source), dir =>
                        {
                            Parallel.ForEach(Directory.GetFiles(dir), file =>
                            {
                                CheckFile(file);
                            });
                        });
                    }
                    catch(Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                    {
                        passing = false;
                        errors += $"{ex.Message}\n";
                    }

                    void CheckFile(string file)
                    {
                        FileInfo fi = new FileInfo(file);
                        FileStream fs = null;
                        try
                        {
                            fs = fi.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                        }
                        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                        {
                            passing = false;
                            errors += $"{ex.Message}\n";
                        }
                        finally
                        {
                            if (fs != null)
                                fs.Dispose();
                        }
                    }
                }
            }

            //Check if there's enough free space on disk
            if (passing)
            {
                long Size = 0;
                DirectoryInfo Dest = new DirectoryInfo(source);
                foreach (FileInfo file in Dest.GetFiles("*", SearchOption.AllDirectories))
                {
                    Size += file.Length;
                }
                DriveInfo DestDrive = new DriveInfo(Path.GetPathRoot(destination));
                if (DestDrive.AvailableFreeSpace < Size)
                {
                    errors += $"There is not enough free space on the {DestDrive.Name} disk. {Size / 1000000}MB required, {DestDrive.AvailableFreeSpace / 1000000} available.\n\n";
                    passing = false;
                }
            }


            if (!passing)
                MessageBox.Show(errors, "Errors encountered during preliminary phase");

            return passing;
        }

        private void Begin()
        {
            //Get the original and the new path from the textboxes
            string source, destination;
            source = textBox_From.Text.TrimEnd('\\');
            destination = Path.Combine(textBox_To.Text.Length > 3 ? textBox_To.Text.TrimEnd('\\') : textBox_To.Text, Path.GetFileName(source));

            //Check for errors before copying
            if (CheckFolders(source, destination))
            {
                bool success;

                //Move files
                //If the paths are on the same drive use the .NET Move() method
                if (Directory.GetDirectoryRoot(source) == Directory.GetDirectoryRoot(destination))
                {
                    try
                    {
                        button_Move.Text = "Moving...";
                        Enabled = false;
                        Directory.Move(source, destination);
                        success = true;
                    }
                    catch (IOException ex)
                    {
                        Unauthorized(ex);
                        success = false;
                    }
                    finally
                    {
                        button_Move.Text = "Move";
                        Enabled = true;
                    }
                }
                //If they are on different drives move them manually using filestreams
                else
                {
                    success = StartMoving(source, destination, false);
                }

                //Link the old paths to the new location
                if (success)
                {
                    if (MakeLink(destination, source))
                    {
                        //If told to make the link hidden
                        if (checkBox1.Checked)
                        {
                            DirectoryInfo olddir = new DirectoryInfo(source);
                            var attrib = File.GetAttributes(source);
                            olddir.Attributes = attrib | FileAttributes.Hidden;
                        }
                        MessageBox.Show("Done.");
                        Reset();
                    }
                    else
                    {
                        //Handle linking error
                        var result = MessageBox.Show(Properties.Resources.ErrorUnauthorizedLink, "ERROR, could not create a directory junction", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            StartMoving(destination, source, true, "Wait, moving files back...");
                        }
                    }
                }
            }

        }

        private bool StartMoving(string source, string destination, bool doNotReplace, string ProgressMessage)
        {
            var mvDiag = new MoveDialog(source, destination, doNotReplace, ProgressMessage);
            mvDiag.ShowDialog();
            return mvDiag.Result;
        }

        private bool StartMoving(string source, string destination, bool doNotReplace)
        {
            var mvDiag = new MoveDialog(source, destination, doNotReplace);
            mvDiag.ShowDialog();
            return mvDiag.Result;
        }

        //Configure tooltips
        private void SetToolTips()
        {
            ToolTip Tip = new ToolTip()
            {
                ShowAlways = true,
                AutoPopDelay = 5000,
                InitialDelay = 600,
                ReshowDelay = 500
            };
            Tip.SetToolTip(this.textBox_From, "Select the folder you want to move");
            Tip.SetToolTip(this.textBox_To, "Select where you want to move the folder");
            Tip.SetToolTip(this.checkBox1, "Select whether you want to hide the shortcut which is created in the old location or not");
        }

        private void Reset()
        {
            textBox_From.Text = "";
            textBox_To.Text = "";
            textBox_From.Focus();
        }

        public static void Unauthorized(Exception ex)
        {
            MessageBox.Show(Properties.Resources.ErrorUnauthorizedMoveDetails + ex.Message, "Error details");
        }
        #endregion

        #region Event Handlers
        private void Button_Move_Click(object sender, EventArgs e)
        {
            Begin();
        }

        //Show a directory picker for the source directory
        private void Button_BrowseFrom_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_From.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        //Show a directory picker for the destination directory
        private void Button_BrowseTo_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_To.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        //Start on enter key press
        private void TextBox_To_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Begin();
            }
        }

        //Close the form
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Open GitHub page
        private void GitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/imDema/FreeMove");
        }

        //Open the report an issue page on GitHub
        private void ReportAnIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/imDema/FreeMove/issues/new");
        }

        //Show an update dialog
        private void CheckNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Updater().ShowDialog();
        }

        //Set to check updates on program start
        private void CheckOnProgramStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.ToggleAutoUpdate();
            checkOnProgramStartToolStripMenuItem.Checked = Settings.AutoUpdate;
        }
        #endregion

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = String.Format(Properties.Resources.AboutContent, System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion);
            MessageBox.Show(msg, "About FreeMove");
        }

        private void FullPermissionCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.TogglePermCheck();
            PermissionCheckToolStripMenuItem.Checked = Settings.PermCheck;
        }

        private void SafeModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.DisableSafeModeMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                safeMode = false;
                safeModeToolStripMenuItem.Checked = false;
                safeModeToolStripMenuItem.Enabled = false;
            }
        }

        private void textBox_From_DragEnter(object sender, DragEventArgs e)
        {
            //コントロール内にドラッグされたとき実行される
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
                e.Effect = DragDropEffects.Copy;
            else
                //ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
        }

        private void textBox_From_DragDrop(object sender, DragEventArgs e)
        {
            //コントロール内にドロップされたとき実行される
            //ドロップされたすべてのファイル名を取得する
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
           if (Directory.Exists(files[0])) {
                textBox_From.Text = files[0];
           } else {
                textBox_From.Text = System.IO.Path.GetDirectoryName(files[0]);
           }
        }

        private void textBox_To_DragDrop(object sender, DragEventArgs e)
        {
            //コントロール内にドロップされたとき実行される
            //ドロップされたすべてのファイル名を取得する
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (Directory.Exists(files[0]))
            {
                textBox_To.Text = files[0];
            }
            else
            {
                textBox_To.Text = System.IO.Path.GetDirectoryName(files[0]);
            }
        }
    }
}
