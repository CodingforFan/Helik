/*
 * Created by SharpDevelop.
 * User: Silen
 * Date: 30.1.2017
 * Time: 17:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Animator
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		List<string> Sprites = new List<string>();
		int i = 0;
		bool Pong = false;
		
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
		void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			foreach (string a in openFileDialog1.FileNames)
			{
				Sprites.Add(a);
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			if (Sprites.Count != 0) {
			timer1.Interval = (int) numericUpDown1.Value * 100;
			timer1.Enabled = true;
			i = 0;
			}
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			if(!checkBox1.Checked){
				if (i>Sprites.Count - 1)
				{
					i=0;
				}
				label1.Text = "Sprite" + i;
				pictureBox1.BackgroundImage = Image.FromFile(Sprites[i]);
				i++;
			}else{
				if(!Pong){
					if (i>=Sprites.Count - 1)
					{
						i --;
						Pong = true;
					}
					label1.Text = "Sprite" + i;
					pictureBox1.BackgroundImage = Image.FromFile(Sprites[i]);
					i++;
				}else{
					if (i < 1)
					{
						i++;
						Pong = false;
					}
					label1.Text = "Sprite" + i;
					pictureBox1.BackgroundImage = Image.FromFile(Sprites[i]);
					i--;
				}
			}
		}
		void PictureBox1Click(object sender, EventArgs e)
		{
			Sprites.Clear();
			openFileDialog1.ShowDialog();
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			
		}
	}
}
