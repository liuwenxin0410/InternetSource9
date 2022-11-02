#include "lcd1602.h"

/************************�˿ڳ�ʼ��*******************************/
void Lcd_GPIO_init(void)
{
     GPIO_InitTypeDef GPIO_InitStructure;   //�����ṹ��

    /********Data�˿�����*************/
	 RCC_APB2PeriphClockCmd(RCC_GPIO_DATA, ENABLE);  //�򿪶˿�Bʱ�� 
     GPIO_InitStructure.GPIO_Pin  = GPIO_DATA_0_PIN|GPIO_DATA_1_PIN|GPIO_DATA_2_PIN|GPIO_DATA_3_PIN|GPIO_DATA_4_PIN|GPIO_DATA_5_PIN|GPIO_DATA_6_PIN|GPIO_DATA_7_PIN; //  DB8~DB15
     GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;  //��׼���ģʽ
     GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz; //50Mʱ���ٶ�
     GPIO_Init(GPIO_DATA_0, &GPIO_InitStructure);      //��ʼ���˿�

	 /********ʹ�ܶ˿�����**********/
	 RCC_APB2PeriphClockCmd(RCC_GPIO_EN, ENABLE);    	//�򿪶˿�ʱ�� 
     GPIO_InitStructure.GPIO_Pin =  GPIO_EN_PIN;     	// ʹ�ܶ˿�
     GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;  //��׼���ģʽ
     GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz; //50Mʱ���ٶ�
     GPIO_Init(GPIO_EN, &GPIO_InitStructure);

	 /********��/д�˿�����**********/
	 RCC_APB2PeriphClockCmd(RCC_GPIO_RW, ENABLE);    //�򿪶˿�ʱ�� 
     GPIO_InitStructure.GPIO_Pin =  GPIO_RW_PIN;     // ʹ�ܶ˿�
     GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;  //��׼���ģʽ
     GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz; //50Mʱ���ٶ�
     GPIO_Init(GPIO_RW, &GPIO_InitStructure);

	 /********ָ��/���ݶ˿�����**********/
	 RCC_APB2PeriphClockCmd(RCC_GPIO_RS, ENABLE);    //�򿪶˿�ʱ�� 
     GPIO_InitStructure.GPIO_Pin =  GPIO_RS_PIN;     // ʹ�ܶ˿�
     GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; //���츴�����
     GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz; //50Mʱ���ٶ�
     GPIO_Init(GPIO_RS, &GPIO_InitStructure);


}
/******************************************************************/



void Lcd_Init( void )  //��ʼ��
{  
 	Lcd_GPIO_init();
	delay_us(1500);                     //��ʱ15ms
	Lcd_Write_Command( 0x38,0);       // дָ��38H �����æ�ź�
	delay_us(500);				      //��ʱ5ms
    Lcd_Write_Command( 0x38,0);       // дָ��38H �����æ�ź�
	delay_us(500);					  //��ʱ5ms
    Lcd_Write_Command( 0x38,0);       // дָ��38H �����æ�ź�
   									  //�Ժ�ÿ��дָ���/д���ݲ���֮ǰ����æ�ź�
	Lcd_Write_Command( 0x38,1);       //��ʾģʽ���� 
    Lcd_Write_Command( 0x08,1);		  //��ʾ�ر�
	Lcd_Write_Command( 0x01,1);       //��ʾ����
    Lcd_Write_Command( 0x06,1);       //��ʾ����ƶ����� 
    Lcd_Write_Command( 0x0C,1); 	  //��ʾ������겻��ʾ
} 
/******************************************************/

void Lcd_En_Toggle(void) //��ʹ������
{
	SET_EN;        //ʹ��1
	delay_us(5);   //��ʱ160us
	CLE_EN;
}


void Lcd_Busy(void)//�ж�æ
{
	 unsigned int later0=0;
     GPIO_InitTypeDef GPIO_InitStructure;
	 RCC_APB2PeriphClockCmd(RCC_GPIO_DATA, ENABLE);    //��DATA�˿�ʱ�� 

     GPIO_InitStructure.GPIO_Pin  = GPIO_DATA_0_PIN|GPIO_DATA_1_PIN|GPIO_DATA_2_PIN|GPIO_DATA_3_PIN|GPIO_DATA_4_PIN|GPIO_DATA_5_PIN|GPIO_DATA_6_PIN|GPIO_DATA_7_PIN; //  DB8~DB15
     GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU; //����ģʽ = ��������
     GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz; //50Mʱ���ٶ�
     GPIO_Init(GPIO_DATA_7, &GPIO_InitStructure);      //��æ���˿�

 	 CLE_RS; //RS = 0
	 //delay_us(1);   //��ʱ10us
	 SET_RW; //RW = 1
	 //delay_us(1);   //��ʱ10us
	 SET_EN; //EN = 1
	 //delay_us(2);   //��ʱ20us
     while ((GPIO_ReadInputDataBit(GPIO_DATA_7,GPIO_DATA_7_PIN))&&(later0<20000)) //ѭ���ȴ�æ���˿� = 0
	 {
	 	delay_us(5);
		later0++;	
	 }
	 CLE_EN; //EN = 0

     //�ָ��˿�Ϊ���״̬ 
   	 RCC_APB2PeriphClockCmd(RCC_GPIO_DATA, ENABLE);    //��DATA�˿�ʱ�� 
	 GPIO_InitStructure.GPIO_Pin  = GPIO_DATA_0_PIN|GPIO_DATA_1_PIN|GPIO_DATA_2_PIN|GPIO_DATA_3_PIN|GPIO_DATA_4_PIN|GPIO_DATA_5_PIN|GPIO_DATA_6_PIN|GPIO_DATA_7_PIN; //  DB8~DB15
     GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; //�������
     GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz; //50Mʱ���ٶ�
     GPIO_Init(GPIO_DATA_7, &GPIO_InitStructure);

} 

