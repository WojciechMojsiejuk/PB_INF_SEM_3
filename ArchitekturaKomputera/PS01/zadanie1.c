#include <msp430x14x.h>
int mydelay()
{
  int a=0;
  for(a=0;a<400;a++)
    {
    int b=0;
    for(b=0;b<400;b++)
      {
      _NOP();
      }
    }
}

void main(void)
{
  WDTCTL=WDTPW+WDTHOLD;
  P1DIR |=BIT5+BIT6;
  P2DIT |=0x02;
  while(1)
  {
    P1OUT=P1OUT |0x0020;
    mydelay();
    P1OUT=P1OUT |0x0040;
    mydelay();
    P2OUT = POUT2 |BIT1;
    mydelay();
    P1OUT &=0x00;
    P2OUT &=~BIT1;
    mydelay();
  }
  
  
