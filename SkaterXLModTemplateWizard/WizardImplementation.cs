using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using EnvDTE;

namespace SkaterXLModTemplateWizard {
    using Templates;

    class WizardImplementation : IWizard {

        bool outputModComponent = false;
        bool outputPatchExamples = false;

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

                Dictionary<string, object> templateParameters = new Dictionary<string, object> {
                    { "UseModMenu", form.UseModMenu.IsChecked ?? false },
                    { "ModSettings", form.ModSettings.IsChecked ?? false },
                    { "AddModComponent", (form.UseModMenu.IsChecked ?? false) && (form.AddModComponent.IsChecked ?? false) },
                    { "UMMSettingsGUI", (form.ModSettings.IsChecked ?? false) && (form.UMMSettingsGUI.IsChecked ?? false) },
                    { "ModMenuExampleCode", (form.UseModMenu.IsChecked ?? false) && (form.ModMenuSampleCode.IsChecked ?? false) },
                    { "ModNamespace", replacementsDictionary["$safeprojectname$"] },
                    { "AuthorID", form.AuthorID.Text },
                    { "AuthorName", form.AuthorName.Text },
                    { "DisplayName", form.DisplayName.Text },
                    { "ModHomepage", form.ModHomepage.Text },
                    { "ModRepo", form.ModRepo.Text }
                };

                outputModComponent = (form.UseModMenu.IsChecked ?? false) && (form.AddModComponent.IsChecked ?? false);
                outputPatchExamples = form.PatchSampleCode.IsChecked ?? false;

                replacementsDictionary.Add("$outputModComponent$", outputModComponent.ToString());
                replacementsDictionary.Add("$outputPatchExamples$", outputPatchExamples.ToString());

                MainTemplate mainTemplate = new MainTemplate {
                    Session = templateParameters
                };
                mainTemplate.Initialize();
                string mainContent = mainTemplate.TransformText();
                replacementsDictionary.Add("$maincontent$", mainContent);

                ModComponentTemplate modComponentTemplate = new ModComponentTemplate {
                    Session = templateParameters
                };
                modComponentTemplate.Initialize();
                string modComponentContent = modComponentTemplate.TransformText();
                replacementsDictionary.Add("$modcomponentcontent$", modComponentContent);

                InfoTemplate infoTemplate = new InfoTemplate {
                    Session = templateParameters
                };
                infoTemplate.Initialize();
                string infoContent = infoTemplate.TransformText();
                replacementsDictionary.Add("$infocontent$", infoContent);

                PatchExamplesTemplate patchExamplesTemplate = new PatchExamplesTemplate {
                    Session = templateParameters
                };
                patchExamplesTemplate.Initialize();
                string patchExamplesContent = patchExamplesTemplate.TransformText();
                replacementsDictionary.Add("$patchexamplescontent$", patchExamplesContent);

            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        // Only called for item templates, not project templates.
        public bool ShouldAddProjectItem(string filePath) {
            switch (filePath) {
                case "ModComponent.cs.template":
                    return outputModComponent;
                case "PatchExamples.cs.template":
                    return outputPatchExamples;
                default:
                    return true;
            }
        }
    }
}
