using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.GlobalClasses
{
    public class clsUtil
    {
        public static string GenerateNewGUID()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }
        public static bool CreateFolderIfDoesNotExist(string Filepath)
        {
            string NewFile=Filepath;
            if (!Directory.Exists(NewFile)) {
                try
                {
                    Directory.CreateDirectory(NewFile);
                    return true;
                }
             catch(Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    clsEventLog.RegistryErrorTo_EventViewer(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                    return false;
                }
            }
            return true;
        }
        public static string ReplaceFileNameWithGUID(string Source)
        {
            string NewFile=Source;
            FileInfo file = new FileInfo(NewFile);
            string newFileName = file.Extension;
            return GenerateNewGUID() + newFileName;
            
        }
    
        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            string DestinationFolder = @"C:\DVLD_People_Images\";

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string NewExtension = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, NewExtension, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsEventLog.RegistryErrorTo_EventViewer(iox.Message, System.Diagnostics.EventLogEntryType.Error);

                return false;
            }
            sourceFile = NewExtension;
            return true;

        }
    }
}
