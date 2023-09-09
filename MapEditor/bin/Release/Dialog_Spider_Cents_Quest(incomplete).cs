using System;

namespace Ealadh
{
    public class Dialog_Spider_Cents_Quest : DialogMenuOption
    {
        public Dialog_Spider_Cents_Quest()
        {
            this.Title = "Spider Cents";
        }
        public override Dialog Open(Player p, Npc npc, ClientPacket msg)
        {
            switch (p.GetQuestStep("Spider Cents"))
            {
                string gender = p.Sex == Gender.Male? "sir" : "ma'am";
                case 0:
                    {
                        var dialog = new Dialog_Spider_Cents_Quest_01();
                        dialog.Message = "Whoa there, " + gender + ", not so fast... you look like someone who could use a bit of spare change--am I right?  If so, maybe there's a way we could help each other out.  You see, our lovely inn's blankets aren't quite in the shape they used to be.  They can be repaired, but only with the finest Stella Silk.  Many years ago, I might've been seen slaying spiders myself for this material, but I'm afraid my age is beginning to catch up to me.  If you could bring me.. let's say, two pieces of this silk, and a bit of Beeswax to bind the material together, I'll be sure to make it worth your while.  Think you could help an old man out?";
                        return dialog;
                    }
                case 1:
                    {
                        var dialog = new Dialog_Spider_Cents_Quest_02();
                        dialog.Message = "Back already, huh?  Have you found me some Silk and Beeswax?";
                        return dialog;
                    }
                case 2:
                    {
                        var dialog = new Dialog_Spider_Cents_Quest_03();
                        dialog.Message = "Fantastic!  Much appreciated, " + gender + ".  As it turns out, I had some old silk left over that I was able to use for some of my repairs.  I'll turn some of your silk into a special gift as thanks for your troubles.  Come back in a little while to pick it up.";
                        return dialog;
                    }
                case 3:
                    {
                        DateTime dt;
                        if (DateTime.TryParse(p.GetQuestString("Spider Cents", "WaitABit"), out dt))
                        {
                            if (DateTime.UtcNow.Subtract(dt).TotalMinutes < 20)
                            {
                                var dialog = new Dialog_Spider_Cents_Quest_00();
                                dialog.Message = "I'm sorry, but I haven't finished yet.  Please check back again in a little while.";
                                return dialog;
                            }
                            else
                            {
                                var dialog = new Dialog_Spider_Cents_Quest_04();
                                dialog.Message = "Hello again!  I've finished your gift--a special silken cloak that can be used to help recover some stamina.";
                                return dialog;
                            }
                        }
                        return null;
                    }
                default: return null;
            }
        }
        public override bool CanOpen(Player p)
        {
            return true;
        }
    }

    public class Dialog_Pet_Floppy_Quest_00 : NormalDialog
    {
        public Dialog_Pet_Floppy_Quest_00()
        {
            this.CanGoBack = false;
            this.CanGoNext = false;
        }
        public override DialogB Back(Player p, ClientPacket msg)
        {
            return null;
        }
        public override DialogB Next(Player p, ClientPacket msg)
        {
            return null;
        }
        public override DialogB Exit(Player p, ClientPacket msg)
        {
            return null;
        }
    }

    public class Dialog_Spider_Cents_Quest_01 : OptionDialog
    {
        public Dialog_Spider_Cents_Quest_01()
        {
            this.CanGoBack = false;
            this.CanGoNext = true;
            this.Options.Add("Yes");
            this.Options.Add("No");
        }
        public override DialogB Back(Player p, ClientPacket msg)
        {
            return null;
        }
        public override DialogB Next(Player p, ClientPacket msg)
        {
            msg.ReadByte();
            switch (msg.ReadByte())
            {
                case 0x01:
                    {
                        p.SetQuestStep("Quest_Spider_Cents", 1);

                        var dialog = new Dialog_Spider_Cents_Quest_00();
                        dialog.Message = "Head south or east of town and hunt in the fields.  Spiders are easily found, but not all spiders will relinquish their silk.  Beeswax can also be found on bees in the same places.";
                        return dialog;
                    }
                case 0x02: return null;
                default: return null;
            }
        }
        public override DialogB Exit(Player p, ClientPacket msg)
        {
            return null;
        }
    }

    // ~~~ Done up through here.  Finish below

    public class Dialog_Spider_Cents_Quest_02 : NormalDialog
    {
        public Dialog_Spider_Cents_Quest_02()
        {
            this.CanGoBack = false;
            this.CanGoNext = true;
        }
        public override DialogB Back(Player p, ClientPacket msg)
        {
            return null;
        }
        public override DialogB Next(Player p, ClientPacket msg)
        {
            int index1 = p.Inventory.IndexOf<Item_Baby_Green_Floppy>();
            int index2 = p.Inventory.IndexOf<Item_Baby_Golden_Floppy>();
            if (index1 < 0 || index2 < 0)
            {
                var dialog = new Dialog_Pet_Floppy_Quest_00();
                dialog.Message = "You haven't brought me two baby floppies.";
                return dialog;
            }
            else
            {
                p.SetQuestStep("Quest_Taming_The_Wild_Floppy", 2);
                p.SetQuestString("Taming the Wild Floppy", 2, "WaitOneHour", DateTime.UtcNow.ToString());
                p.RemoveItem(index1);
                p.RemoveItem(index2);

                var dialog = new Dialog_Pet_Floppy_Quest_00();
                dialog.Message = "Thank you! It will take me a while to tame these floppies. Please return in one hour.";
                return dialog;
            }
        }
        public override DialogB Exit(Player p, ClientPacket msg)
        {
            return null;
        }
    }

    public class Dialog_Pet_Floppy_Quest_03 : OptionDialog
    {
        public Dialog_Pet_Floppy_Quest_03()
        {
            this.CanGoBack = false;
            this.CanGoNext = true;
            this.Options.Add("Green Floppy");
            this.Options.Add("Golden Floppy");
        }
        public override DialogB Back(Player p, ClientPacket msg)
        {
            return null;
        }
        public override DialogB Next(Player p, ClientPacket msg)
        {
            msg.ReadByte();
            switch (msg.ReadByte())
            {
                case 1:
                    {
                        p.SetQuestStep("Quest_Taming_The_Wild_Floppy", 3);
                        var item = p.GameServer.CreateItem("Item_Pet_Green_Floppy");
                        p.AddItem(item);

                        var dialog = new Dialog_Pet_Floppy_Quest_00();
                        dialog.Message = "Take good care of him!";
                        return dialog;
                    }
                case 2:
                    {
                        p.SetQuestStep("Quest_Taming_The_Wild_Floppy", 3);
                        var item = p.GameServer.CreateItem("Item_Pet_Golden_Floppy");
                        p.AddItem(item);

                        var dialog = new Dialog_Pet_Floppy_Quest_00();
                        dialog.Message = "Take good care of him!";
                        return dialog;
                    }
                default: return null;
            }
        }
        public override DialogB Exit(Player p, ClientPacket msg)
        {
            return null;
        }
    }
}