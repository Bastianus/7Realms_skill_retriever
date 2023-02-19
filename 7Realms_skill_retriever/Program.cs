﻿namespace _7Realms_skill_retriever
{
    public class Program 
    {
        static void Main()
        {
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();

                //use for debug
                //var mainDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\..\"));

                //use for release
                var mainDirectory = currentDirectory;

                var inputDirectory = mainDirectory + "Input";
                var outputDirectory = mainDirectory + "Output";

                Folders.CreateFoldersIfNotExist(inputDirectory, outputDirectory);

                Folders.EmptyOutputFolder(outputDirectory);

                Tekst.DisplayStartInstructions(inputDirectory);

                var gegevens = new DataReader(inputDirectory).ReadData();

                Tekst.DisplayResultaten(gegevens);

                Tekst.Afsluiting();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}