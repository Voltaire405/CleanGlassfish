using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CleanGFC
{
    class GlassFish
    {
        private DirectoryInfo root;

        public GlassFish(DirectoryInfo root)
        {
            this.Root = root ?? throw new ArgumentNullException(nameof(root));
        }

        public DirectoryInfo Root { get => root; set => root = value; }

        public void RemoveCache(string domainName)
        {
            //stackoverflow reference: https://stackoverflow.com/questions/1288718/how-to-delete-all-files-and-folders-in-a-directory 
            DirectoryInfo directory = new DirectoryInfo(Root.FullName + Path.DirectorySeparatorChar + 
                "glassfish"+ Path.DirectorySeparatorChar +"domains" +
                Path.DirectorySeparatorChar + domainName);
            DirectoryInfo[] directories = new DirectoryInfo[4] {
            new DirectoryInfo(directory.FullName + Path.DirectorySeparatorChar +
                "generated"),
            new DirectoryInfo(directory.FullName + Path.DirectorySeparatorChar +
                "applications"),
            new DirectoryInfo(directory.FullName + Path.DirectorySeparatorChar +
                "autodeploy"),
            new DirectoryInfo(directory.FullName + Path.DirectorySeparatorChar +
                "osgi-cache")
        };
            foreach (DirectoryInfo dir in directories)
            {
                try
                {
                    DeleteFolders(dir);
                    Console.WriteLine("{0} Eliminado!",
                        dir.Name);
                }
                catch (Exception)
                {
                    Console.WriteLine("No se completó la eliminación del directorio {0}, compruebe la ruta y eliminelo manualmente.\n",
                        dir.FullName);
                }                
            }

        }

        private void DeleteFolders(DirectoryInfo directory)
        {
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo subdirectories in directory.GetDirectories())
            {
                subdirectories.Delete(true);
            }
        }
    }
}
