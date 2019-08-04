using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Ionic.Zip;
using System.Text.RegularExpressions;

namespace BinMaster
{
    public partial class Form1 : Form
    {
        const string modelNamePrefix = "Model Name: "; //if model name was used instead of selecting the file
        string userTempDir = Path.GetTempPath();

        /// <summary>
        /// List of errors to present if required fields are not filled in.
        /// </summary>
        List<string> checkList = new List<string>();

        /// <summary>
        /// Delays auto setting the res folder until after the list has been loaded from the config file. Prevents duplicates.
        /// </summary>
        private bool allowSetResFolder = false;

        ZipFile epCRF;
        ZipFile rootCRF;
        ZipFile resCRF;

        /// <summary>
        /// Source file for object conversion should be deleted ONLY if this is true.
        /// </summary>
        private bool modelExtracted;

        private string configFile = "BinMaster.cfg";

        /// <summary>
        /// All valid texture file extensions, in NewDark priority order
        /// </summary>
        private string[] tExtensions = { ".dds", ".png", ".tga", ".bmp", ".pcx", ".gif" };
        //private string[] tExtensions = { ".gif" }; //shortened version for testing

        public Form1()
        {
            InitializeComponent();
            setWindowTitle();
        }

        private void setWindowTitle()
        {
            string version = ProductVersion;
            if (version.EndsWith(".0"))
            {
                int endOf = version.LastIndexOf(".0");
                version = version.Substring(0, endOf);
            }

            Text += " " + version;
        }

        private void btnObjBrowse_Click(object sender, EventArgs e)
        {
            AddToComboBox.UpdateItems(dlgSelObject, cbObjModel);
        }

        private void btnModelName_Click(object sender, EventArgs e)
        {
            ModelName mN = new ModelName();
            DialogResult dR = mN.ShowDialog();

            if (!mN.ShapeModelName.StartsWith("."))
            {
                AddToComboBox.UpdateItems(modelNamePrefix + mN.ShapeModelName, cbObjModel);
            }
        }

        private void btnBrowseGameDir_Click(object sender, EventArgs e)
        {
            AddToComboBox.UpdateItems(dlgGameDir, cbGameDir);
            if (chkAutoSetResourceDir.Checked)
            {
                AddToComboBox.UpdateItems(cbGameDir.Text, cbResDir);
            }
        }

        private void btnBrowseResMod_Click(object sender, EventArgs e)
        {
            AddToComboBox.UpdateItems(dlgResMod, cbResMod);
        }

        private void btnBrowseConvObjDir_Click(object sender, EventArgs e)
        {
            AddToComboBox.UpdateItems(dlgConvObjOutput, cbConvObjDir);
            if (chkConvTexInObjDir.Checked)
            {
                if(cbConvObjDir.Items.Count != 0)
                {
                    AddToComboBox.UpdateItems(cbConvObjDir.Items[0].ToString(), cbConvTexDir);
                }
            }
        }

        private void btnBrowseConvTexDir_Click(object sender, EventArgs e)
        {
            AddToComboBox.UpdateItems(dlgConvTexDir, cbConvTexDir);
        }

