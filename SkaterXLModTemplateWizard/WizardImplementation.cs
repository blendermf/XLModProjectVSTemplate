using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using EnvDTE;

namespace SkaterXLModTemplateWizard {
    using Templates;

    class WizardImplementation : IWizard {

        // Called before opening an item that has OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem) {

        }

        public void ProjectFinishedGenerating(Project project) {

        }

        // Only called for item templates, not project templates.
        public void ProjectItemFinishedGenerating(ProjectItem projectItem) {

        }

        // Called after project is created
        public void RunFinished() {

        }


        public void RunStarted(object automationObject, 
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams) {
            try {
                WizardForm form = new WizardForm();
                form.ShowDialog();

                Dictionary<string, object> templateParameters = new Dictionary<string, object>();

                templateParameters.Add("UseModMenu", form.UseModMenu.IsChecked ?? false);
                templateParameters.Add("ModSettings", form.ModSettings.IsChecked ?? false);
                templateParameters.Add("AddModComponent", (form.UseModMenu.IsChecked ?? false) && (form.AddModComponent.IsChecked ?? false) );
                templateParameters.Add("UMMSettingsGUI", (form.ModSettings.IsChecked ?? false) && (form.UMMSettingsGUI.IsChecked ?? false) );
                templateParameters.Add("ModMenuExampleCode", (form.UseModMenu.IsChecked ?? false) && (form.ModMenuSampleCode.IsChecked ?? false));
                templateParameters.Add("ModNamespace", replacementsDictionary["$safeprojectname$"]);
                templateParameters.Add("AuthorID",form.AuthorID.Text);
                templateParameters.Add("AuthorName", form.AuthorName.Text);
                templateParameters.Add("DisplayName", form.DisplayName.Text);
                templateParameters.Add("ModHomepage", form.ModHomepage.Text);
                templateParameters.Add("ModRepo", form.ModRepo.Text);

                MainTemplate mainTemplate = new MainTemplate();
                mainTemplate.Session = templateParameters;
                mainTemplate.Initialize();
                string mainContent = mainTemplate.TransformText();
                replacementsDictionary.Add("$maincontent$", mainContent);
                
                ModComponentTemplate modComponentTemplate = new ModComponentTemplate();
                modComponentTemplate.Session = templateParameters;
                modComponentTemplate.Initialize();
                string modComponentContent = modComponentTemplate.TransformText();
                replacementsDictionary.Add("$modcomponentcontent$", modComponentContent);

                InfoTemplate infoTemplate = new InfoTemplate();
                infoTemplate.Session = templateParameters;
                infoTemplate.Initialize();
                string infoContent = infoTemplate.TransformText();
                replacementsDictionary.Add("$infocontent$", infoContent);

            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        // Only called for item templates, not project templates.
        public bool ShouldAddProjectItem(string filePath) {
            Console.WriteLine("************   -   " + filePath);
            return true;
        }
    }
}
