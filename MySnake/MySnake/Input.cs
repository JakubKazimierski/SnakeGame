﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySnake
{
    class Input
    {
        //LOAD LIST OF AVALIABLE KEYBOARDS BUTTONS
        private static Hashtable keyTable = new Hashtable();

        //Check if particular button is pressed
        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }

            return (bool) keyTable[key];

        }

        //Detect if keybord button is pressed   
        public static void  ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }

    }
}
