namespace _7Realms_skill_retriever
{
    internal static class Tekst
    {
        internal static void DisplayStartInstructions(string inputPath)
        {
            Console.WriteLine("Plaats alle excel karakter formulieren die je wilt analyseren in de input folder van dit programma.");
            Console.WriteLine($"Deze is te vinden in: {inputPath}");
            Console.WriteLine("Druk daarna op een toets (met deze window geselecteerd) om verder te gaan.");
            Console.ReadLine();
        }
    }
}
