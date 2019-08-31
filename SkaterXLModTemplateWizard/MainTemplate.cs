﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace SkaterXLModTemplateWizard
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class MainTemplate : MainTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using UnityEngine;\r\nusing Harmony12;\r\nusing System.Reflection;\r\nusing UnityModMan" +
                    "agerNet;\r\nusing System;\r\n");
            
            #line 16 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

if (UseModMenu) {

            
            #line default
            #line hidden
            this.Write("using XLShredLib;\r\n");
            
            #line 20 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

}

            
            #line default
            #line hidden
            this.Write("\r\nnamespace ");
            
            #line 24 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ModNamespace));
            
            #line default
            #line hidden
            this.Write(" {\r\n\t");
            
            #line 25 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

	if (ModSettings) {
	
            
            #line default
            #line hidden
            this.Write(@"	[Serializable]
	public class Settings : UnityModManager.ModSettings {


		/*	
		========
		Insert Settings Here. 

		Normal fields/properties can be used here. eg:
		public float customSetting = 0f;
		========
		*/


		public Settings() : base() {


			/*	
			========
			Code ran when settings first loaded
			========
			*/


		}

		public override void Save(UnityModManager.ModEntry modentry) {
			UnityModManager.ModSettings.Save<Settings>(this, modEntry);
		}
	}
	");
            
            #line 58 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

	}
	
            
            #line default
            #line hidden
            this.Write("\r\n\tstatic class Main\r\n\t{\r\n\t\tpublic static bool enabled = false;\r\n\t\tpublic static " +
                    "Settings settings;\r\n\t\tpublic static String modId;\r\n\t\tpublic static HarmonyInstan" +
                    "ce harmonyInstance;\r\n\r\n\t\tstatic bool Load(UnityModManager.ModEntry modEntry) {\r\n" +
                    "\t\t\t");
            
            #line 70 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

			if (ModSettings) {
			
            
            #line default
            #line hidden
            this.Write("\t\t\tsettings = Settings.Load<Settings>(modEntry);\r\n\t\t\t");
            
            #line 74 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

			}
			
            
            #line default
            #line hidden
            this.Write("\t\t\tmodId = modEntry.Info.Id;\r\n\t\t\t");
            
            #line 78 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

			if (ModSettings) {
			
            
            #line default
            #line hidden
            this.Write("\t\t\tmodEntry.OnSaveGUI = OnSaveGUI;\r\n\t\t\t");
            
            #line 82 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

			}
			
            
            #line default
            #line hidden
            this.Write(@"			modEntry.OnToggle = OnToggle;


			/*	
			========
			Code ran when mod is first loaded by UMM (not necesarily enabled, so only use for stuff needed in both enabled and disabled state)
			========
			*/


			return true;
		}

		static bool OnToggle(UnityModManager.ModEntry modEntry, bool value) {
			if (enabled == value) return true; // toggle hasn't actually changed value somehow
            enabled = value;
            if (enabled) {
				// Do patching on enable
                harmonyInstance = HarmonyInstance.Create(modEntry.Info.Id);
                harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
				");
            
            #line 105 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

				if (AddModComponent) {
				
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t// Add component to ModMenu gameObject on enable\r\n                ModMenu.I" +
                    "nstance.gameObject.AddComponent<");
            
            #line 110 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ModNamespace));
            
            #line default
            #line hidden
            this.Write(">();\r\n\t\t\t\t");
            
            #line 111 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

				}
				
            
            #line default
            #line hidden
            this.Write("\r\n\r\n\t\t\t\t/*\t\r\n\t\t\t\t========\r\n\t\t\t\tCode ran when mod enabled\r\n\t\t\t\t========\r\n\t\t\t\t*/\r\n\r" +
                    "\n\r\n            } else {\r\n\t\t\t\t// Remove patches when disabled\r\n                ha" +
                    "rmonyInstance.UnpatchAll(harmonyInstance.Id);\r\n\t\t\t\t");
            
            #line 126 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

				if (AddModComponent) {
				
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t// Remove component from ModMenu gameObject when disabled\r\n                " +
                    "UnityEngine.Object.Destroy(ModMenu.Instance.gameObject.GetComponent<");
            
            #line 131 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ModNamespace));
            
            #line default
            #line hidden
            this.Write(">());\r\n\t\t\t\t");
            
            #line 132 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

				}
				
            
            #line default
            #line hidden
            this.Write("\r\n\r\n\t\t\t\t/*\t\r\n\t\t\t\t========\r\n\t\t\t\tCode ran when mod disabled (you should remove chan" +
                    "ges made on enable)\r\n\t\t\t\t========\r\n\t\t\t\t*/\r\n\r\n\r\n            }\r\n            return" +
                    " true;\r\n\t\t}\r\n\t\t");
            
            #line 147 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

		if (ModSettings) {
		
            
            #line default
            #line hidden
            this.Write("\t\tstatic void OnSaveGUI(UnityModManager.ModEntry modEntry) {\r\n            setting" +
                    "s.Save(modEntry);\r\n\r\n\r\n\t\t\t/*\t\r\n\t\t\t========\r\n\t\t\tPerform any other action when set" +
                    "tings are saved\r\n\t\t\t========\r\n\t\t\t*/\r\n\r\n\r\n        }\r\n\t\t");
            
            #line 162 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

		}
		
            
            #line default
            #line hidden
            this.Write("\r\n\t\t");
            
            #line 166 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

		if (UMMSettingsGUI) {
		
            
            #line default
            #line hidden
            this.Write(@"		public static void OnSettingsGUI(UnityModManager.ModEntry modEntry) {


			/*	
			========
			Insert GUI Code Here

			use GUILayout (https://docs.unity3d.com/ScriptReference/GUILayout.html) to add controls for settings here. eg:

			GUILayout.BeginHorizontal();
            GUILayout.Label(""Text Option"");
            GUILayout.Space(8);
            TextOption = GUILayout.TextField(TextOption, GUILayout.ExpandWidth(true));
			GUILayout.EndHorizontal();

			TextOption would be a string field in your Settings class.
			========
			*/


		}
		");
            
            #line 190 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

		}
		
            
            #line default
            #line hidden
            this.Write("\t}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\MainTemplate.tt"

private bool _UseModMenuField;

/// <summary>
/// Access the UseModMenu parameter of the template.
/// </summary>
private bool UseModMenu
{
    get
    {
        return this._UseModMenuField;
    }
}

private bool _ModSettingsField;

/// <summary>
/// Access the ModSettings parameter of the template.
/// </summary>
private bool ModSettings
{
    get
    {
        return this._ModSettingsField;
    }
}

private bool _AddModComponentField;

/// <summary>
/// Access the AddModComponent parameter of the template.
/// </summary>
private bool AddModComponent
{
    get
    {
        return this._AddModComponentField;
    }
}

private bool _UMMSettingsGUIField;

/// <summary>
/// Access the UMMSettingsGUI parameter of the template.
/// </summary>
private bool UMMSettingsGUI
{
    get
    {
        return this._UMMSettingsGUIField;
    }
}

private string _ModNamespaceField;

/// <summary>
/// Access the ModNamespace parameter of the template.
/// </summary>
private string ModNamespace
{
    get
    {
        return this._ModNamespaceField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool UseModMenuValueAcquired = false;
if (this.Session.ContainsKey("UseModMenu"))
{
    this._UseModMenuField = ((bool)(this.Session["UseModMenu"]));
    UseModMenuValueAcquired = true;
}
if ((UseModMenuValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("UseModMenu");
    if ((data != null))
    {
        this._UseModMenuField = ((bool)(data));
    }
}
bool ModSettingsValueAcquired = false;
if (this.Session.ContainsKey("ModSettings"))
{
    this._ModSettingsField = ((bool)(this.Session["ModSettings"]));
    ModSettingsValueAcquired = true;
}
if ((ModSettingsValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ModSettings");
    if ((data != null))
    {
        this._ModSettingsField = ((bool)(data));
    }
}
bool AddModComponentValueAcquired = false;
if (this.Session.ContainsKey("AddModComponent"))
{
    this._AddModComponentField = ((bool)(this.Session["AddModComponent"]));
    AddModComponentValueAcquired = true;
}
if ((AddModComponentValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("AddModComponent");
    if ((data != null))
    {
        this._AddModComponentField = ((bool)(data));
    }
}
bool UMMSettingsGUIValueAcquired = false;
if (this.Session.ContainsKey("UMMSettingsGUI"))
{
    this._UMMSettingsGUIField = ((bool)(this.Session["UMMSettingsGUI"]));
    UMMSettingsGUIValueAcquired = true;
}
if ((UMMSettingsGUIValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("UMMSettingsGUI");
    if ((data != null))
    {
        this._UMMSettingsGUIField = ((bool)(data));
    }
}
bool ModNamespaceValueAcquired = false;
if (this.Session.ContainsKey("ModNamespace"))
{
    this._ModNamespaceField = ((string)(this.Session["ModNamespace"]));
    ModNamespaceValueAcquired = true;
}
if ((ModNamespaceValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ModNamespace");
    if ((data != null))
    {
        this._ModNamespaceField = ((string)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class MainTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
