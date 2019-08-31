using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using EnvDTE;

namespace SkaterXLModTemplateWizard {
    class WizardImplementation : IWizard {

        private UserInputForm inputForm;
        private string customMessage;

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
                //inputForm = new UserInputForm();
                //inputForm.ShowDialog();

                Dictionary<string, object> templateParameters = new Dictionary<string, object>();

                templateParameters.Add("UseModMenu", true);
                templateParameters.Add("ModSettings", true);
                templateParameters.Add("AddModComponent", true);
                templateParameters.Add("UMMSettingsGUI", true);
                templateParameters.Add("ModNamespace", replacementsDictionary["$safeprojectname$"]);

                MainTemplate mainTemplate = new MainTemplate();
                mainTemplate.Session = templateParameters;
                mainTemplate.Initialize();
                string mainContent = mainTemplate.TransformText();

                // Add custom paramaters.
                replacementsDictionary.Add("$maincontent$", mainContent);
            } catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        // Only called for item templates, not project templates.
        public bool ShouldAddProjectItem(string filePath) {
            Console.WriteLine(filePath);
            return true;
        }
    }
}