        private void chkAutoSetResourceDir_CheckedChanged(object sender, EventArgs e)
        {
            cbResDir.Enabled = !chkAutoSetResourceDir.Checked;
            btnBrowseResDir.Enabled = !chkAutoSetResourceDir.Checked;

            if(allowSetResFolder && chkAutoSetResourceDir.Checked)
            {
                AddToComboBox.UpdateItems(cbGameDir.Text, cbResDir);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            convertObject();
        }

        private void convertObject()
        {
            //Ensure res dir matches game dir if 'auto set' is checked
            if (chkAutoSetResourceDir.Checked)
            {
                AddToComboBox.UpdateItems(cbGameDir.Text, cbResDir);
            }
            //Ensure conv tex dir matches obj dir if checkbox is selected
            if(chkConvTexInObjDir.Checked)
            {
                AddToComboBox.UpdateItems(cbConvObjDir.Text, cbConvTexDir);
            }

            errorCheck();
            modelExtracted = false; //initialise value
            ObjectType obType = getObjectType(cbObjModel.Text);
            string modelFolder = "obj"; //obj or mesh, depending on object type
            if (obType == ObjectType.Mesh)
                modelFolder = "mesh";

            if (checkList.Count == 0) //checks that relevant things have been filled in, but not if they're any good.
            {
                if(openCRFs(obType) && checkWriteAccess()) //checks that conversion can probably be done.
                {
                    string shortName = Path.GetFileName(cbObjModel.Text).Trim();
                    string chosenModelPath = findModelFile(cbObjModel.Text, modelFolder, shortName);
                    if (chosenModelPath != "")
                    {
                        string noExt = Path.GetFileNameWithoutExtension(shortName);
                        
                        string eFilePath = Path.Combine(cbConvObjDir.Text, noExt + ".e");

                        if (chosenModelPath.ToLower().EndsWith(".bin"))
                        {
                            string binToECommand = "\"" + cbBintoE.Text + "\" \"" + chosenModelPath + "\" \"" + eFilePath + "\"";
                            RunCommand.Execute(binToECommand);
                        }
                        else
                        {
                            File.Copy(chosenModelPath, eFilePath, true);
                        }
                        if (modelExtracted)
                            File.Delete(chosenModelPath); //delete source file if it was extracted from a CRF.

                        if (checkEFile(eFilePath))
                        {
                            if (!chkNoTextures.Checked)
                            {
                                convertETextures(eFilePath, modelFolder);
                            }

                            editEFile(eFilePath);

                            if (rdo3dsConv.Checked)
                            {
                                string eto3dsCommand = generate3dsCommand(eFilePath);
                                RunCommand.Execute(eto3dsCommand);
                                File.Delete(eFilePath);
                            }
                        }
                        else
                        {
                            MessageBox.Show(".e file not created or bintoe failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show(cbObjModel.Text + " cannot be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }

            else
            {
                StringBuilder sB = new StringBuilder();
                foreach (string error in checkList)
                {
                    sB.AppendLine(error);
                }
                MessageBox.Show(sB.ToString(), "Errors", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// Generates a command for eto3ds. The output file is always in the same dir as the input file.
        /// </summary>
        /// <param name="eFilePath"></param>
        /// <returns></returns>
        private string generate3dsCommand(string eFilePath)
        {
            StringBuilder sB = new StringBuilder();
            sB.Append("\"" + cbEto3ds.Text + "\" ");
            if (!chkNoTextures.Checked) sB.Append(" /e" + cbTexFormat.Text.Replace(".", "") + " "); //redundant now that .e file is being edited, but useful as a backup
            sB.Append("\"" + eFilePath + "\" ");

            return sB.ToString();
        }

        /// <summary>
        /// Remove spaces from material names, and replaces texture extensions if user has chosen to convert.
        /// </summary>
        /// <param name="eFilePath"></param>
        private void editEFile(string eFilePath)
        {
            string eFileContent = File.ReadAllText(eFilePath);
            eFileContent = removeSpacesFromMaterialNames(eFileContent);

            if (!chkNoTextures.Checked)
            {
                StringBuilder replaceExensions = new StringBuilder(eFileContent);
                foreach(string ext in tExtensions)
                {
                    if(ext != cbTexFormat.Text)
                    {
                        replaceExensions.Replace(ext, cbTexFormat.Text);
                    }
                }
                eFileContent = replaceExensions.ToString();
            }
            File.WriteAllText(eFilePath, eFileContent);
        }

        private string removeSpacesFromMaterialNames(string eFileContent)
        {
            string materialWithSpaces = "\\d+,\"\\w* +\\w*\""; //one ore more digits, comma, double quote, any word char, one or more spaces, any word char, double quote

            MatchCollection foundBadMaterials = Regex.Matches(eFileContent, materialWithSpaces);

            if (foundBadMaterials.Count > 0) //If materials with spaces were found
            {
                foreach (Match m in foundBadMaterials)
                {
                    string oldMatName = m.Value;

                    //Replace spaces with underscores
                    string newMatName = oldMatName.Replace(" ", "_");
                    eFileContent = eFileContent.Replace(oldMatName, newMatName);
                }
            }
            return eFileContent;
        }

        /// <summary>
        /// Ensures the specified file exists and its length is more than 0
        /// </summary>
        /// <returns></returns>
        private bool checkEFile(string eFilePath)
        {
            if (File.Exists(eFilePath))
            {
                FileInfo fInfo = new FileInfo(eFilePath);
                if (fInfo.Length > 0) return true;
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Converts the object's textures to the desired format, using NewDark's exenstion priority.
        /// </summary>
        /// <param name="eFilePath"></param>
        /// <param name="objType"></param>
        private void convertETextures(string eFilePath, string modelFolder)
        {
            try
            {
                List<string> foundTextures = findETextures(eFilePath);
                List<TextureFoundInfo> sourceTextures = findOrExtractTextures(foundTextures, modelFolder);

                string texConvProg = cbTexConvProg.Text;
                string texConvTemplate = cbTexConvCmd.Text;
                string targetExtension = cbTexFormat.Text;
                //exmple: [exe-path] [source-img] /convert=[dest-img]

                List<string> convCommandList = new List<string>();
                List<string> deleteTextureCommands = new List<string>(); //list of source textures to delete
                foreach (TextureFoundInfo sTexture in sourceTextures)
                {
                    string curExtension = Path.GetExtension(sTexture.FullPath);
                    string shortName = Path.GetFileNameWithoutExtension(sTexture.FullPath);
                    string destFile = Path.Combine(cbConvTexDir.Text, shortName + targetExtension);

                    if(curExtension.ToLower() == ".dds")
                    {
                        File.Copy(sTexture.FullPath, Path.Combine(cbConvTexDir.Text, shortName + ".dds"));
                    }
                    if (curExtension != targetExtension)
                    {
                        //convert to output dir
                        StringBuilder sB = new StringBuilder(texConvTemplate);
                        sB.Replace("[exe-path]", "\"" + cbTexConvProg.Text + "\"");
                        sB.Replace("[source-img]", "\"" + sTexture.FullPath + "\"");
                        sB.Replace("[dest-img]", "\"" + destFile + "\"");
                        convCommandList.Add(sB.ToString());
                    }
                    else
                    {
                        //just copy to output dir
                        File.Copy(sTexture.FullPath, destFile, true);
                    }
                    if (sTexture.CanDelete)
                        deleteTextureCommands.Add("del \"" + sTexture.FullPath + "\"");
                }

                if (convCommandList.Count > 0)
                    RunCommand.ExecuteMultiple(convCommandList);

                //Needs to be done separately to ensure source file isn't deleted before conversion finishes.
                if (deleteTextureCommands.Count > 0)
                    RunCommand.ExecuteMultiple(deleteTextureCommands);
            }
            catch(Exception e)
            {
                MessageBox.Show("E file could not be scanned.\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// For each object texture found, return its location (either permanent file in \txt(16) or texture library, or temp file) and whether or not it can be deleted after conversion.
        /// </summary>
        /// <param name="simpleTextureNames"></param>
        /// <returns></returns>
        private List<TextureFoundInfo> findOrExtractTextures(List<string> simpleTextureNames, string modelFolder)
        {
            List<TextureFoundInfo> sourceTextures = new List<TextureFoundInfo>(); //Lists found/extracted texture locations

            string txt16 = Path.Combine(cbGameDir.Text, modelFolder, "txt16");
            string txt = Path.Combine(cbGameDir.Text, modelFolder, "txt");

            string[] folderLocations = { txt16, txt };
            ZipFile[] crfFiles = { epCRF, rootCRF, resCRF };

            //search priority is location, then extension. e.g. a gif in the fm folder overrides a png in ep2.crf
            foreach (string texture in simpleTextureNames)
            {
                bool found = false;
                // look in /txt16 and then .dds, then .png etc, then txt
                foreach (string texFolder in folderLocations) //if found in txt16 or txt
                {
                    foreach (string extension in tExtensions)
                    {
                        string testFile = Path.Combine(texFolder, texture + extension);
                        if (File.Exists(testFile))
                        {
                            TextureFoundInfo foundTexture = new TextureFoundInfo();
                            foundTexture.FullPath = testFile;
                            foundTexture.CanDelete = false;
                            sourceTextures.Add(foundTexture);
                            found = true;
                            break;
                        }
                    }
                    if (found) break;
                }
                if (found) continue; //stop searching for texture

                //look in each crf file, starting with ep2.crf (unless user isn't using it)
                foreach (ZipFile crf in crfFiles)
                {
                    foreach (string extension in tExtensions)
                    {
                        if (chkNoResMods.Checked && crf == epCRF) //don't look in ep crf if user is ignoring it
                            continue;

                        if (crf != null && ZipFileTools.FindTextureEP(crf, modelFolder, texture + extension))
                        {
                            ZipFileTools.ExtractTextureEP(crf, modelFolder, texture + extension, userTempDir, true);

                            TextureFoundInfo info = new TextureFoundInfo();
                            info.FullPath = Path.Combine(userTempDir, texture + extension);
                            info.CanDelete = true;

                            sourceTextures.Add(info);
                            found = true;
                            break;
                        }
                        else if (crf != null && ZipFileTools.FindTexture(crf, texture + extension))
                        {
                            ZipFileTools.ExtractTexture(crf, texture + extension, userTempDir, true);

                            TextureFoundInfo info = new TextureFoundInfo();
                            info.FullPath = Path.Combine(userTempDir, texture + extension);
                            info.CanDelete = true;

                            sourceTextures.Add(info);
                            found = true;
                            break;
                        }
                    }
                    if (found) break; //stop looking in crf files
                }
            }

            return sourceTextures;
        }

        /// <summary>
        /// Full path of an object texture and whether or not it's safe to delete after conversion (true if it's in %temp%)
        /// </summary>
        private struct TextureFoundInfo
        {
            public string FullPath;
            public bool CanDelete;
        }

        /// <summary>
        /// Gets a list of all the unique textures specified in the E file.
        /// </summary>
        /// <param name="eFilePath"></param>
        /// <returns></returns>
        private List<string> findETextures(string eFilePath)
        {
            List<string> foundTextures = new List<string>();
            string[] fileLines = File.ReadAllLines(eFilePath);
            for (int i = 0; i < fileLines.Length; i++)
            {
                if (fileLines[i].Contains("MATERIALS"))
                {
                    foundTextures.AddRange(findTexturesInMaterialBlock(fileLines, i));
                }
                //break;
            }
            return foundTextures;
        }

        /// <summary>
        /// Scans a 'material' line to get the name of the texture
        /// </summary>
        /// <param name="eLine"></param>
        /// <returns></returns>
        private List<string> findTexturesInMaterialBlock(string[] fileLines, int startLine)
        {
            List<string> foundTextures = new List<string>();
            StringBuilder mStringBuilder = new StringBuilder();

            //Cannot assume 1 material per line after with } on the next line on its own, 
            //so keep adding text to string builder and only stop when a line ending with } is found.
            int i = startLine;
            do
            {
                mStringBuilder.Append(fileLines[i]);
                i++;
            }
            while (!fileLines[i-1].EndsWith("}")); //go one line beyond the closing }

            string materialBlock = mStringBuilder.ToString();

            string matchMaterial = "TMAP \"\\w+"; //doesn't get texture extension, which is actually useful
            MatchCollection mats = Regex.Matches(materialBlock, matchMaterial);
            
            foreach(Match m in mats)
            {
                int quoteIndex = m.Value.IndexOf('\"');
                string s = m.Value.Substring(quoteIndex + 1, m.Value.Length -1 - quoteIndex); //get all text after the first "
                if(!foundTextures.Contains(s))
                    foundTextures.Add(s);
            }

            return foundTextures;
        }

        /// <summary>
        /// Search for model file, first in user's FM folder, then in any of the CRF files. Extract if necessary, then return location.
        /// </summary>
        /// <param name="userModelName">Text the user has entered in the ComboBox.</param>
        /// <param name="subFolderName">obj or mesh.</param>
        /// <param name="shortName">Filename with extension.</param>
        /// <returns></returns>
        private string findModelFile(string userModelName, string subFolderName, string shortName)
        {
            if (File.Exists(userModelName))
                return userModelName; //no need to extract if file is already in place
            else //model name and/or file in CRF
            {
                if (userModelName.StartsWith(modelNamePrefix))//model name
                {
                    string userGameDirObjectPath = Path.Combine(cbGameDir.Text, subFolderName, shortName); //try the users FM obj dir
                    if (File.Exists(userGameDirObjectPath)) //object FM obj dir
                        return userGameDirObjectPath;
                    else
                    {
                        if (!chkNoResMods.Checked && ZipFileTools.FindFile(epCRF, shortName, true)) //Found in resource mod
                        {
                            ZipFileTools.ExtractFile(shortName, epCRF, userTempDir, true, true, out modelExtracted);
                            return Path.Combine(userTempDir, shortName); //prepare to extract to %temp%
                        }
                        else
                        {
                            if (rootCRF != null)
                            {
                                if (ZipFileTools.FindFile(rootCRF, shortName, false)) //found in Thief2\obj.crf - 1.18 patch
                                {
                                    ZipFileTools.ExtractFile(shortName, rootCRF, userTempDir, true, false, out modelExtracted);
                                    return Path.Combine(userTempDir, shortName); //prepare to extract to %temp%
                                }
                            }
                            if (resCRF != null)
                            {
                                if (ZipFileTools.FindFile(resCRF, shortName, false)) //found in Thief2\RES\obj.crf
                                {
                                    ZipFileTools.ExtractFile(shortName, resCRF, userTempDir, true, false, out modelExtracted);
                                    return Path.Combine(userTempDir, shortName); //prepare to extract to %temp%
                                }
                            }
                        }
                    }
                }
                return ""; //default if file not found
            }
        }

        /// <summary>
        /// Uses the extension (.bin or .e) to work out if this is an ojbect or a mesh.
        /// </summary>
        /// <param name="userModelName">Text from the CombBox.</param>
        /// <returns></returns>
        private ObjectType getObjectType(string userModelName)
        {
            if (Path.GetExtension(userModelName.ToLower()) == ".bin")
                return ObjectType.Object;
            else
                return ObjectType.Mesh;
        }

        /// <summary>
        /// Checks for write access to object and texture dirs.
        /// </summary>
        /// <param name="objDir">Converted object dir.</param>
        /// <param name="texDir">If this is the same as object dir, it's access is the same.</param>
        private bool checkWriteAccess()
        {
            bool objWriteAccess = checkDirWriteAccess(cbConvObjDir.Text);
            bool texWriteAccess = objWriteAccess; //depends on whether this is the same as conv object dir

            if(!chkConvTexInObjDir.Checked && cbConvObjDir.Text != cbConvTexDir.Text)
                texWriteAccess = checkDirWriteAccess(cbConvTexDir.Text);

            if (objWriteAccess && texWriteAccess)
                return true;
            else
            {
                StringBuilder report = new StringBuilder();
                if (!objWriteAccess)
                    report.AppendLine("No write access to " + cbConvObjDir.Text);
                if (!texWriteAccess && !chkConvTexInObjDir.Checked && cbConvObjDir.Text != cbConvTexDir.Text)
                    report.AppendLine("No write acess to " + cbConvTexDir.Text);
                MessageBox.Show(report.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        /// Checks that user has write access to folder.
        /// </summary>
        /// <returns></returns>
        private bool checkDirWriteAccess(string outputDir)
        {
            //attempt to create dir\temp. if no write acess, exception will be thrown.

            string tempObjDir = Path.Combine(outputDir, "temp");
            try
            {
                Directory.CreateDirectory(tempObjDir);
                Directory.Delete(tempObjDir); //this only deletes the final subfolder, not the whole directory tree.
                return true;
            }
            catch(UnauthorizedAccessException)
            {
                //MessageBox.Show("No write access to " + outputDir, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        /// Attempts to open each CRF file. Objects will remain null if files not found
        /// </summary>
        /// <param name="objectType">Enum: Object or Mesh, determines if obj.crf or mesh.crf is used.</param>
        private bool openCRFs(ObjectType objectType)
        {
            string crfName;
            if(objectType == ObjectType.Object)
                crfName = "obj.crf";
            else
                crfName = "mesh.crf";

            if (!chkNoResMods.Checked && File.Exists(cbResMod.Text))
                epCRF = ZipFile.Read(cbResMod.Text);

            string gameRoot;
            if (!chkAutoSetResourceDir.Checked)
                gameRoot = findRESParentDir(cbResDir.Text);
            else
            {
                //take game/fm folder and look for folder called RES
                if (Directory.Exists(Path.Combine(cbGameDir.Text, "RES")))
                    gameRoot = cbGameDir.Text;
                else
                    gameRoot = findRESParentDir(cbGameDir.Text);
            }

            if (File.Exists(Path.Combine(gameRoot, crfName)))
                rootCRF = ZipFile.Read(Path.Combine(gameRoot, crfName));
            if (File.Exists(Path.Combine(gameRoot, "RES", crfName)))
                resCRF = ZipFile.Read(Path.Combine(gameRoot, "RES", crfName));

            if (epCRF == null && rootCRF == null && resCRF == null)
            {
                MessageBox.Show("No CRF files found. Choose a different Game/FM Folder or choose an alternate folder in the \"Resource Paths\" tab.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Looks in current folder then each parent folder till it finds RES. From there, each obj.crf can be found.
        /// </summary>
        /// <param name="startDir"></param>
        /// <returns></returns>
        private string findRESParentDir(string startDir)
        {
            try
            {
                DirectoryInfo dInfo = Directory.GetParent(startDir);
                string testResDir = Path.Combine(dInfo.FullName, "RES");
                if (Directory.Exists(testResDir))
                {
                    DirectoryInfo resDInfo = Directory.GetParent(testResDir);
                    return resDInfo.FullName;
                }
                else
                    return findRESParentDir(dInfo.FullName);
            }
            catch
            {
                //MessageBox.Show("Could not locate original resources in Game folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return "";
            }
        }

        /// <summary>
        /// Checks all params and returns a list of any that are missing. I.e. count = 0 if all params set
        /// </summary>
        /// <returns></returns>
        private void errorCheck()
        {
            checkList.Clear();
            inputCheck(cbObjModel, "Object");
            inputCheck(cbGameDir, "Game Folder");
            if(!chkNoResMods.Checked)
            {
                inputCheck(cbResMod, "Resource Mod");
            }
            inputCheck(cbConvObjDir, "Converted Object Folder");
            if (!chkConvTexInObjDir.Checked)
            {
                inputCheck(cbConvTexDir, "Converted Textures Folder");
            }
            inputCheck(cbBintoE, "BintoE Path");
            if (rdo3dsConv.Checked)
            {
                inputCheck(cbEto3ds, "Eto3ds Path");
            }
            if (!chkNoTextures.Checked)
            {
                inputCheck(cbTexConvProg, "Texture Conversion Program");
                inputCheck(cbTexConvCmd, "Texture Conversion Command Template");
                if(cbTexFormat.SelectedIndex == -1)
                {
                    checkList.Add("Texture Conversion Format not selected. How did you manage that, it's a preset drop down?");
                }
            }
            if (!chkAutoSetResourceDir.Checked)
            {
                inputCheck(cbResDir, "Resource Installation Folder");
            }
        }

        /// <summary>
        /// Checks that a ComboBox has something selected.
        /// </summary>
        /// <param name="cBtoCheck">ComboBox to check.</param>
        /// <param name="messageToAdd">Error message prefix. " not selected" will be added to the end.</param>
        /// <param name="listToUpdate">Error list to update with the message.</param>
        private void inputCheck(ComboBox cBtoCheck, string messageToAdd)
        {
            if (cBtoCheck.Text == "")
                checkList.Add(messageToAdd + " not selected.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show("Close?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dR == DialogResult.Yes)
            {
                saveSettings();
                Close();
            }
        }

        /// <summary>
        /// Saves settings to config file
        /// </summary>
        private void saveSettings()
        {
            BinMasterSettings settings = new BinMasterSettings();
            //Tab page 1
            settings.objectModel = saveComboBox(cbObjModel);
            settings.convTo3ds = rdo3dsConv.Checked;
            settings.convToE = rdoEConv.Checked;
            settings.noTextureConv = chkNoTextures.Checked;
            settings.gameDir = saveComboBox(cbGameDir);
            settings.resPackFile = saveComboBox(cbResMod);
            settings.noResPack = chkNoResMods.Checked;
            settings.convObjDir = saveComboBox(cbConvObjDir);
            settings.convTexDir = saveComboBox(cbConvTexDir);
            settings.convTexDirSameAsObj = chkConvTexInObjDir.Checked;
            //Tab page 2
            settings.binToEPath = saveComboBox(cbBintoE);
            settings.eto3dsPath = saveComboBox(cbEto3ds);
            settings.texConvProgPath = saveComboBox(cbTexConvProg);
            settings.texConvCommandTemplate = saveComboBox(cbTexConvCmd);
            settings.texFormatID = cbTexFormat.SelectedIndex;
            //Tab page 3
            settings.autoSetResourceDir = chkAutoSetResourceDir.Checked;
            settings.altResourceDir = saveComboBox(cbResDir);

            string saveSettings = JsonConvert.SerializeObject(settings, Formatting.Indented);

            File.WriteAllText(configFile, saveSettings);
        }

        /// <summary>
        /// Converts the items in a ComboBox to a string array which can be saved to a JSON file.
        /// </summary>
        /// <param name="cBtoSave"></param>
        /// <returns></returns>
        private string[] saveComboBox(ComboBox cBtoSave)
        {
            //Add the 'text' item as if it were a user selection, which puts it at the top of the list of items
            if(cBtoSave.Text != "")
                AddToComboBox.UpdateItems(cBtoSave.Text, cBtoSave);

            string[] cbItems = new string[cBtoSave.Items.Count];
            cBtoSave.Items.CopyTo(cbItems, 0);
            return cbItems;
        }

        /// <summary>
        /// Reads the config file and polulates controls
        /// </summary>
        private void loadSettings()
        {
            if (File.Exists(configFile))
            {
                string strSettings = File.ReadAllText(configFile);
                BinMasterSettings settings = JsonConvert.DeserializeObject<BinMasterSettings>(strSettings);
                //Tab page 1
                cbObjModel.Items.AddRange(settings.objectModel);
                rdo3dsConv.Checked = settings.convTo3ds;
                rdoEConv.Checked = settings.convToE;
                chkNoTextures.Checked = settings.noTextureConv;
                cbGameDir.Items.AddRange(settings.gameDir);
                cbResMod.Items.AddRange(settings.resPackFile);
                chkNoResMods.Checked = settings.noResPack;
                cbConvObjDir.Items.AddRange(settings.convObjDir);
                cbConvTexDir.Items.AddRange(settings.convTexDir);
                chkConvTexInObjDir.Checked = settings.convTexDirSameAsObj;
                //Tab page 2
                cbBintoE.Items.AddRange(settings.binToEPath);
                cbEto3ds.Items.AddRange(settings.eto3dsPath);
                cbTexConvProg.Items.AddRange(settings.texConvProgPath);
                cbTexConvCmd.Items.AddRange(settings.texConvCommandTemplate);
                cbTexFormat.SelectedIndex = settings.texFormatID;
                //Tab page 3
                chkAutoSetResourceDir.Checked = settings.autoSetResourceDir;
                cbResDir.Items.AddRange(settings.altResourceDir);

                //Fill combo boxes
                selectComboItem0(cbGameDir);
                selectComboItem0(cbResMod);
                selectComboItem0(cbBintoE);
                selectComboItem0(cbEto3ds);
                selectComboItem0(cbTexConvProg);
                selectComboItem0(cbTexConvCmd);
                selectComboItem0(cbResDir);
                allowSetResFolder = true;
            }
        }

        /// <summary>
        /// Selects the 1st item in a combo box's list if any items exist.
        /// </summary>
        /// <param name="cB"></param>
        private void selectComboItem0(ComboBox cB)
        {
            if (cB.Items.Count != 0)
                cB.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadSettings();
        }

        private void btnSetTexConvCmd_Click(object sender, EventArgs e)
        {
            TexConvCmd tcc = new TexConvCmd();
            DialogResult dR = tcc.ShowDialog();

            if (dR == DialogResult.OK)
            {
                AddToComboBox.UpdateItems(tcc.TexConvCommand, cbTexConvCmd);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbObjModel.Text);
        }

        private void chkConvTexInObjDir_CheckedChanged(object sender, EventArgs e)
        {
            cbConvTexDir.Enabled = !chkConvTexInObjDir.Checked;
            btnBrowseConvTexDir.Enabled = !chkConvTexInObjDir.Checked;
            if (chkConvTexInObjDir.Checked && cbConvObjDir.Items.Count != 0)
            {
                AddToComboBox.UpdateItems(cbConvObjDir.Text, cbConvTexDir);
            }
        }

        private void btnBrowseBintoe_Click(object sender, EventArgs e)
        {
            AddToComboBox.UpdateItems(dlgBinToEPath, cbBintoE);
        }

        private void btnBrowseEto3ds_Click(object sender, EventArgs e)
        {
            AddToComboBox.UpdateItems(dlgEto3dsPath, cbEto3ds);
        }

        private void btnBrowseTexConvProg_Click(object sender, EventArgs e)
        {
            AddToComboBox.UpdateItems(dlgTexConvProgPath, cbTexConvProg);
        }

        private void btnBrowseResDir_Click(object sender, EventArgs e)
        {
            AddToComboBox.UpdateItems(dlgAltResDir, cbResDir);
        }

        private void cbConvObjDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkConvTexInObjDir.Checked)
            {
                AddToComboBox.UpdateItems(cbConvObjDir.Text, cbConvTexDir);
            }
        }

        private void chkNoResMods_CheckedChanged(object sender, EventArgs e)
        {
            cbResMod.Enabled = !chkNoResMods.Checked;
            btnBrowseResMod.Enabled = !chkNoResMods.Checked;
        }

        private void rcOpenFolder_Click(object sender, EventArgs e)
        {
            // Try to cast the sender to a ToolStripItem
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    ComboBox cB = owner.SourceControl as ComboBox;

                    if (cB.Text != "")
                    {
                        if (Directory.Exists(cB.Text))
                        {
                            openDir(cB.Text);
                        }
                        else if (File.Exists(cB.Text))
                        {
                            openDir(Path.GetDirectoryName(cB.Text));
                        }
                        else
                        {
                            MessageBox.Show("Invalid Folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void editSavedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Try to cast the sender to a ToolStripItem
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    ComboBox cB = owner.SourceControl as ComboBox;
                    if (cB.Items.Count > 0)
                    {
                        string[] items = new string[cB.Items.Count];
                        cB.Items.CopyTo(items, 0);
                        EditItems edit = new EditItems(items);
                        DialogResult dR = edit.ShowDialog();

                        if (dR == DialogResult.OK)
                        {
                            cB.Items.Clear();
                            cB.Items.AddRange(edit.RemainingItems);
                            if (edit.RemainingItems.Length == 0)
                                cB.Text = "";
                        }
                    }
                }
            }
        }

        private void openDir(string dir)
        {
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = dir;
            prc.Start();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //add typed text to game dir combo box to make it official
            AddToComboBox.UpdateItems(cbGameDir.Text, cbGameDir);
            TabControl tC = (TabControl)sender;
            if(tC.SelectedIndex == 2) //3rd page selected, resource paths (for finding original CRF files)
            {
                if (chkAutoSetResourceDir.Checked)
                {
                    AddToComboBox.UpdateItems(cbGameDir.Text, cbResDir);
                }
            }
        }

        private void removeAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Try to cast the sender to a ToolStripItem
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    ComboBox cB = owner.SourceControl as ComboBox;
                    if (cB.Items.Count > 0)
                    {
                        DialogResult dR = MessageBox.Show("This operation cannot be undone. Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dR == DialogResult.Yes)
                        {
                            cB.Items.Clear();
                            cB.Text = "";
                        }
                    }
                }
            }
        }
    }

    public enum ObjectType { Object, Mesh }

    class BinMasterSettings
    {
        public string[] objectModel;
        public bool convTo3ds;
        public bool convToE;
        public bool noTextureConv;
        public string[] gameDir;
        public string[] resPackFile;
        public bool noResPack;
        public string[] convObjDir;
        public string[] convTexDir;
        public bool convTexDirSameAsObj;
        public string[] binToEPath;
        public string[] eto3dsPath;
        public string[] texConvProgPath;
        public string[] texConvCommandTemplate;
        public int texFormatID;
        public bool autoSetResourceDir;
        public string[] altResourceDir;
    }
}
