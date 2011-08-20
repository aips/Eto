using System;
using System.Collections;
using System.Collections.Generic;
using Eto.Drawing;

namespace Eto.Forms
{
	public interface IContainer : IControl
	{
		Size ClientSize { get; set; }
		object ContainerObject { get; }
		void SetLayout(Layout layout);
	}
	
	public class Container : Control
	{
		IContainer inner;
		ControlCollection controls = new ControlCollection();

		public IEnumerable<Control> Controls
		{
			get { return controls; }
		}
		
		internal ControlCollection InnerControls
		{
			get { return controls; }
		}
		
		public override void OnLoad(EventArgs e)
		{
			
			foreach (Control control in controls)
			{
				control.OnLoad(e);
			}
			
			base.OnLoad(e);
			
			if (Layout != null) Layout.OnLoad (e);
		}

		public override void OnLoadComplete(EventArgs e)
		{
			
			foreach (Control control in controls)
			{
				control.OnLoadComplete(e);
			}
			
			base.OnLoadComplete(e);
			
			if (Layout != null) Layout.OnLoadComplete (e);
		}
		
		protected Container(Generator g, Type type, bool initialize = true) : base(g, type, initialize)
		{
			inner = (IContainer)base.Handler;
		}
		
		public object ContainerObject
		{
			get { return inner.ContainerObject; }
		}
		
		public Layout Layout { get; private set; }
		
		public Size ClientSize
		{
			get { return inner.ClientSize; }
			set { inner.ClientSize = value; }
		}

		
		public void SetLayout (Layout layout)
		{
			this.Layout = layout;
			inner.SetLayout(layout);
			if (Loaded) {
				layout.OnLoad (EventArgs.Empty);
				layout.OnLoadComplete (EventArgs.Empty);
			}
		}
	}
}