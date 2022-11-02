#ifndef __DS18B20_H
#define __DS18B20_H 
#include "sys.h"   
//////////////////////////////////////////////////////////////////////////////////	 
//������ֻ��ѧϰʹ�ã�δ��������ɣ��������������κ���;
//ALIENTEK MiniSTM32������
//DS18B20��������	   
//����ԭ��@ALIENTEK
//������̳:www.openedv.com
//�޸�����:2014/3/12
//�汾��V1.0
//��Ȩ���У�����ؾ���
//Copyright(C) ������������ӿƼ����޹�˾ 2009-2019
//All rights reserved									  
//////////////////////////////////////////////////////////////////////////////////
#define GPIO_DQ       GPIOC                 //  ʹ�ܶ˿���
#define GPIO_DQ_PIN   GPIO_Pin_13            //  ʹ�ܶ˿ں�
#define RCC_GPIO_DQ   RCC_APB2Periph_GPIOC  //  ʹ��ʱ����										   
#define	DS18B20_DQ_OUT PCout(13) //���ݶ˿�	
#define	DS18B20_DQ_IN  PCin(13)  //���ݶ˿�	

void DS18B20_IO_IN(void);
void DS18B20_IO_OUT(void);

   	
u8 DS18B20_Init(void);			//��ʼ��DS18B20
short DS18B20_Get_Temp(void);	//��ȡ�¶�
void DS18B20_Start(void);		//��ʼ�¶�ת��
void DS18B20_Write_Byte(u8 dat);//д��һ���ֽ�
u8 DS18B20_Read_Byte(void);		//����һ���ֽ�
u8 DS18B20_Read_Bit(void);		//����һ��λ
u8 DS18B20_Check(void);			//����Ƿ����DS18B20
void DS18B20_Rst(void);			//��λDS18B20    
#endif















