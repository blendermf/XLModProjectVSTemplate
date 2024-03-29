﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace SkaterXLModTemplateWizard.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class ModComponentTemplate : ModComponentTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using UnityEngine;\r\nusing XLShredLib;\r\nusing XLShredLib.UI;\r\n\r\nusing System;\r\nusi" +
                    "ng System.Linq;\r\n\r\nnamespace ");
            
            #line 17 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ModNamespace));
            
            #line default
            #line hidden
            this.Write(" {\r\n\r\n    class ");
            
            #line 19 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ModNamespace));
            
            #line default
            #line hidden
            this.Write(" : MonoBehaviour {\r\n\r\n        private ModUIBox uiBox;\r\n\r\n\r\n\t\t/*\r\n\t\t========\r\n\t\tIn" +
                    "sert mod fields\r\n\t\t========\r\n\t\t*/\r\n\r\n\r\n ");
            
            #line 31 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
 if (ModMenuExampleCode) { 
            
            #line default
            #line hidden
            this.Write("\t\t// Example Labels\r\n\t\tprivate ModUILabel uiLabelTextExample;\r\n        private Mo" +
                    "dUILabel uiLabelToggleExample;\r\n\t\tprivate ModUILabel uiLabelButtonExample;\r\n\r\n ");
            
            #line 37 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("        public void Start() {\r\n\r\n            uiBox = ModMenu.Instance.RegisterMod" +
                    "Maker(\"");
            
            #line 40 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AuthorID));
            
            #line default
            #line hidden
            this.Write("\", \"");
            
            #line 40 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AuthorName));
            
            #line default
            #line hidden
            this.Write("\");\r\n\r\n\r\n\t\t\t/*\r\n\t\t\t========\r\n\t\t\tInsert mod component setup\r\n\t\t\t========\r\n\t\t\t*/\r\n\r" +
                    "\n\r\n ");
            
            #line 50 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
 if (ModMenuExampleCode) { 
            
            #line default
            #line hidden
            this.Write(@"			// Text Label Example
			uiLabelTextExample = uiBox.AddLabel(""label-text-example"", ""A Text Label Example"", Side.left,
											() => true /* label visibility, can control with some logic if you like */, 
											2 /* optional priority setting */);

			// Toggle Label Example
            uiLabelToggleExample = uiBox.AddLabel(""label-toggle-example"", LabelType.Toggle, ""A Toggle Label Example"", Side.left, 
													() => true /* label visibility, can control with some logic if you like */, 
													false /* initial toggle value, eg: Main.settings.someToggle */, 
													(b) => { /* store toggle value, eg: Main.settings.someToggle = b */ },
													1 /* optional priority setting */);

			// Button Label Example
            uiLabelButtonExample = uiBox.AddLabel(""label-button-example"", LabelType.Button, ""A Toggle Button Example"", Side.left, 
													() => true /* label visibility, can control with some logic if you like */, 
													false /* initial toggle value, eg: Main.settings.someToggle */, 
													(b) => { /* perform action on click */ },
													0 /* optional priority setting */);

			// Control Timescale Example (only include if you actually want to control that)
            ModMenu.Instance.RegisterTimeScaleTarget(Main.modId, () => {
                return 1.0f; // returns the target timescale.
            });

 ");
            
            #line 75 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("        }\r\n\r\n        public void Update() {\r\n\t\t\t\r\n\t\t\t\r\n\t\t\t/*\r\n\t\t\t========\r\n\t\t\tRan" +
                    " every frame\r\n\t\t\t========\r\n\t\t\t*/\r\n\r\n\t\t\t\r\n ");
            
            #line 88 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
 if (ModMenuExampleCode) { 
            
            #line default
            #line hidden
            this.Write(@"			// Control Setting with Controller Button
            if (PlayerController.Instance.inputController.player.GetButtonSinglePressDown(""LB"")) {

				/* You can toggle a setting / toggle label for example
				=======

                Main.settings.someToggle = !Main.settings.someToggle;
                uiLabelToggleExample.SetToggleValue(Main.settings.someToggle);

                if (Main.settings.someToggle) {
                    ModMenu.Instance.ShowMessage(""Toggle Example: ON"");
                } else {
                    ModMenu.Instance.ShowMessage(""Toggle Example: OFF"");
                }

				*/

				/* Or perform an action
				=======

				PlayerController.Instance.ForceBail(); // Force Character to Bail

				ModMenu.Instance.HideCursor(Main.modId); // hide cursor
				ModMenu.Instance.ShowCursor(Main.modId); // show cursor
					
				ModMenu.Instance.EnableMenuHide(Main.modId); // temporary menu hide
				ModMenu.Instance.DisableMenuHide(Main.modId); // disable temporary menu hide

				*/

            }

			// Control setting with Keypress
			ModMenu.Instance.KeyPress(KeyCode.X, 0.2f /* time buffer between presses */, () => {

				// Perform an action (same examples from controller button apply)

			});

 ");
            
            #line 128 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("        }\r\n\r\n\t\tpublic void FixedUpdate() {\r\n\t\t\t\r\n\t\t\t\r\n\t\t\t/*\r\n\t\t\t========\r\n\t\t\tRan " +
                    "every physics tick\r\n\t\t\t========\r\n\t\t\t*/\r\n\r\n\t\t\t\r\n\t\t}\r\n\r\n        public void OnDest" +
                    "roy() {\r\n\t\t\t\r\n\t\t\t\r\n\t\t\t/*\r\n\t\t\t========\r\n\t\t\tClean up component\r\n\t\t\t========\r\n\t\t\t*/" +
                    "\r\n\r\n\t\t\t\r\n ");
            
            #line 153 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
 if (ModMenuExampleCode) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t// Remove labels from menu\r\n\t\t\tuiBox.RemoveLabel(\"label-text-example\");\r\n     " +
                    "       uiBox.RemoveLabel(\"label-toggle-example\");\r\n\t\t\tuiBox.RemoveLabel(\"label-b" +
                    "utton-example\");\r\n\r\n ");
            
            #line 159 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t}\r\n\r\n    }\r\n\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\ModComponentTemplate.tt"

private bool _ModMenuExampleCodeField;

/// <summary>
/// Access the ModMenuExampleCode parameter of the template.
/// </summary>
private bool ModMenuExampleCode
{
    get
    {
        return this._ModMenuExampleCodeField;
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

private string _AuthorIDField;

/// <summary>
/// Access the AuthorID parameter of the template.
/// </summary>
private string AuthorID
{
    get
    {
        return this._AuthorIDField;
    }
}

private string _AuthorNameField;

/// <summary>
/// Access the AuthorName parameter of the template.
/// </summary>
private string AuthorName
{
    get
    {
        return this._AuthorNameField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool ModMenuExampleCodeValueAcquired = false;
if (this.Session.ContainsKey("ModMenuExampleCode"))
{
    this._ModMenuExampleCodeField = ((bool)(this.Session["ModMenuExampleCode"]));
    ModMenuExampleCodeValueAcquired = true;
}
if ((ModMenuExampleCodeValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ModMenuExampleCode");
    if ((data != null))
    {
        this._ModMenuExampleCodeField = ((bool)(data));
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
bool AuthorIDValueAcquired = false;
if (this.Session.ContainsKey("AuthorID"))
{
    this._AuthorIDField = ((string)(this.Session["AuthorID"]));
    AuthorIDValueAcquired = true;
}
if ((AuthorIDValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("AuthorID");
    if ((data != null))
    {
        this._AuthorIDField = ((string)(data));
    }
}
bool AuthorNameValueAcquired = false;
if (this.Session.ContainsKey("AuthorName"))
{
    this._AuthorNameField = ((string)(this.Session["AuthorName"]));
    AuthorNameValueAcquired = true;
}
if ((AuthorNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("AuthorName");
    if ((data != null))
    {
        this._AuthorNameField = ((string)(data));
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
    public class ModComponentTemplateBase
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
