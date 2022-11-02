#include "led.h"
#include "delay.h"
#include "sys.h"
#include "usart.h"
#include <stdio.h>
#include "timer.h"
#include "key.h"
#include "exti.h"
#include "adxl345.h"
#include "lcd1602.h"
#include "ds18b20.h" 

unsigned char ReadAdxl345;	   //定时读取adxl345数据
unsigned char ErrorNum=0;   //记录错误次数
unsigned char CheckNum=0;   //检测次数
	  
char dis0[16];//液晶数组显示暂存
char dis1[35];

unsigned int xlTab[5];//心率数组
unsigned char count=0;	//心率滤波计数
unsigned int xinLater=0;//	心率延时处理
unsigned int xinLv =0;    //心率值

unsigned int BuShu=0;//步数
unsigned int Normal_num=0;			//正常次数
unsigned int Error_num=0;			//倾斜次数

unsigned int disBuShu = 0;  //显示步数
float disJuLi = 0;//显示距离
float temperature;  //温度
unsigned char readTemp = 0;	//读取温度标志

int main(void)
 { 
	delay_init();	    	 //延时函数初始化	  
	uart_init(9600);	 	//串口初始化为9600
  TIM3_Int_Init(49,7199);//50ms  	
	EXTIX_Init();		// 初始化外部中断
	LED_Init();		  		//初始化与LED连接的硬件接口
	KEY_Init();			//初始化按键

	Lcd_GPIO_init();  //初始化lcd引脚
	Lcd_Init();		  //初始化lcd屏幕
	delay_ms(200);
	 
  Init_ADXL345();
  if(Single_Read_ADXL345(0X00)==0xe5)	
  {
    delay_ms(5);
  }
  else
  {
    delay_ms(3);
  }
	 
	while(1)
	{

    if(ReadAdxl345== 1)   //定时读取adxl345数据
    {
      ReadAdxl345= 0;
      ReadData_x();  						//三轴检测函数
      CheckNum++;
      if((temp_Y>450)||(temp_Y<-450)) //查看正常次数     
      {
        Normal_num++;  //正常次数++
      }
      else
      {
        Error_num++;//倾斜次数
      }
      if((Error_num!=0)&&(Normal_num!=0))//检测到步数
      {
				BuShu++;   //步数脉冲量++
        Error_num=0;    //清除一个周期检测
        Normal_num=0;
      }
    }
		
		if(disFlag==1)	   //显示标志
		{
			disFlag = 0;

			readTemp++;  //定时计数
			if(readTemp >= 8)//约800ms处理一次数据 温度
			{
				readTemp =0;//重新计数
				temperature=(float)DS18B20_Get_Temp()/10;	//缩小10倍为实际值			
			}
						
			disBuShu = BuShu/2;  //显示步数
			disJuLi = disBuShu*0.45;//显示距离
			
			sprintf(dis0,"X:%03d/min %4.1f C",xinLv,temperature);//打印
			Lcd_Puts(0,0,(unsigned char *)dis0);	//显示
			Lcd_1Put(14,0,0xdf);//显示符号
			sprintf(dis1,"BS:%03d JL:%4.1fm  ",disBuShu,disJuLi);//打印
			Lcd_Puts(0,1,(unsigned char *)dis1);	//显示
	
		}	
	}											    
}	





