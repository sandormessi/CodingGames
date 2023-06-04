namespace CodingGameSpringChallenge2023;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

internal static class FileMergeProgram
{
   #region Constants and Fields

   private const string ClassName = "GameEntryPoint";

   private static readonly string ProjectPath;

   private static readonly string FileName = $"{ClassName}.cs";

   private static readonly string TargetFilePath;

   #endregion

   #region Constructors and Destructors

   static FileMergeProgram()
   {
      ProjectPath = Path.GetFullPath(@"..\..\..\..\SpringChallenge.Core");
      string thisProjectPath = Path.GetFullPath(@"..\..\..\");

      TargetFilePath = Path.Combine(thisProjectPath, $"{FileName}.cs");
   }

   #endregion

   #region Methods

   internal static void Execute()
   {
      Console.WriteLine("Merging files.");

      List<CodeFile> codeFiles = new(32);

      string[] codeFilesPaths = Directory.GetFiles(ProjectPath, "*.cs", SearchOption.AllDirectories)
         .Where(x => x.Contains("Implementations") || x.Contains("Abstractions")).ToArray();

      foreach (string codeFilesPath in codeFilesPaths)
      {
         string content = File.ReadAllText(codeFilesPath);
         int startOfNameSpace = content.IndexOf("namespace", StringComparison.InvariantCulture);
         string nameSpaceCode = content[startOfNameSpace..];
         int firstCommaIndex = nameSpaceCode.IndexOf(';');
         string ns = nameSpaceCode[(startOfNameSpace + 10)..firstCommaIndex];

         int[] startIndexes =
         {
            nameSpaceCode.IndexOf("class", StringComparison.InvariantCulture),
            nameSpaceCode.IndexOf("interface", StringComparison.InvariantCulture),
            nameSpaceCode.IndexOf("enum", StringComparison.InvariantCulture)
         };

         int indexOfStartOfType = startIndexes.Max();
         nameSpaceCode = content[indexOfStartOfType..];

         CodeFile codeFile = new(codeFilesPath, nameSpaceCode, ns);
         codeFiles.Add(codeFile);
      }

      StringBuilder oneFileStringBuilder = new(codeFiles.Count * 2048);

      oneFileStringBuilder.AppendLine("namespace CodingGameSpringChallenge2023;");
      oneFileStringBuilder.AppendLine($"internal static class {ClassName}");
      oneFileStringBuilder.AppendLine("{");

      oneFileStringBuilder.AppendLine("private static void Main()");

      oneFileStringBuilder.AppendLine("{");

      oneFileStringBuilder.AppendLine("ICrystalHarvestingGame game = new CrystalHarvestingGame();");
      oneFileStringBuilder.AppendLine("game.StartGame();");

      oneFileStringBuilder.AppendLine("}");

      oneFileStringBuilder.AppendLine("}");
      foreach (IGrouping<string, CodeFile> codeFile in codeFiles.GroupBy(x => x.Namespace, StringComparer.InvariantCulture))
      {
         CodeFile[] codeFilesArray = codeFile.ToArray();
         oneFileStringBuilder.AppendLine($"#region {codeFilesArray.First().Namespace}");

         foreach (CodeFile codeFileInNamespace in codeFilesArray)
         {
            oneFileStringBuilder.AppendLine("internal " + codeFileInNamespace.FileContent);
         }

         oneFileStringBuilder.AppendLine("#endregion");
      }

      File.WriteAllText(TargetFilePath, oneFileStringBuilder.ToString());

      Console.WriteLine("Ready.");
      Console.ReadKey();
   }

   #endregion

   private class CodeFile
   {
      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="T:System.Object"/> class.</summary>
      public CodeFile(string path, string fileContent, string ns)
      {
         Path = path;
         FileContent = fileContent;
         Namespace = ns;
      }

      #endregion

      #region Public Properties

      public string FileContent { get; }

      public string Namespace { get; }

      public string Path { get; }

      #endregion
   }
}