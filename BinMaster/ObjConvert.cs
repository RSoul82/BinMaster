using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace BinMaster
{
    class ObjConvert
    {
        private string objFileName;
        private string objLocation;
        private string newObjLocation;
        private string obj_e_FileName;
        private string obj_3ds_FileName;
        private string bin2ePath;
        private string e23dsPath;
        private string convTexSwitch;

        bool newObjDest = false;

        /// <summary>
        /// Converts the source object to 3ds.
        /// </summary>
        /// <param name="objectFileName">Object filename without path, e.g. "kettle.bin".</param>
        /// <param name="objectLocation">Directory where object file came from.</param>
        /// <param name="newObjectLocation">Directory where converted object will be created.</param>
        /// <param name="binToEPath">Full path of bintoe.exe.</param>
        /// <param name="eTo3dsPath">Full path of eto3ds.exe</param>
        /// <param name="convertedTextureFormat">Determines the /e switch value for eto3ds.</param>
        /// <param name="dontConvTextures">Don't use any /e switch.</param>
        public ObjConvert(string objectFileName, string objectLocation, string newObjectLocation, string binToEPath, string eTo3dsPath, string convertedTextureFormat, bool dontConvTextures)//, string gifTarget, string tgaTarget, string pcxTarget, string pngTarget, string ddsTarget)
        {
            //Set variables
            objFileName = objectFileName;
            objLocation = objectLocation;

            if(newObjectLocation != "")
            {
                newObjLocation = newObjectLocation;
                newObjDest = true;
            }

            bin2ePath = binToEPath;
            e23dsPath = eTo3dsPath;

            if(!dontConvTextures)
            {
                convTexSwitch = " /e" + convertedTextureFormat + " ";
            }
            else convTexSwitch = "";

        }

        public bool BeginConversion(bool eOnly=false)
        {
            bool success = false;

            objFileName = objFileName.ToLower();

            if(objFileName.EndsWith(".bin"))
            {
                //set e and 3ds filenames
                obj_e_FileName = objFileName.Replace(".bin", ".e");
                obj_3ds_FileName = obj_e_FileName.Replace(".e", ".3ds");

                binToE();
                if(checkEFile())
                {
                    if (!eOnly)
                    {
                        eTo3ds();
                    }
                    success = true;
                }
                else
                {
                    MessageBox.Show("BinToE didn't work. Cannot continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    File.Delete(newObjLocation + obj_e_FileName);
                }
            }
            else if(objFileName.EndsWith(".e"))
            {
                //copy e file to temp folder
                obj_e_FileName = objFileName;
                if(objLocation != newObjLocation) //Copy file if it has not been placed in Temp by extracting it from a crf
                    File.Copy(objLocation + "\\" + obj_e_FileName, newObjLocation + "\\" + obj_e_FileName, true);

                //set 3ds filename
                obj_3ds_FileName = objFileName.Replace(".e", ".3ds");
                if(checkEFile())
                {
                    eTo3ds();
                    success = true;
                }
            }
            else
            {
                MessageBox.Show("Not a .bin or .e file", "File Format Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                del_e_File();
            }
            return success;
        }

        private void binToE()
        {
            StringBuilder bintoeCommand = new StringBuilder();
            //insert file and folder paths into conversion command
            bintoeCommand.Append("\"" + bin2ePath + "\"");
            bintoeCommand.Append(" ");
            bintoeCommand.Append("\"" + objLocation + objFileName + "\"");
            bintoeCommand.Append(" ");
            bintoeCommand.Append("\"" + newObjLocation + obj_e_FileName + "\"");

            RunCommand.Execute(bintoeCommand.ToString());

            Thread.Sleep(50); //Wait 50ms to give the above time to run
            if(File.Exists(newObjLocation + objFileName)) File.Delete(newObjLocation + objFileName);
        }

        /// <summary>
        /// Ensures the specified file exists and its length is more than 0
        /// </summary>
        /// <returns></returns>
        private bool checkEFile()
        {
            bool good = false;
            string ePath = newObjLocation + obj_e_FileName;

            if(File.Exists(ePath))
            {
                FileInfo fInfo = new FileInfo(ePath);
                if(fInfo.Length > 0) good = true;
            }
            return good;
        }

        private void eTo3ds()
        {
            string ePath = (newObjLocation + obj_e_FileName).Replace("\\\\", "\\");
            //Call the method that removes spaces from material names
            editEFile(ePath);

            StringBuilder eto3dsCommand = new StringBuilder();
            eto3dsCommand.Append("\"" + e23dsPath + "\"");
            if(!convTexSwitch.Contains(".gif")) eto3dsCommand.Append(convTexSwitch);
            eto3dsCommand.Append(" ");
            eto3dsCommand.Append("\"" + ePath + "\"");
            // If the converted object is to go in a new folder, append the new location and filename
            if(newObjDest)
            {
                eto3dsCommand.Append(" ");
                eto3dsCommand.Append("\"" + newObjLocation + obj_3ds_FileName + "\"");
            }

            RunCommand.Execute(eto3dsCommand.ToString());

            //Ask if e file should be deleted - only if source object is bin file
            if(objFileName.ToLower().EndsWith(".bin"))
            {
                del_e_File();
            }
            else if(objFileName.ToLower().EndsWith(".e"))
            {
                File.Delete(ePath);
            }
        }

        private void editEFile(string eFilePath)
        {
            string eFileContent = File.ReadAllText(eFilePath);
            eFileContent = removeSpacesFromMaterialNames(eFileContent);
            File.WriteAllText(eFilePath, eFileContent);
        }

        private string removeSpacesFromMaterialNames(string eFileContent)
        {
            string materialWithSpaces = "\\d+,\"\\w* +\\w*\""; //one ore more digits, comma, double quote, any word char, one or more spaces, any word char, double quote

            MatchCollection foundBadMaterials = Regex.Matches(eFileContent, materialWithSpaces);

            if(foundBadMaterials.Count > 0) //If materials with spaces were found
            {
                foreach(Match m in foundBadMaterials)
                {
                    string oldMatName = m.Value;

                    //Replace spaces with underscores
                    string newMatName = oldMatName.Replace(" ", "_");
                    eFileContent = eFileContent.Replace(oldMatName, newMatName);
                }
            }
            return eFileContent;
        }

        private void del_e_File()
        {
            //DialogResult delete_e = MessageBox.Show("Delete e file", "Intermediate file...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //if(delete_e == DialogResult.Yes)
            //{
               File.Delete(newObjLocation + obj_e_FileName);
            //}
        }
    }
}
