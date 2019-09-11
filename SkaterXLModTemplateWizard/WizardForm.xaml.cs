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
using System.IO;


namespace SkaterXLModTemplateWizard {
    /// <summary>
    /// Interaction logic for WizardForm.xaml
    /// </summary>
    public partial class WizardForm {
        public bool AddingProjectToExistingSolution = false;

        public WizardForm() {
            InitializeComponent();
        }

        public static bool CheckURL(string url) {
            return Uri.TryCreate(url.Trim(), UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private void Submit_Click(object sender, RoutedEventArgs e) {
            bool valid = true;
            if (!File.Exists(this.GameDirectory.Text.Trim() + @"\SkaterXL.exe")) {
                // not game directory
                MessageBox.Show("Invalid game directory!", "Error");
                valid = false;
            }
            if (!File.Exists(this.SteamExecutable.Text.Trim())) {
                // not steam executable
                MessageBox.Show("Steam executable not found!", "Error");
                valid = false;
            }
            if (DisplayName.Text.Trim() == "") {
                MessageBox.Show("Mod Display Name required!", "Error");
                valid = false;
            }
            if (AuthorID.Text.Trim() == "") {
                MessageBox.Show("Author ID required!", "Error");
                valid = false;
            }
            if (AuthorName.Text.Trim() == "") {
                MessageBox.Show("Author Name required!", "Error");
                valid = false;
            }
            if (ModHomepage.Text.Trim() != "") {
                if (!CheckURL(ModHomepage.Text)) {
                    MessageBox.Show("Invalid URL! Mod Homepage must either be left blank, or a valid url");
                    valid = false;
                }
            }
            if (ModRepo.Text.Trim() != "") {
                if (!CheckURL(ModRepo.Text)) {
                    MessageBox.Show("Invalid URL! Mod Repo must either be left blank, or a valid url");
                    valid = false;
                }
            }

            if (valid) {
                this.Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void SteamBrowse_Click(object sender, RoutedEventArgs e) {

        }

        private void GameBrowse_Click(object sender, RoutedEventArgs e) {

        }

        private void UseModMenu_Changed(object sender, RoutedEventArgs e) {
            AddModComponent.IsEnabled = UseModMenu.IsChecked ?? false;
            AddModComponent.IsChecked = false;
            ModMenuSampleCode.IsEnabled = UseModMenu.IsChecked ?? false;
            ModMenuSampleCode.IsChecked = false;
        }

        private void ModSettings_Changed(object sender, RoutedEventArgs e) {
            UMMSettingsGUI.IsEnabled = ModSettings.IsChecked ?? false;
            UMMSettingsGUI.IsChecked = false;
        }
    }
}
