using System;
using SD = System.Drawing;
using SWF = System.Windows.Forms;
using Eto.Forms;

namespace Eto.Platform.Windows
{
	public class TextAreaHandler : WindowsControl<System.Windows.Forms.TextBox, TextArea>, ITextArea
	{
		public TextAreaHandler()
		{
			Control = new SWF.TextBox();
			Control.Multiline = true;
			Control.AcceptsReturn = true;
			Control.AcceptsTab = true;
		}
		
		#region ITextArea Members
		
		public bool ReadOnly
		{
			get { return Control.ReadOnly; }
			set { Control.ReadOnly = value; }
		}
		
		#endregion
	}
}