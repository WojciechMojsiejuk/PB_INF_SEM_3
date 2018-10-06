#include <msp430x14x.h>
void main(void)
{
  WDTCTL=WDTPW+WDTHOLD;
  P1DIR |= BIT5+BIT6;
  P2DIT |= BIT2;
  P4DIR &= ~BIT4;
  P4DIR &= ~BIT5;
  P4DIR &= ~BIT6;
  while(1)
  {
    if( (PIN4 & BIT4) != 0)
    {
      P1OUT=P1OUT &~BIT5;
    }
    else
    {
      P1OUT |=BIT5;
    }
    if( (P4IN & BIT5) != 0)
    {
      P1OUT=P1OUT &~BIT6;
    }
    else
    {
      P1OUT |=BIT6;
    }
    if( (PIN4 & BIT6) != 0)
    {
      P2OUT |= BIT1;
    }
    else
    {
      P2OUT |= P2OUT &~BIT1;
    }
  }
  
  
