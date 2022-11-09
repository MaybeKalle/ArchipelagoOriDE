using System.Collections.Generic;
using System.Diagnostics;

namespace OriForestArchipelago.Types
{
    public class ItemMessageProvider : MessageProvider
    {
        public MessageProvider Message;
        public MessageDescriptor[] messages;
        
        public ItemMessageProvider()
        {
            this.messages = new MessageDescriptor[1];
        }
        [DebuggerHidden]
        public override IEnumerable<MessageDescriptor> GetMessages()
        {
            return this.messages;
        }
        public void SetMessage(string message)
        {
            this.messages[0] = new MessageDescriptor(message);
        }
    }
}