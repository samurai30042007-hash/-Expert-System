namespace VVII_laba3
{
    internal class Node
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public Dictionary<string, string> Answer { get; set; }
        public bool IsFinal { get; set; }
    }
}
