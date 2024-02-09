internal class Program
{
    private static void Main(string[] args)
    {
        string sentence = "Sekwencja kwasów nukleinowych: 5-AATTGGCC-3";
        const string file = "biodata.txt";
        File.WriteAllText(file, sentence);//saving to a file

        using (var fileStream= new FileStream(file, FileMode.Open))
        {
            int sign = sentence.IndexOf("5");
            fileStream.Seek(sign+1, SeekOrigin.Begin);
            using (var reader = new StreamReader(fileStream))
            {
                string remainingContent = reader.ReadToEnd();
                Console.WriteLine($"{remainingContent}");
                Console.ReadKey();
            }
        }
        Console.Clear();
        File.Delete(file);
        Console.ReadKey();
    }
}