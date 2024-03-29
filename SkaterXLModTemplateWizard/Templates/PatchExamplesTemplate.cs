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
    
    #line 1 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\PatchExamplesTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class PatchExamplesTemplate : PatchExamplesTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

// This class contains a bunch of examples of the most common methods that I use when patching SkaterXL.
// More detail and info on all this can be found on the wiki for Harmony (https://github.com/pardeike/Harmony/wiki)

namespace ");
            
            #line 15 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\PatchExamplesTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ModNamespace));
            
            #line default
            #line hidden
            this.Write(".Patches {\r\n/*\r\n\t[HarmonyPatch(typeof(SomeClass), \"SomeMethod\")]\r\n\tstatic class S" +
                    "omeClass_SomeMethod_Patch {\r\n\r\n\t\t// you can prepare your state here / decide if " +
                    "the patch should happen\r\n\t\tstatic bool Prepare() {\r\n\t\t\t// Do whatever you need t" +
                    "o do before patching\r\n\r\n\t\t\treturn true; // do the patch\r\n\t\t}\r\n\r\n\t\t// a patch tha" +
                    "t runs before the original method\r\n\t\tstatic void Prefix() {\r\n\t\t\t// Do what you n" +
                    "eed to do\r\n\t\t}\r\n\r\n\t\t\r\n\t\t// a patch that runs before the original method and modi" +
                    "fies a private member of the class(someMember plus three underscores prefixing i" +
                    "t), \r\n\t\t// accesses the class instance, and takes a paramater from the original " +
                    "method (value)\r\n\t\tstatic void Prefix(SomeClass __instance, ref float ___someMemb" +
                    "er, float value) {\r\n\t\t\t// Do what you need to do\r\n\r\n\t\t\t// set ___someMember\r\n\t\t\t" +
                    "___someMember = value * 2.0f;\r\n\t\t}\r\n\r\n\t\t// a patch that runs before the original" +
                    " method, but can cancel the call to the original method and prefixes after this\r" +
                    "\n\t\tstatic bool Prefix() {\r\n\t\t\t// Do what you need to do\r\n\r\n\t\t\tif(cancelOriginalM" +
                    "ethod) {\r\n\t\t\t\treturn false;\r\n\t\t\t} else {\r\n\t\t\t\treturn true;\r\n\t\t\t}\r\n\t\t}\r\n\r\n\t\t// Re" +
                    "place function with return value\r\n\t\tstatic bool Prefix(ref string __result) {\r\n\t" +
                    "\t\t__result = \"theresult\"; // set the return value\r\n\t\t\treturn false; // skip the " +
                    "actual function, and any other prefixes after this one, be careful when doing th" +
                    "is\r\n\t\t}\r\n\r\n\t\t// a patch that runs after the original method\r\n\t\tstatic void Postf" +
                    "ix() {\r\n\t\t\t// Do what you need to do\r\n\t\t}\r\n\r\n\t\t// Change function with return va" +
                    "lue\r\n\t\tstatic void Postfix(ref string __result) {\r\n\t\t\t__result = \"theresult\"; //" +
                    " set the return value\r\n\t\t}\r\n\r\n\t\t// Replace function fully (can also do this with" +
                    " a prefix that returns false)\r\n\t\tstatic IEnumerable<CodeInstruction> Transpiler(" +
                    "IEnumerable<CodeInstruction> instructions) {\r\n            yield return new CodeI" +
                    "nstruction(OpCodes.Ldarg_0); // the first argument, which in the case of a class" +
                    " instance is the \'this\' variable (this is an implicit paramater)\r\n            yi" +
                    "eld return new CodeInstruction(OpCodes.Ldarg_1); // load argument 1 onto call st" +
                    "ack\r\n            yield return new CodeInstruction(OpCodes.Ldarg_2); // load argu" +
                    "ment 2 onto call stack\r\n            yield return new CodeInstruction(OpCodes.Cal" +
                    "l, AccessTools.Method(typeof(SomeClassExtensions), nameof(SomeClassExtensions.So" +
                    "meMethod1)); // call the method, in this case it\'s a c# extension method\r\n      " +
                    "      yield return new CodeInstruction(OpCodes.Ret); // return\r\n        }\r\n\r\n\t\t/" +
                    "/ skip some instructions in the original method, and also add our own code (if y" +
                    "ou want)\r\n\t\tstatic IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstr" +
                    "uction> instructions) {\r\n\t\t\tvar codes = instructions.ToList();\r\n\r\n\t\t\tint skipCou" +
                    "nt = 0;\r\n\r\n\t\t\tfor (int i = 0; i < codes.Count; i++) {\r\n\t\t\t\tvar inst = codes[i];\r" +
                    "\n\r\n\r\n\t\t\t\tif (skipCount > 0) {\r\n                    skipCount--;\r\n               " +
                    "     continue;\r\n                }\r\n\r\n\t\t\t\t// detect some instruction in the funct" +
                    "ion where you want to start the skipping of instructions, in this case\r\n\t\t\t\t// w" +
                    "here a field specific field is being set to a new value\r\n\t\t\t\tif (inst.opcode == " +
                    "OpCodes.Stfld\r\n                    && (FieldInfo)inst.operand == AccessTools.Fie" +
                    "ld(typeof(SomeClass), \"_someField\")) {\r\n\r\n\t\t\t\t\tskipCount = 10; // set how many i" +
                    "nstructions to skip at this point\r\n\r\n\t\t\t\t\tyield return inst; // assuming you\'re " +
                    "not skipping the instruction we\'re detecting but those after it, otherwise leave" +
                    " this out\r\n\r\n\t\t\t\t\t// can also insert some new instructions here to replace what " +
                    "is skipped,, in this case calling an extension method (with no arguments this ti" +
                    "me)\r\n\t\t\t\t\tyield return new CodeInstruction(OpCodes.Ldarg_0); // implicit this pa" +
                    "rameter\r\n                    yield return new CodeInstruction(OpCodes.Call, Acce" +
                    "ssTools.Method(typeof(SomeClassExtensions), nameof(SomeClassExtensions.SomeMetho" +
                    "d2)));\r\n                    continue;\r\n\t\t\t\t\t\r\n\t\t\t\t}\r\n\r\n\t\t\t\t// if it\'s not an ins" +
                    "truction we want to modify, return the original instruction at this index\r\n\t\t\t\ty" +
                    "ield return inst;\r\n\t\t\t}\r\n\r\n\t\t}\r\n\r\n\t}\r\n\r\n\t// C# extension methods\r\n\tpublic static" +
                    " class SomeClassExtensions {\r\n\t\tpublic static void SomeMethod1(this SomeClass ob" +
                    ", float arg1, float arg2) {\r\n\t\t\t// perform some action on the SomeClass instance" +
                    ", can access private fields/methods using Traverse (https://github.com/pardeike/" +
                    "Harmony/wiki/Utilities#traverse)\r\n\t\t}\r\n\r\n\t\tpublic static void SomeMethod1(this S" +
                    "omeClass ob) {\r\n\t\t\t// perform some action on the SomeClass instance, can access " +
                    "private fields/methods using Traverse (https://github.com/pardeike/Harmony/wiki/" +
                    "Utilities#traverse)\r\n\t\t}\r\n\t}\r\n*/\r\n}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\Users\blendermf\Documents\Visual Studio 2017\Projects\SkaterXLModTemplate\SkaterXLModTemplateWizard\Templates\PatchExamplesTemplate.tt"

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
    public class PatchExamplesTemplateBase
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
