namespace CSharp9.LearningTests
{
    public static class DefaultFonts
    {
        public static FontSettings Consolas { get; } 
            = new FontSettings("Consolas", 16);

        public static FontSettings FiraCode { get; }
            = new FontSettings("Fira Code", 15);
        
        public static FontSettings Arial { get; }
            = new FontSettings("Arial", 14);
    }
}