namespace CSharp9.LearningTests
{
    public static class DefaultFonts
    {
        public static FontSettings Consolas16 { get; } 
            = new FontSettings("Consolas", 16);

        public static FontSettings FiraCode15 { get; }
            = new FontSettings("Fira Code", 15);
        
        public static FontSettings Arial14 { get; }
            = new FontSettings("Arial", 14);
    }
}