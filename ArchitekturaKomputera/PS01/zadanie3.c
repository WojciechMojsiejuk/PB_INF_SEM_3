#include <msp430x14x.h>
int mydelay(int delay)
{
  int a=0;
  for(a=0;a<delay;a++)
    {
    int b=0;
    for(b=0;b<delay;b++)
      {
      _NOP();
      }
    }
}

void main(void)
{
  WDTCTL=WDTPW+WDTHOLD;
  P1DIR |= BIT5;
  P4DIR &= ~BIT4;
  P4DIR &= ~BIT5;
  int delay = 400;
  while(1)
  {
    if( (PIN4 & BIT4) != 0)
    {
      delay +=100;
    }
    if( (P4IN & BIT5) != 0)
    {
      delay -=100;
    }
  }
  
  
