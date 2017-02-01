/*
 * Created by SharpDevelop.
 * User: Asus
 * Date: 30. 1. 2017
 * Time: 17:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Helik
{
	public partial class MainForm : Form
	{
		Point target = new Point(0,0);
		int helikSpeed = 2;
		int doing;
		Random walkStand = new Random();
		Random rndX = new Random();
		Random rndY = new Random();
		Point moveDirector = new Point(0,0);
		List<string> spritesPaths = new List<string>();
		List<string> actualList = new List<string>();
		bool PingPong = false;
		bool Looping = false;
		bool Pong = false;
		int i = 0;
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			foreach(string a in Directory.GetFiles("./Skin")){
				spritesPaths.Add(a);
			}
			if(spritesPaths.Count > 0){
				BackgroundImage = Image.FromFile(spritesPaths[0]);
			}
			Move.Start();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			if(doing > 40 && doing < 43){
				if(target == new Point(0,0)){
					AnimPlay("Walk", 100, false, true);
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
				AnimPlay("Idle", 130, true, true);
			}
		}
		
		public void AnimPlay(string ID, int howSlow = 100, bool pingPong = false, bool loop = false){
			Anim.Interval = howSlow;
			PingPong = pingPong;
			Looping = loop;
			actualList = new List<string>();
			for(int i = 0; i < spritesPaths.Count; i++){
				if(spritesPaths[i].Contains(ID)){
					actualList.Add(spritesPaths[i]);
				}
			}
			Anim.Start();
		}
			
		void AnimTick(object sender, EventArgs e)
		{
			if(actualList.Count > 0){
				if(Looping){
					if(!PingPong){
						if (i>actualList.Count - 1)
						{
							i=0;
						}
						BackgroundImage = Image.FromFile(actualList[i]);
						i++;
					}else{
						if(!Pong){
							if (i>=actualList.Count - 1)
							{
								i --;
								Pong = true;
							}
							BackgroundImage = Image.FromFile(actualList[i]);
							i++;
						}else{
							if (i < 1)
							{
								i++;
								Pong = false;
							}
							BackgroundImage = Image.FromFile(actualList[i]);
							i--;
						}
					}
				}else{
					if(!PingPong){
						if (i>actualList.Count - 1)
						{
							i=0;
							Anim.Stop();
						}
						BackgroundImage = Image.FromFile(actualList[i]);
						i++;
					}else{
						if(!Pong){
							if (i>=actualList.Count - 1)
							{
								i --;
								Pong = true;
							}
							BackgroundImage = Image.FromFile(actualList[i]);
							i++;
						}else{
							if (i < 1)
							{
								i++;
								Pong = false;
								Anim.Stop();
							}
							BackgroundImage = Image.FromFile(actualList[i]);
							i--;
						}
					}
				}
			}
		}
	}
}
