// 代码生成时间: 2025-08-16 02:15:12
using System;
using System.Net.NetworkInformation;
using System.Windows; // For WPF

namespace NetworkStatusCheckerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NetworkChange networkChange;

        public MainWindow()
        {
            InitializeComponent();
            networkChange = new NetworkChange();
            networkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
        }

        /// <summary>
        /// Handler for NetworkAddressChanged event.
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (IsConnectedToInternet())
                {
                    // Update UI to show connected status
                    lblStatus.Content = "Connected";
                }
                else
                {
                    // Update UI to show disconnected status
                    lblStatus.Content = "Disconnected";
                }
            });
        }

        /// <summary>
        /// Method to check if the system is connected to the internet.
        /// </summary>
        /// <returns>True if connected, False otherwise</returns>
        private bool IsConnectedToInternet()
        {
            try
            {
                using (var ping = new Ping())
                {
                    PingReply reply = ping.Send("www.google.com");
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle it appropriately
                MessageBox.Show("Error checking internet connection: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Clean up resources when the window is closing.
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            networkChange.Dispose();
        }
    }

    /// <summary>
    /// Class to monitor network changes.
    /// </summary>
    public class NetworkChange : IDisposable
    {
        public event EventHandler NetworkAddressChanged;

        private NetworkChange nc;
        private bool isNetworkChangeRegistered;

        public NetworkChange()
        {
            nc = new NetworkChange("System.Net.NetworkInformation",
                "NetworkAddressChanged");
            nc.NetworkAddressChanged += new NetworkAddressChangedEventHandler(OnNetworkAddressChanged);
            isNetworkChangeRegistered = true;
        }

        public void Dispose()
        {
            if (isNetworkChangeRegistered)
            {
                isNetworkChangeRegistered = false;
                nc.NetworkAddressChanged -= new NetworkAddressChangedEventHandler(OnNetworkAddressChanged);
            }
        }

        private void OnNetworkAddressChanged(object sender, EventArgs e)
        {
            if (NetworkAddressChanged != null)
            {
                NetworkAddressChanged(this, e);
            }
        }
    }
}