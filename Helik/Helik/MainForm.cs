/*
 * Created by SharpDevelop.
 * User: Asus
 * Date: 30. 1. 2017
 * Time: 17:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Helik
{
	public partial class MainForm : Form
	{
		Point target = new Point(0,0);
		int helikSpeed = 5;
		int doing;
		Random walkStand = new Random();
		Random rndX = new Random();
		Random rndY = new Random();
		Point moveDirector = new Point(0,0);
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			Move.Stop();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			Move.Start();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			if(doing > 40 && doing < 43){
				if(target == new Point(0,0)){
					target = new Point(rndX.Next(0 + Width/2, Screen.PrimaryScreen.WorkingArea.Width - Width/2), rndY.Next(0 + Height/2, Screen.PrimaryScreen.WorkingArea.Height - Height/2));
				}else{
					if(((Location.X + Width/2) - target.X) < -helikSpeed){
						moveDirector.X = helikSpeed;
					}else if(((Location.X + Width/2) - target.X) > helikSpeed){
						moveDirector.X = -helikSpeed;
					}else{
						moveDirector.X = 0;
					}
					if(((Location.Y + Height/2) - target.Y) < -helikSpeed){
						moveDirector.Y = helikSpeed;
					}else if(((Location.Y + Height/2) - target.Y) > helikSpeed){
						moveDirector.Y = -helikSpeed;
					}else{
						moveDirector.Y = 0;
					}
					Location = new Point(Location.X + moveDirector.X, Location.Y + moveDirector.Y);
					if(moveDirector == new Point(0,0)){
						doing = walkStand.Next(0, 100);
						target = new Point(0,0);
					}
				}	
			}else{
				doing = walkStand.Next(0, 100);
			}
		}
	}
}
