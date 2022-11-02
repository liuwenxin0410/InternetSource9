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

unsigned char ReadAdxl345;	   //��ʱ��ȡadxl345����
unsigned char ErrorNum=0;   //��¼�������
unsigned char CheckNum=0;   //������
	  
char dis0[16];//Һ��������ʾ�ݴ�
char dis1[35];

unsigned int xlTab[5];//��������
unsigned char count=0;	//�����˲�����
unsigned int xinLater=0;//	������ʱ����
unsigned int xinLv =0;    //����ֵ

unsigned int BuShu=0;//����
unsigned int Normal_num=0;			//��������
unsigned int Error_num=0;			//��б����

unsigned int disBuShu = 0;  //��ʾ����
float disJuLi = 0;//��ʾ����
float temperature;  //�¶�
unsigned char readTemp = 0;	//��ȡ�¶ȱ�־

int main(void)
 { 
	delay_init();	    	 //��ʱ������ʼ��	  
	uart_init(9600);	 	//���ڳ�ʼ��Ϊ9600
  TIM3_Int_Init(49,7199);//50ms  	
	EXTIX_Init();		// ��ʼ���ⲿ�ж�
	LED_Init();		  		//��ʼ����LED���ӵ�Ӳ���ӿ�
	KEY_Init();			//��ʼ������

	Lcd_GPIO_init();  //��ʼ��lcd����
	Lcd_Init();		  //��ʼ��lcd��Ļ
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

    if(ReadAdxl345== 1)   //��ʱ��ȡadxl345����
    {
      ReadAdxl345= 0;
      ReadData_x();  						//�����⺯��
      CheckNum++;
      if((temp_Y>450)||(temp_Y<-450)) //�鿴��������     
      {
        Normal_num++;  //��������++
      }
      else
      {
        Error_num++;//��б����
      }
      if((Error_num!=0)&&(Normal_num!=0))//��⵽����
      {
				BuShu++;   //����������++
        Error_num=0;    //���һ�����ڼ��
        Normal_num=0;
      }
    }
		
		if(disFlag==1)	   //��ʾ��־
		{
			disFlag = 0;

			readTemp++;  //��ʱ����
			if(readTemp >= 8)//Լ800ms����һ������ �¶�
			{
				readTemp =0;//���¼���
				temperature=(float)DS18B20_Get_Temp()/10;	//��С10��Ϊʵ��ֵ			
			}
						
			disBuShu = BuShu/2;  //��ʾ����
			disJuLi = disBuShu*0.45;//��ʾ����
			
			sprintf(dis0,"X:%03d/min %4.1f C",xinLv,temperature);//��ӡ
			Lcd_Puts(0,0,(unsigned char *)dis0);	//��ʾ
			Lcd_1Put(14,0,0xdf);//��ʾ����
			sprintf(dis1,"BS:%03d JL:%4.1fm  ",disBuShu,disJuLi);//��ӡ
			Lcd_Puts(0,1,(unsigned char *)dis1);	//��ʾ
	
		}	
	}											    
}	





