using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace DVLD.Classes
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();
            
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
         
            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;
            
        }
     
        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }
       
        public static  bool CopyImageToProjectImagesFolder(ref string  sourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string DestinationFolder = @"C:\Users\XIGMATEK\source\repos\AADL\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show (iox.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile= destinationFile;
            return true;
        }

        public static uint RowsPerPage => uint.TryParse(ConfigurationManager.AppSettings["RowsPerPage"] ?? "", out uint result) ? result : 15;

        public static Color MainColor => Color.LimeGreen;

        public static void CustomizeDataGridView(DataGridView dgv)
        {
            // Set Fill Mode to all cells
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Resize the row header column (the one used for selecting rows)
            dgv.RowHeadersWidth = 25;

            // Resize the column header heigth
            dgv.ColumnHeadersHeight = 40;

            // Disable visual styles for headers to allow custom styling
            dgv.EnableHeadersVisualStyles = false;


            // Customize the header style
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 9, FontStyle.Bold),
                BackColor = MainColor,
                ForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter // Center the text
            };
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;


            // customize the default cell styles as well
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 8, FontStyle.Regular),
                BackColor = Color.White,
                ForeColor = Color.Black,
            };
            dgv.DefaultCellStyle = cellStyle;

            // Customize row styles for alternating colors
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 233, 233, 233);
        }

        public static void IsNumber(KeyPressEventArgs e)
        {
            // Check if the key pressed is a control key (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true; // Suppress the character
        }
    }
}
