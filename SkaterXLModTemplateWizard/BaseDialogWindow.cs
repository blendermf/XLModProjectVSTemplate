using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xaml;

namespace SkaterXLModTemplateWizard {
    public class BaseDialogWindow : DialogWindow {

        public BaseDialogWindow() {
            this.HasMaximizeButton = false;
            this.HasMinimizeButton = false;
            this.IsCloseButtonEnabled = false;
        }
    }
}
