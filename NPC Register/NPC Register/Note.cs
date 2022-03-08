using System;
using System.Drawing;
using System.Windows.Forms;

namespace NPC_Register
{
    class Note
    {
        public Point position;
        public Panel workspace;
        public Panel note;

        public Note(Panel workspace) {
            this.workspace = workspace;

        }

        ///I'll add a function to create the actual note object w/in the workspace later.
    }
}
