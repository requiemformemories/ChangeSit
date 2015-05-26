/*
 * Created by SharpDevelop.
 * User: home
 * Date: 2014/9/2
 * Time: 下午 09:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace changesit
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		//string[] name= {"1  王俞蓓","2  江姿嫺","3  江逸思","4  周幸儀","5  林依萱","6  林芷均","7  張心藍","8  張家寧","9  張涵絜","10 張瑋儀","11 梁祐瑜","12 莊皓淳","13 許文菁","14 許晏甄","15 郭思妤","16 陳凱莘","17 曾齡儀","18 賀培瑄","19 黃  詒","20 黃台禮","21 黃怡菁","22 黃品媛","23 黃譓安","24 楊先雯","25 溫苡甯","26 廖怡婷","27 熊心瑜","28 趙煒婷","29 劉芳妤","30 蔡孟穎"};
		string[] name = new string[30];
		
		int[] remem={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}; 
		string[] remem2= {" ","1 王俞蓓","2 江姿嫺","3 江逸思","4 周幸儀","5 林依萱","6 林芷均","7 張心藍","8 張家寧","9 張涵絜","10 張瑋儀","11 梁祐瑜","12 莊皓淳","13 許文菁","14 許晏甄"," 15 郭思妤","16 陳凱莘","17 曾齡儀","18 賀培瑄","19 黃詒","20 黃台禮","21 黃怡菁","22 黃品媛","23 黃譓安","24 楊先雯","25 溫苡甯","26 廖怡婷","27 熊心瑜","28 趙煒婷","29 劉芳妤","30 蔡孟穎"};
		
		string str = System.Windows.Forms.Application.StartupPath;		
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
		

		
		void Button1Click(object sender, EventArgs e)
		{
			button1.Enabled = false;
			button2.Enabled = false;
			button3.Enabled = false;		
			
			System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Application.StartupPath+"\\music\\music.wav");
			System.Media.SoundPlayer sp2 = new System.Media.SoundPlayer(Application.StartupPath+"\\music\\surprise.wav");
			sp.Play(); 
			
			Random r= new Random(); 
			for(int i2=0;i2<=80;i2++)   //num
			{
				int[] array={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
				if(i2==80)  //num
				{
					for(int i=1;i<=30;i++)
					{
						int x =r.Next(0,30);
							while(array[x] == 1)
						{
							x =r.Next(0,30);
						}
						this.Controls.Find("label" + i, false)[0].Text = name[x];
						array[x] = 1;
						remem[x]=i;
						remem2[i]=name[x];
						Application.DoEvents(); //更新畫面	
					}
				}
				else
				{
					for(int i=1;i<=30;i++)
					{
						int x =r.Next(0,30);
						this.Controls.Find("label" + i, false)[0].Text = name[x];
					}
				Application.DoEvents(); //更新畫面
				Thread.Sleep(10);	
				
				}
				
			}
			
			
			/*for(int i=1;i<=30;i++)
			{
				for(int j=1;j<=10;j++)  ///每個數字亂碼一下下
				{
					int x2 =r.Next(0,30);
					this.Controls.Find("label" + i, false)[0].Text = Convert.ToString(x2+1);
					Application.DoEvents(); //更新畫面
					Thread.Sleep(50);
				}

				int x =r.Next(0,30);
					while(array[x] == 1)
				{
					x =r.Next(0,30);
				}
					this.Controls.Find("label" + i, false)[0].Text = name[x];
				array[x] = 1;
				Application.DoEvents(); //更新畫面
				//Thread.Sleep(100);
			}*/
			
			button1.Enabled = true; 
			button2.Enabled = true;
			button3.Enabled = true;
			textBox1.Visible =true;
			textBox2.Visible =true;
			label32.Visible =true;
			button2.Visible =true;
			button3.Visible =true;
			Thread.Sleep(20);
			sp2.Play(); 

			
		}
		
		
		
		void Button2Click(object sender, EventArgs e)  //A和B換座位
		{
			int cha1,cha2,temp1;
			cha1=Convert.ToInt32(textBox1.Text)-1;
			cha2=Convert.ToInt32(textBox2.Text)-1;
			try{
				this.Controls.Find("label" + remem[cha2], false)[0].Text = name[cha1];
				this.Controls.Find("label" + remem[cha1], false)[0].Text = name[cha2];
				remem2[remem[cha2]]=name[cha1];
				remem2[remem[cha1]]=name[cha2];
				
				temp1=remem[cha1];
				remem[cha1]=remem[cha2];
				remem[cha2]=temp1;
				
				//temp2=remem2[cha1];
				//remem2[cha1]=remem2[cha2];
				//remem2[cha2]=temp2;
				
				
			}
			catch(Exception)
			{
				MessageBox.Show("What are you talking about?");
			}
				
				
		}
		
	
		
		void Button3Click(object sender, EventArgs e)
		{
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@str + "\\sit.txt"))
				{
					file.WriteLine(remem2[1]+"   "+remem2[2]+"   "+remem2[3]+"   "+remem2[4]+"   "+remem2[5]+"   "+remem2[6]);
					file.WriteLine(remem2[7]+"   "+remem2[8]+"   "+remem2[9]+"   "+remem2[10]+"   "+remem2[11]+"   "+remem2[12]);
					file.WriteLine(remem2[13]+"   "+remem2[14]+"   "+remem2[15]+"   "+remem2[16]+"   "+remem2[17]+"   "+remem2[18]);
					file.WriteLine(remem2[19]+"   "+remem2[20]+"   "+remem2[21]+"   "+remem2[22]+"   "+remem2[23]+"   "+remem2[24]);
					file.WriteLine(remem2[25]+"   "+remem2[26]+"   "+remem2[27]+"   "+remem2[28]+"   "+remem2[29]+"   "+remem2[30]);
					
				}	
				
				MessageBox.Show("檔案已產生！");
			
		}
		
		void Button4Click(object sender, EventArgs e)
		{
        	
        	try{
        			// Read the file and display it line by line.
					System.IO.StreamReader file = new System.IO.StreamReader(@str + "\\students.txt");
					int count = 0;

					/*while(file.ReadLine() != null)
					{
  						name[count] = file.ReadLine();
   						count++;
					}*/
					/*while((name[count] = file.ReadLine()) != null)
					{
  						Console.WriteLine (name[count]);
   						count++;
					}*/
					while(count < 30)
					{
						//( name[count] = file.ReadLine() ) != null;
						name[count] = file.ReadLine();
						//MessageBox.Show(name[count]);
   						count++;
					}
					file.Close();
					
					MessageBox.Show("同學姓名已讀取！");
					button1.Enabled = true;
					label33.Visible = false;
					
        		}
				catch(Exception)
				{
					MessageBox.Show("Something went wrong.請檢查檔案students.txt是否有問題!!");
				}
				
			
				
			
		}
		
		
		void PictureBox1Click(object sender, EventArgs e)
		{
			MessageBox.Show("Hello~有事嗎?");
		}
	}
}
