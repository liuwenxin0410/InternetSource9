#ifndef __lcd1602_H
#define __lcd1602_H	 

#include "stm32f10x.h"
#include "delay.h"

/********************���˿ڶ���*********************************/
#define GPIO_EN       GPIOB                 //  ʹ�ܶ˿���
#define GPIO_EN_PIN   GPIO_Pin_7            //  ʹ�ܶ˿ں�
#define RCC_GPIO_EN   RCC_APB2Periph_GPIOB  //  ʹ��ʱ����

#define GPIO_RW       GPIOB                 //  ��/дѡ��˿���
#define GPIO_RW_PIN   GPIO_Pin_6            //  ��/дѡ��˿ں�
#define RCC_GPIO_RW   RCC_APB2Periph_GPIOB  //  ��/дʱ����

#define GPIO_RS       GPIOB                 //  ����/����˿���
#define GPIO_RS_PIN   GPIO_Pin_5            //  ����/����˿ں�
#define RCC_GPIO_RS   RCC_APB2Periph_GPIOB  //  ����/����ʱ����

#define GPIO_DATA_0       GPIOB         //  ������0_�˿���
#define GPIO_DATA_0_PIN   GPIO_Pin_8    //  ������0_�˿ں�
#define GPIO_DATA_1       GPIOB         //  ������1_�˿���0
#define GPIO_DATA_1_PIN   GPIO_Pin_9    //  ������1_�˿ں�
#define GPIO_DATA_2       GPIOB         //  ������2_�˿���
#define GPIO_DATA_2_PIN   GPIO_Pin_10   //  ������2_�˿ں�
#define GPIO_DATA_3       GPIOB         //  ������3_�˿���
#define GPIO_DATA_3_PIN   GPIO_Pin_11   //  ������3_�˿ں�
#define GPIO_DATA_4       GPIOB         //  ������4_�˿���
#define GPIO_DATA_4_PIN   GPIO_Pin_12   //  ������4_�˿ں�
#define GPIO_DATA_5       GPIOB         //  ������5_�˿���
#define GPIO_DATA_5_PIN   GPIO_Pin_13   //  ������5_�˿ں�
#define GPIO_DATA_6       GPIOB         //  ������6_�˿���
#define GPIO_DATA_6_PIN   GPIO_Pin_14   //  ������6_�˿ں�
#define GPIO_DATA_7       GPIOB         //  ������7_�˿���
#define GPIO_DATA_7_PIN   GPIO_Pin_15   //  ������7_�˿ں�
#define RCC_GPIO_DATA   RCC_APB2Periph_GPIOB  //  ������ʱ����


/******************************************************************/


/***********************����ָ��***********************************/
#define SET_EN  GPIO_SetBits(GPIO_EN, GPIO_EN_PIN)		//EN ʹ��  ���1
#define CLE_EN  GPIO_ResetBits(GPIO_EN, GPIO_EN_PIN)	//      ���0 
#define SET_RW  GPIO_SetBits(GPIO_RW, GPIO_RW_PIN)      //RW ��д  ���1
#define CLE_RW  GPIO_ResetBits(GPIO_RW, GPIO_RW_PIN)	//      ���0
#define SET_RS  GPIO_SetBits(GPIO_RS, GPIO_RS_PIN)		//RS ָ��  ���1
#define CLE_RS  GPIO_ResetBits(GPIO_RS, GPIO_RS_PIN)	//      ���0
/******************************************************************/

void Lcd_GPIO_init(void);
void Lcd_Init( void ) ;
void Lcd_En_Toggle(void);
void Lcd_Busy(void);
void Gpio_data(unsigned char x);
void Lcd_Write_Command(unsigned char x,char Busy);
void Lcd_Write_Data( unsigned char x); 
void Lcd_SetXY(unsigned char x,unsigned char y);
void Lcd_Puts(unsigned char x,unsigned char y, unsigned char *string);
void Lcd_1Put(unsigned char x,unsigned char y, unsigned char Data0);

		 				    
#endif
