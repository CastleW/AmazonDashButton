using System;
using System.Diagnostics;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AmazonDashUI
{
    /// <summary>
    /// The main form class
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Prevent saving settings while still loading them
        /// </summary>
        private bool loadingSettings = false;

        /// <summary>
        /// The network socket for listening for receiving messages
        /// </summary>
        private Socket mainSocket;

        /// <summary>
        /// The buffer for raw network messages
        /// </summary>
        private byte[] byteData = new byte[4096];

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The callback to make a cross-thread call to the UI
        /// </summary>
        /// <param name="hardwareAddress">The hardware address from the DHCP message</param>
        internal delegate void DashButtonPressCallback(string hardwareAddress);

        /// <inheritdoc/>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            this.mainSocket.Bind(new IPEndPoint(IPAddress.Any, 67));

            this.LoadSettings();

            this.mainSocket.BeginReceive(this.byteData, 0, this.byteData.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
        }

        /// <inheritdoc/>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            var tempSocket = this.mainSocket;
            if (tempSocket == null)
            {
                return;
            }

            this.mainSocket = null;
            tempSocket.Shutdown(SocketShutdown.Both);
            tempSocket.Close();
        }

        /// <summary>
        /// Called when a socket message is received
        /// </summary>
        /// <param name="ar">The result object containing the status and message</param>
        private void OnReceive(IAsyncResult ar)
        {
            var tempSocket = this.mainSocket;

            if (tempSocket == null)
            {
                return;
            }

            try
            {
                var received = tempSocket.EndReceive(ar);

                this.HandleMessage(this.byteData, received);

                tempSocket.BeginReceive(this.byteData, 0, this.byteData.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AmazonDashUI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This handles the raw network message
        /// </summary>
        /// <param name="bytes">The raw bytes of the message</param>
        /// <param name="received">The number of bytes received</param>
        private void HandleMessage(byte[] bytes, int received)
        {
            var message = new DHCPMessageHelper(bytes, received);
            if (message.OperationCode != OperationCode.Request)
            {
                return;
            }

            if (message.HardwareType != HardwareType.Ethernet)
            {
                return;
            }

            var callback = new DashButtonPressCallback(this.OnDashButtonPressed);
            this.Invoke(callback, new object[] { message.ClientHardwareAddress });
        }

        /// <summary>
        /// This carries out the action associated with pushing the button
        /// </summary>
        /// <param name="hardwareAddress">The hardware address of the button</param>
        private void OnDashButtonPressed(string hardwareAddress)
        {
            this.lastButtonDetected.Text = hardwareAddress;

            if ((this.specificButton.Checked && (hardwareAddress == this.specificButtonToAllow.Text)) || this.allowAnyButton.Checked)
            {
                this.TakeAction();
            }
        }

        /// <summary>
        /// Take action only on a specific button
        /// </summary>
        /// <param name="sender">The sender of the button click</param>
        /// <param name="e">Additional arguments</param>
        private void UseOnlyThisButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lastButtonDetected.Text))
            {
                return;
            }

            this.specificButton.Checked = true;
            this.allowAnyButton.Checked = false;
            this.specificButtonToAllow.Text = this.lastButtonDetected.Text;

            this.SaveSettings();
        }

        /// <summary>
        /// When this form is minimized show the tray icon
        /// </summary>
        /// <param name="sender">The sender of the resize message</param>
        /// <param name="e">Resize message arguments</param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        /// <summary>
        /// When the tray icon is clicked open the form
        /// </summary>
        /// <param name="sender">The sender of the message</param>
        /// <param name="e">Mouse event arguments</param>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = false;
        }

        /// <summary>
        /// Load settings from the user store
        /// </summary>
        private void LoadSettings()
        {
            this.loadingSettings = true;

            this.allowAnyButton.Checked = Properties.Settings.Default.AnyButton;
            this.specificButton.Checked = !Properties.Settings.Default.AnyButton;
            this.specificButtonToAllow.Text = Properties.Settings.Default.SpecificButton;
            this.webPageToOpen.Text = Properties.Settings.Default.WebPageToOpen;
            this.playChime.Checked = Properties.Settings.Default.PlayChime;
            this.openThisWebPage.Checked = !Properties.Settings.Default.PlayChime;

            this.loadingSettings = false;
        }

        /// <summary>
        /// Save settings to the user store
        /// </summary>
        private void SaveSettings()
        {
            if (this.loadingSettings)
            {
                return;
            }

            Properties.Settings.Default.AnyButton = this.allowAnyButton.Checked;
            Properties.Settings.Default.SpecificButton = this.specificButtonToAllow.Text;
            Properties.Settings.Default.WebPageToOpen = this.webPageToOpen.Text;
            Properties.Settings.Default.PlayChime = this.playChime.Checked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// If the Allow Any button changes state, save the settings
        /// </summary>
        /// <param name="sender">The sender of the message</param>
        /// <param name="e">Checked message arguments</param>
        private void allowAnyButton_CheckedChanged(object sender, EventArgs e)
        {
            this.SaveSettings();
        }

        /// <summary>
        /// If the Allow Any button changes state, save the settings
        /// </summary>
        /// <param name="sender">The sender of the message</param>
        /// <param name="e">Checked message arguments</param>
        private void specificButton_CheckedChanged(object sender, EventArgs e)
        {
            this.SaveSettings();
        }

        /// <summary>
        /// If the Play Chime button changes state, save the settings
        /// </summary>
        /// <param name="sender">The sender of the message</param>
        /// <param name="e">Checked message arguments</param>
        private void playChime_CheckedChanged(object sender, EventArgs e)
        {
            this.SaveSettings();
        }

        /// <summary>
        /// If the Open This Web Page button changes state, save the settings
        /// </summary>
        /// <param name="sender">The sender of the message</param>
        /// <param name="e">Checked message arguments</param>
        private void openThisWebPage_CheckedChanged(object sender, EventArgs e)
        {
            this.SaveSettings();
        }

        /// <summary>
        /// If the specific text is changed, save the settings
        /// </summary>
        /// <param name="sender">The sender of the message</param>
        /// <param name="e">Text changed message arguments</param>
        private void specificButtonToAllow_TextChanged(object sender, EventArgs e)
        {
            this.SaveSettings();
        }

        /// <summary>
        /// If the web page to open text is changed, save the settings
        /// </summary>
        /// <param name="sender">The sender of the message</param>
        /// <param name="e">Text changed message arguments</param>
        private void webPageToOpen_TextChanged(object sender, EventArgs e)
        {
            this.SaveSettings();
        }

        /// <summary>
        /// Show the configured web page
        /// </summary>
        /// <param name="sender">The sender of the message</param>
        /// <param name="e">Click message arguments</param>
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            this.OpenWebPage();
        }

        /// <summary>
        /// Take action now that the button has been pressed
        /// </summary>
        private void TakeAction()
        {
            if (this.playChime.Checked)
            {
                this.PlayDoorbell();
            }
            else
            {
                this.OpenWebPage();
            }
        }

        /// <summary>
        /// This opens the configured web page using the default browser
        /// </summary>
        private void OpenWebPage()
        {
            Process.Start($"{this.webPageToOpen.Text}", "--start-fullscreen");
        }

        /// <summary>
        /// Play the doorbell chime
        /// </summary>
        private void PlayDoorbell()
        {
            using (var str = Properties.Resources.doorbell)
            {
                SoundPlayer snd = new SoundPlayer(str);
                snd.Play();
            }
        }
    }
}
