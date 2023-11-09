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
                if (Number == 10 && (IsStrike() || IsSpare()))
                {
                    ThirdRoll = pins;
                }
                else if (IsStrike())
                {
                    throw new Exception("Ist ein Strike geht nicht");
                }

                SecondRoll = pins;
                CurrentTry++;
            }
            else
            {
                throw new Exception("Nur zwei Würfe zulässig");
            }
        }

        public int Score()
        {            
            if (IsSpare() && Number != 10)
            {
                BonusScore = NextFrame.FirstRoll;
            }

            if (IsStrike())
            {
                if (Number == 10 && IsSpare())
                {
                    BonusScore = ThirdRoll;
                }
                else
                {
                    if (NextFrame.IsStrike())
                    {
                        BonusScore = NextFrame.FirstRoll;
                        if(Number == 9)
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
            }

            return FirstRoll + SecondRoll + BonusScore;
        }

        //public int _Score()
        //{
        //    if (ThirdRoll != -1)
        //    {
        //        return FirstRoll + SecondRoll + ThirdRoll + BonusScore;
        //    }
        //    else
        //    {
        //        return FirstRoll + SecondRoll + BonusScore;
        //    }
        //}        
    }
}