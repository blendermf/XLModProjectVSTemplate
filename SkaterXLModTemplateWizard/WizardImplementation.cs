using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using EnvDTE;
using EnvDTE80;
using VSLangProj;

namespace SkaterXLModTemplateWizard {
    using Microsoft.VisualStudio.Shell;
    using Templates;

    class WizardImplementation : IWizard {
        Dictionary<string, object> templateParameters = null;

        bool outputModComponent = false;
        bool outputPatchExamples = false;
        bool outputRepoFile = false;

        // Called before opening an item that has OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem) {

        }

        public void ProjectFinishedGenerating(Project project) {
            DTE dte = project.DTE;

            var solItems = dte.Solution.Projects.Cast<Project>().FirstOrDefault(p => p.Name == "Solution Items" || p.Kind == EnvDTE.Constants.vsProjectItemKindSolutionItems);
            if (solItems == null) {
                Solution2 sol2 = (Solution2)dte.Solution;
                solItems = sol2.AddSolutionFolder("Solution Items");
                string solDir = Path.GetDirectoryName(sol2.FullName);

                if (outputRepoFile) {
                    RepositoryTemplate repositoryTemplate = new RepositoryTemplate {
                        Session = templateParameters
                    };
                    repositoryTemplate.Initialize();
                    string repositoryTemplateContent = repositoryTemplate.TransformText();
                    string repositoryFilePath = $"{solDir}\\repository.json";
                    File.WriteAllText(repositoryFilePath, repositoryTemplateContent);
                    solItems.ProjectItems.AddFromFile(repositoryFilePath);
                }

                ConfigTemplate configTemplate = new ConfigTemplate {
                    Session = templateParameters
                };
                configTemplate.Initialize();
                string configTemplateContent = configTemplate.TransformText();
                string configFilePath = $"{solDir}\\config.json";
                File.WriteAllText(configFilePath, configTemplateContent);
                solItems.ProjectItems.AddFromFile(configFilePath);

                string runtimePath = Directory.GetCurrentDirectory();
                solItems.ProjectItems.AddFromFileCopy(runtimePath + "\\.gitignore");
                solItems.ProjectItems.AddFromFileCopy(runtimePath + "\\pre_build.ps1");
                solItems.ProjectItems.AddFromFileCopy(runtimePath + "\\post_build.ps1");
                solItems.ProjectItems.AddFromFileCopy(runtimePath + "\\launch_game.ps1");

                // pre-copy references
                Directory.CreateDirectory($"{solDir}\\references");
                string referencesGitIgnorePath = $"{solDir}\\references\\.gitignore";
                File.WriteAllText(referencesGitIgnorePath, "*\n!.gitignore");

                string pre_build = $@"{solDir.Replace(@"\", @"\\")}\\pre_build.ps1";

                string argument = $@"-ExecutionPolicy Unrestricted -File ""{pre_build}"" -SolutionDir ""{solDir.Replace(@"\", @"\\")}\\""";
                if ((bool)templateParameters["UseModMenu"]) {
                    argument += @" -ModAssemblyReferences ""blendermf.XLShredMenu\\XLShredLib.dll""";
                }
                var process = new System.Diagnostics.Process {
                    StartInfo = new System.Diagnostics.ProcessStartInfo {
                        FileName = "powershell",
                        Arguments = argument,
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                process.WaitForExit();
            } else {
                var repo = solItems.ProjectItems.Cast<ProjectItem>().FirstOrDefault(p => p.Name == "repository.json");
            }

            (project.Object as VSProject)?.Refresh();

            foreach (Configuration config in project.ConfigurationManager) {
                config.Properties.Item("StartAction").Value = 1; // Launch external program
                config.Properties.Item("StartProgram").Value = @"C:\Windows\system32\WindowsPowerShell\v1.0\powershell.exe";
                config.Properties.Item("StartArguments").Value = @"-ExecutionPolicy Unrestricted -File ""./launch_game.ps1""";
                config.Properties.Item("StartWorkingDirectory").Value = @"../../../";
            }

            project.Save(project.FileName);
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
                DTE dte = automationObject as DTE;

                var solItems = dte.Solution.Projects.Cast<Project>().FirstOrDefault(p => p.Name == "Solution Items" || p.Kind == EnvDTE.Constants.vsProjectItemKindSolutionItems);
                if (solItems != null) {
                    form.HideSolutionOptions();
                }
                
                form.ShowDialog();

                if (form.Cancelled) {
                    throw new WizardBackoutException();
                }

                templateParameters = new Dictionary<string, object> {
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
                    { "ModRepo", form.ModRepo.Text },
                    { "GameDirectory", form.GameDirectory.Text.Replace(@"\", @"\\") },
                    { "SteamExecutable", form.SteamExecutable.Text.Replace(@"\", @"\\") }
                };

                outputModComponent = (form.UseModMenu.IsChecked ?? false) && (form.AddModComponent.IsChecked ?? false);
                outputPatchExamples = form.PatchSampleCode.IsChecked ?? false;
                outputRepoFile = form.AddRepoFile.IsChecked ?? false;

                replacementsDictionary.Add("$outputModComponent$", outputModComponent.ToString());
                replacementsDictionary.Add("$outputPatchExamples$", outputPatchExamples.ToString());
                replacementsDictionary.Add("$useModMenu$", (form.UseModMenu.IsChecked ?? false).ToString());

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
                String destinationDirectory = replacementsDictionary["$destinationdirectory$"];
                if (Directory.Exists(destinationDirectory)) {
                    Directory.Delete(destinationDirectory, true);

                    try {
                        Directory.GetParent(destinationDirectory).Delete();
                    } catch {}
                }

                Console.WriteLine(ex);

                throw ex;
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
