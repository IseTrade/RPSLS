using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    //An abstract class which sets the groundrules for what each type of player must implement
    public abstract class Player
    {
        //Abstract ideas between objects because humans have hands and computer doens't
        public abstract string ThrowGesture();
    }
}