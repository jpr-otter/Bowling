using System;

namespace bowling
{
    public class Frame
    {
        public int Number { get; set; }
        public int BonusScore { get; set; }
        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }
        public int ThirdRoll { get; set; }
        public Frame NextFrame { get; set; }
        public int CurrentTry { get; set; }

        public Frame(int paraNumber)
        {
            FirstRoll = 0;
            SecondRoll = 0;
            ThirdRoll = -1;
            Number = paraNumber;
            CurrentTry = 0;
        }

        public int CurrentFrame()
        {
            return Number;
        }

        public bool IsFinalFrame()
        {
            return Number == 10;
        }

        public bool IsFinished()
        {
            if (IsFinalFrame())
            {
                return CurrentTry == 3 || (CurrentTry == 2 && !IsSpare() && !IsStrike());
            }
            else
            {
                return IsStrike() || IsSpare() || CurrentTry == 2;
            }
        }

        public bool IsStrike()
        {
            return FirstRoll == 10;
        }

        public bool IsSpare()
        {
            if (IsStrike())
            {
                return false;
            }
            return FirstRoll + SecondRoll == 10;
        }

        public void AddRoll(int pins)
        {
            if (CurrentTry == 0)
            {
                FirstRoll = pins;
                CurrentTry++;
            }
            else if (CurrentTry == 1)
            {
                if (Number == 10 && IsStrike())
                {
                    ThirdRoll = pins;
                }
                else if (IsStrike())
                {
                    throw new Exception("Another Strike is not allowed!");
                }

                SecondRoll = pins;
                CurrentTry++;
            }
            else if (Number == 10 && IsSpare() && CurrentTry == 2)
            {
                ThirdRoll = pins;
                CurrentTry++;
            }
            else
            {
                throw new Exception("Only two throws valid!");
            }
        }

        public int Score()
        {
            if (IsSpare())
            {
                if (Number != 10)
                {
                    BonusScore = NextFrame.FirstRoll;
                }
                else
                {
                    BonusScore = ThirdRoll;
                }
            }

            if (IsStrike())
            {                
                if (NextFrame.IsStrike())
                {
                    BonusScore = NextFrame.FirstRoll;
                    if (Number == 9)
                    {
                        BonusScore += NextFrame.ThirdRoll;
                    }
                    else
                    {
                        BonusScore += NextFrame.NextFrame.FirstRoll;
                    }
                }
                else
                {
                    BonusScore = NextFrame.FirstRoll;
                    BonusScore += NextFrame.SecondRoll;
                }
            }

            return FirstRoll + SecondRoll + BonusScore;
        }        
    }
}