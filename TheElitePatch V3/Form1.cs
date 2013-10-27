﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Net;

namespace TheElitePatch_V3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ObjectForScripting = new ScriptManager(this);
        }
        string[] loadfiles = new string[] { Directory.GetCurrentDirectory() + @"\tep.html", Directory.GetCurrentDirectory() + @"\bg.png", Directory.GetCurrentDirectory() + @"\spriteh.png", Directory.GetCurrentDirectory() + @"\update.exe" };
        private void Form1_Load(object sender, EventArgs e)
        {
            #region set title
            string os = "Windows Edition";
            string targetframework = ".Net 4.0 Client Profile";
            if (IsRunningOnMono())
            {
                targetframework = "Mono 2.8";
            }
            if (isLinux())
            {
                os = "Linux Edition";
            }
            else if (isMacOS())
            {
                os = "Mac OSX Edition";
            }
            else if (isWindows())
            {
                os = "Windows Edition";
            }
            this.Text = "The Elite Patch - V" + TheElitePatch_V3.Properties.Settings.Default.buildver + " - " + targetframework + " - " + os;
            #endregion
            #region choose running mode
            if (CheckForInternetConnection())
            {
                webBrowser1.Navigate("http://tep.theelitepatch.com/");
            }
            else
            {
                foreach (string resource_name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                {
                    string filetocheck = Directory.GetCurrentDirectory() + @"\" + resource_name.Substring((resource_name.IndexOf(".") + 1), (resource_name.Length - (resource_name.IndexOf(".") + 1)));
                    filetocheck = filetocheck.Substring((filetocheck.IndexOf(".") + 1), (filetocheck.Length - (filetocheck.IndexOf(".") + 1)));
                    if (filetocheck.Contains(".png") || filetocheck.Contains(".html"))
                    {
                        filetocheck = Directory.GetCurrentDirectory() + @"\" + filetocheck;
                        if (!File.Exists(filetocheck))
                        {
                            ExtractFileResource(resource_name, filetocheck);
                        }
                    }
                }
                webBrowser1.Navigate("file://" + Directory.GetCurrentDirectory() + @"\tep.html");
            }
            #endregion
        }
        [ComVisible(true)]
        #region web interactions
        public class ScriptManager
        {
            Form1 _form;
            public ScriptManager(Form1 form)
            {
                _form = form;
            }
            public void OpenUrl(object obj)
            {
                Process.Start(obj.ToString());
            }
            public void PatchHost(object hoststring)
            {
                string hosts = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\drivers\etc\hosts";
                try
                {
                    string[] patchdata = hoststring.ToString().Split('=');
                    foreach (string contents in patchdata)
                    {
                        System.IO.File.AppendAllText(hosts, Environment.NewLine + contents + Environment.NewLine);
                    }
                    MessageBox.Show("Successfully patched!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There has been an error patching!" + Environment.NewLine + "Exact Error: " + ex.Message);
                }
            }
            public void RemoveHost(object instring)
            {
                string[] line = instring.ToString().Split('=');
                string file = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\drivers\etc\hosts";
                try
                {
                    if (!System.IO.File.Exists(file) && System.IO.File.Exists(file + "bak"))
                        System.IO.File.Copy(file + "bak", file);
                    string[] strArray = System.IO.File.ReadAllLines(file);
                    System.IO.File.WriteAllText(file + "tmp", "");
                    if (System.IO.File.Exists(file + "new"))
                        System.IO.File.Delete(file + "new");
                    if (System.IO.File.Exists(file + "bak"))
                        System.IO.File.Delete(file + "bak");
                    else
                        System.IO.File.Copy(file, file + "bak");
                    foreach (string str in strArray)
                    {
                        string lines = str;
                        if (!Enumerable.Any<string>((IEnumerable<string>)line, (Func<string, bool>)(s => lines.Contains(s))))
                            System.IO.File.AppendAllText(file + "tmp", lines + Environment.NewLine);
                    }
                    System.IO.File.Delete(file);
                    System.IO.File.Copy(file + "tmp", file);
                    MessageBox.Show("Host Removed Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There has been an error removing this host!" + Environment.NewLine + "Exact Error: " + ex.Message);
                }
            }
            public string LoggedInUser()
            {
                return TheElitePatch_V3.Properties.Settings.Default.user;
            }
            public void setUser(object user)
            {
                TheElitePatch_V3.Properties.Settings.Default.user = user.ToString();
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            public void logout()
            {
                TheElitePatch_V3.Properties.Settings.Default.user = "";
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            public void VerifSite(object Veriflink)
            {
                Process.Start(Veriflink.ToString());
            }
            public void VersSite(object verlnk)
            {
                Process.Start(verlnk.ToString());
            }
            public void VisitSite(object site)
            {
                Process.Start(site.ToString());
            }
            public int programversion()
            {
                return TheElitePatch_V3.Properties.Settings.Default.progver;
            }
            public bool checklogins()
            {
                bool loggedin = false;
                if (!String.IsNullOrEmpty(TheElitePatch_V3.Properties.Settings.Default.user))
                {
                    loggedin = true;
                }
                return loggedin;
            }
            public void setFriendlyVersion(object verstring)
            {
                TheElitePatch_V3.Properties.Settings.Default.buildver = verstring.ToString();
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            string updurl = "";
            public void update(object updateurl)
            {
                updurl = updateurl.ToString();
                WebClient WC = new WebClient();
                WC.DownloadFileCompleted += new AsyncCompletedEventHandler(WC_DownloadFileCompleted);
                WC.DownloadFileAsync(new Uri("http://download.theelitepatch.com/update.exe"), Directory.GetCurrentDirectory() + @"\update.exe");
            }
            void WC_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            {
                string file = Process.GetCurrentProcess().ProcessName + ".exe";
                file = file.Replace(" ", "_");
                file = file.Replace(".vshost", "");
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.Arguments = updurl + " " + file;
                psi.FileName = "update.exe";
                p.StartInfo = psi;
                p.Start();
                Environment.Exit(0);
            }
        }
        #endregion
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (string loadfile in loadfiles)
            {
                if (File.Exists(loadfile))
                {
                    File.Delete(loadfile);
                }
            }
            Environment.Exit(0);
        }
        #region system checks
        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://theelitepatch.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool isLinux()
        {
            return false;
        }
        public static bool isWindows()
        {
            return true;
        }
        public static bool isMacOS()
        {
            return false;
        }
        #endregion
        static void ExtractFileResource(string resource_name, string file_name)
        {
            try
            {
                if (File.Exists(file_name))
                    File.Delete(file_name);

                if (!Directory.Exists(Path.GetDirectoryName(file_name)))
                    Directory.CreateDirectory(Path.GetDirectoryName(file_name));

                using (Stream sfile = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource_name))
                {
                    byte[] buf = new byte[sfile.Length];
                    sfile.Read(buf, 0, Convert.ToInt32(sfile.Length));

                    using (FileStream fs = File.Create(file_name))
                    {
                        fs.Write(buf, 0, Convert.ToInt32(sfile.Length));
                        fs.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Can't extract resource '{0}' to file '{1}': {2}", resource_name, file_name, ex.Message), ex);
            }
        }
    }
}
