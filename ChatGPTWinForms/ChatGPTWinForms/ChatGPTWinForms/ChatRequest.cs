using OpenAI.Chat;

namespace ChatGPTWinForms
{
    internal class ChatRequest
    {
        public string Model { get; set; }
        public List<ChatMessage> Messages { get; set; }
    }
}