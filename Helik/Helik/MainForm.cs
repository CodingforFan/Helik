/*
 * Created by SharpDevelop.
 * User: Silen
 * Date: 30.1.2017
 * Time: 17:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Helik
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int helixSpeed = 5;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			Move(true);
		}
		
		public void Move(bool active){
			if(active){
				if(!timer1.Enabled){
					timer1.Start();
				}
				var mouses = new Point(0,0);
				if(((Location.X + Width/2) - MousePosition.X) > helixSpeed){
					mouses.X = -helixSpeed;
				}else if(((Location.X + Width/2) - MousePosition.X) < -helixSpeed){
					mouses.X = helixSpeed;
				}else{
					mouses.X = 0;
				}
				if(((Location.Y + Height/2) - MousePosition.Y) > helixSpeed){
					mouses.Y = -helixSpeed;
				}else if(((Location.Y + Height/2) - MousePosition.Y) < -helixSpeed){
					mouses.Y = helixSpeed;
				}else{
					mouses.Y = 0;
				}
				Location = new Point(Location.X + mouses.X, Location.Y + mouses.Y);
			}else{
				timer1.Stop();
			}
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			Move(true);
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			Move(false);
		}
	}
}