void Gpio_data(unsigned char x)  //�˿���������
{  
GPIO_ResetBits(GPIO_DATA_0, GPIO_DATA_0_PIN);  //DB0
GPIO_ResetBits(GPIO_DATA_0, GPIO_DATA_1_PIN);  //DB1
GPIO_ResetBits(GPIO_DATA_0, GPIO_DATA_2_PIN);  //DB2
GPIO_ResetBits(GPIO_DATA_0, GPIO_DATA_3_PIN);  //DB3
GPIO_ResetBits(GPIO_DATA_0, GPIO_DATA_4_PIN);  //DB4
GPIO_ResetBits(GPIO_DATA_0, GPIO_DATA_5_PIN);  //DB5
GPIO_ResetBits(GPIO_DATA_0, GPIO_DATA_6_PIN);  //DB6
GPIO_ResetBits(GPIO_DATA_0, GPIO_DATA_7_PIN);  //DB7
if(x&0X01)GPIO_SetBits(GPIO_DATA_0, GPIO_DATA_0_PIN);//DB0
if(x&0X02)GPIO_SetBits(GPIO_DATA_0, GPIO_DATA_1_PIN);//DB1
if(x&0X04)GPIO_SetBits(GPIO_DATA_0, GPIO_DATA_2_PIN);//DB2
if(x&0X08)GPIO_SetBits(GPIO_DATA_0, GPIO_DATA_3_PIN);//DB3
if(x&0X10)GPIO_SetBits(GPIO_DATA_0, GPIO_DATA_4_PIN);//DB4
if(x&0X20)GPIO_SetBits(GPIO_DATA_0, GPIO_DATA_5_PIN);//DB5
if(x&0X40)GPIO_SetBits(GPIO_DATA_0, GPIO_DATA_6_PIN);//DB6
if(x&0X80)GPIO_SetBits(GPIO_DATA_0, GPIO_DATA_7_PIN);//DB7
}


//��Һ������д��ָ��  ʱ��RS=L,RW=L,Data0-Data7=ָ���룬E=������
void Lcd_Write_Command(unsigned char x,char Busy) 
{ 
    if(Busy) Lcd_Busy();
    //delay_us(1);   //��ʱ10us
	CLE_RS;  //RS = 0 
    //delay_us(1);   //��ʱ10us
	CLE_RW;  //RW = 0 
    //delay_us(4);   //��ʱ40us
    Gpio_data(x);  //�˿���������
    //delay_us(4);   //��ʱ40us
	Lcd_En_Toggle();  //��ʹ������
    //delay_us(1);   //��ʱ100us
	Lcd_Busy(); //��æ

}
//��Һ������д������  ʱ��RS=H,RW=L,Data0-Data7=ָ���룬E=������
void Lcd_Write_Data( unsigned char x) //��Һ������д������ 
{ 
	Lcd_Busy(); //��æ
    //delay_us(1);   //��ʱ10us
	SET_RS;   //RS = 1 
    //delay_us(1);   //��ʱ10us
    CLE_RW;   //RW = 0
    //delay_us(4);   //��ʱ40us
    Gpio_data(x);
    //delay_us(4);   //��ʱ40us
	Lcd_En_Toggle();  //��ʹ������
    //delay_us(1);   //��ʱ100us
	Lcd_Busy(); //��æ

} 

void Lcd_SetXY(unsigned char x,unsigned char y)   //�ַ���ʼλ���趨��x��ʾ�У�y��ʾ�� 
{ 
     unsigned char addr; 
     if(y==0) 
          addr=0x80+x; 
     else if(y==1)
          addr=0xC0+x; 
     Lcd_Write_Command(addr,1) ; 
} 
/******************************************************/

void Lcd_Puts(unsigned char x,unsigned char y, unsigned char *string) //��1602дһ���ַ��� 
{ 
   //unsigned char i=0;
   Lcd_SetXY(x,y); 
	while(*string) 
	  { 
	   Lcd_Write_Data(*string); 
       string++; 
      } 
}

void Lcd_1Put(unsigned char x,unsigned char y, unsigned char Data0)
{
   	Lcd_SetXY(x,y); 
	Lcd_Write_Data(Data0); 
}

