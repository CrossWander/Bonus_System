using Bonus_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bonus_System.EventModels
{
    public sealed class FindCardEvent
    {
        private FullInfoBonusCardModel _fullinfoBonusCard;

        public FindCardEvent()
        {
        }

        public FindCardEvent(FullInfoBonusCardModel fullinfo)
        {
            FullInfoBonusCard = fullinfo;
        }

        public FullInfoBonusCardModel FullInfoBonusCard
        {
            get { return _fullinfoBonusCard; }
            set
            {
                _fullinfoBonusCard = value;
            }
        }

    }
}
