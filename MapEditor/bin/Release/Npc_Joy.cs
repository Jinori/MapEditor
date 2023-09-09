
namespace Ealadh
{
    public class Npc_Joy : Npc
    {
        public Npc_Joy()
        {
            this.Name = "Joy";
            this.Sprite = 518;
            this.Portrait = "inn.spf";
            this.Greeting = "Hello.  How can I help you?";
            this.DialogMenuOptions.Add(new Dialog_Pet_Floppy_Quest());
            this.BaseTickSpeed = 1000;
            this.BaseMaximumHP = 1000000000;
        }

        public override void OnTick()
        {

        }
        public override void OnChatMessage(Character c, string msg)
        {

        }
    }
}