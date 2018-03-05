using System.Collections.Generic;
using ObjectGenerator.Models;
using System.IO;
using RazorEngine;
using RazorEngine.Templating;

namespace ObjectGenerator
{
   public class Generator
    {
        public void GenerateObjects(string basePath)
        {
            string templateFilePath = Path.Combine(basePath, "Templates/ObjectTemplates/ObjectTemplate.cshtml");
            string outputFolderPath = Path.Combine(basePath, "Output/Objects");

            bool exists = Directory.Exists(outputFolderPath);

            if (!exists)
                Directory.CreateDirectory(outputFolderPath);

            DirectoryInfo d = new DirectoryInfo(outputFolderPath);

            foreach (FileInfo file in d.GetFiles())
            {
                file.Delete();
            }

            Engine.Razor.AddTemplate("object_template", File.ReadAllText(templateFilePath));
            Engine.Razor.Compile("object_template", typeof(GeneratorModel.ObjectEntity));

            foreach (GeneratorModel.ObjectEntity item in GetEntities())
            {
                string result = Engine.Razor.Run("object_template", typeof(GeneratorModel.ObjectEntity), item);
                using (StreamWriter sw = File.CreateText(Path.Combine(outputFolderPath, string.Format("{0}.cs", item.ObjectName))))
                {
                    sw.Write(result);
                }
            }
        }

        private List<GeneratorModel.ObjectEntity> GetEntities()
        {
            return new List<GeneratorModel.ObjectEntity>() {
                new GeneratorModel.ObjectEntity() {
                    ObjectName = "qqqqq",
                    ObjectElements = new List<GeneratorModel.ObjectElement>(){
                        new GeneratorModel.ObjectElement(){ ElementName = "CustomerId", ElementType = typeof(int).Name },
                        new GeneratorModel.ObjectElement(){ ElementName = "CustomerName", ElementType = typeof(string).Name  }
                    }
                },
            };
        }
    }
}
