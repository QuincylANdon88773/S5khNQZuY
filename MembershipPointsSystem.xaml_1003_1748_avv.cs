// 代码生成时间: 2025-10-03 17:48:55
 * MembershipPointsSystem.xaml.cs
 * This file implements a basic membership points system in a WPF application.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MembershipPointsSystem
{
    // MainWindow class represents the main window of the WPF application.
    public partial class MainWindow : Window
    {
        private readonly MembershipPointsManager pointsManager = new MembershipPointsManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Button click event handler to add points to a member.
        private void AddPoints_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string memberId = MemberIdTextBox.Text;
                int pointsToAdd = int.Parse(PointsToAddTextBox.Text);
                pointsManager.AddPoints(memberId, pointsToAdd);
                MessageBox.Show($"Added {pointsToAdd} points to member {memberId}.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number of points to add.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Button click event handler to deduct points from a member.
        private void DeductPoints_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string memberId = MemberIdTextBox.Text;
                int pointsToDeduct = int.Parse(PointsToDeductTextBox.Text);
                pointsManager.DeductPoints(memberId, pointsToDeduct);
                MessageBox.Show($"Deducted {pointsToDeduct} points from member {memberId}.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number of points to deduct.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }

    // MembershipPointsManager class manages the operations related to membership points.
    public class MembershipPointsManager
    {
        private Dictionary<string, int> memberPoints = new Dictionary<string, int>();

        // Adds points to a member's account.
        public void AddPoints(string memberId, int points)
        {
            if (memberPoints.ContainsKey(memberId))
            {
                memberPoints[memberId] += points;
            }
            else
            {
                memberPoints.Add(memberId, points);
            }
        }

        // Deducts points from a member's account.
        public void DeductPoints(string memberId, int points)
        {
            if (memberPoints.ContainsKey(memberId) && memberPoints[memberId] >= points)
            {
                memberPoints[memberId] -= points;
            }
            else
            {
                throw new InvalidOperationException($"Member {memberId} does not have enough points or does not exist.");
            }
        }
    }
}